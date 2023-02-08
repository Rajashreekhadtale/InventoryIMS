using System.ComponentModel.DataAnnotations;

namespace InventoryIMS.Models
{
    public class TblProduct
    {
        [Key]
        public int Product_Id { get; set; }
        public string? Product_Name { get; set; } 
        public decimal Product_Price { get; set; }
        public int? Product_Qty { get; set; }

        public virtual ICollection<TblSale>? TblSales { get; set; }
       
    }
}
