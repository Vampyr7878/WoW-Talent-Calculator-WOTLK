namespace WoW_Talent_Calculator_WOTLK
{
    //class to store inscribed glyphs
    class Glyph
    {
        //glyphs name
        private string name;
        //glyphs type
        private string type;
        //glyphs description
        private string description;
        //glyphs index
        private int index;

        //prepare empty glpyh slot
        public Glyph(string type)
        {
            name = "Empty";
            this.type = type;
            description = "Click here to choose a Glyph to inscribe to your spellbook";
            index = -1;
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        public int Index
        {
            set { index = value; }
            get { return index; }
        }

        //prepare tooltip text
        public string ToolTip()
        {
            string temp = type + "\n" + description + "\n";
            if (name != "Empty")
            {
                temp += "Right Click to remove\n";
            }
            return temp;
        }
    }
}
