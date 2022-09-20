using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Service {
    interface AddressService {

        void createAddress(Address address);
        void updateAddress(Address address);

        List<Address> GetAddresses();

        Address GetAddressById(int Id);

        

    }
}
