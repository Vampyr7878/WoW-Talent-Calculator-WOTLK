using System.Windows.Forms;
using System.Drawing;
using System.Collections.Specialized;

namespace WoW_Talent_Calculator_WOTLK
{
    //extension of ListBox class to allow icons and descriptions
    class GlyphListBox : ListBox
    {
        //item icons
        StringCollection icons;
        //item descriptions
        StringCollection descriptions;

        //allow custom drawing
        public GlyphListBox()
            : base()
        {
            icons = new StringCollection();
            descriptions = new StringCollection();
            this.DrawMode = DrawMode.OwnerDrawVariable;
        }

        public StringCollection Icons
        {
            get { return icons; }
        }

        public StringCollection Descriptions
        {
            get { return descriptions; }
        }

        //draw item's icon, item's name and item's description
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= this.Items.Count || e.Index <= -1)
            {
                return;
            }
            string item = this.Items[e.Index].ToString();
            string icon = icons[e.Index];
            string description = descriptions[e.Index];
            if (item == null)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                graphics.FillRectangle(new SolidBrush(Color.DimGray), e.Bounds);
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);
            }
            graphics.FillRectangle(new TextureBrush(new Bitmap(new Bitmap(icon), e.Bounds.Height, e.Bounds.Height)), e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
            SizeF stringSize = graphics.MeasureString(item, this.Font);
            graphics.DrawString(item, this.Font, new SolidBrush(this.ForeColor), 15, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2);
            graphics.DrawString(description, this.Font, new SolidBrush(this.ForeColor), 190, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2);
        }
    }
}
