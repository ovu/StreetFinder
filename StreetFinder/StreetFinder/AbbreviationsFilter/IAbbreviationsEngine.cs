using System.Collections.Generic;

namespace StreetFinder.AbbreviationsFilter
{
    public interface IAbbreviationsEngine
    {
        bool HasAbbreviationsOrIsAbbreviation(string textToSearch, out List<string> result);

        bool HasAbbreviationsOrIsAbbreviation(string textToSearch);

        bool IsEqualsOrAbbreviationOf(string abbreviation, string possibleAbbreviation);
    }
}