namespace O_Shifter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip_File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_FIle_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_Ok = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Numeric_Count = new System.Windows.Forms.NumericUpDown();
            this.Numeric_Size = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Size)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_File,
            this.toolStripLabel2,
            this.toolStripLabel1,
            this.toolStrip_Ok});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1084, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip_File
            // 
            this.toolStrip_File.BackColor = System.Drawing.Color.BurlyWood;
            this.toolStrip_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_File_Open,
            this.toolStrip_FIle_Save});
            this.toolStrip_File.Name = "toolStrip_File";
            this.toolStrip_File.Size = new System.Drawing.Size(49, 22);
            this.toolStrip_File.Text = "файл";
            // 
            // toolStrip_File_Open
            // 
            this.toolStrip_File_Open.Name = "toolStrip_File_Open";
            this.toolStrip_File_Open.Size = new System.Drawing.Size(131, 22);
            this.toolStrip_File_Open.Text = "открыть";
            this.toolStrip_File_Open.Click += new System.EventHandler(this.ToolStrip_File_Open_Click);
            // 
            // toolStrip_FIle_Save
            // 
            this.toolStrip_FIle_Save.Name = "toolStrip_FIle_Save";
            this.toolStrip_FIle_Save.Size = new System.Drawing.Size(131, 22);
            this.toolStrip_FIle_Save.Text = "сохранить";
            this.toolStrip_FIle_Save.Click += new System.EventHandler(this.ToolStrip_FIle_Save_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(300, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(110, 22);
            this.toolStripLabel2.Text = "Размер фрагмента";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(100, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(116, 22);
            this.toolStripLabel1.Text = "Кол-во фрагментов";
            // 
            // toolStrip_Ok
            // 
            this.toolStrip_Ok.BackColor = System.Drawing.Color.BurlyWood;
            this.toolStrip_Ok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_Ok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_Ok.Margin = new System.Windows.Forms.Padding(100, 1, 0, 2);
            this.toolStrip_Ok.Name = "toolStrip_Ok";
            this.toolStrip_Ok.Size = new System.Drawing.Size(74, 22);
            this.toolStrip_Ok.Text = "Применить";
            this.toolStrip_Ok.ToolTipText = "Применить";
            this.toolStrip_Ok.Click += new System.EventHandler(this.ToolStrip_Ok_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1084, 586);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 586);
            this.panel1.TabIndex = 2;
            // 
            // Numeric_Count
            // 
            this.Numeric_Count.Location = new System.Drawing.Point(685, 0);
            this.Numeric_Count.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.Numeric_Count.Name = "Numeric_Count";
            this.Numeric_Count.Size = new System.Drawing.Size(53, 20);
            this.Numeric_Count.TabIndex = 3;
            // 
            // Numeric_Size
            // 
            this.Numeric_Size.Location = new System.Drawing.Point(470, 0);
            this.Numeric_Size.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.Numeric_Size.Name = "Numeric_Size";
            this.Numeric_Size.Size = new System.Drawing.Size(53, 20);
            this.Numeric_Size.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.Numeric_Size);
            this.Controls.Add(this.Numeric_Count);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Перевертыши";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStrip_File;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_File_Open;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_FIle_Save;
        private System.Windows.Forms.ToolStripButton toolStrip_Ok;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.NumericUpDown Numeric_Count;
        private System.Windows.Forms.NumericUpDown Numeric_Size;
    }
}

