using ConfigParser.ConfigNodes;
using System.Collections.Generic;

namespace ConfigParser
{
    class ProjectSetter : ConfigWalker
    {
        protected override IEnumerable<ValueNode> VisitValue(ValueNode value)
        {
            if (value.Name == "item22")
            {
                value.Value = "編集したよ";
            }

            return new[] { value };
        }
    }
}
