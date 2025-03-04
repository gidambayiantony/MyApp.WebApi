using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using MyApp.Domain.Core.Models;
// using MyApp.Domain.Enums;
namespace MyApp.Models;

    //[MaxLength(10), MinLength(5)]

    [Table("users")]
    public partial class User  : AuditableEntity 
    {
        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int Id { get; set; }   

        [Column(TypeName = "varchar(50)")]   
        public string? Name { get; set; } 
        public string? Username { get; set; }     
       
        public string? Email { get; set; }
        public string? Password { get; set; }       
        public  string? Phone { get; set; }
        public string? Profpic { get; set; } 
        public string?  CountryCode  { get; set; } 
        public DateTime Datejoined { get; set; }
        public DateTime? Lastseen { get; set; }
        
        [DefaultValue("false")]
        public bool? Isapp { get; set; }
         [DefaultValue("false")]
        public bool IsPhoneVerified { get; set; }
         [DefaultValue("false")]
        public bool IsEmailVerified { get; set; }     
        // public UserStatus? Status { get; set; }         
        public float? Appv { get; set; }       
        public string? Actuallocation { get; set; }       
        public string? Locationdescr { get; set; }
      
        [DefaultValue("0")]
        public double? Lat { get; set; }
        [DefaultValue("0")]
        public double? Lon { get; set; }        
        public bool? LocEnabled { get; set; }      
        public int RoleId { get; set; } 

        [Column(TypeName = "varchar(20)")]
        public string? Rolename { get; set; } 
        public string Userid { get; set; } = null!;

        // [DefaultValue("false")]
        // public bool IsLocked { get; set; } = false;

        // [NotMapped]
        // public ShopOwners ShopOwners { get; set; } = null!;
        // [NotMapped]
        // public virtual ShopAttedants ShopAttedants { get; set; } = null!;
        
        [NotMapped]
        public virtual UserLogin UserLogin { get; set; } = null!;

        // [NotMapped]
        // public virtual Customers Customers { get; set; } = null!;

        // [NotMapped]
        // public virtual SystemUsers SystemUsers { get; set; } = null!;

        // [NotMapped]
        // public virtual List<ConnectedUsers>? ConnectedUsers { get; set; } 
        
    }

