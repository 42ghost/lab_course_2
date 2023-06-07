namespace lab2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lab2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab2dopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab31ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lab31ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parsingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorStack = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.saveToolStripMenuItem.Text = "save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.openToolStripMenuItem.Text = "open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.closeToolStripMenuItem.Text = "close";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab2ToolStripMenuItem,
            this.lab2dopToolStripMenuItem,
            this.lab31ToolStripMenuItem1,
            this.lab31ToolStripMenuItem,
            this.parsingToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem2.Text = "Labs";
            // 
            // lab2ToolStripMenuItem
            // 
            this.lab2ToolStripMenuItem.Name = "lab2ToolStripMenuItem";
            this.lab2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lab2ToolStripMenuItem.Text = "lab2";
            this.lab2ToolStripMenuItem.Click += new System.EventHandler(this.lab2ToolStripMenuItem_Click);
            // 
            // lab2dopToolStripMenuItem
            // 
            this.lab2dopToolStripMenuItem.Name = "lab2dopToolStripMenuItem";
            this.lab2dopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lab2dopToolStripMenuItem.Text = "lab2_dop";
            this.lab2dopToolStripMenuItem.Click += new System.EventHandler(this.lab2dopToolStripMenuItem_Click);
            // 
            // lab31ToolStripMenuItem1
            // 
            this.lab31ToolStripMenuItem1.Name = "lab31ToolStripMenuItem1";
            this.lab31ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.lab31ToolStripMenuItem1.Text = "lab3_1";
            this.lab31ToolStripMenuItem1.Click += new System.EventHandler(this.lab3ToolStripMenuItem1_Click);
            // 
            // lab31ToolStripMenuItem
            // 
            this.lab31ToolStripMenuItem.Name = "lab31ToolStripMenuItem";
            this.lab31ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lab31ToolStripMenuItem.Text = "lab3_2";
            this.lab31ToolStripMenuItem.Click += new System.EventHandler(this.lab31ToolStripMenuItem_Click);
            // 
            // parsingToolStripMenuItem
            // 
            this.parsingToolStripMenuItem.Name = "parsingToolStripMenuItem";
            this.parsingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parsingToolStripMenuItem.Text = "Parsing";
            this.parsingToolStripMenuItem.Click += new System.EventHandler(this.parsingToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorStack
            // 
            this.errorStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorStack.Location = new System.Drawing.Point(0, 24);
            this.errorStack.Multiline = true;
            this.errorStack.Name = "errorStack";
            this.errorStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorStack.Size = new System.Drawing.Size(750, 369);
            this.errorStack.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 393);
            this.Controls.Add(this.errorStack);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lab2ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem lab2dopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lab31ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lab31ToolStripMenuItem1;
        public System.Windows.Forms.TextBox errorStack;
        private System.Windows.Forms.ToolStripMenuItem parsingToolStripMenuItem;
    }
}

