namespace ConfigParser.ConfigItems
{
    class CommentItem
    {
        public string Comment = "";

        public CommentItem(string comment)
        {
            this.Comment = comment;
        }

        public override string ToString()
        {
            return ";" + this.Comment;
        }
    }
}
