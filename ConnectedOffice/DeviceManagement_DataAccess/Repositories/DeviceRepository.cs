using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Interfaces;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement_DataAccess.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        private readonly ConnectedOfficeContext _context;
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Device> GetDevicesWithCategoryAndZone()
        {
            return _context.Device.Include(x => x.Category).Include(x => x.Zone);
        }

        public Device GetDeviceWithCategoryAndZoneById(Guid? id)
        {
            return _context.Device.Include(d => d.Category).Include(d => d.Zone).FirstOrDefault(d => d.DeviceId == id);
        }
    }
}