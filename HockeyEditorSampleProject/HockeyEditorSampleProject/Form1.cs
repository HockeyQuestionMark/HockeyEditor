using System;
using HockeyEditor;
using System.Windows.Forms;

namespace HockeyEditorSampleProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            MemoryWriter.Init();
            InitializeComponent();
            timer1.Start();
        }

        private void ResetPuck_Click(object sender, EventArgs e)
        {
            Client.PuckPosition = new float[3] { 15.5f, 0.5f, 30.5f };
        }

        private void ResetVel_Click(object sender, EventArgs e)
        {
            Client.PuckVelocity = new float[3] { 0f, 0f, 0f };
        }

        private void ResetSpin_Click(object sender, EventArgs e)
        {
            Client.PuckRotationalVelocity = new float[3] { 0f, 0f, 0f };
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PuckPos_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float[] puckPos = Client.PuckPosition;
            PuckPos.Text = "Puck Pos: ("+puckPos[0].ToString("0.00")+","+ puckPos[1].ToString("0.00")+","+ puckPos[2].ToString("0.00")+")";

            float[] puckRot = Client.PuckRotationalVelocity;
            PuckSpin.Text = "Puck Spin: (" + puckRot[0].ToString("0.00") + "," + puckRot[1].ToString("0.00") + "," + puckRot[2].ToString("0.00") + ")";

            float[] puckVel = Client.PuckVelocity;
            PuckVel.Text = "Puck Velocity: (" + puckVel[0].ToString("0.00") + "," + puckVel[1].ToString("0.00") + "," + puckVel[2].ToString("0.00") + ")";

            float[] playerPos = Client.PlayerPosition;
            PlayerPos.Text = "Player Pos: (" + playerPos[0].ToString("0.00") + "," + playerPos[1].ToString("0.00") + "," + playerPos[2].ToString("0.00") + ")";

            float[] playerStickPos = Client.PlayerStickPosition;
            PlayerStick.Text = "Player Stick Pos: (" + playerStickPos[0].ToString("0.00") + "," + playerStickPos[1].ToString("0.00") + "," + playerStickPos[2].ToString("0.00") + ")";
        }
    }
}
