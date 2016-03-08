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
            HQMEditor.PuckPosition = new HQMVector( 15f, 0.5f, 30.5f );
        }

        private void ResetVel_Click(object sender, EventArgs e)
        {
            HQMEditor.PuckVelocity = new HQMVector ( 0f, 0f, 0f );
        }

        private void ResetSpin_Click(object sender, EventArgs e)
        {
            HQMEditor.PuckRotationalVelocity = new HQMVector ( 0f, 0f, 0f );
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PuckPos_Click(object sender, EventArgs e)
        {
            HQMEditor.PuckVelocity = (LocalPlayer.StickPosition - HQMEditor.PuckPosition).normalized * 0.1f;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HQMVector puckPos = HQMEditor.PuckPosition;
            PuckPos.Text = "Puck Pos: (" + puckPos + ")";

            HQMVector puckRot = HQMEditor.PuckRotationalVelocity;
            PuckSpin.Text = "Puck Spin: (" + puckRot + ")";

            HQMVector puckVel = HQMEditor.PuckVelocity;
            PuckVel.Text = "Puck Velocity: (" + puckVel + ")";

            HQMVector playerPos = LocalPlayer.Position;
            PlayerPos.Text = "Player Pos: (" + playerPos + ")";

            HQMVector playerStickPos = LocalPlayer.StickPosition;
            PlayerStick.Text = "Player Stick Pos: (" + playerStickPos + ")";
        }
    }
}
