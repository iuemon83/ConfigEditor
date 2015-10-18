namespace ConfigParser.ConfigNodes
{
    /// <summary>
    /// 値要素
    /// </summary>
    class ValueNode : IConfigNode
    {
        /// <summary>
        /// 値の名前
        /// </summary>
        public string Name;

        /// <summary>
        /// 値
        /// </summary>
        public string Value;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public ValueNode(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="str"></param>
        public ValueNode(string str)
            : this(str.Split('=')[0], str.Split('=')[1])
        {

        }

        /// <summary>
        /// 値要素を文字列として取得します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name + "=" + this.Value;
        }
    }
}
