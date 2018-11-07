using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader.StatementProcessor
{
    /// <summary>
    /// Abstract statement processor
    /// </summary>
    public interface IStatementProcessor
    {
        /// <summary>
        /// Process statements passed as an input
        /// </summary>
        /// <param name="_context">Context where data being sotred or retrieved</param>
        /// <param name="statement">Statement passed as an input</param>
        /// <returns>Processed value based on the input query</returns>
        float ProcessStatement(IContext _context, string statement);
    }
}
