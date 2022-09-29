using Core;
using Core.Interfaces;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_DataAccess.Repositories
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }
    }
}