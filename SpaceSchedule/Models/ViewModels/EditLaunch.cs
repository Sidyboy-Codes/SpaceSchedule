using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceSchedule.Models.ViewModels
{
    public class EditLaunch
    {
        public LaunchDto editLaunch { get; set; }

        public IEnumerable<RocketDto> editRockets { get; set; }
    }
}