using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example {
    public class ButtonSprite : Sprite {
        private bool backgroundState = false;
        public bool BackgroundState {
            get { return backgroundState; }
            set { backgroundState = value; }
        }
        public ButtonSprite(int x, int y, int width, int height,Color color) : base(x, y) {
            this.color = color;
            this.Width = width;
            this.Height = height;
        }
        private bool alreadyClicked = false;
        public bool AlreadyClicked {
            get { return alreadyClicked; }
            set { alreadyClicked = value; }
        }
        private Color color = Color.FromArgb(255, 0, 0);

        public Color Color {
            get { return color; }
            set { color = value; }
        }
        public override void Draw(Graphics g) {
            /*Matrix m = g.Transform.Clone();
            g.TranslateTransform((float)X, (float)Y);
            g.DrawImage(image, (float)(x - width / 2), (float)(x - height / 2), (float)(width), (float)(height));
            */
            if (Globals.state) {
                g.FillRectangle(new SolidBrush(color), (float)X, (float)Y, (float)Width, (float)Height);
            }
        }
        private bool Contains(int screenX, int screenY) {
            PointF[] points = new PointF[] { new PointF(screenX, screenY) };
            Matrix m = M.Clone();
            m.Invert();
            m.TransformPoints(points);
            float x = points[0].X;
            float y = points[0].Y;
            Console.WriteLine(x + "," + y);
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;

        }
        private void flipColors() {
            if (backgroundState) {
                Globals.bcolor = Color.Blue;
            }
            else {
                Globals.bcolor = Color.Red;
            }
        }

        public override void Act() {
            if (Engine.IsMouseDown && Contains(Engine.ClickX, Engine.ClickY) && Globals.state == true && alreadyClicked == false) {
                alreadyClicked = true;
                backgroundState = !backgroundState;
                flipColors();
            }
            else {
                alreadyClicked = false;
            }
        }
    }
}
