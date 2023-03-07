using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro_3x3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
           // DrawChessBoard();
        }



       /* void DrawChessBoard()
        {
            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<6;j++)
                {
                    Button btn = new Button()
                    {
                        Width = CONST.chess_width,
                        Height = CONST.chess_height,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                };

                    btn.Click += ButtonClick;
                    BanCo.Controls.Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + CONST.chess_height);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }
       */

       /* void ButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = Convert.ToString(btn.Location.X/60);
            textBox2.Text = Convert.ToString("5-" + (5-(btn.Location.X / 60)) + "-" + ((btn.Location.Y / 60)+1) + "-O");
            CONST.vitri = Convert.ToString("5-" + (5 - (btn.Location.X / 60)) + "-" + ((btn.Location.Y / 60) + 1) + "-O");
            Player();
            
            if ( CONST.mark=="o")
                    {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = Convert.ToString("5-" + btn.Location.X / 60 + "-" + btn.Location.Y / 60 + "-O");

            }
            else if(CONST.mark=="x")
                    {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = Convert.ToString("5-" + btn.Location.X / 60 + "-" + btn.Location.Y / 60 + "-X");

            }
            serialPort1.Write(CONST.vitri);
            serialPort1.Write(" ");
            CONST.luot = CONST.luot + 1;




        }*/

        void Player()
        {
            if (CONST.PLAYER == 0)
            {
                if (CONST.player == 0)
                {
                    CONST.mark = CONST.MARK;
                }
                else if (CONST.player == 1)
                {
                    CONST.mark = CONST.MARKIV;
                }
            }
            else
            {
                if (CONST.player == 0)
                {
                    CONST.mark = CONST.MARKIV;
                }
                else if (CONST.player == 1)
                {
                    CONST.mark = CONST.MARK;
                }

            }
        }

        private void XOButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CONST.state = 1 - CONST.state;
            if (CONST.state == 0)
            {
                CONST.MARK = "o";
                CONST.MARKIV = "x";
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
            }
            else if (CONST.state == 1)
            {
                CONST.MARK = "x";
                CONST.MARKIV = "o";
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
            }
        }

        private void PlayerButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CONST.PLAYER = 1 - CONST.PLAYER;
            if (CONST.PLAYER == 0)
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\mot.png");
            }
            else if (CONST.PLAYER == 1)
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\hai.png");
            }
        }








        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-01-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-01-X";
            }
            textBox1.Text = Convert.ToString(CONST.PLAYER);
            textBox2.Text = Convert.ToString(CONST.player);
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-02-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-02-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-03-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-03-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-04-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-04-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-05-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-05-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-06-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-06-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-07-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-07-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-08-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-08-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-09-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-09-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-10-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-10-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-11-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-11-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-12-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-12-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-13-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-13-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-14-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-14-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-15-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-15-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-16-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-16-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-17-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-17-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-18-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-18-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-19-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-19-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-20-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-20-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-21-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-21-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-22-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-22-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-23-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-23-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-24-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-24-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Player();
            if (CONST.mark == "o")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butO.png");
                CONST.vitri = "5-25-O";
            }
            else if (CONST.mark == "x")
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\butX.png");
                CONST.vitri = "5-25-X";
            }
            if (CONST.PLAYER == CONST.player)
            {
                serialPort1.Write(CONST.vitri);
            }
            CONST.player = 1 - CONST.player;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
