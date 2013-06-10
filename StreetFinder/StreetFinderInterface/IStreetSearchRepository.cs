using System.Collections.Generic;

namespace StreetFinderInterface
{
    public interface IStreetSearchRepository
    {
        void CreateStreetRepository();

        bool ExistStreetRepository();

        void DeleteStreetRepository();

        IEnumerable<Street> SearchForStreets(int zipCode, string streetName);

        void InsertStreet(Street street);

        void InsertStreets(IList<Street> streets);
    }
}
