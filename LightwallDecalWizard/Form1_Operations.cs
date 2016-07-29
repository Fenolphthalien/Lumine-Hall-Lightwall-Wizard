using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightwallDecalWizard
{
    public interface IForm1Operation
    {
        bool Run(Form1 form1, out string s);
    }

    public partial class Form1
    {
        Operations_LineFillWindow lineFillWindow;
        IForm1Operation nextOperation;

        bool ignoreZero { get { return randomFillIgnoreZeroItem.Checked; } }


        private void lineFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenlineFillWindow();
        }

        void lineFillWindow_FormClosing(object sender, EventArgs args)
        {
            if(lineFillWindow.exitByConfirm)
                nextOperation = lineFillWindow.ToOperation();
        }

        void lineFillWindow_FormClosed(object sender, EventArgs args)
        {
            if (nextOperation != null)
            {
                string str;
                if(nextOperation.Run(this, out str))
                    numberStringGrid1.SetString(str);
            }
            nextOperation = null;
        }

        private void randomFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformRandomFill();
        }

        private void randomFillIgnoreZeroItem_Click(object sender, EventArgs e)
        {
            randomFillIgnoreZeroItem.Checked = !ignoreZero;
        }

        void OpenlineFillWindow()
        {
            lineFillWindow = new Operations_LineFillWindow((int)xCellsUpDown.Value,(int)yCellsUpDown.Value,(int)indicesUpDown.Value);
            lineFillWindow.FormClosing += lineFillWindow_FormClosing;
            lineFillWindow.FormClosed += lineFillWindow_FormClosed;
            lineFillWindow.Show();
        }

        void PerformRandomFill()
        {
            int ignore = ignoreZero ? 0 : -1;
            string s;
            nextOperation = new RandomFillOperation(numberStringGrid1.GetString(), (int)indicesUpDown.Value, ignore);
            nextOperation.Run(this, out s);
            numberStringGrid1.SetString(s);
            nextOperation = null;
        }
    }

    public class LineFillOperation : IForm1Operation
    {
        public bool row;
        public int target, runFor, rows, columns, value;

        Form1 m_form1;

        public LineFillOperation(bool _operationIsRow,int maxx, int maxy, int _target, int _runFor, int _value)
        {
            row = _operationIsRow;
            target = _target;
            rows = maxx;
            columns = maxy;
            value = _value;
            runFor = _runFor;
        }

        public bool Run(Form1 form1, out string s)
        {
            if (form1 == null)
            {
                s = null;
                return false;
            }

            m_form1 = form1;
            string str = form1.GetWizardString();
            if (row)
                ModifyAsRow(ref str);
            else
                ModifyAsColumn(ref str);
            s = str;
            return true;
        }

        void ModifyAsRow(ref string str)
        {
            int A = columns * target;
            int B = columns * (runFor+target);
            int start = A < B ? A : B;
            int end = A < B ? B : A;
            
            char[] s = str.ToArray();
            
            for(int i = start; i < end; i++)
            {
                s[i] = (char)(value + '0');
            }
            str = new string(s);
        }

        void ModifyAsColumn(ref string str)
        {
            int start = target;
            int end = columns * (rows) + start;
            int offsetSign = Math.Sign(runFor);

            int offsetA = offsetSign < 0 ? runFor : 0;
            int offsetB = offsetSign < 0 ? 0 : runFor;
            
            char[] s = str.ToArray();

            for (int i = start; i < end; i += columns)
            {
                for (int offset = offsetA; offset < offsetB; offset++)
                {
                    if (i + offset >= rows * columns)
                        continue;
                    s[i + offset] = (char)(value + '0');
                }
            }
            str = new string(s);
        }
    }

    public class RandomFillOperation : IForm1Operation
    {
        string str;
        int maxRandom;
        char ignore;

        public RandomFillOperation(string _str, int _maxRandom, int _ignore)
        {
            str = _str;
            maxRandom = _maxRandom;
            ignore = (char)(_ignore + '0');
        }

        public bool Run(Form1 form1, out string s)
        {
            char[] cStr = str.ToArray();
            char current;
            int length = str.Length;

            System.Random rand = new Random();
            
            for (int i = 0; i < length; i++)
            {
                current = cStr[i];
                if (current == ignore)
                    continue;
                do
                {
                    current = (char)((rand.Next() % maxRandom) + '0');
                } while (current == ignore);
               
                cStr[i] = current;
            }
            s = new string(cStr);
            return true;
        }
    }
}
