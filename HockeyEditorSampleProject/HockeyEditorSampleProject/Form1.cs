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
            HQMEditor.PuckPosition = new HQMVector( 15.5f, 0.5f, 30.5f );
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

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HQMVector puckPos = HQMEditor.PuckPosition;
            PuckPos.Text = "Puck Pos: ("+puckPos.X.ToString("0.00")+","+ puckPos.Y.ToString("0.00")+","+ puckPos.Z.ToString("0.00")+")";

            HQMVector puckRot = HQMEditor.PuckRotationalVelocity;
            PuckSpin.Text = "Puck Spin: (" + puckRot.X.ToString("0.00") + "," + puckRot.Y.ToString("0.00") + "," + puckRot.Z.ToString("0.00") + ")";

            HQMVector puckVel = HQMEditor.PuckVelocity;
            PuckVel.Text = "Puck Velocity: (" + puckVel.X.ToString("0.00") + "," + puckVel.Y.ToString("0.00") + "," + puckVel.Z.ToString("0.00") + ")";

            HQMVector playerPos = HQMEditor.PlayerPosition;
            PlayerPos.Text = "Player Pos: (" + playerPos.X.ToString("0.00") + "," + playerPos.Y.ToString("0.00") + "," + playerPos.Z.ToString("0.00") + ")";

            HQMVector playerStickPos = HQMEditor.PlayerStickPosition;
            PlayerStick.Text = "Player Stick Pos: (" + playerStickPos.X.ToString("0.00") + "," + playerStickPos.Y.ToString("0.00") + "," + playerStickPos.Z.ToString("0.00") + ")";
        }
    }
}
