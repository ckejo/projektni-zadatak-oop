namespace projektni_zadatak_oop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tLogoShow = new System.Windows.Forms.Timer(this.components);
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.bStart = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.tBackgroundStart = new System.Windows.Forms.Timer(this.components);
            this.tBackgroundAnim = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tLogoShow
            // 
            this.tLogoShow.Enabled = true;
            this.tLogoShow.Interval = 1250;
            this.tLogoShow.Tick += new System.EventHandler(this.tLogoShow_Tick);
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbLogo.ImageLocation = "C:\\Users\\ck3jo\\Documents\\GitHub\\projektni-zadatak-oop\\projektni-zadatak-oop\\logo." +
    "png";
            this.pbLogo.Location = new System.Drawing.Point(12, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(791, 779);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            this.pbLogo.Visible = false;
            // 
            // bStart
            // 
            this.bStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bStart.AutoSize = true;
            this.bStart.FlatAppearance.BorderSize = 0;
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStart.Font = new System.Drawing.Font("ProggyTinyTT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bStart.ForeColor = System.Drawing.Color.White;
            this.bStart.Location = new System.Drawing.Point(305, 616);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(200, 76);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "POKRENI IGRU";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Visible = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bExit
            // 
            this.bExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bExit.AutoSize = true;
            this.bExit.FlatAppearance.BorderSize = 0;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExit.Font = new System.Drawing.Font("ProggyTinyTT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bExit.ForeColor = System.Drawing.Color.White;
            this.bExit.Location = new System.Drawing.Point(305, 715);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(200, 76);
            this.bExit.TabIndex = 2;
            this.bExit.Text = "IZADJI";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Visible = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // tBackgroundStart
            // 
            this.tBackgroundStart.Interval = 1250;
            this.tBackgroundStart.Tick += new System.EventHandler(this.tBackgroundStart_Tick);
            // 
            // tBackgroundAnim
            // 
            this.tBackgroundAnim.Enabled = true;
            this.tBackgroundAnim.Interval = 75;
            this.tBackgroundAnim.Tick += new System.EventHandler(this.tBackgroundAnim_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(815, 803);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.pbLogo);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Galaxigan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tLogoShow;
        private PictureBox pbLogo;
        private Button bStart;
        private Button bExit;
        private System.Windows.Forms.Timer tBackgroundStart;
        private System.Windows.Forms.Timer tBackgroundAnim;
    }
}