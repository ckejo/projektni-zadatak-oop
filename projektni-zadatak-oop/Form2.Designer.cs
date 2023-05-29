namespace projektni_zadatak_oop
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tProjectileMover = new System.Windows.Forms.Timer(this.components);
            this.lbScoreTitle = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.tEnemyMover = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tProjectileMover
            // 
            this.tProjectileMover.Interval = 50;
            this.tProjectileMover.Tick += new System.EventHandler(this.tProjectileMover_Tick);
            // 
            // lbScoreTitle
            // 
            this.lbScoreTitle.AutoSize = true;
            this.lbScoreTitle.Font = new System.Drawing.Font("8BIT WONDER", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbScoreTitle.ForeColor = System.Drawing.Color.Red;
            this.lbScoreTitle.Location = new System.Drawing.Point(12, 9);
            this.lbScoreTitle.Name = "lbScoreTitle";
            this.lbScoreTitle.Size = new System.Drawing.Size(90, 16);
            this.lbScoreTitle.TabIndex = 0;
            this.lbScoreTitle.Text = "SCORE:";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("8BIT WONDER", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbScore.ForeColor = System.Drawing.Color.White;
            this.lbScore.Location = new System.Drawing.Point(13, 36);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(0, 12);
            this.lbScore.TabIndex = 1;
            this.lbScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tEnemyMover
            // 
            this.tEnemyMover.Enabled = true;
            this.tEnemyMover.Interval = 1250;
            this.tEnemyMover.Tick += new System.EventHandler(this.tEnemyMover_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(815, 803);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.lbScoreTitle);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Galaxigan";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tProjectileMover;
        private Label lbScoreTitle;
        private Label lbScore;
        private System.Windows.Forms.Timer tEnemyMover;
    }
}