using System;
using HockeyEditor;
using System.Windows.Forms;

namespace HockeyEditorSampleProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            HQMEditor.Init();
            InitializeComponent();
            timer1.Start();
        }

        private void ResetPuck_Click(object sender, EventArgs e)
        {
            Puck.position = new HQMVector( 15f, 0.5f, 30.5f );
        }

        private void ResetVel_Click(object sender, EventArgs e)
        {
            Puck.velocity = new HQMVector ( 0f, 0f, 0f );
        }

        private void ResetSpin_Click(object sender, EventArgs e)
        {
            Puck.spin = new HQMVector ( 0f, 0f, 0f );
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PuckPos_Click(object sender, EventArgs e)
        {
            Puck.velocity = (LocalPlayer.stickPosition - Puck.position).normalized * 0.1f;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HQMVector puckPos = Puck.position;
            PuckPos.Text = "Puck Pos: (" + puckPos + ")";

            HQMVector puckRot = Puck.spin;
            PuckSpin.Text = "Puck Spin: (" + puckRot + ")";

            HQMVector puckVel = Puck.velocity;
            PuckVel.Text = "Puck Velocity: (" + puckVel + ")";

            HQMVector playerPos = LocalPlayer.position;
            PlayerPos.Text = "Player Pos: (" + playerPos + ")";

            HQMVector playerStickPos = LocalPlayer.stickPosition;
            PlayerStick.Text = "Player Stick Pos: (" + playerStickPos + ")";
        }
    }
}
