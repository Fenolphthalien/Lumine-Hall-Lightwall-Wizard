using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightwallDecalWizard
{
    class WallDecalExport : IDisposable, ICSVWritable
    {
        public int x, y, size, indices;
        public int[] data = null;

        public void Dispose()
        {
            int length = data.Length;
            Array.Clear(data,0,length);
            data = null;
        }

        public string GetHeader()
        {
            return "Name,x,y,size,indices,data\n";
        }

        public string GetRow()
        {
            string intStr = string.Join(",", data);
            string dataStr = string.Format("{0},{1},{2},{3},{4}\n", x, y, size, indices, intStr);
            return dataStr;
        }
    }
}
