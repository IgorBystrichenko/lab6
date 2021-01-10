namespace lab6
{
    partial class GameWindow
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
            this.EnemyScore = new System.Windows.Forms.Label();
            this.PlayerScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EnemyScore
            // 
            this.EnemyScore.AutoSize = true;
            this.EnemyScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyScore.Location = new System.Drawing.Point(42, 119);
            this.EnemyScore.Name = "EnemyScore";
            this.EnemyScore.Size = new System.Drawing.Size(30, 31);
            this.EnemyScore.TabIndex = 0;
            this.EnemyScore.Text = "0";
            // 
            // PlayerScore
            // 
            this.PlayerScore.AutoSize = true;
            this.PlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerScore.Location = new System.Drawing.Point(42, 379);
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.Size = new System.Drawing.Size(30, 31);
            this.PlayerScore.TabIndex = 1;
            this.PlayerScore.Text = "0";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.PlayerScore);
            this.Controls.Add(this.EnemyScore);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EnemyScore;
        private System.Windows.Forms.Label PlayerScore;
    }
}