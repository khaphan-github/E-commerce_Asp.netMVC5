using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Service {
    interface AddressService {
        
        // QUẢN LÝ ĐỊA CHỈ
        void createAddress(Address address);
        void updateAddress(Address address);

        List<Address> GetAddresses();

        Address GetAddressById(int Id);

        // QUẢN LÝ TỈNH THÀNH
        void createProvince(Province province);

        void updateProvince(Province province);

        void deteteProvince(int Id);

        List<Province> GetProvinces();

        Province GetProvince(int Id);

        // QUẢN LÝ QUẬN HUYỆN
        District GetDistrict(int Id);
        List<District> GetDistricts();
        void createDistrict(District district);

        void updateDistrict(District district);
        void deteteDistrict(int Id);

        // QUẢN LÝ PHƯỜNG XÃ
        Wards GetWard(int Id);
        List<Wards> GetWards();
        void createWards(Wards wards);

        void updateWards(Wards wards);
        void deteteWards(int Id);

    }
}
