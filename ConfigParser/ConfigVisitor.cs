using ConfigParser.ConfigItems;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConfigParser
{
    class ConfigVisitor
    {
        public void Visit(string filePath)
        {
            var result = new Dictionary<string, Dictionary<string, string>>();
            var currentSelection = "";
            SectionItem currentSection = null;

            File.ReadLines(filePath, ConfigParser.Encoding)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ForEach(line =>
                {
                    var isComment = line.StartsWith(";");
                    var isSection = line.StartsWith("[");

                    if (isComment)
                    {
                        this.VisitComment(new CommentItem(line));
                    }
                    if (isSection)
                    {
                        if (currentSection != null) this.VisitSection(currentSection);

                        var sectionName = line.Trim('[', ']');
                        currentSection = new SectionItem(sectionName);

                        if (!result.ContainsKey(sectionName))
                        {
                            result.Add(sectionName, new Dictionary<string, string>());
                            currentSelection = sectionName;
                        }
                    }
                    else
                    {
                        var items = line.Split('=');
                        result[currentSelection].Add(items[0], items[1]);
                       currentSection.ValueItemList
                    }
                });
        }

        public virtual CommentItem VisitComment(CommentItem comment)
        {
            return comment;
        }

        public virtual SectionItem VisitSection(SectionItem section)
        {
            return section;
        }
    }
}
