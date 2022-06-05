using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaceSchedule.Models
{
    public class Rocket
    {
        // primary key RocketID
        [Key]
        public int RocketID { get; set; }

        // rocket name 
        public string RocketName { get; set; }

        //information of rocket
        public string RocketInfo { get; set; }

        // Space Agency of rocket
        [ForeignKey("SpaceAgency")]
        public int SpaceAgencyID { get; set; }
        public virtual SpaceAgency SpaceAgency { get; set; }

    }

    // foreign keys will not be readbale and will casuse error while retriveing data 
    // so we will create a simplified class ( a data transfer object )

    public class RocketDto
    {
        public int RocketID { get; set; }
        public string RocketName { get; set; }
        public string RocketInfo { get; set; }
        public int SpaceAgencyID { get; set; }
        public string SpaceAgencyName { get; set; }

    }


}