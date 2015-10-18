using System;
using System.Linq;
using System.Text;

namespace ConfigParser.ConfigNodes
{
    /// <summary>
    /// 設定ファイル
    /// </summary>
    class ConfigDocument
    {
        /// <summary>
        /// 設定ファイルの改行文字
        /// </summary>
        public static readonly string NewLine = Environment.NewLine;

        /// <summary>
        /// 設定ファイルのエンコード
        /// </summary>
        public static readonly Encoding Encoding = Encoding.UTF8;

        /// <summary>
        /// 設定ファイルに記述する要素
        /// </summary>
        private readonly IConfigNode[] configNodeList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configNodeList"></param>
        public ConfigDocument(params IConfigNode[] configNodeList)
        {
            this.configNodeList = configNodeList.ToArray();
        }

        /// <summary>
        /// 設定ファイルの内容を文字列として取得します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(ConfigDocument.NewLine, configNodeList.Select(configNode => configNode.ToString()));
        }
    }
}
