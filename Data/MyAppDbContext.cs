using Microsoft.EntityFrameworkCore;

 
using MyApp.WebApi.Models;
public class AppDbContext : DbContext
{
    public DbSet<Affiliate> Affiliates { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Shop> Shops { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     {
            
    //         if (!optionsBuilder.IsConfigured)
    //         {
    //             var connectionString = "server=127.0.0.1; port=3306; database=stockapp_db; user=root; password=NamasakaOlvine_254cls;Convert Zero Datetime=True";
    //            //optionsBuilder.UseMySql("name=stockapp_dev", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
    //              optionsBuilder.UseMySql(connectionString,
    //              ServerVersion.AutoDetect(connectionString),
    //              options => options.UseMicrosoftJson());
    //         }
    //     }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shop>()
            
            .HasOne(s => s.Customer)
            .WithMany(c => c.Shops)
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Affiliate)
            .WithMany(a => a.Customers)
            .HasForeignKey(c => c.AffId);


            
             modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasOne(e => e.UserLogin)
                .WithOne(e => e.User)
                .HasForeignKey<UserLogin>(e => e.UserId)
                .HasPrincipalKey<User>(x => x.Userid);

                // entity.HasOne(e => e.ShopOwners)
                // .WithOne(e => e.User)
                // .HasForeignKey<ShopOwners>(e => e.UserId)
                // .HasPrincipalKey<User>(x => x.Userid); 

                // entity.HasOne(e => e.ShopAttedants)
                // .WithOne(e => e.User)
                // .HasForeignKey<ShopAttedants>(e => e.UserId)
                // .HasPrincipalKey<User>(x => x.Userid);    

                // entity.HasOne(e => e.SystemUsers)
                // .WithOne(e => e.User)
                // .HasForeignKey<SystemUsers>(e => e.UserId)
                // .HasPrincipalKey<User>(x => x.Userid);             

                // entity.HasOne(e => e.Customers)
                // .WithOne(e => e.User)
                // .HasForeignKey<Customers>(e => e.UserId)
                // .HasPrincipalKey<User>(x => x.Userid);                          
               
                entity.HasIndex(e => e.Datejoined, "dateJoindIndex");

                entity.HasIndex(e => e.Email, "emailIndex");

                entity.HasIndex(e => e.Lastseen, "lastseenIndex");

                entity.HasIndex(e => e.Userid, "userid");

                entity.HasIndex(e => e.Username, "usernameIndex");

                entity.Property(e => e.Id).HasColumnName("id");              

                entity.Property(e => e.Actuallocation)
                    .HasColumnType("text")
                    .HasColumnName("actuallocation");               
             
                entity.Property(e => e.Appv).HasColumnName("appv");               

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(20)
                    .HasColumnName("countrycode");               

                entity.Property(e => e.Datejoined)
                    .HasColumnType("datetime")
                    .HasColumnName("datejoined");

                entity.Property(e => e.Deleted).HasColumnName("deleted");                

                entity.Property(e => e.Email).HasColumnName("email");             

                entity.Property(e => e.Isapp).HasColumnName("isapp");

                entity.Property(e => e.Lastseen)
                    .HasColumnType("datetime")
                    .HasColumnName("lastseen");

                entity.Property(e => e.Lat).HasColumnName("lat");
                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.LocEnabled).HasColumnName("loc_enabled");

                entity.Property(e => e.Locationdescr)
                    .HasColumnType("text")
                    .HasColumnName("locationdescr");          


                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");
                
                entity.Property(e => e.IsPhoneVerified)                   
                    .HasColumnName("isPhoneVerified"); 
                
                entity.Property(e => e.IsEmailVerified)                   
                    .HasColumnName("isEmailVerified"); 

                entity.Property(e => e.Profpic)
                    .HasColumnType("text")
                    .HasColumnName("profpic");             

                entity.Property(e => e.RoleId).HasColumnName("roleid");

                // entity.Property(e => e.Status)                   
                //     .HasColumnName("status");             

                entity.Property(e => e.Userid)
                    .HasMaxLength(250)
                    .HasColumnName("userid");

                entity.Property(e => e.Username)
                    .HasColumnName("username");
            });   
    }

    
}
