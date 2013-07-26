using System.Collections;
using System.Collections.Generic;

namespace StreetFinder.AbbreviationsFilter
{
    public class AbbreviationsEngine: IAbbreviationsEngine
    {
        private readonly Hashtable _abbreviations = new Hashtable();

        public AbbreviationsEngine()
        {
            _abbreviations.Add("st", new List<string> {"sankt"});
            _abbreviations.Add("sankt", new List<string> { "st" });
            _abbreviations.Add("dr", new List<string> { "doktor" });
            _abbreviations.Add("doktor", new List<string> { "dr" });
            _abbreviations.Add("prof", new List<string> { "prof" });
            _abbreviations.Add("str", new List<string> { "strasse", "straße" });
        }

        public bool HasAbbreviationsOrIsAbbreviation(string textToSearch, out List<string> result)
        {
            if (_abbreviations.ContainsKey(textToSearch))
            {
                result = (List<string>)_abbreviations[textToSearch];
                return true;
            }

            result = null;
            return false;
        }
    }
}