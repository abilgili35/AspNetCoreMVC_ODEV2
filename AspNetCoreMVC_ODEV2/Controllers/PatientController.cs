using AspNetCoreMVC_ODEV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_ODEV2.Controllers
{
    public class PatientController : Controller
    {
        HospitalAutomationNtierContext _db = new HospitalAutomationNtierContext();

        public IActionResult Index()
        {
            return View(_db.Patients.ToList());
        }

        public IActionResult Detail(int id)
        {
            if(id > 0)
            {
                var patient = _db.Patients.Find(id);

                if(patient != null) 
                {
                    return View(patient);
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
