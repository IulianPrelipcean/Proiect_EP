using System.Windows.Forms;

namespace SimpleCheckers
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jocNouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxBoard = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.levelDifficulty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.depthSearch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.evaluateFunctionType = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jocToolStripMenuItem,
            this.ajutorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1461, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jocToolStripMenuItem
            // 
            this.jocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jocNouToolStripMenuItem,
            this.iesireToolStripMenuItem});
            this.jocToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.jocToolStripMenuItem.Name = "jocToolStripMenuItem";
            this.jocToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.jocToolStripMenuItem.Text = "&Joc";
            // 
            // jocNouToolStripMenuItem
            // 
            this.jocNouToolStripMenuItem.Name = "jocNouToolStripMenuItem";
            this.jocNouToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.jocNouToolStripMenuItem.Text = "Joc &nou";
            this.jocNouToolStripMenuItem.Click += new System.EventHandler(this.jocNouToolStripMenuItem_Click);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.iesireToolStripMenuItem.Text = "&Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // ajutorToolStripMenuItem
            // 
            this.ajutorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despreToolStripMenuItem});
            this.ajutorToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ajutorToolStripMenuItem.Name = "ajutorToolStripMenuItem";
            this.ajutorToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.ajutorToolStripMenuItem.Text = "&Ajutor";
            // 
            // despreToolStripMenuItem
            // 
            this.despreToolStripMenuItem.Name = "despreToolStripMenuItem";
            this.despreToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.despreToolStripMenuItem.Text = "&Reguli...";
            this.despreToolStripMenuItem.Click += new System.EventHandler(this.despreToolStripMenuItem_Click);
            // 
            // pictureBoxBoard
            // 
            this.pictureBoxBoard.Location = new System.Drawing.Point(0, 32);
            this.pictureBoxBoard.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxBoard.Name = "pictureBoxBoard";
            this.pictureBoxBoard.Size = new System.Drawing.Size(1000, 1000);
            this.pictureBoxBoard.TabIndex = 1;
            this.pictureBoxBoard.TabStop = false;
            this.pictureBoxBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBoard_Paint);
            this.pictureBoxBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoard_MouseUp);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(1016, 104);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(416, 249);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1047, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Timp de căutare pentru fiecare mutare";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Goldenrod;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1047, 391);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nivel de dificultate ales:";
            // 
            // levelDifficulty
            // 
            this.levelDifficulty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.levelDifficulty.Enabled = false;
            this.levelDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelDifficulty.Location = new System.Drawing.Point(1251, 388);
            this.levelDifficulty.Name = "levelDifficulty";
            this.levelDifficulty.Size = new System.Drawing.Size(100, 24);
            this.levelDifficulty.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1047, 446);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Adâncimea de căutare:";
            // 
            // depthSearch
            // 
            this.depthSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.depthSearch.FormattingEnabled = true;
            this.depthSearch.Items.AddRange(new object[] {
            "1",
            "4",
            "6"});
            this.depthSearch.Location = new System.Drawing.Point(1251, 446);
            this.depthSearch.Name = "depthSearch";
            this.depthSearch.Size = new System.Drawing.Size(130, 24);
            this.depthSearch.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Goldenrod;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1047, 507);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Functia obiectiv: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // evaluateFunctionType
            // 
            this.evaluateFunctionType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.evaluateFunctionType.FormattingEnabled = true;
            this.evaluateFunctionType.Items.AddRange(new object[] {
            "evaluare rapida",
            "evaluare complexa"});
            this.evaluateFunctionType.Location = new System.Drawing.Point(1209, 503);
            this.evaluateFunctionType.Name = "evaluateFunctionType";
            this.evaluateFunctionType.Size = new System.Drawing.Size(172, 24);
            this.evaluateFunctionType.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(1461, 746);
            this.Controls.Add(this.evaluateFunctionType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.depthSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.levelDifficulty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBoxBoard);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Gray;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Dame simple";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jocNouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxBoard;
        private System.Windows.Forms.ToolStripMenuItem ajutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
        private RichTextBox richTextBox1;
        private Label label1;
        private Label label2;
        private TextBox levelDifficulty;
        private Label label3;
        private ComboBox depthSearch;
        private Label label4;
        private ComboBox evaluateFunctionType;

        // This is outrageous but it can be an easy logger
        //public static RichTextBox richTextBox1 { get; set; }
    }
}

