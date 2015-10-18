using ConfigParser.ConfigNodes;
using System;

namespace ConfigParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var walker = new ProjectSetter();
            walker.Visit("Sample.txt");
            Console.WriteLine(walker);


            var config = new ConfigDocument(
                new CommentNode("ここはコメント"),
                new CommentNode("ここもコメント"),
                new SectionNode("section",
                    new ValueNode("item", "value")),
                new SectionNode("セクション",
                    new ValueNode("item1", "value1"),
                    new ValueNode("item2", "value2")
                    ),
                new CommentNode("こめんと"),
                new SectionNode("せくしょん１２３",
                    new ValueNode("item11", "value11"),
                    new ValueNode("item22", "value22"),
                    new ValueNode("item33", "value33")
                    ));

            Console.WriteLine(config);
        }
    }
}
