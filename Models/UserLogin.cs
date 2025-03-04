using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models;

    [Table("userlogin")]
    public partial class UserLogin
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }   
        public string? Username { get; set; }           
        public string? Email { get; set; }
        public string? Password { get; set; } 
        public string? NormalizedPassword { get; set; }
       // public int RoleId { get; set; }
        public DateTime LastLogin { get; set; }
        public string UserId { get; set; } = null!;

        public bool IsLocked { get; set; } 

        [NotMapped]
        public User User { get; set; } = null!;
        //public ShopOwners shopOwners = null!;
       


    }
