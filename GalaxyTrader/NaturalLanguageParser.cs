using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader
{
    public enum StatementType
    {
        Invalid_Statement,
        Assignment,
        Assignment_Credit,
        How_Many_Credits,
        How_Much
    }

    /// <summary>
    /// Natural language parser that parses the statement and evaluates the statement type
    /// </summary>
    public class NaturalLanguageParser
    {
        string statement;

        public StatementType StatementType { get; set; }

        public NaturalLanguageParser(string _statement)
        {
            statement = _statement;
            ProcessStatement();
        }

        private void ProcessStatement()
        {
            string[] split = statement.Split(' ');

            //Is the query valid 
            bool isValidQuery = false;
            if (split.Contains("is") || split.Contains("IS") || split.Contains("Is") || split.Contains("iS"))
                isValidQuery = true;

            if (!isValidQuery)
            {
                StatementType = StatementType.Invalid_Statement;
                return;
            }

            if (split.Length == 3)
            {
                if (split[1].ToLower() == "is")
                {
                    StatementType = StatementType.Assignment;
                    return;
                }
                else
                {
                    StatementType = StatementType.Invalid_Statement;
                    return;
                }
            }

            if(split[split.Length - 1].ToLower() == "credits")
            {
                StatementType = StatementType.Assignment_Credit;
                return;
            }

            if(split[0].ToLower() == "how")
            {
                if(split[1].ToLower() == "much")
                {
                    StatementType = StatementType.How_Much;
                    return;
                }
                else if(split[1].ToLower() == "many")
                {
                    StatementType = StatementType.How_Many_Credits;
                    return;
                }
                else
                {
                    StatementType = StatementType.Invalid_Statement;
                    return;
                }
            }
            else
            {
                StatementType = StatementType.Invalid_Statement;
                return;
            }

        }
    }
}
