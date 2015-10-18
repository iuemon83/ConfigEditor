using System.Collections.Generic;
using System.Linq;

namespace ConfigParser.ConfigNodes
{
    /// <summary>
    /// セクション要素
    /// </summary>
    class SectionNode : IConfigNode
    {
        /// <summary>
        /// 指定された文字列がセクション要素であればTrue、そうでなければFalse を取得します。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsSection(string str)
        {
            return str.StartsWith("[");
        }

        /// <summary>
        /// セクション名
        /// </summary>
        public string SectionName;

        /// <summary>
        /// セクション内の要素
        /// </summary>
        public readonly List<ValueNode> ValueItemList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="valueNodeList"></param>
        public SectionNode(string sectionName, params ValueNode[] valueNodeList)
        {
            this.SectionName = sectionName?.Trim('[', ']');
            this.ValueItemList = valueNodeList.ToList();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sectionName"></param>
        public SectionNode(string sectionName)
            : this(sectionName, new ValueNode[0])
        {
        }

        /// <summary>
        /// セクション要素を文字列として取得します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[" + this.SectionName + "]"
                + ConfigDocument.NewLine
                + string.Join(ConfigDocument.NewLine, this.ValueItemList.Select(item => item.ToString()))
                + ConfigDocument.NewLine;
        }
    }
}
