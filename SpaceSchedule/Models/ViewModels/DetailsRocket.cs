using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceSchedule.Models.ViewModels
{
    public class DetailsRocket
    {
        public RocketDto SelectedRocket { get; set; }
        public IEnumerable<LaunchDto> LaunchesByRocket { get; set; }
    }
}