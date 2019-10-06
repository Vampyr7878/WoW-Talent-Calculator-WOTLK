using System.Windows.Forms;
using System.Drawing;
using System.Collections.Specialized;

namespace WoW_Talent_Calculator_WOTLK
{
    //extension of ListBox class to allow icons and descriptions
    class GlyphListBox : ListBox
    {
        //item icons
        public StringCollection Icons { get; }

        //item descriptions
        public StringCollection Descriptions { get; }

        //allow custom drawing
        public GlyphListBox()
            : base()
        {
            Icons = new StringCollection();
            Descriptions = new StringCollection();
            DrawMode = DrawMode.OwnerDrawVariable;
        }

        //draw item's icon, item's name and item's description
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= Items.Count || e.Index <= -1)
            {
                return;
            }
            string item = Items[e.Index].ToString();
            string icon = Icons[e.Index];
            string description = Descriptions[e.Index];
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
                graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            }
            graphics.FillRectangle(new TextureBrush(new Bitmap(new Bitmap(icon), e.Bounds.Height, e.Bounds.Height)), e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
            SizeF stringSize = graphics.MeasureString(item, Font);
            graphics.DrawString(item, Font, new SolidBrush(ForeColor), 15, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2);
            graphics.DrawString(description, Font, new SolidBrush(ForeColor), 190, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2);
        }
    }
}
