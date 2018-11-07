using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader
{
    /// <summary>
    /// Context to search, store or retrive data from
    /// </summary>
    public interface IContext
    {
        void AddVariable(string key, GalacticUnit galacticUnit);
        void AddCredit(string key, float credit);
        GalacticUnit GetVariable(string key);
        float GetCredit(string key);
        bool IsVariableExists(string key);
        bool IsCreditExists(string key);
    }
}
