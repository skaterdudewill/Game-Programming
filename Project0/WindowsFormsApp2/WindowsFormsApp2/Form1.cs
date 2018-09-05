using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2{


    public partial class Form1 : Form {
        static bool[,] board = new bool[5,5];
        static int indexl = new Random().Next(3, 7);
        static int indexr = new Random().Next(0, 3);
        public Form1() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {

            //base.OnPaint(e);
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            e.Graphics.FillRectangle(Brushes.White,0,0,w,h);
            if (((indexl == 4 && indexr == 0) || (indexl == 5 && indexr == 6)) || indexl < -1) {
                e.Graphics.DrawString("You Win!", new Font("Ubuntu", 24), Brushes.Black, (w / 3) + 50, h / 3);
                indexl = -99999;
                indexr = -99999;
            }
            else {
                if (indexl == 0) {
                    e.Graphics.FillRectangle(Brushes.Gray, 0, 0, w / 2, h);
                }
                else if (indexl == 1) {
                    e.Graphics.FillRectangle(Brushes.Fuchsia, 0, 0, w / 2, h);
                }
                else if (indexl == 2) {
                    e.Graphics.FillRectangle(Brushes.Cyan, 0, 0, w / 2, h);
                }
                else if (indexl == 3) {
                    e.Graphics.FillRectangle(Brushes.Green, 0, 0, w / 2, h);
                }
                else if (indexl == 4) {
                    e.Graphics.FillRectangle(Brushes.White, 0, 0, w / 2, h);
                }
                else if (indexl == 5) {
                    e.Graphics.FillRectangle(Brushes.HotPink, 0, 0, w / 2, h);
                }
                else if (indexl == 6) {
                    e.Graphics.FillRectangle(Brushes.PaleGoldenrod, 0, 0, w / 2, h);
                }
                if (indexr == 0) {
                    e.Graphics.FillRectangle(Brushes.White, w / 2, 0, w / 2, h);
                }
                else if (indexr == 1) {
                    e.Graphics.FillRectangle(Brushes.Red, w / 2, 0, w / 2, h);
                }
                else if (indexr == 2) {
                    e.Graphics.FillRectangle(Brushes.Yellow, w / 2, 0, w / 2, h);
                }
                else if (indexr == 3) {
                    e.Graphics.FillRectangle(Brushes.LightGreen, w / 2, 0, w / 2, h);
                }
                else if (indexr == 4) {
                    e.Graphics.FillRectangle(Brushes.Blue, w / 2, 0, w / 2, h);
                }
                else if (indexr == 5) {
                    e.Graphics.FillRectangle(Brushes.Brown, w / 2, 0, w / 2, h);
                }
                else if (indexr == 6) {
                    e.Graphics.FillRectangle(Brushes.HotPink, w / 2, 0, w / 2, h);
                }
            }

         }

        private void Form1_Resize(object sender, EventArgs e) {
            this.Refresh();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            this.Update();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e) {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            int i = e.X / (w / 2);
            int j = e.Y / (h / 2);
            if (e.Button == MouseButtons.Right) {
                if (indexr > 5) {
                    indexr = 0;
                }
                else {
                    indexr++;
                }
            }
            else {
                if (indexl > 5) {
                    indexl = 0;
                }
                else {
                    indexl++;
                }
            }
            this.Refresh();
        }
    }
}