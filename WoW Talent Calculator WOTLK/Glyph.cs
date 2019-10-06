namespace WoW_Talent_Calculator_WOTLK
{
    //class to store inscribed glyphs
    class Glyph
    {
        //glyphs type
        private string type;

        //glyphs name
        public string Name { set; get; }

        //glyphs description
        public string Description { set; get; }

        //glyphs index
        public int Index { set; get; }

        //prepare empty glpyh slot
        public Glyph(string type)
        {
            Name = "Empty";
            this.type = type;
            Description = "Click here to choose a Glyph to inscribe to your spellbook";
            Index = -1;
        }

        //prepare tooltip text
        public string ToolTip()
        {
            string temp = type + "\n" + Description + "\n";
            if (Name != "Empty")
            {
                temp += "Right Click to remove\n";
            }
            return temp;
        }
    }
}
