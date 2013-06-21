using System;
using System.Collections.Generic;
using ApproximativeSearch;
using StreetFinder;

namespace AproximativeSearchImpl
{
    public class AddressService: IAddressService
    {
        private StreetRepositoryLucene streetRepository;

        public AddressService()
        {
            streetRepository = new StreetRepositoryLucene();    
        }

        public IEnumerable<string> Search(string zip, string street)
        {
            throw new NotImplementedException();
        }

        public void Insert(string zip, ISet<string> streets)
        {
            throw new NotImplementedException();
        }

        public void Insert(string zip, string streetName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
