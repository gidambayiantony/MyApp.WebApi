
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.WebApi.Models;


namespace MyApp.WebApi.Models
{
    public partial class Shop : AuditableEntity 
    {   
        public int Id { get; set; }
        public string Shopid { get; set; } = null!;
        public string Name { get; set; }  = null!;
        [Column(TypeName = "varchar(45)")]     
        public string? Type { get; set; } 
        [Column(TypeName = "varchar(45)")]  
        public string? Category { get; set; }
        public string? Region { get; set; } 
        // public string? Mapinfo { get; set; }
        [Column(TypeName = "varchar(45)")]  
        public string? CountryCode { get; set; }
        //public string? CountryName { get; set; } = null!;
        //public string? Continent { get; set; } = null!;
        public DateTime Datejoined { get; set; }
        public DateTime Lastseen { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Status { get; set; } = null!;
         [Column(TypeName = "varchar(45)")]           
        // public string? AffiliateId { get; set; }
       // public string? Agentid { get; set; }
        // public bool IsPremium { get; set; }
        // public int IsActive { get; set; }        
        // public bool? Backupstatus { get; set; }
        // [Column(TypeName = "varchar(45)")]
        public string? Backupemail { get; set; } 
        [Column(TypeName = "varchar(45)")]
        public string? Backupsent { get; set; }
        public DateTime? LastManualBackup { get; set; }
        //public string Notifsettings { get; set; } = null!;
        
        //[NotMapped] ShopSettingDTO
         //public ShopSettingDTO? Settings { get; set; }
        
        // [Column(TypeName = "json")]
        // public string? Settings { get; set; }
        //public bool? Cangetemails { get; set; }
        //public string? Exitcode { get; set; }
        // public double? Lat { get; set; }
        // public double? Lon { get; set; }
        public string? Descr { get; set; }
        
        public bool Onlineenabled { get; set; }
        // public bool? Issupplier { get; set; }
        [Column(TypeName = "varchar(45)")]  
        public string? Currency { get; set; }
        //ublic bool Deleted { get; set; }
       // public DateTime Actiontime { get; set; }
       // public string? Lastchanges { get; set; }
        //public string? Logedby { get; set; }
        // public bool? Migrated { get; set; }
        public string? Pdfheader { get; set; }
        public string? Pdffooter { get; set; }
        public string? Logo { get; set; }

        
               
        [Column(TypeName = "varchar(45)")]  
        public string Ownerid { get; set; } = null!; // Required foreign key property
        [NotMapped]
        public ShopOwners ShopOwners { get;  } = null!;
        //[NotMapped]
        //public ShopAttedants? ShopAttedants { get; set; }  // Required reference navigation to principal
        // [NotMapped]
        // public ShopPackages? ShopPackages { get; set; }

       // [NotMapped]
      //  public ShopSettings ShopSettings { get; set; } = null!; 

       // public ICollection<ShopCustomers> ShopCustomers {get;} = new List<ShopCustomers>();

      
    }
}
