using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceSchedule.Models.ViewModels
{
    public class EditRocket
    {
        public RocketDto editRocket { get; set; }

        public IEnumerable<SpaceAgency> editspaceAgencies { get; set; }
    }
}