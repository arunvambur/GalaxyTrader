using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader.StatementProcessor
{
    class VariableAssignmentProcessor : IStatementProcessor
    {
        public float ProcessStatement(IContext _context, string statement)
        {
            string[] split = statement.Split(' ');

            GalacticUnit gu = new GalacticUnit(split[2]);
            _context.AddVariable(split[0], gu);

            return gu.ToArabic();

        }
    }
}
