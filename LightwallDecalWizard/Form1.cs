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
    public partial class Form1 : Form
    {
        const string mainWindowName = "Wall Decal Wizard ~ ", defaultFileName = "Untitled", positionLabelText = "X: {0} | Y:{1} | 1D:{2}", kFileHeader = "WDECAL_CFG";

        string fileName = defaultFileName;

        bool bDisplaySaveOnExit = true;

        string filePath = null;

        int exportFormat = 0;

        public Form1()
        {
            InitializeComponent();
            indicesUpDown.Minimum = 2;

            numberStringGrid1.OnDataDirty += numberGrid1_OnDataDirty;
            numberStringGrid1.OnMouseCellChanged += numberGrid1_OnMouseCellChanged;
            numberStringGrid1.OnReinitialasation += numberGrid1_OnReinitialastion;

            numberStringGrid1.SaveMembersToInitVariables();

            positionLabel.Text = string.Format(positionLabelText, 0, 0, 0);
            RefreshForm();
        }

        private void yCellsUpDown_ValueChanged(object sender, EventArgs e)
        {
            numberStringGrid1.rows = (int)yCellsUpDown.Value;
        }

        private void xCellsUpDown_ValueChanged(object sender, EventArgs e)
        {
            numberStringGrid1.columns = (int)xCellsUpDown.Value;
        }

        private void indicesUpDown_ValueChanged(object sender, EventArgs e)
        {
            numberStringGrid1.indices = (int)indicesUpDown.Value;
        }

        private void numberGrid1_OnReinitialastion(object sender, EventArgs e)
        {
            indicesUpDown.Value = numberStringGrid1.indices;
            xCellsUpDown.Value = numberStringGrid1.columns;
            yCellsUpDown.Value = numberStringGrid1.rows;
        }

        private void numberGrid1_OnDataDirty(object sender, EventArgs e)
        {
            bDisplaySaveOnExit = true;
            UpdateFileNameInDisplay();
        }

        private void numberGrid1_OnMouseCellChanged(object sender, EventArgs e)
        {
            int x, y, oned;
            numberStringGrid1.GetSelectionPosition(out x, out y, out oned);
            positionLabel.Text = string.Format(positionLabelText, x, y, oned);
        }

        private void fillPaint_Click(object sender, EventArgs e)
        {
            numberStringGrid1.PaintAll();
        }

        private void fillErase_Click(object sender, EventArgs e)
        {
            numberStringGrid1.EraseAll();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            if (numberStringGrid1 == null)
            {
                e.Cancel = true;
            }
            SaveFile(name);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = openFileDialog1.FileName;
            if (numberStringGrid1 == null)
            {
                e.Cancel = true;
            }

            //Declare variables.
            int x, y, length, indices;

            string data;

            //Open file reader and read file.
            LoadFile(name, out x, out y, out length, out indices, out data);
            numberStringGrid1.Deserialise(x, y, indices, data);

            filePath = name;
            fileName = Path.GetFileName(name);
            bDisplaySaveOnExit = false;
            RefreshForm();
        }

        //Save as clicked.
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void numberStringGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == 'S' || e.KeyValue == 's') && e.Control)
            {
                if (e.Shift)SaveFileAs();
                else BeginSaveFile();
                return;
            }
            else if (e.KeyValue == 'R' || e.KeyValue == 'r' && e.Control)
            {
                PerformRandomFill();
            }

            else if (e.KeyValue == 'E' || e.KeyValue == 'e' && e.Control)
            {
                if (e.Shift)RepeatLastExport(true);
                else RepeatLastExport(false);
                return;
            }
        }

        private void saveFileMenuItem_Click(object sender, EventArgs e)
        {
            BeginSaveFile();
        }

        private void UpdateFileNameInDisplay()
        {
            Text = string.Format("{0}{1}{2}", mainWindowName, fileName, GetSaveSuffix());
        }

        private void NewFile()
        {
            filePath = null;
            fileName = defaultFileName;
            ClearExport();
            GC.Collect();
            numberStringGrid1.Initialise();
            RefreshForm();
        }

        private void BeginSaveFile()
        {
            if (filePath == null)
                SaveFileAs();
            else
                SaveFile(filePath);
        }

        private void SaveFile(string path)
        {
            //Create file Writer and Override an existing at the path.
            using (System.IO.BinaryWriter BW = new System.IO.BinaryWriter(File.Open(path, FileMode.Create)))
            {
                //Declare variables.
                int x, y, length, indices;
                string data = String.Empty;
                numberStringGrid1.RequestSerialisableData(out x, out y, out length, out indices, out data);

                //Begin writing data.
                char[] header = kFileHeader.ToArray(); //Null terminator not included.
                BW.Write(header); //Write Header
                BW.Write(x); //Write X
                BW.Write(y); //Write Y
                BW.Write(length); //Write size = X*Y;
                BW.Write(indices); //Write number of indices;
                char[] dataArray = data.ToArray();
                BW.Write(dataArray);
                BW.Close();
            }
            filePath = path;
            fileName = Path.GetFileName(path);
            bDisplaySaveOnExit = false;
            RefreshForm();
        }

        private void SaveFileAs()
        {
            saveFileDialog1.ShowDialog();
        }

        private void LoadFile(string path, out int x, out int y, out int size, out int indices, out string data)
        {
            int kHeaderLength = kFileHeader.Length;
            using (BinaryReader BR = new System.IO.BinaryReader(File.Open(path, FileMode.Open)))
            {
                //Read header bytes.
                char[] headerBuffer;
                headerBuffer = BR.ReadChars(kHeaderLength);

                //Header check - exit if file appears to be the wrong format.
                string header = new string(headerBuffer);
                if (header != kFileHeader)
                {
                    //Close the stream for disposal.
                    BR.Close();
                    x = 0;
                    y = 0;
                    size = 0;
                    indices = 0;
                    data = null;
                    return;
                }

                //Read the rest of the file.
                x = BR.ReadInt32(); //Read x
                y = BR.ReadInt32(); //Read y
                size = BR.ReadInt32(); //Read Number of indices.
                indices = BR.ReadInt32();
                char[] dataBuffer = new char[size];

                dataBuffer = BR.ReadChars(size);

                //Close the stream for disposal.
                BR.Close();
                data = new string(dataBuffer);
            }
        }

        private string GetSaveSuffix()
        {
            return bDisplaySaveOnExit ? "*" : " ";
        }

        public string GetWizardString()
        {
            return numberStringGrid1.GetString();
        }

        public void SetWizardString(string s)
        {
           numberStringGrid1.SetString(s);
        }

        private void RefreshForm()
        {
            xCellsUpDown.Value = numberStringGrid1.columns;
            yCellsUpDown.Value = numberStringGrid1.rows;
            indicesUpDown.Value = numberStringGrid1.indices;
            UpdateFileNameInDisplay();
            Refresh();
        }
    }
}
