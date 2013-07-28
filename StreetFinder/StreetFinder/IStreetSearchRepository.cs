using System.Collections.Generic;

namespace StreetFinder
{
    public interface IStreetSearchRepository
    {
        void CreateStreetRepository();

        bool ExistStreetRepository();

        void DeleteStreetRepository();

        IEnumerable<Street> SearchForStreets(string zipCode, string streetName);

        void InsertStreet(Street street);

        void InsertStreets(string zipCode, ISet<string> streets);
    }
}
