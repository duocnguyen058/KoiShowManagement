using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;
using System.Threading.Tasks;

namespace KoiShowManagement.WebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllEvents();
            return View(events);
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            return View(eventItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _eventService.AddEvent(eventItem);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(eventItem);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await _eventService.UpdEvent(eventItem);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(eventItem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            if (eventItem != null)
            {
                bool isDeleted = await _eventService.DelEvent(eventItem);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
