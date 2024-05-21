using DZ150524.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace DZ150524.Controllers
{
    public class HomeController : Controller
    {
        CarContext db;
        public HomeController(CarContext context)
        {
            db = context;
            // добавим начальные данные для тестирования
            if (!db.Cars.Any())
            {
                Car c1 = new Car
                {
                    marka = "vaz",
                    model = "granta",
                    bodytype = "sedan",
                    enginetype = "benzin",
                    engineDisplacement = 2,
                    transmissionType = "jac",
                    averageConsumption = 7
                };

                Car c2 = new Car
                {
                    marka = "bmw",
                    model = "m5",
                    bodytype = "sedan",
                    enginetype = "benzin",
                    engineDisplacement = 6.3,
                    transmissionType = "akpp",
                    averageConsumption = 11
                };

                db.Cars.AddRange(c1, c2);
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index()
        {
            var c = db.Cars.ToList();
            IndexViewModel indexView = new IndexViewModel(c);
            return View(indexView);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            db.Cars.Add(car);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Car car = new Car { Id = id.Value };
                db.Entry(car).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> EditAsync(int? id)
        {
            Car? c = await db.Cars.FirstOrDefaultAsync(p => p.Id == id);
            if (c != null)
            {
                return View(c);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            if (car != null)
            {
                Car? c = await db.Cars.FirstOrDefaultAsync(p => p.Id == car.Id);
                if (c != null)
                {
                    c.model = car.model;
                    c.marka = car.marka;
                    c.engineDisplacement = car.engineDisplacement;
                    c.bodytype = car.bodytype;
                    c.averageConsumption = car.averageConsumption;
                    c.enginetype = car.enginetype;
                    c.transmissionType = car.transmissionType;


                    db.Cars.Update(c);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}

