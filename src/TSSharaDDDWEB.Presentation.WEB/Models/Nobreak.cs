using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSSharaDDDWEB.Presentation.WEB.Models
{
    public class Nobreak
    {
        public Nobreak()
        {
            NobreakEvents = new List<NobreakEvent>();
            Users = new List<ApplicationUser>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Serial { get; set; }
        public string CompanyName { get; set; }
        public string UPSModel { get; set; }
        public string Version { get; set; }
        public string Label { get; set; } 

        [JsonIgnore]
        public virtual ICollection<ApplicationUser> Users { get; set; }

        [JsonIgnore] 
        public virtual ICollection<NobreakEvent> NobreakEvents { get; set; }

        public override string ToString()
        {
            return Serial;
        }

        private class IndexAttribute : Attribute
        {
        }
    }
}