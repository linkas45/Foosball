namespace Foosball
{
    partial class Counting_Goals
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
            this.TextBoxGoalsTeam1 = new System.Windows.Forms.TextBox();
            this.EndGame = new System.Windows.Forms.Button();
            this.textBoxXY = new System.Windows.Forms.TextBox();
            this.TextBoxGoalsTeam2 = new System.Windows.Forms.TextBox();
            this.ButtonLeaderboards = new System.Windows.Forms.Button();
            this.PBGoalMinus2 = new System.Windows.Forms.PictureBox();
            this.PBGoalPlus2 = new System.Windows.Forms.PictureBox();
            this.PBGoalMinus1 = new System.Windows.Forms.PictureBox();
            this.PBGoalPlus1 = new System.Windows.Forms.PictureBox();
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBGoalMinus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBGoalPlus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBGoalMinus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBGoalPlus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxGoalsTeam1
            // 
            this.TextBoxGoalsTeam1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxGoalsTeam1.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxGoalsTeam1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxGoalsTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.TextBoxGoalsTeam1.Location = new System.Drawing.Point(119, 20);
            this.TextBoxGoalsTeam1.Multiline = true;
            this.TextBoxGoalsTeam1.Name = "TextBoxGoalsTeam1";
            this.TextBoxGoalsTeam1.ReadOnly = true;
            this.TextBoxGoalsTeam1.Size = new System.Drawing.Size(200, 45);
            this.TextBoxGoalsTeam1.TabIndex = 1;
            this.TextBoxGoalsTeam1.TabStop = false;
            this.TextBoxGoalsTeam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxGoalsTeam1.TextChanged += new System.EventHandler(this.GoalsCountText_TextChanged);
            // 
            // EndGame
            // 
            this.EndGame.Location = new System.Drawing.Point(222, 460);
            this.EndGame.Name = "EndGame";
            this.EndGame.Size = new System.Drawing.Size(100, 40);
            this.EndGame.TabIndex = 0;
            this.EndGame.Text = "End Game";
            this.EndGame.UseVisualStyleBackColor = true;
            this.EndGame.Click += new System.EventHandler(this.EndGame_Click);
            // 
            // textBoxXY
            // 
            this.textBoxXY.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxXY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxXY.Location = new System.Drawing.Point(13, 460);
            this.textBoxXY.Multiline = true;
            this.textBoxXY.Name = "textBoxXY";
            this.textBoxXY.ReadOnly = true;
            this.textBoxXY.Size = new System.Drawing.Size(203, 39);
            this.textBoxXY.TabIndex = 4;
            this.textBoxXY.TabStop = false;
            this.textBoxXY.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TextBoxGoalsTeam2
            // 
            this.TextBoxGoalsTeam2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxGoalsTeam2.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxGoalsTeam2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxGoalsTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.TextBoxGoalsTeam2.Location = new System.Drawing.Point(119, 75);
            this.TextBoxGoalsTeam2.Multiline = true;
            this.TextBoxGoalsTeam2.Name = "TextBoxGoalsTeam2";
            this.TextBoxGoalsTeam2.ReadOnly = true;
            this.TextBoxGoalsTeam2.Size = new System.Drawing.Size(200, 45);
            this.TextBoxGoalsTeam2.TabIndex = 5;
            this.TextBoxGoalsTeam2.TabStop = false;
            this.TextBoxGoalsTeam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ButtonLeaderboards
            // 
            this.ButtonLeaderboards.Location = new System.Drawing.Point(12, 506);
            this.ButtonLeaderboards.Name = "ButtonLeaderboards";
            this.ButtonLeaderboards.Size = new System.Drawing.Size(310, 20);
            this.ButtonLeaderboards.TabIndex = 10;
            this.ButtonLeaderboards.Text = "Leaderboards";
            this.ButtonLeaderboards.UseVisualStyleBackColor = true;
            this.ButtonLeaderboards.Click += new System.EventHandler(this.ButtonLeaderboards_Click);
            // 
            // PBGoalMinus2
            // 
            this.PBGoalMinus2.BackgroundImage = global::Foosball.Properties.Resources.Minus;
            this.PBGoalMinus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBGoalMinus2.Location = new System.Drawing.Point(66, 71);
            this.PBGoalMinus2.Name = "PBGoalMinus2";
            this.PBGoalMinus2.Size = new System.Drawing.Size(45, 45);
            this.PBGoalMinus2.TabIndex = 9;
            this.PBGoalMinus2.TabStop = false;
            this.PBGoalMinus2.Click += new System.EventHandler(this.PBGoalMinus2_Click);
            // 
            // PBGoalPlus2
            // 
            this.PBGoalPlus2.BackgroundImage = global::Foosball.Properties.Resources.Plus;
            this.PBGoalPlus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBGoalPlus2.Location = new System.Drawing.Point(12, 71);
            this.PBGoalPlus2.Name = "PBGoalPlus2";
            this.PBGoalPlus2.Size = new System.Drawing.Size(45, 45);
            this.PBGoalPlus2.TabIndex = 8;
            this.PBGoalPlus2.TabStop = false;
            this.PBGoalPlus2.Click += new System.EventHandler(this.PBGoalPlus2_Click);
            // 
            // PBGoalMinus1
            // 
            this.PBGoalMinus1.BackgroundImage = global::Foosball.Properties.Resources.Minus;
            this.PBGoalMinus1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBGoalMinus1.Location = new System.Drawing.Point(66, 20);
            this.PBGoalMinus1.Name = "PBGoalMinus1";
            this.PBGoalMinus1.Size = new System.Drawing.Size(45, 45);
            this.PBGoalMinus1.TabIndex = 7;
            this.PBGoalMinus1.TabStop = false;
            this.PBGoalMinus1.Click += new System.EventHandler(this.PBGoalMinus1_Click);
            // 
            // PBGoalPlus1
            // 
            this.PBGoalPlus1.BackgroundImage = global::Foosball.Properties.Resources.Plus;
            this.PBGoalPlus1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBGoalPlus1.Location = new System.Drawing.Point(12, 20);
            this.PBGoalPlus1.Name = "PBGoalPlus1";
            this.PBGoalPlus1.Size = new System.Drawing.Size(45, 45);
            this.PBGoalPlus1.TabIndex = 6;
            this.PBGoalPlus1.TabStop = false;
            this.PBGoalPlus1.Click += new System.EventHandler(this.PBGoalPlus1_Click);
            // 
            // ibOriginal
            // 
            this.ibOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ibOriginal.Enabled = false;
            this.ibOriginal.Location = new System.Drawing.Point(12, 125);
            this.ibOriginal.Margin = new System.Windows.Forms.Padding(2);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(310, 323);
            this.ibOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibOriginal.TabIndex = 3;
            this.ibOriginal.TabStop = false;
            // 
            // Counting_Goals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(334, 533);
            this.Controls.Add(this.ButtonLeaderboards);
            this.Controls.Add(this.PBGoalMinus2);
            this.Controls.Add(this.PBGoalPlus2);
            this.Controls.Add(this.PBGoalMinus1);
            this.Controls.Add(this.PBGoalPlus1);
            this.Controls.Add(this.TextBoxGoalsTeam2);
            this.Controls.Add(this.textBoxXY);
            this.Controls.Add(this.EndGame);
            this.Controls.Add(this.ibOriginal);
            this.Controls.Add(this.TextBoxGoalsTeam1);
            this.Name = "Counting_Goals";
            this.Text = "Counting Goals";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Counting_Goals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBGoalMinus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBGoalPlus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBGoalMinus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBGoalPlus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TextBoxGoalsTeam1;
        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button EndGame;
        private System.Windows.Forms.TextBox textBoxXY;
        public System.Windows.Forms.TextBox TextBoxGoalsTeam2;
        private System.Windows.Forms.PictureBox PBGoalPlus1;
        private System.Windows.Forms.PictureBox PBGoalMinus1;
        private System.Windows.Forms.PictureBox PBGoalMinus2;
        private System.Windows.Forms.PictureBox PBGoalPlus2;
        private System.Windows.Forms.Button ButtonLeaderboards;
    }
}