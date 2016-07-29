using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightwallDecalWizard
{
    public class CSVString : IDisposable
    {
        string str;
        int row = 0;

        public CSVString()
        {
            str = string.Empty;
        }

        public string GetString()
        {
            return str;
        }

        public void WriteObjHeader(ICSVWritable obj)
        {
            str += obj.GetHeader();
        }

        public void WriteObjRow(ICSVWritable obj)
        {
            str += row.ToString();
            str += obj.GetRow();
            row++;
        }

        public void Dispose()
        {
            str = string.Empty;
            str = null;
        }
    }

    public interface ICSVWritable
    {
        string GetHeader();
        string GetRow();
    }
}
