using System.Collections.Generic;
using System.Linq;
using StreetFinder.AbbreviationsFilter;

namespace StreetFinder.CombineFilter
{
    public class StreetTokenCombiner
    {
        private readonly List<string> _tokensList = new List<string>();
        private int _index = -1 ;
        private string lastToken;
        readonly AbbreviationsEngine _abbreviationsEngine = new AbbreviationsEngine();

        public void Add(string token)
        {
            if (_tokensList.Count == 0)
            {
                _tokensList.Add(token);
                lastToken = token;
                return;               
            }

            if (_abbreviationsEngine.HasAbbreviationsOrIsAbbreviation(_tokensList.Last()))
            {
                _tokensList.Add(token);
                lastToken = token;
                return;
            }

            if (lastToken.Equals(_tokensList.Last()))
            {
                _tokensList.RemoveAt(_tokensList.Count -1);
            }

            _tokensList.Add(lastToken + token);

            _tokensList.Add(token);
            lastToken = token;

        }

        public bool NextElement()
        {
            _index++;

            if (_tokensList.Count <= 0 || _index >= _tokensList.Count )
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
