using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.WebApi.Models
{
    [Table("shopowners")]
    public partial class ShopOwners
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }   
      
        [Column(TypeName = "varchar(45)")] 
        public string UserId { get; set; } = null!;
        
        [Column(TypeName = "varchar(45)")]
        public string? Referedby { get; set; }
        public int? Accesscounts { get; set; }
        
        [Column(TypeName = "json")]
        public string? Settings { get; set; }
        [NotMapped]
        public ICollection<Shop> Shops { get;  } = [];
        // [NotMapped]
        // public ICollection<ShopAttedants> ShopAttedants { get;  } = new List<ShopAttedants>();
        [NotMapped]
        public User User { get; } = null!;
        public decimal Discount { get; set; }
    }
}