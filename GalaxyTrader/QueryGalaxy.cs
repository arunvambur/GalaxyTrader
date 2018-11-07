using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaxyTrader.StatementProcessor;

namespace GalaxyTrader
{
    /// <summary>
    /// Implementation of Galaxy Trader Query
    /// </summary>
    public class QueryGalaxy : IQueryGalaxy
    {
        Dictionary<StatementType, IStatementProcessor> processors;

        public QueryGalaxy()
        {
            processors = new Dictionary<StatementType, IStatementProcessor>();

            processors.Add(StatementType.Assignment, new VariableAssignmentProcessor());
            processors.Add(StatementType.Assignment_Credit, new CreditAssignmentProcessor());
            processors.Add(StatementType.How_Many_Credits, new HowManyProcessor());
            processors.Add(StatementType.How_Much, new HowMuchProcessor());
        }

        public float Query(IContext context, string line)
        {
            NaturalLanguageParser nlp = new NaturalLanguageParser(line);

            if(nlp.StatementType == StatementType.Invalid_Statement)
                throw new QueryGalaxyException("Invalid query", line, null);

            try
            {
                if (processors.ContainsKey(nlp.StatementType))
                {
                    IStatementProcessor statementProcessor = processors[nlp.StatementType];
                    return statementProcessor.ProcessStatement(context, line);
                }
                else
                    throw new QueryGalaxyException("No processor defined", line, null);
            }

            catch (ArithmeticException ae)
            {
                throw new QueryGalaxyException("The unit passed is not a valid Galactic Unit", line, null, ae);
            }
        }
    }
}
