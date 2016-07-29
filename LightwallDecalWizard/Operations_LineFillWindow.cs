using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightwallDecalWizard
{
    public partial class Operations_LineFillWindow : Form
    {
        int rows, columns, indices;

        public bool exitByConfirm = false;
        bool IsRows { get { return rowCheckBox.Checked; } }

        public Operations_LineFillWindow()
        {
            InitializeComponent();
        }

        public Operations_LineFillWindow(int _rows, int _columns, int _indices)
        {
            InitializeComponent();
            
            rows = _rows;
            columns = _columns;
            indices = _indices;

            indexUpDown.Maximum = indices;

            operationChanged(rowCheckBox, null);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            exitByConfirm = true;
            this.Close();
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void operationChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            CheckBox other = checkBox == rowCheckBox ? columnCheckBox : rowCheckBox;
            other.Checked = !checkBox.Checked;

            targetUpDown.Maximum = IsRows ? rows : columns;
        }

        public LineFillOperation ToOperation()
        {
            return new LineFillOperation(IsRows, rows, columns, (int)targetUpDown.Value, (int)repeatUpDown.Value, (int)indexUpDown.Value);
        }
    }
}
