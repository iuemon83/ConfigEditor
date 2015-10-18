namespace ConfigParser.ConfigNodes
{
    /// <summary>
    /// コメント要素
    /// </summary>
    class CommentNode : IConfigNode
    {
        /// <summary>
        /// 指定された文字列がコメント要素であればTrue、そうでなければFalse を取得します。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsComment(string str)
        {
            return str.StartsWith(";");
        }

        /// <summary>
        /// コメント内容
        /// </summary>
        public string Comment = "";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="comment"></param>
        public CommentNode(string comment)
        {
            this.Comment = IsComment(comment)
                ? comment.Substring(1)
                : comment;
        }

        /// <summary>
        /// コメント要素を文字列として取得します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ";" + this.Comment;
        }
    }
}
