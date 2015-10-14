using ConfigParser.ConfigItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigParser
{
    class ConfigParser
    {
        public static readonly Encoding Encoding = Encoding.UTF8;// Encoding.GetEncoding("SJIS");
        public static readonly string NewLine = Environment.NewLine;

        public static Dictionary<string, Dictionary<string, string>> FromFile(string filePath)
        {
            var result = new Dictionary<string, Dictionary<string, string>>();
            var currentSelection = "";

            File.ReadLines(filePath, ConfigParser.Encoding)
                .Where(line => !(string.IsNullOrWhiteSpace(line) || line.StartsWith(";")))
                .ForEach(line =>
                {
                    var isSection = line.StartsWith("[");
                    if (isSection)
                    {
                        var selectionName = line.Trim('[', ']');
                        if (!result.ContainsKey(selectionName))
                        {
                            result.Add(selectionName, new Dictionary<string, string>());
                            currentSelection = selectionName;
                        }
                    }
                    else
                    {
                        var items = line.Split('=');
                        result[currentSelection].Add(items[0], items[1]);
                    }
                });

            return result;
        }

        public static void Write(string filePath, IEnumerable<IConfigItem> configItemList)
        {
            var lines = configItemList.Select(configItem => configItem.ToString());

            //var lines = source.Select(selection =>
            //    "[" + selection.Key + "]"
            //    + ConfigParser.NewLine
            //    + string.Join(ConfigParser.NewLine, selection.Value.Select(item => item.Key + "=" + item.Value)));

            File.WriteAllLines(filePath, lines);
        }
    }
}
