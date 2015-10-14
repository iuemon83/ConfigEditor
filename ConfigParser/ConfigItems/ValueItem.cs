namespace ConfigParser.ConfigItems
{
    class ValueItem
    {
        public string Name;
        public string Value;

        public ValueItem(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Name + "=" + this.Value;
        }
    }
}
