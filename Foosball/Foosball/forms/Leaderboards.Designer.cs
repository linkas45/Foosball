namespace Foosball
{
    partial class Leaderboards
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
            this.leaderBoard = new System.Windows.Forms.ListView();
            this.newGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leaderBoard
            // 
            this.leaderBoard.Location = new System.Drawing.Point(-2, -1);
            this.leaderBoard.Name = "leaderBoard";
            this.leaderBoard.Size = new System.Drawing.Size(456, 486);
            this.leaderBoard.TabIndex = 0;
            this.leaderBoard.UseCompatibleStateImageBehavior = false;
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(184, 491);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(75, 23);
            this.newGame.TabIndex = 1;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // Leaderboards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 526);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.leaderBoard);
            this.Name = "Leaderboards";
            this.Text = "Leaderboards";
            this.Load += new System.EventHandler(this.Leaderboards_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView leaderBoard;
        private System.Windows.Forms.Button newGame;
    }
}