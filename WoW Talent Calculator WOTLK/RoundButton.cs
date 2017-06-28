using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace WoW_Talent_Calculator_WOTLK
{
    //extension of Button class to make circle shaped custom buttons
    class RoundButton : Button
    {
        //button's texture
        private string texture;
        //helper to highlighting a button
        private bool hover;
        //helper for glyphs
        private bool active;
        //glyph's type color
        private Color color;
        //inner cirle's rectangle
        private Rectangle small;
        //glyph's rune
        private string rune;

        //allow custom drawing
        public RoundButton(string texture, Color color)
            : base()
        {
            hover = false;
            this.texture = texture;
            this.color = color;
            small = new Rectangle(0, 0, Width, Height);
            this.MouseEnter += new EventHandler(OnMouseEnter);
            this.MouseLeave += new EventHandler(OnMouseLeave);
        }

        public bool Active
        {
            set { active = value; }
            get { return active; }
        }

        public Rectangle Small
        {
            set { small = value; }
            get { return small; }
        }

        public string Rune
        {
            set { rune = value; }
            get { return rune; }
        }

        //draw custom circle shaped glyph button
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(0, 0, Width, Height);
            this.Region = new Region(graphicsPath);
            Graphics graphic = e.Graphics;
            TextureBrush brush = new TextureBrush(new Bitmap(texture));
            graphic.FillEllipse(new SolidBrush(Color.FromArgb(255, 115, 90, 50)), 0, 0, Width, Height);
            graphic.FillEllipse(brush, 0, 0, Width, Height);
            if (hover)
            {
                graphic.FillEllipse(new SolidBrush(Color.FromArgb(16, Color.White)), 0, 0, Width, Height);
            }
            if (active)
            {
                brush = new TextureBrush(Multiply(new Bitmap(new Bitmap(rune), small.Width, small.Height)));
                brush.TranslateTransform(small.X, small.Y);
                graphic.FillEllipse(new SolidBrush(Color.FromArgb(64, color)), small);
                graphic.FillEllipse(brush, small);
            }
        }

        //multiply blend mode
        private Bitmap Multiply(Bitmap image)
        {
            float r1, r2, g1, g2, b1, b2;
            int a ,r, g, b;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    r1 = (float)image.GetPixel(i, j).R / 255;
                    b1 = (float)image.GetPixel(i, j).B / 255;
                    g1 = (float)image.GetPixel(i, j).G / 255;
                    r2 = (float)color.R / 255;
                    b2 = (float)color.B / 255;
                    g2 = (float)color.G / 255;
                    a = image.GetPixel(i, j).A;
                    r = (int)(r1 * r2 * 255);
                    g = (int)(g1 * g2 * 255);
                    b = (int)(b1 * b2 * 255);
                    image.SetPixel(i, j, Color.FromArgb(a, r, g, b));
                }
            }
            return image;
        }

        //hover event start
        private void OnMouseEnter(object sender, EventArgs e)
        {
            hover = true;
        }

        //hover event end
        private void OnMouseLeave(object sender, EventArgs e)
        {
            hover = false;
        }
    }
}
