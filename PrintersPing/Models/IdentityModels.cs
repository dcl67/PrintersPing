using Microsoft.AspNet.Identity.EntityFramework;

namespace PrintersPing.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<PrintersPing.Models.Printer> Printers { get; set; }

        public System.Data.Entity.DbSet<PrintersPing.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<PrintersPing.Models.Make> Makes { get; set; }

        public System.Data.Entity.DbSet<PrintersPing.Models.Model> Models { get; set; }

        public System.Data.Entity.DbSet<PrintersPing.Models.Status> Status { get; set; }
    }
}