namespace HockeyEditorSampleProject
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ResetPuck = new System.Windows.Forms.Button();
            this.ResetVel = new System.Windows.Forms.Button();
            this.PuckVel = new System.Windows.Forms.Label();
            this.ResetSpin = new System.Windows.Forms.Button();
            this.PuckSpin = new System.Windows.Forms.Label();
            this.PlayerPos = new System.Windows.Forms.Label();
            this.PuckPos = new System.Windows.Forms.Label();
            this.PlayerStick = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ResetPuck, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ResetVel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PuckVel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ResetSpin, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PuckSpin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PlayerPos, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PuckPos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayerStick, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.13793F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.86207F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 260);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // ResetPuck
            // 
            this.ResetPuck.Location = new System.Drawing.Point(3, 3);
            this.ResetPuck.Name = "ResetPuck";
            this.ResetPuck.Size = new System.Drawing.Size(135, 51);
            this.ResetPuck.TabIndex = 0;
            this.ResetPuck.Text = "Reset Puck Pos";
            this.ResetPuck.UseVisualStyleBackColor = true;
            this.ResetPuck.Click += new System.EventHandler(this.ResetPuck_Click);
            // 
            // ResetVel
            // 
            this.ResetVel.Location = new System.Drawing.Point(3, 60);
            this.ResetVel.Name = "ResetVel";
            this.ResetVel.Size = new System.Drawing.Size(135, 53);
            this.ResetVel.TabIndex = 2;
            this.ResetVel.Text = "Reset Puck Velocity";
            this.ResetVel.UseVisualStyleBackColor = true;
            this.ResetVel.Click += new System.EventHandler(this.ResetVel_Click);
            // 
            // PuckVel
            // 
            this.PuckVel.AutoSize = true;
            this.PuckVel.Location = new System.Drawing.Point(144, 57);
            this.PuckVel.Name = "PuckVel";
            this.PuckVel.Size = new System.Drawing.Size(131, 13);
            this.PuckVel.TabIndex = 3;
            this.PuckVel.Text = "Puck Vel: (0.55,0.55,0.55)";
            // 
            // ResetSpin
            // 
            this.ResetSpin.Location = new System.Drawing.Point(3, 119);
            this.ResetSpin.Name = "ResetSpin";
            this.ResetSpin.Size = new System.Drawing.Size(135, 66);
            this.ResetSpin.TabIndex = 4;
            this.ResetSpin.Text = "Reset Puck Spin";
            this.ResetSpin.UseVisualStyleBackColor = true;
            this.ResetSpin.Click += new System.EventHandler(this.ResetSpin_Click);
            // 
            // PuckSpin
            // 
            this.PuckSpin.AutoSize = true;
            this.PuckSpin.Location = new System.Drawing.Point(144, 116);
            this.PuckSpin.Name = "PuckSpin";
            this.PuckSpin.Size = new System.Drawing.Size(134, 13);
            this.PuckSpin.TabIndex = 5;
            this.PuckSpin.Text = "Puck Spin:(0.55,0.55,0.55)";
            // 
            // PlayerPos
            // 
            this.PlayerPos.AutoSize = true;
            this.PlayerPos.Location = new System.Drawing.Point(3, 188);
            this.PlayerPos.Name = "PlayerPos";
            this.PlayerPos.Size = new System.Drawing.Size(135, 13);
            this.PlayerPos.TabIndex = 6;
            this.PlayerPos.Text = "Player Pos:(0.55,0.55,0.55)";
            // 
            // PuckPos
            // 
            this.PuckPos.AutoSize = true;
            this.PuckPos.Location = new System.Drawing.Point(144, 0);
            this.PuckPos.Name = "PuckPos";
            this.PuckPos.Size = new System.Drawing.Size(134, 13);
            this.PuckPos.TabIndex = 1;
            this.PuckPos.Text = "Puck Pos: (0.55,0.55,0.55)";
            this.PuckPos.Click += new System.EventHandler(this.PuckPos_Click);
            // 
            // PlayerStick
            // 
            this.PlayerStick.AutoSize = true;
            this.PlayerStick.Location = new System.Drawing.Point(144, 188);
            this.PlayerStick.Name = "PlayerStick";
            this.PlayerStick.Size = new System.Drawing.Size(109, 26);
            this.PlayerStick.TabIndex = 7;
            this.PlayerStick.Text = "Player Stick:(0.55,0.55,0.55)";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ResetPuck;
        private System.Windows.Forms.Label PuckPos;
        private System.Windows.Forms.Button ResetVel;
        private System.Windows.Forms.Label PuckVel;
        private System.Windows.Forms.Button ResetSpin;
        private System.Windows.Forms.Label PuckSpin;
        private System.Windows.Forms.Label PlayerPos;
        private System.Windows.Forms.Label PlayerStick;
        private System.Windows.Forms.Timer timer1;
    }
}

