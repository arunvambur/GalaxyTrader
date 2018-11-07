using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader
{
    /// <summary>
    /// In-Memory storage context
    /// </summary>
    public class StorageContext : IContext
    {
        public Dictionary<string, GalacticUnit> variable;
        public Dictionary<string, float> credits;

        public StorageContext()
        {
            variable = new Dictionary<string, GalacticUnit>();
            credits = new Dictionary<string, float>();
        }

        public void AddCredit(string key, float credit)
        {
            if (credits.ContainsKey(key))
                credits[key] = credit;
            else
                credits.Add(key, credit);
        }

        public void AddVariable(string key, GalacticUnit galacticUnit)
        {
            if (variable.ContainsKey(key))
                variable[key] = galacticUnit;
            else
                variable.Add(key, galacticUnit);
        }

        public float GetCredit(string key)
        {
            return credits.ContainsKey(key) ? credits[key] : -1;
        }

        public GalacticUnit GetVariable(string key)
        {
            return variable.ContainsKey(key) ? variable[key] : throw new QueryGalaxyException("The variable is not valid", null, key, null); 
        }

        public bool IsCreditExists(string key)
        {
            return credits.ContainsKey(key);
        }

        public bool IsVariableExists(string key)
        {
            return variable.ContainsKey(key);
        }
    }
}
