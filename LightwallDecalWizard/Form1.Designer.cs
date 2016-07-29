namespace LightwallDecalWizard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Panel panel2;
            System.Windows.Forms.Label fillLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.indicesUpDown = new System.Windows.Forms.NumericUpDown();
            this.yCellsUpDown = new System.Windows.Forms.NumericUpDown();
            this.xCellsUpDown = new System.Windows.Forms.NumericUpDown();
            this.fillErase = new System.Windows.Forms.Button();
            this.fillPaint = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uE4CompositeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomFillIgnoreZeroItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.JSONexportDialog = new System.Windows.Forms.SaveFileDialog();
            this.csvSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.JSONCompositeDialog_Save = new System.Windows.Forms.SaveFileDialog();
            this.JSONCompositeDialog_Open = new System.Windows.Forms.OpenFileDialog();
            this.numberStringGrid1 = new LightwallDecalWizard.NumberStringGrid();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            fillLabel = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCellsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCellsUpDown)).BeginInit();
            panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 13);
            label1.TabIndex = 2;
            label1.Text = "X:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(85, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(17, 13);
            label2.TabIndex = 3;
            label2.Text = "Y:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(166, 12);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 13);
            label3.TabIndex = 5;
            label3.Text = "Indices:";
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(this.indicesUpDown);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(this.yCellsUpDown);
            panel1.Controls.Add(this.xCellsUpDown);
            panel1.Location = new System.Drawing.Point(12, 27);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(282, 40);
            panel1.TabIndex = 2;
            // 
            // indicesUpDown
            // 
            this.indicesUpDown.Location = new System.Drawing.Point(211, 9);
            this.indicesUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.indicesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.indicesUpDown.Name = "indicesUpDown";
            this.indicesUpDown.Size = new System.Drawing.Size(58, 20);
            this.indicesUpDown.TabIndex = 3;
            this.indicesUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.indicesUpDown.ValueChanged += new System.EventHandler(this.indicesUpDown_ValueChanged);
            // 
            // yCellsUpDown
            // 
            this.yCellsUpDown.Location = new System.Drawing.Point(106, 9);
            this.yCellsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yCellsUpDown.Name = "yCellsUpDown";
            this.yCellsUpDown.Size = new System.Drawing.Size(54, 20);
            this.yCellsUpDown.TabIndex = 2;
            this.yCellsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yCellsUpDown.ValueChanged += new System.EventHandler(this.yCellsUpDown_ValueChanged);
            // 
            // xCellsUpDown
            // 
            this.xCellsUpDown.Location = new System.Drawing.Point(23, 8);
            this.xCellsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xCellsUpDown.Name = "xCellsUpDown";
            this.xCellsUpDown.Size = new System.Drawing.Size(54, 20);
            this.xCellsUpDown.TabIndex = 1;
            this.xCellsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xCellsUpDown.ValueChanged += new System.EventHandler(this.xCellsUpDown_ValueChanged);
            // 
            // panel2
            // 
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(this.fillErase);
            panel2.Controls.Add(this.fillPaint);
            panel2.Location = new System.Drawing.Point(300, 27);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(102, 40);
            panel2.TabIndex = 6;
            // 
            // fillErase
            // 
            this.fillErase.Location = new System.Drawing.Point(51, 8);
            this.fillErase.Name = "fillErase";
            this.fillErase.Size = new System.Drawing.Size(42, 23);
            this.fillErase.TabIndex = 1;
            this.fillErase.Text = "Erase";
            this.fillErase.UseVisualStyleBackColor = true;
            this.fillErase.Click += new System.EventHandler(this.fillErase_Click);
            // 
            // fillPaint
            // 
            this.fillPaint.Location = new System.Drawing.Point(3, 8);
            this.fillPaint.Name = "fillPaint";
            this.fillPaint.Size = new System.Drawing.Size(42, 23);
            this.fillPaint.TabIndex = 0;
            this.fillPaint.Text = "Paint";
            this.fillPaint.UseVisualStyleBackColor = true;
            this.fillPaint.Click += new System.EventHandler(this.fillPaint_Click);
            // 
            // fillLabel
            // 
            fillLabel.AutoSize = true;
            fillLabel.Location = new System.Drawing.Point(304, 61);
            fillLabel.Name = "fillLabel";
            fillLabel.Size = new System.Drawing.Size(19, 13);
            fillLabel.TabIndex = 7;
            fillLabel.Text = "Fill";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.operationsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(414, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator3,
            this.loadToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.exportMenuItem,
            this.toolStripSeparator4,
            this.quitToolStripMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveFileMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem1.Text = "Save As";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jSONToolStripMenuItem,
            this.cSVToolStripMenuItem});
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exportMenuItem.Text = "Export";
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.uE4CompositeFilesToolStripMenuItem});
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.jSONToolStripMenuItem.Text = "JSON";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // uE4CompositeFilesToolStripMenuItem
            // 
            this.uE4CompositeFilesToolStripMenuItem.Name = "uE4CompositeFilesToolStripMenuItem";
            this.uE4CompositeFilesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.uE4CompositeFilesToolStripMenuItem.Text = "UE4 Composite File";
            this.uE4CompositeFilesToolStripMenuItem.Click += new System.EventHandler(this.uE4CompositeFilesToolStripMenuItem_Click);
            // 
            // cSVToolStripMenuItem
            // 
            this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            this.cSVToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cSVToolStripMenuItem.Text = "CSV";
            this.cSVToolStripMenuItem.Click += new System.EventHandler(this.cSVToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(183, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineFillToolStripMenuItem,
            this.randomFillToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // lineFillToolStripMenuItem
            // 
            this.lineFillToolStripMenuItem.Name = "lineFillToolStripMenuItem";
            this.lineFillToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.lineFillToolStripMenuItem.Text = "Line Fill";
            this.lineFillToolStripMenuItem.Click += new System.EventHandler(this.lineFillToolStripMenuItem_Click);
            // 
            // randomFillToolStripMenuItem
            // 
            this.randomFillToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomFillIgnoreZeroItem});
            this.randomFillToolStripMenuItem.Name = "randomFillToolStripMenuItem";
            this.randomFillToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.randomFillToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.randomFillToolStripMenuItem.Text = "Random Fill";
            this.randomFillToolStripMenuItem.Click += new System.EventHandler(this.randomFillToolStripMenuItem_Click);
            // 
            // randomFillIgnoreZeroItem
            // 
            this.randomFillIgnoreZeroItem.Name = "randomFillIgnoreZeroItem";
            this.randomFillIgnoreZeroItem.Size = new System.Drawing.Size(152, 22);
            this.randomFillIgnoreZeroItem.Text = "Ignore 0";
            this.randomFillIgnoreZeroItem.Click += new System.EventHandler(this.randomFillIgnoreZeroItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(16, 61);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(102, 13);
            this.positionLabel.TabIndex = 5;
            this.positionLabel.Text = "X: ## | Y## | 1D:##";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.dat";
            this.saveFileDialog1.Filter = "Wall Decal data(*.dat)|*.dat";
            this.saveFileDialog1.Title = "Save File";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.dat";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Wall Decal data(*dat)|*.dat";
            this.openFileDialog1.Title = "Open File";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // JSONexportDialog
            // 
            this.JSONexportDialog.DefaultExt = "*.json";
            this.JSONexportDialog.Filter = "JSON file(*.json)|*.json";
            this.JSONexportDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.exportJSONDialog_FileOk);
            // 
            // csvSaveDialog
            // 
            this.csvSaveDialog.DefaultExt = "*.csv";
            this.csvSaveDialog.Filter = "CSV file(*.csv)|*.csv";
            this.csvSaveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.csvSaveDialog_FileOk);
            // 
            // JSONCompositeDialog_Save
            // 
            this.JSONCompositeDialog_Save.DefaultExt = "*.json";
            this.JSONCompositeDialog_Save.DereferenceLinks = false;
            this.JSONCompositeDialog_Save.Filter = "UE4 JSON LUT(*.json)|*.json";
            this.JSONCompositeDialog_Save.Title = "Save Composite File At";
            this.JSONCompositeDialog_Save.FileOk += new System.ComponentModel.CancelEventHandler(this.JSONCompositeDialog_Save_FileOk);
            // 
            // JSONCompositeDialog_Open
            // 
            this.JSONCompositeDialog_Open.DefaultExt = "*.dat";
            this.JSONCompositeDialog_Open.FileName = "openFileDialog2";
            this.JSONCompositeDialog_Open.Filter = "Wall Decal Data file(*.dat)|*.dat";
            this.JSONCompositeDialog_Open.Multiselect = true;
            this.JSONCompositeDialog_Open.FileOk += new System.ComponentModel.CancelEventHandler(this.JSONCompositeDialog_Open_FileOk);
            // 
            // numberStringGrid1
            // 
            this.numberStringGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberStringGrid1.cellSize = 18;
            this.numberStringGrid1.columns = 8;
            this.numberStringGrid1.eraseColour = System.Drawing.Color.Blue;
            this.numberStringGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberStringGrid1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.numberStringGrid1.indices = 4;
            this.numberStringGrid1.Location = new System.Drawing.Point(12, 77);
            this.numberStringGrid1.Name = "numberStringGrid1";
            this.numberStringGrid1.paintColour = System.Drawing.Color.Orange;
            this.numberStringGrid1.rows = 8;
            this.numberStringGrid1.Size = new System.Drawing.Size(390, 306);
            this.numberStringGrid1.TabIndex = 0;
            this.numberStringGrid1.Text = "numberStringGrid1";
            this.numberStringGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberStringGrid1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 395);
            this.Controls.Add(fillLabel);
            this.Controls.Add(panel2);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(panel1);
            this.Controls.Add(this.numberStringGrid1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Wall Decal Wizard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCellsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCellsUpDown)).EndInit();
            panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumberStringGrid numberStringGrid1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown yCellsUpDown;
        private System.Windows.Forms.NumericUpDown xCellsUpDown;
        private System.Windows.Forms.NumericUpDown indicesUpDown;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Button fillErase;
        private System.Windows.Forms.Button fillPaint;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SaveFileDialog JSONexportDialog;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog csvSaveDialog;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uE4CompositeFilesToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog JSONCompositeDialog_Save;
        private System.Windows.Forms.OpenFileDialog JSONCompositeDialog_Open;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomFillIgnoreZeroItem;
    }
}

