using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader.StatementProcessor
{
    class HowMuchProcessor : IStatementProcessor
    {
        public float ProcessStatement(IContext _context, string statement)
        {
            string[] calculationSplit = statement.Split(new string[] { " is " }, StringSplitOptions.None);

            string[] tokens = calculationSplit[1].Split(' ', '?');

            StringBuilder sb = new StringBuilder();

            foreach (var t in tokens)
            {
                if (string.IsNullOrWhiteSpace(t)) continue;
                sb.Append(_context.GetVariable(t).Value);
            }

            GalacticUnit galacticUnit = new GalacticUnit(sb.ToString());

            return galacticUnit.ToArabic();
        }
    }
}
