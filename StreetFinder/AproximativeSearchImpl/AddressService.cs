using System;
using System.Collections.Generic;
using System.Linq;
using ApproximativeSearch;
using StreetFinder;

namespace AproximativeSearchImpl
{
    public class AddressService: IAddressService
    {
        private readonly StreetRepositoryLucene _streetRepository;
        private bool _repositoryExists = false;

        private readonly object _objectLock = new object();

        public AddressService()
        {
            var repositoryName = Guid.NewGuid().ToString();
            _streetRepository = new StreetRepositoryLucene(repositoryName);
            _repositoryExists = false;
        }

        public IEnumerable<string> Search(string zip, string street)
        {
            lock (_objectLock)
            {
                var searchResults = _streetRepository.SearchForStreets(zip, street);

                return searchResults.Select(searchResult => searchResult.Name);                
            }
        }

        public void Insert(string zip, ISet<string> streetNames)
        {
            if (string.IsNullOrEmpty(zip))
            {
                throw new ArgumentException("The parameter zip cannot be null nor empty");
            }

            if (streetNames == null)
            {
                throw new ArgumentException("The parameter streetNames cannot be null");
            }

            lock (_objectLock)
            {
                if (_repositoryExists == false && !_streetRepository.ExistStreetRepository())
                {
                    _streetRepository.CreateStreetRepository();
                    _repositoryExists = true;
                }

                _streetRepository.InsertStreets(zip, streetNames);                
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

            lock (_objectLock)
            {
                var street = new Street { Name = streetName, Pobox = zip };

                if (_repositoryExists == false && !_streetRepository.ExistStreetRepository())
                {
                    _streetRepository.CreateStreetRepository();
                    _repositoryExists = true;
                }

                _streetRepository.InsertStreet(street);                
            }
        }

        public void Dispose()
        {
            _streetRepository.DeleteStreetRepository();
        }
    }
}
