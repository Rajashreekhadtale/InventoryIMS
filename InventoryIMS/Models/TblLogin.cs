using MessagePack;
using System;
using System.Collections.Generic;

namespace InventoryIMS.Models
{
    public partial class TblLogin
    {
     
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
