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
        /// <summary>
        ///  Class: Printer 
        ///  Properties:
        ///     int id : Key
        ///     Location Printer_Location : Fk
        ///     Make Printer_Make : Fk
        ///     Model Printer_Model : Fk
        ///     String Printer_Type
        ///     String IP
        ///     String VLAN
        ///     String Ink_or_Toner
        ///     String Comment
        ///     Status Printer_Status : Fk
        ///     String Warning
        ///     String Serial
        ///     String MAC_Address
        /// </summary>
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
        
        [Display(Name = "Location")]
        public int Location_id { get; set; }
        [ForeignKey("Location_id")]
        public Location Printer_Location { get; set; }

        [Display(Name = "Make")]
        public int Make_id { get; set; }
        [ForeignKey("Make_id")]
        public Make Printer_Make { get; set; }
        
        [Display(Name = "Model")]
        public int Model_id { get; set; }
        [ForeignKey("Model_id")]
        public Model Printer_Model { get; set; }

        public string Printer_Type { get; set; }
        public string IP { get; set; }
        public string VLAN { get; set; }
        public string Ink_or_Toner { get; set; }
        public string Comment { get; set; }
        
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
        /// <summary>
        ///     int Status_id : Key
        ///     String Printer_Status
        /// </summary>
        [Key]
        public int Status_id { get; set; }

        [Required]
        public string Printer_Status { get; set; }
    }

    public class Model
    {
        /// <summary>
        ///     int Model_id : Key
        ///     String Printer_Model
        /// </summary>
        [Key]
        public int Model_id { get; set; }

        [Required]
        public string Printer_Model { get; set; }
    }

    public class Make
    {
        /// <summary>
        ///     int Make_id : Key
        ///     String Printer_Make
        /// </summary>
        [Key]
        public int Make_id { get; set; }

        [Required]
        public string Printer_Make { get; set; }
    }

    public class Location
    {
        /// <summary>
        ///     int Location_id
        ///     String Printer_Location
        /// </summary>
        [Key]
        public int Location_id { get; set; }

        [Required]
        public string Printer_Location { get; set; }
    }

    public class ApplicationDBContext : Printer
    {
        /// <summary>
        ///     Database context defined for all defined models and relationships
        /// </summary>
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Make> Make { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}