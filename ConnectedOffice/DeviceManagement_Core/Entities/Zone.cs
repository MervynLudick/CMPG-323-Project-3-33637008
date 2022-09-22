using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DeviceManagement_WebApp.Models
{
    public sealed partial class Zone
    {
        public Zone()
        {
            Device = new HashSet<Device>();
        }
        
        public Guid ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneDescription { get; set; }
        public DateTime DateCreated { get; set; }

        [DisplayName("Device")]
        public ICollection<Device> Device { get; set; }
    }
}
