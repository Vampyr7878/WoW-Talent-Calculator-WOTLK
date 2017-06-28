using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace WoW_Talent_Calculator_WOTLK
{
    public partial class Glyphs : Form
    {
        //glyphs file
        private XmlDocument glyphs;
        //glyphs list
        private XmlNode list;
        //selected glyph
        private XmlNode selected;
        //listbox of glyphs
        private GlyphListBox glyphListBox;
        //glyphs currently used
        private string[] used;
        //index of slected glyph
        private int index;

        //setup dialog
        public Glyphs(string name, string type, string[] used)
        {
            InitializeComponent();
            glyphListBox = new GlyphListBox();
            glyphListBox.BackColor = Color.Black;
            glyphListBox.ForeColor = Color.White;
            glyphListBox.FormattingEnabled = true;
            glyphListBox.Location = new Point(13, 12);
            glyphListBox.Size = new Size(569, 212);
            glyphListBox.TabIndex = 0;
            glyphListBox.HorizontalScrollbar = true;
            this.Controls.Add(glyphListBox);
            this.used = used;
            glyphs = new XmlDocument();
            glyphs.Load(@"Data\Glyphs.xml");
            Graphics graphics = glyphListBox.CreateGraphics();
            int itemWidth;
            foreach (XmlNode character in glyphs.ChildNodes[1].ChildNodes)
            {
                if (character.ChildNodes[0].InnerText == name)
                {
                    switch (type)
                    {
                        case "Minor":
                            list = character.ChildNodes[1].ChildNodes[0];
                            break;
                        case "Major":
                            list = character.ChildNodes[1].ChildNodes[1];
                            break;
                    }
                    foreach (XmlNode glyph in list.ChildNodes)
                    {
                        if (!used.Contains(glyph.ChildNodes[1].InnerText))
                        {
                            glyphListBox.Icons.Add(@"Textures\Icons\INV_Glyph_" + type + name.Replace(" ", "") + ".png");
                            glyphListBox.Items.Add(glyph.ChildNodes[1].InnerText);
                            glyphListBox.Descriptions.Add(glyph.ChildNodes[3].InnerText);
                            itemWidth = 190 + (int)graphics.MeasureString(glyph.ChildNodes[3].InnerText, glyphListBox.Font).Width;
                            if (glyphListBox.HorizontalExtent < itemWidth)
                            {
                                glyphListBox.HorizontalExtent = itemWidth;
                            }
                        }
                    }
                }
            }
        }

        public XmlNode Selected
        {
            get { return selected; }
        }

        public int Index
        {
            get { return index; }
        }

        //exit on cancel
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //return selected choice
        private void select_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (XmlNode glyph in list)
            {
                if (glyph.ChildNodes[1].InnerText == glyphListBox.Items[glyphListBox.SelectedIndex].ToString())
                {
                    index = i;
                    selected = glyph;
                }
                i++;
            }
            this.Close();
        }
    }
}
