namespace CarAvoidGame
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.panelGameArea = new System.Windows.Forms.Panel();
            this.buttonMoveRight = new System.Windows.Forms.Button();
            this.buttonMoveLeft = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.progressHealth = new System.Windows.Forms.ProgressBar();
            this.panelGameArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGameArea
            // 
            this.panelGameArea.BackColor = System.Drawing.Color.Transparent;
            this.panelGameArea.Controls.Add(this.progressHealth);
            this.panelGameArea.Controls.Add(this.labelScore);
            this.panelGameArea.Controls.Add(this.buttonMoveRight);
            this.panelGameArea.Controls.Add(this.buttonStart);
            this.panelGameArea.Controls.Add(this.buttonMoveLeft);
            this.panelGameArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGameArea.Location = new System.Drawing.Point(0, 0);
            this.panelGameArea.Name = "panelGameArea";
            this.panelGameArea.Size = new System.Drawing.Size(784, 362);
            this.panelGameArea.TabIndex = 0;
            this.panelGameArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGameArea_Paint);
            // 
            // buttonMoveRight
            // 
            this.buttonMoveRight.BackColor = System.Drawing.Color.White;
            this.buttonMoveRight.FlatAppearance.BorderSize = 0;
            this.buttonMoveRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveRight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMoveRight.ForeColor = System.Drawing.Color.Black;
            this.buttonMoveRight.Location = new System.Drawing.Point(642, 26);
            this.buttonMoveRight.Name = "buttonMoveRight";
            this.buttonMoveRight.Size = new System.Drawing.Size(75, 27);
            this.buttonMoveRight.TabIndex = 3;
            this.buttonMoveRight.Text = "Right";
            this.buttonMoveRight.UseVisualStyleBackColor = false;
            this.buttonMoveRight.Click += new System.EventHandler(this.buttonMoveRight_Click);
            // 
            // buttonMoveLeft
            // 
            this.buttonMoveLeft.BackColor = System.Drawing.Color.White;
            this.buttonMoveLeft.FlatAppearance.BorderSize = 0;
            this.buttonMoveLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveLeft.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMoveLeft.ForeColor = System.Drawing.Color.Black;
            this.buttonMoveLeft.Location = new System.Drawing.Point(529, 26);
            this.buttonMoveLeft.Name = "buttonMoveLeft";
            this.buttonMoveLeft.Size = new System.Drawing.Size(75, 27);
            this.buttonMoveLeft.TabIndex = 2;
            this.buttonMoveLeft.Text = "Left";
            this.buttonMoveLeft.UseVisualStyleBackColor = false;
            this.buttonMoveLeft.Click += new System.EventHandler(this.buttonMoveLeft_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.White;
            this.buttonStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonStart.FlatAppearance.BorderSize = 0;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.ForeColor = System.Drawing.Color.Black;
            this.buttonStart.Location = new System.Drawing.Point(173, 26);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 27);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(37, 23);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(91, 30);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "Score: 0";
            this.labelScore.Click += new System.EventHandler(this.labelScore_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 40;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // progressHealth
            // 
            this.progressHealth.BackColor = System.Drawing.Color.White;
            this.progressHealth.ForeColor = System.Drawing.Color.Red;
            this.progressHealth.Location = new System.Drawing.Point(290, 35);
            this.progressHealth.Name = "progressHealth";
            this.progressHealth.Size = new System.Drawing.Size(200, 18);
            this.progressHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressHealth.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.panelGameArea);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Avoid Game";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panelGameArea.ResumeLayout(false);
            this.panelGameArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGameArea;
        private System.Windows.Forms.Button buttonMoveRight;
        private System.Windows.Forms.Button buttonMoveLeft;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ProgressBar progressHealth;
    }
}

