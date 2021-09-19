using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_lab3_oop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Brush[] brushes = new Brush[]
        {
            Brushes.AliceBlue,
            Brushes.AntiqueWhite,
            Brushes.Aqua,
            Brushes.YellowGreen,
            Brushes.Red,
            Brushes.DarkGoldenrod,
            Brushes.LightBlue,
            Brushes.MediumPurple,
            Brushes.DarkSeaGreen,
        };

        private tPoint[] points = new tPoint[100];

        private Random random = new Random();

        private Graphics graphics;

        private int _movementMode = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);

            foreach (var point in points)
            {
                DrawPoint(point);
                if (_movementMode == 1) {
                    point.RandomMovementPoint(pictureBox2.Width, pictureBox2.Height);
                }
                else
                {
                    point.MovementPoint_AlongX(pictureBox2.Width, pictureBox2.Height);
                }
                
            }

            pictureBox2.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            graphics = Graphics.FromImage(pictureBox2.Image);

            for (int i = 0; i < points.Length; i++)
            {
                int X = random.Next(8, pictureBox2.Width-8);
                int Y = random.Next(8, pictureBox2.Height-8);
                Brush brush = brushes[random.Next(brushes.Length)];
                points[i] = new tPoint(brush,X,Y);
            }

            timer2.Start();
        }


        private void DrawPoint(tPoint point)
        {
            int EllipsSize = 8;

            graphics.FillEllipse(point.brush, point.X, point.Y, EllipsSize, EllipsSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _movementMode = 1 - _movementMode;
        }
    }
}
