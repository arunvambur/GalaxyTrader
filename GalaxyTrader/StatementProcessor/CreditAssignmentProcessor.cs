using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader.StatementProcessor
{
    class CreditAssignmentProcessor : IStatementProcessor
    {
        public float ProcessStatement(IContext _context, string statement)
        {
            string[] split = statement.Split(' ');

            string[] creditsSplit = statement.Split(new string[] { " is " }, StringSplitOptions.None);

            string[] galacticUnits = creditsSplit[0].Trim().Split(' ');

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < galacticUnits.Length - 1; i++)
            {
                sb.Append(_context.GetVariable(galacticUnits[i]).Value);
            }

            int count = new GalacticUnit(sb.ToString()).ToArabic();
            string key = galacticUnits[galacticUnits.Length - 1];

            //Check if the key is already in variables list
            if (_context.IsVariableExists(key)) throw new QueryGalaxyException("The variable name cannot be used", statement, key, null);

            string[] creditUnits = creditsSplit[1].Trim().Split(' ');

            int totalCredits = int.Parse(creditUnits[0]);

            float oneCredit = ((float)totalCredits / (float)count);

            _context.AddCredit(key, oneCredit);

            return oneCredit;
        }
    }
}
