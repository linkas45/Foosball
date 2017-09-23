namespace Foosball
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelOuter = new System.Windows.Forms.TableLayoutPanel();
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.ibThresh = new Emgu.CV.UI.ImageBox();
            this.textBoxXYRadius = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelInner = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibThresh)).BeginInit();
            this.tableLayoutPanelInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelOuter
            // 
            this.tableLayoutPanelOuter.ColumnCount = 2;
            this.tableLayoutPanelOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOuter.Controls.Add(this.ibOriginal, 0, 0);
            this.tableLayoutPanelOuter.Controls.Add(this.ibThresh, 1, 0);
            this.tableLayoutPanelOuter.Controls.Add(this.tableLayoutPanelInner, 0, 1);
            this.tableLayoutPanelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOuter.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOuter.Name = "tableLayoutPanelOuter";
            this.tableLayoutPanelOuter.RowCount = 2;
            this.tableLayoutPanelOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelOuter.Size = new System.Drawing.Size(1436, 577);
            this.tableLayoutPanelOuter.TabIndex = 0;
            // 
            // ibOriginal
            // 
            this.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibOriginal.Enabled = false;
            this.ibOriginal.Location = new System.Drawing.Point(3, 3);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(712, 455);
            this.ibOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            // 
            // ibThresh
            // 
            this.ibThresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibThresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibThresh.Enabled = false;
            this.ibThresh.Location = new System.Drawing.Point(721, 3);
            this.ibThresh.Name = "ibThresh";
            this.ibThresh.Size = new System.Drawing.Size(712, 455);
            this.ibThresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibThresh.TabIndex = 2;
            this.ibThresh.TabStop = false;
            // 
            // textBoxXYRadius
            // 
            this.textBoxXYRadius.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxXYRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxXYRadius.Location = new System.Drawing.Point(3, 3);
            this.textBoxXYRadius.Multiline = true;
            this.textBoxXYRadius.Name = "textBoxXYRadius";
            this.textBoxXYRadius.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxXYRadius.Size = new System.Drawing.Size(1424, 104);
            this.textBoxXYRadius.TabIndex = 2;
            this.textBoxXYRadius.WordWrap = false;
            // 
            // tableLayoutPanelInner
            // 
            this.tableLayoutPanelInner.ColumnCount = 2;
            this.tableLayoutPanelOuter.SetColumnSpan(this.tableLayoutPanelInner, 2);
            this.tableLayoutPanelInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInner.Controls.Add(this.textBoxXYRadius, 1, 0);
            this.tableLayoutPanelInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInner.Location = new System.Drawing.Point(3, 464);
            this.tableLayoutPanelInner.Name = "tableLayoutPanelInner";
            this.tableLayoutPanelInner.RowCount = 1;
            this.tableLayoutPanelInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInner.Size = new System.Drawing.Size(1430, 110);
            this.tableLayoutPanelInner.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 577);
            this.Controls.Add(this.tableLayoutPanelOuter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanelOuter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibThresh)).EndInit();
            this.tableLayoutPanelInner.ResumeLayout(false);
            this.tableLayoutPanelInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOuter;
        private Emgu.CV.UI.ImageBox ibOriginal;
        private Emgu.CV.UI.ImageBox ibThresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInner;
        private System.Windows.Forms.TextBox textBoxXYRadius;
    }
}

