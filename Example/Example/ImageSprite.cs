using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Example {
    public class ImageSprite:Sprite {
        private Image image;

        public Image Image {
            get { return image; }
            set { image = value; }
        }

        public ImageSprite(Image image, int x, int y):base(x,y) {
            this.image = image;
            this.Width = image.Width;
            this.Height = image.Height;
        }

        public override void Draw(Graphics g) {
            if (Globals.state == false) {
                g.DrawImage(image, (float)(X - Width / 2), (float)(Y - Height / 2), (float)(Width), (float)(Height));
            }
        }
        public override void Act() {
            
        }
    }
}
