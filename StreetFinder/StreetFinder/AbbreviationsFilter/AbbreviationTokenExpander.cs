using System.Collections.Generic;
using System.Linq;

namespace StreetFinder.AbbreviationsFilter
{
    public class AbbreviationTokenExpander
    {
        private readonly List<string> _tokensList = new List<string>();
        private int _index = -1;
        private string lastToken;
        readonly AbbreviationsEngine _abbreviationsEngine = new AbbreviationsEngine();

        public void Add(string token)
        {
            List<string> abbreviations;
            _tokensList.Add(token);

            if (token.EndsWith("str"))
            {
                if (_abbreviationsEngine.HasAbbreviationsOrIsAbbreviation("str", out abbreviations))
                {
                    foreach (var abbreviation in abbreviations)
                    {
                        _tokensList.Add(abbreviation);
                    }
                }
            }

            if (_abbreviationsEngine.HasAbbreviationsOrIsAbbreviation(token, out abbreviations))
            {
                foreach (var abbreviation in abbreviations)
                {
                    _tokensList.Add(abbreviation);
                }
            }
        }

        public bool NextElement()
        {
            _index++;

            if (_tokensList.Count <= 0 || _index >= _tokensList.Count)
            {
                return false;
            }

            return true;
        }

        public string ElementAt(int position)
        {
            if (_tokensList.Count <= 0 || position >= _tokensList.Count || position < 0)
            {
                return null;
            }

            return _tokensList.ElementAt(position);
        }

        public string CurrentElement()
        {
            if (_tokensList.Count <= 0 || _index >= _tokensList.Count)
            {
                return null;
            }

            return _tokensList.ElementAt(_index);
        }

        public int Count()
        {
            return _tokensList.Count;
        }
    }
}
