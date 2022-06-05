using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceSchedule.Models
{
    public class SpaceAgency
    {
        // primary key SpaceAgencyID
        [Key]
        public int SpaceAgencyID { get; set; }

        // name of space agency
        public string SpaceAgencyName { get; set; }

        // few info of Space agency
        public string SpaceAgencyInfo { get; set; }

    }
}