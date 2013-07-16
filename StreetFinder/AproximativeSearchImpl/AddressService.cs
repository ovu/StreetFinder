using System;
using System.Collections.Generic;
using System.Linq;
using ApproximativeSearch;
using StreetFinder;

namespace AproximativeSearchImpl
{
    public class AddressService: IAddressService
    {
        private readonly StreetRepositoryLucene streetRepository;
        private bool _repositoryExists = false;

        public AddressService()
        {
            streetRepository = new StreetRepositoryLucene();    
        }

        public IEnumerable<string> Search(string zip, string street)
        {
            var searchResults = streetRepository.SearchForStreets(zip, street);

            return searchResults.Select(searchResult => searchResult.Name);
        }

        public void Insert(string zip, ISet<string> streetNames)
        {
            foreach (var streetName in streetNames)
            {
                Insert(zip, streetName);
            }
        }

        public void Insert(string zip, string streetName)
        {
            if (string.IsNullOrEmpty(zip))
            {
                throw new ArgumentException("The parameter zip cannot be null nor empty");
            }

            if (string.IsNullOrEmpty(streetName))
            {
                throw new ArgumentException("The parameter streetname cannot be null nor empty");
            }

            var street = new Street {Name = streetName, Pobox = zip};

            if (_repositoryExists == false && !streetRepository.ExistStreetRepository())
            {
                streetRepository.CreateStreetRepository();
                _repositoryExists = true;
            }

            streetRepository.InsertStreet(street);
        }

        public void Dispose()
        {
        }
    }
}
