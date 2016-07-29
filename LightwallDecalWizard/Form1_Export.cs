using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace LightwallDecalWizard
{
    public partial class Form1
    {
        string saveJsonPath, saveCompositePath;
        string[] exportPaths;

        delegate void ExportOperation(bool forceDialog);
        ExportOperation lastExportOperation;

        bool forcingDialog;

        //Json export Menu items
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepareJSONExport(false);
        }

        private void uE4CompositeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepareUE4JSONExport(false);
        }
       
        private void exportJSONDialog_FileOk(object sender, CancelEventArgs e)
        {
            saveJsonPath = JSONexportDialog.FileName;
            
            //Prepare export Object
            WallDecalExport obj2Export = PrepareExportObject();

            ExportJSON(obj2Export, saveJsonPath);
        }

        private void JSONCompositeDialog_Save_FileOk(object sender, CancelEventArgs e)
        {
            string file = JSONCompositeDialog_Save.FileName;
            saveCompositePath = file;
            if (exportPaths == null || forcingDialog)
                JSONCompositeDialog_Open.ShowDialog();
            else
                ExportUE4JSON();
        }

        private void JSONCompositeDialog_Open_FileOk(object sender, CancelEventArgs e)
        {
            exportPaths = JSONCompositeDialog_Open.FileNames;
            ExportUE4JSON();
        }
        
        //CSV export Menu items
        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportFormat = 2;
            csvSaveDialog.ShowDialog();
        }

        private void csvSaveDialog_FileOk(object sender, CancelEventArgs e)
        {
            string dialogFilePath = csvSaveDialog.FileName, extension = Path.GetExtension(dialogFilePath);
            //Prepare export Object
            WallDecalExport obj2Export = PrepareExportObject();
            ExportCSV(obj2Export, filePath);
        }

        //Private methods

        //Preparation Methods
        void PrepareUE4JSONExport(bool forceDialog)
        {
            exportFormat = 1;
            forcingDialog = forceDialog;
            if (saveCompositePath == null || forcingDialog)
                JSONCompositeDialog_Save.ShowDialog();
            else
                ExportUE4JSON();
        }

        void PrepareJSONExport(bool forceDialog)
        {
            exportFormat = 0;
            forcingDialog = forceDialog;
            if (saveJsonPath == null)
                JSONexportDialog.ShowDialog();
        }

        void RepeatLastExport(bool forceDialog)
        {
            if (lastExportOperation != null)
                lastExportOperation.Invoke(forceDialog);
        }

        private WallDecalExport PrepareExportObject()
        {
            int x, y, size, indices;
            int[] data;
            string str;
            numberStringGrid1.RequestSerialisableData(out x, out y, out size, out indices, out str);
            data = new int[size];

            WallDecalExport obj2Export = new WallDecalExport();
            obj2Export.x = x;
            obj2Export.y = y;
            obj2Export.size = size;
            obj2Export.indices = indices;
            for (int i = 0; i < size; i++)
            {
                data[i] = str[i] - '0';
            }
            obj2Export.data = data;
            return obj2Export;
        }

        private void PrepareUE4ExportObject(int x, int y, int size, int indices, string str, ref WallDecalExport obj2Export)
        {
            int[] data;
            data = new int[size];

            obj2Export.x = x;
            obj2Export.y = y;
            obj2Export.size = size;
            obj2Export.indices = indices;
            for (int i = 0; i < size; i++)
            {
                data[i] = str[i] - '0';
            }
            obj2Export.data = data;
        }

        string SerialiseUE4JSON(WallDecalExport obj2JSON, int row, bool capArray = true)
        {
            string JSON = JsonConvert.SerializeObject(obj2JSON);
            JSON = JSON.Insert(2, string.Format("Name\":\"{0}\",\"EntryID\":\"{0}\",\"", row.ToString()));
            if (capArray)
                JSON += "]";
            return JSON;
        }

        void ExportJSON(WallDecalExport obj2JSON, string path)
        {
            int row = 0;
            if (exportFormat == 0)
            {
                using (StreamWriter file = File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, obj2JSON);
                }
                return;
            }

            string JSON = SerialiseUE4JSON(obj2JSON, row);
            using (TextWriter tw = File.CreateText(path))
            {
                tw.Write(JSON);
                tw.Close();
            }
            lastExportOperation = PrepareJSONExport;
        }

        void ExportUE4JSON()
        {
            int length = exportPaths.Length;

            int x, y, size, indices;
            string data;

            WallDecalExport[] exportObj = new WallDecalExport[length];
            for (int i = 0; i < length; i++)
            {
                LoadFile(exportPaths[i], out x, out y, out size, out indices, out data);
                exportObj[i] = new WallDecalExport();
                PrepareUE4ExportObject(x, y, size, indices, data, ref exportObj[i]);
            }
            CompositeIntoUE4JSONDataTable(exportObj, saveCompositePath);
            lastExportOperation = PrepareUE4JSONExport;
        }

        void ExportCSV(ICSVWritable csvObj, string path)
        {
            using (CSVString csv = new CSVString())
            {
                csv.WriteObjHeader(csvObj);
                csv.WriteObjRow(csvObj);

                using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    bw.Write(csv.GetString());
                    bw.Close();
                }
            }
        }

        void CompositeIntoUE4JSONDataTable(WallDecalExport[] files, string path)
        {
            if (files == null || files.Length == 0)
                return;

            int length = files.Length;
            string JSON = "[";
            for (int i = 0; i < length; i++)
            {
                JSON += SerialiseUE4JSON(files[i], i,false);
                if (i != length - 1)
                {
                    JSON += ",\n";
                    continue;
                }
            }
            JSON += "]";

            using (TextWriter tw = File.CreateText(path))
            {
                tw.Write(JSON);
                tw.Close();
            }
        }

        void ClearExport()
        {
            exportPaths = null;
            saveCompositePath = null;
            saveJsonPath = null;
            lastExportOperation = null;
        }
    }
}
