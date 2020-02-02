using Microsoft.EntityFrameworkCore;  
namespace MyAPI.Models {
  public class CISClassContext : DbContext {
      public CISClassContext(DbContextOptions<CISClassContext> options) : base(options){ 

      }

      public DbSet<CISClassModel> CISClassItems {get; set;}
  }
}