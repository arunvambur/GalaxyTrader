using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader
{
    /// <summary>
    /// Query the galaxy trader
    /// </summary>
    public interface IQueryGalaxy
    {
        float Query(IContext context, string line);
    }
}
