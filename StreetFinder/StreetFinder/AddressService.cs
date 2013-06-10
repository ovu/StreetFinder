using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApproximativeSearch;

namespace StreetFinder
{
    public class AddressService: IAddressService
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Search(string zip, string street)
        {
            throw new NotImplementedException();
        }

        public void Insert(string zip, ISet<string> streets)
        {
            throw new NotImplementedException();
        }

        public void Insert(string zip, string street)
        {
            throw new NotImplementedException();
        }
    }
}
