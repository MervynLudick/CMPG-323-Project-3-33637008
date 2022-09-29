using System;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using DeviceManagement_DataAccess;
using DeviceManagement_DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly ICategoriesRepository _categoryRepository;
        public DevicesController(IDeviceRepository deviceRepository, IZoneRepository zoneRepository, ICategoriesRepository categoryRepository)
        {
            _deviceRepository = deviceRepository;
            _zoneRepository = zoneRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: Devices
        public IActionResult Index()
        {
            var devices = _deviceRepository.GetDevicesWithCategoryAndZone();
            return View(devices);
        }

        // GET: Devices/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetDeviceWithCategoryAndZoneById(id);
            
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            
            device.DeviceId = Guid.NewGuid();
            _deviceRepository.Add(device);
            _deviceRepository.SaveAll();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Devices/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName", device.CategoryId);
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName", device.ZoneId);
            
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                _deviceRepository.Update(device);
                _deviceRepository.SaveAll();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetDeviceWithCategoryAndZoneById(id);

            // var device = await _context.Device
            //     .Include(d => d.Category)
            //     .Include(d => d.Zone)
            //     .FirstOrDefaultAsync(m => m.DeviceId == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var device = _deviceRepository.GetById(id);
            _deviceRepository.Remove(device);
            _deviceRepository.SaveAll();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            return _deviceRepository.DoesExist(id);
        }
    }
}
