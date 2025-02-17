using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Protocol.Core.Types;
using TpCrApp.Dal;
using TpCrApp.Models;

namespace TpCrApp.Controllers
{
    public class TouristPlaceController : Controller
    {
        private readonly TouristPlaceContext _context;
        public TouristPlaceController(TouristPlaceContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {

            //TouristPlaceContext context = new TouristPlaceContext();
            //List<TouristPlace> tplist = context.touristPlaces.ToList();
            return View(_context.touristPlaces.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TouristPlace tp)
        {
            if(ModelState.IsValid)
            {
                _context.touristPlaces.Add(tp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            TouristPlace? tp = _context.touristPlaces.Find(id);
            if (tp == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(tp);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            TouristPlace? tp = _context.touristPlaces.Find(id);
            if (tp != null)
            {
                return View(tp);    
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Edit(TouristPlace ntp)
        {
            TouristPlace? etp = _context.touristPlaces.Find(ntp.TouristPlaceId);
            if (etp != null)
            {
               if(ModelState.IsValid)
                {
                    etp.TouristPlaceName = ntp.TouristPlaceName;
                    etp.TouristPlaceType = ntp.TouristPlaceType;
                    etp.Location = ntp.Location;
                    _context.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return View(etp);
                }
            }   
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TouristPlace? dtp = _context.touristPlaces.Find(id);
            if (dtp != null)
            {
                return View(dtp);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete()
        {
            int id = int.Parse(Request.Form["TouristPlaceId"].ToString());

            TouristPlace? dtp = _context.touristPlaces.Find(id);
            if (dtp != null)
            {
                _context.touristPlaces.Remove(dtp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
