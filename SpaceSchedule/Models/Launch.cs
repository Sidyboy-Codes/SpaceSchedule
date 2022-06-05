using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaceSchedule.Models
{
    public class Launch
    {
        // primary key for each launch
        [Key]
        public int LaunchId { get; set; }

        // mission name
        public string LaunchName { get; set; }

        // mission/launch info 
        public string LaunchInfo { get; set; }

        [ForeignKey("Rocket")]
        public int RocketID { get; set; }
        public virtual Rocket Rocket { get; set; }

        public DateTime LaunchDate { get; set; }
    }

    public class LaunchDto
    {
        public int LaunchId { get; set; }
        public string LaunchName { get; set; }
        public string LaunchInfo { get; set; }
        public int RocketID { get; set; }
        public string RocketName { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}