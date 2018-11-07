using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader.StatementProcessor
{
    class HowManyProcessor : IStatementProcessor
    {
        public float ProcessStatement(IContext _context, string statement)
        {
            string[] split = statement.Split(' ');

            string[] calculationSplit = statement.Split(new string[] { " is " }, StringSplitOptions.None);

            string[] tokens = calculationSplit[1].Split(' ', '?');

            //Remove any null variable
            List<string> validTokens = new List<string>();
            foreach (var v in tokens)
            {
                if (!string.IsNullOrWhiteSpace(v))
                    validTokens.Add(v);
            }

            tokens = validTokens.ToArray();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                sb.Append(_context.GetVariable(tokens[i]).Value);
            }

            int count = new GalacticUnit(sb.ToString()).ToArabic();
            string key = tokens[tokens.Length - 1];

            if (!_context.IsCreditExists(key)) throw new QueryGalaxyException("The credit variable is not valid", statement, key, null);

            float total = _context.GetCredit(key) * count;

            return total;
        }
    }
}
