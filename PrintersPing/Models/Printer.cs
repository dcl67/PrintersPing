using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrintersPing.Models
{
    public class Printer
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
        
        [Display(Name = "Location")]
        public int Location_id { get; set; }
        [ForeignKey("Location_id")]
        public Location Printer_Location { get; set; }
        //public string Printer_Location { get; set; }

        [Display(Name = "Make")]
        public int Make_id { get; set; }
        [ForeignKey("Make_id")]
        public Make Printer_Make { get; set; }
        //public string Printer_Make { get; set; }
        
        //[ForeignKey("Printer_Model")]
        [Display(Name = "Model")]
        public int Model_id { get; set; }
        [ForeignKey("Model_id")]
        public Model Printer_Model { get; set; }

        //public string Printer_Model { get; set; }
        public string Printer_Type { get; set; }
        public string IP { get; set; }
        public string VLAN { get; set; }
        public string Ink_or_Toner { get; set; }
        public string Comment { get; set; }
        
        //[ForeignKey("Printer_Status")]
        [Display(Name = "Status")]
        public int Status_id { get; set; }
        [ForeignKey("Status_id")]
        public Status Printer_Status { get; set; }

        public string Warning { get; set; }
        public string Serial { get; set; }
        public string MAC_Address { get; set; }
    }

    public class Status
    {
        [Key]
        public int Status_id { get; set; }

        [Required]
        public string Printer_Status { get; set; }
    }

    public class Model
    {
        [Key]
        public int Model_id { get; set; }

        [Required]
        public string Printer_Model { get; set; }
    }

    public class Make
    {
        [Key]
        public int Make_id { get; set; }

        [Required]
        public string Printer_Make { get; set; }
    }

    public class Location
    {
        [Key]
        public int Location_id { get; set; }

        [Required]
        public string Printer_Location { get; set; }
    }

    public class ApplicationDBContext : Printer
    {
        //Database.SetInitializer<Models.ApplicationDBContext>(null);
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Make> Make { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}