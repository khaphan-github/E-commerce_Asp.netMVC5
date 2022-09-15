using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    // Tỉnh thành phố
    public class Wards
    {
        [Key]
        public int WardsId { get; set; }
        public string WardName { get; set; }
        // Miền
        public string Domain { get; set; }
        // QUan hệ 1 - 1 với Address
        public virtual Address Address { get; set; }

        // Một tỉnh thành phố có nhiều quận huyện Quan hệ 1 nhiều
        public virtual ICollection<District> Districts { get; set; }

        public Address Address { get; set; }
        public ICollection <District> Districts { get; set; }

    }
}
