using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryIMS.Models
{
    public partial class TblSale
    {
        
        public int ReceiptId { get; set; }
        public decimal? Price { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? CustomerName { get; set; }
        public string? City { get; set; }
        public decimal? Total { get; set; }
      

        public virtual List<TblProduct> ProductNavigation { get; set; } = null!;
    }
}
