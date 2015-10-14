using System.Linq;

namespace ConfigParser.ConfigItems
{
    class SectionItem
    {
        public string SectionName;
        public ValueItem[] ValueItemList;

        public SectionItem(string sectionName)
        {
            this.SectionName = sectionName;
            this.ValueItemList = new ValueItem[0];
        }

        public override string ToString()
        {
            return "[" + this.SectionName + "]"
                + ConfigParser.NewLine
                + string.Join(ConfigParser.NewLine, this.ValueItemList.Select(item => item.ToString()));
        }
    }
}
