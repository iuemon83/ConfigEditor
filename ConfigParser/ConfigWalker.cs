using ConfigParser.ConfigNodes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConfigParser
{
    /// <summary>
    /// 設定内容を解析する
    /// </summary>
    class ConfigWalker
    {
        /// <summary>
        /// 解析済み設定要素の一覧
        /// </summary>
        private List<IConfigNode> configNodeList = new List<IConfigNode>();

        /// <summary>
        /// 設定内容を文字列として取得します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return new ConfigDocument(this.configNodeList.ToArray()).ToString();
        }

        /// <summary>
        /// 指定した設定ファイルの内容を解析します。
        /// </summary>
        /// <param name="filePath"></param>
        public void Visit(string filePath)
        {
            SectionNode currentSection = null;

            File.ReadLines(filePath, ConfigDocument.Encoding)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ForEach(line =>
                {
                    if (CommentNode.IsComment(line))
                    {
                        this.configNodeList.AddRange(this.VisitComment(new CommentNode(line)));
                    }
                    else if (SectionNode.IsSection(line))
                    {
                        if (currentSection != null)
                        {
                            this.configNodeList.AddRange(this.VisitSection(currentSection));
                            currentSection = null;
                        }

                        currentSection = new SectionNode(line);
                    }
                    else
                    {
                        var newValueItemList = this.VisitValue(new ValueNode(line));
                        currentSection.ValueItemList.AddRange(newValueItemList);
                    }
                });

            if (currentSection != null)
            {
                this.configNodeList.AddRange(this.VisitSection(currentSection));
                currentSection = null;
            }
        }

        /// <summary>
        /// コメント要素を解析します。
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        protected virtual IEnumerable<CommentNode> VisitComment(CommentNode comment)
        {
            return new[] { comment };
        }

        /// <summary>
        /// セクション要素を解析します。
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        protected virtual IEnumerable<SectionNode> VisitSection(SectionNode section)
        {
            return new[] { section };
        }

        /// <summary>
        /// 値要素を解析します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual IEnumerable<ValueNode> VisitValue(ValueNode value)
        {
            return new[] { value };
        }
    }
}
