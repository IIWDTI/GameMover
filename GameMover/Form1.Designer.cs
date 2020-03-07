namespace GameMover
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
            this.cb_Source = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Game = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Dest = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMoveGame = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_Source
            // 
            this.cb_Source.FormattingEnabled = true;
            this.cb_Source.Location = new System.Drawing.Point(75, 29);
            this.cb_Source.Name = "cb_Source";
            this.cb_Source.Size = new System.Drawing.Size(302, 21);
            this.cb_Source.TabIndex = 0;
            this.cb_Source.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path:";
            // 
            // cb_Game
            // 
            this.cb_Game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Game.Enabled = false;
            this.cb_Game.FormattingEnabled = true;
            this.cb_Game.Location = new System.Drawing.Point(75, 84);
            this.cb_Game.Name = "cb_Game";
            this.cb_Game.Size = new System.Drawing.Size(302, 21);
            this.cb_Game.TabIndex = 3;
            this.cb_Game.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Game:";
            // 
            // cb_Dest
            // 
            this.cb_Dest.Enabled = false;
            this.cb_Dest.FormattingEnabled = true;
            this.cb_Dest.Location = new System.Drawing.Point(75, 136);
            this.cb_Dest.Name = "cb_Dest";
            this.cb_Dest.Size = new System.Drawing.Size(302, 21);
            this.cb_Dest.TabIndex = 5;
            this.cb_Dest.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "New Path:";
            // 
            // btnMoveGame
            // 
            this.btnMoveGame.Enabled = false;
            this.btnMoveGame.Location = new System.Drawing.Point(170, 189);
            this.btnMoveGame.Name = "btnMoveGame";
            this.btnMoveGame.Size = new System.Drawing.Size(75, 23);
            this.btnMoveGame.TabIndex = 7;
            this.btnMoveGame.Text = "Move game!";
            this.btnMoveGame.UseVisualStyleBackColor = true;
            this.btnMoveGame.Click += new System.EventHandler(this.btnMoveGame_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 236);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(361, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 350);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnMoveGame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Dest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Game);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Source);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameMover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Source;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Game;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_Dest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMoveGame;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
    }
}

