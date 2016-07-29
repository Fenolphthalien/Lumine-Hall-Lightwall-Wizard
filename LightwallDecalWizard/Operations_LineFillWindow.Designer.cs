namespace LightwallDecalWizard
{
    partial class Operations_LineFillWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rowCheckBox = new System.Windows.Forms.CheckBox();
            this.columnCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.targetUpDown = new System.Windows.Forms.NumericUpDown();
            this.operationLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.repeatUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.indexUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.targetUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indexUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.columnCheckBox);
            this.panel1.Controls.Add(this.rowCheckBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 40);
            this.panel1.TabIndex = 0;
            // 
            // rowCheckBox
            // 
            this.rowCheckBox.AutoSize = true;
            this.rowCheckBox.Checked = true;
            this.rowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rowCheckBox.Location = new System.Drawing.Point(11, 13);
            this.rowCheckBox.Name = "rowCheckBox";
            this.rowCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rowCheckBox.Size = new System.Drawing.Size(63, 17);
            this.rowCheckBox.TabIndex = 0;
            this.rowCheckBox.Text = "Fill Row";
            this.rowCheckBox.UseVisualStyleBackColor = true;
            this.rowCheckBox.CheckedChanged += new System.EventHandler(this.operationChanged);
            // 
            // columnCheckBox
            // 
            this.columnCheckBox.AutoSize = true;
            this.columnCheckBox.Location = new System.Drawing.Point(87, 13);
            this.columnCheckBox.Name = "columnCheckBox";
            this.columnCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.columnCheckBox.Size = new System.Drawing.Size(76, 17);
            this.columnCheckBox.TabIndex = 1;
            this.columnCheckBox.Text = "Fill Column";
            this.columnCheckBox.UseVisualStyleBackColor = true;
            this.columnCheckBox.CheckedChanged += new System.EventHandler(this.operationChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operation";
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.indexUpDown);
            this.panel2.Controls.Add(this.repeatUpDown);
            this.panel2.Controls.Add(this.targetUpDown);
            this.panel2.Location = new System.Drawing.Point(11, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 40);
            this.panel2.TabIndex = 2;
            // 
            // targetUpDown
            // 
            this.targetUpDown.Location = new System.Drawing.Point(12, 10);
            this.targetUpDown.Name = "targetUpDown";
            this.targetUpDown.Size = new System.Drawing.Size(40, 20);
            this.targetUpDown.TabIndex = 0;
            this.targetUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // operationLabel
            // 
            this.operationLabel.AutoEllipsis = true;
            this.operationLabel.AutoSize = true;
            this.operationLabel.Location = new System.Drawing.Point(27, 101);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(29, 13);
            this.operationLabel.TabIndex = 3;
            this.operationLabel.Text = "Row";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Settings";
            // 
            // repeatUpDown
            // 
            this.repeatUpDown.Location = new System.Drawing.Point(120, 9);
            this.repeatUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repeatUpDown.Name = "repeatUpDown";
            this.repeatUpDown.Size = new System.Drawing.Size(42, 20);
            this.repeatUpDown.TabIndex = 1;
            this.repeatUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.repeatUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "For";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(11, 123);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(85, 23);
            this.confirmButton.TabIndex = 6;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(105, 123);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // indexUpDown
            // 
            this.indexUpDown.Location = new System.Drawing.Point(65, 9);
            this.indexUpDown.Name = "indexUpDown";
            this.indexUpDown.Size = new System.Drawing.Size(42, 20);
            this.indexUpDown.TabIndex = 2;
            this.indexUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.indexUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "With";
            // 
            // Operations_LineFillWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 155);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Operations_LineFillWindow";
            this.Text = "Line Fill";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.targetUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indexUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox columnCheckBox;
        private System.Windows.Forms.CheckBox rowCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown repeatUpDown;
        private System.Windows.Forms.NumericUpDown targetUpDown;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown indexUpDown;
        private System.Windows.Forms.Label label2;
    }
}