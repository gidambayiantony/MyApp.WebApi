using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyApp.Models;

public class AuditableEntity 
{
    [Column(TypeName = "varchar(45)")] 
    public string? CreatedBy { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("createdOn",TypeName = "datetime")] 
    public DateTime CreatedOn { get; set; }
    
    [Column("lastModifiedBy",TypeName = "varchar(45)")]
   
    public string? LastModifiedBy { get; set; } //Guid

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column("lastModifiedOn",TypeName = "datetime")]    
    public DateTime? LastModifiedOn { get; set; } //DateTimeOffset
    
    [DefaultValue("false")]
    public bool Deleted { get; set; } = false;
}

/*
 entity.Property(e => e.CreatedBy)
    .HasMaxLength(45)
    .HasColumnName("createdby");

    entity.Property(e => e.CreatedOn)
    .HasColumnType("datetime")
    .HasDefaultValueSql("CURRENT_TIMESTAMP")
    .HasColumnName("createdOn");

    entity.Property(e => e.LastModifiedOn)
    .HasColumnType("datetime")
    .HasDefaultValueSql("CURRENT_TIMESTAMP")
    .HasColumnName("lastmodifiedon");
*/