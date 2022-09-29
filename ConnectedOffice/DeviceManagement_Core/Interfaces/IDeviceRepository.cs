using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        /// <summary>
        /// Gets all devices and include Category and Zone related entities
        /// </summary>
        /// <returns>IEnumerable of Devices</returns>
        public IEnumerable<Device> GetDevicesWithCategoryAndZone();
        
        /// <summary>
        /// Gets a Device with related entity Category and related entity Zone
        /// </summary>
        /// <param name="id">The Device Id</param>
        /// <returns>Device</returns>
        public Device GetDeviceWithCategoryAndZoneById(Guid? id);
    }
}