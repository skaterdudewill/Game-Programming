using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example {
    public class BlockSprite:Sprite {

        private Color color = Color.FromArgb(0, 0, 0);

        public Color Color {
            get { return color; }
            set { color = value; }
        }

        private bool isDown = false;

        private int i;

        public BlockSprite(int x, int y,int width, int height):base(x,y) {
            this.Width = width;
            this.Height = height;
        }

        public override void Draw(Graphics g) {
            /*Matrix m = g.Transform.Clone();
            g.TranslateTransform((float)X, (float)Y);
            g.DrawImage(image, (float)(x - width / 2), (float)(x - height / 2), (float)(width), (float)(height));
            */
            g.FillRectangle(new SolidBrush(color), (float)X, (float)Y, (float)Width, (float)Height);
        }

        public override void Act() {
            int r = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 100.0));
            int g = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 57.0));
            int b = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 69.0));
            Console.WriteLine(X + "," + Y);
            if (isDown) {
                r = 0;
                g = 255;
                b = 0;
            }
            color = Color.FromArgb(r, g, b);
        }
    }
}
