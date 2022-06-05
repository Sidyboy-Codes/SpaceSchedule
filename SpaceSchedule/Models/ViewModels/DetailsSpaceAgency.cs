using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceSchedule.Models.ViewModels
{
    public class DetailsSpaceAgency
    {
        public SpaceAgency SelectedSpaceAgency { get; set; }

        public IEnumerable<RocketDto> RocketsBySpaceAgency { get; set; }
    }
}