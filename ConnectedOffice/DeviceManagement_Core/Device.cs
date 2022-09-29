﻿using System;
using System.ComponentModel;
using DeviceManagement_WebApp.Models;

// Code scaffolded by EF DeviceManagement_Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core
{
    public partial class Device
    {
        [DisplayName("Device ID")]
        public Guid DeviceId { get; set; }
        [DisplayName("Device Name")]
        public string DeviceName { get; set; }
        [DisplayName("Category ID")]
        public Guid CategoryId { get; set; }
        [DisplayName("Zone ID")]
        public Guid ZoneId { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Category")]
        public virtual Category Category { get; set; }
        [DisplayName("Zone")]
        public virtual Zone Zone { get; set; }
    }
}
