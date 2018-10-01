using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example {


    public partial class Engine : Form {
        static bool[,] board = new bool[5, 5];
        static Sprite s = new Sprite(0, 0);

        private static int frameCount = 0;
        public static int FrameCount {
            get { return frameCount; }
        }
        private static int clickX;
        public static int ClickX {
            get { return clickX; }
            set { clickX = value; }
        }
        private static int clickY;
        public static int ClickY {
            get { return clickY; }
            set { clickY = value; }
        }
        private static bool mouseDown = false;
        public static bool IsMouseDown {
            get { return mouseDown; }
        }
        public Engine() {
            InitializeComponent();
            DoubleBuffered = true;
            //s.Children.Add(new BlockSprite(10, 10, 100, 100));
            s.Children.Add(new ButtonSprite(40, 60, 75, 50, Color.FromArgb(255,255,0)));
            s.Children.Add(new StateSprite(175, 150, 50, 25));
            //s.Children.Add(new ImageSprite(Image.FromFile("c:\\users\\singularity\\pictures\\skeleton.avi"), 50, 50));
            s.X = 200;
            s.Angle = 0;
            s.Scale = 2;
            //s.Children.Add(new ImageSprite(Image.FromFile("acorn.png"), 100, 0));
            //s.Children.Add(new ImageSprite(Image.FromFile("acorn.png"), -100, 0));
            pictureBox1.Image = Image.FromFile("c:\\users\\singularity\\pictures\\skeleton.gif");
            pictureBox1.Width = 150;
            pictureBox1.Height = 150;
            Timer t = new Timer();
            t.Interval = 33;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e) {
            if (Globals.state == true) {
                BackColor = Globals.bcolor;
            }
            else {
                BackColor = Color.White;
            }
            pictureBox1.Visible = Globals.gifstate;
            frameCount += 1;
            s.Update();
            Refresh();
            //Console.WriteLine(frameCount);
        }

        protected override void OnPaint(PaintEventArgs e) {
            //base.OnPaint(e);
            //e.Graphics.RotateTransform(10);
            /*int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            e.Graphics.FillRectangle(Brushes.White, 0, 0, w, h);
            e.Graphics.DrawString("asdf", new Font("Times New Roman", 10), Brushes.Black, 10, 10);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j])
                    {
                        //e.Graphics.FillRectangle(Brushes.Black, w * i / 5, h * j / 5, w / 5, h / 5);
                        e.Graphics.DrawImage(Image.FromFile("acorn.png"), w * i / 5, h * j / 5, w / 5, h / 5);
                    }
                }
                */
            s.Paint(e.Graphics);


        }

        private void Form1_Resize(object sender, EventArgs e) {
            this.Refresh();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            this.Update();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e) {
        }

        private void Engine_MouseDown(object sender, MouseEventArgs e) {
            mouseDown = true;
            clickX = e.X;
            clickY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            //s.X = e.X;
            //s.Y = e.Y;
            //Refresh();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e) {
            s.Scale *= Math.Pow(1.001, e.Delta);
            s.Angle += e.Delta / 10.0;
            Refresh();
        }

        private void Engine_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }

        private void Engine_MouseHover(object sender, EventArgs e) {
        }

        private void Engine_MouseEnter(object sender, EventArgs e) {
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
        }
    }
}