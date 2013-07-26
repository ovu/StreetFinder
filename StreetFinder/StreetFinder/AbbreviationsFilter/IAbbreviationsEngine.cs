using System.Collections.Generic;

namespace StreetFinder.AbbreviationsFilter
{
    public interface IAbbreviationsEngine
    {
        bool HasAbbreviationsOrIsAbbreviation(string textToSearch, out List<string> result);
    }
}