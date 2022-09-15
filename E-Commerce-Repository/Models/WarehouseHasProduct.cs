
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    
    public class WarehouseHasProduct
    {

        [Key]
        public int Id { get; set; }
        public int numberofproduct { get; set; }
        
        public virtual WareHouse Warehouse { get; set; }
        public virtual Product Product { get; set; }
    }
}
