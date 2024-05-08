using AspNetCoreMVC_ODEV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_ODEV2.Controllers
{
    public class DoctorController : Controller
    {
        HospitalAutomationNtierContext _db = new HospitalAutomationNtierContext();

        public IActionResult Index()
        {
            return View(_db.Doctors.ToList());
        }

        public IActionResult Detail(int id)
        {
            if(id > 0)
            {
                var doctor = _db.Doctors.Find(id);

                if(doctor != null)
                {
                    return View(doctor);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

    }
}
