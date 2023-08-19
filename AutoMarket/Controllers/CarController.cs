using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetCars();

            if (response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);
            if(response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
            {
				return RedirectToAction("Error");
			}

            return View(response.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);

            if(response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
            {
                return RedirectToAction("Error");
            }

            return RedirectToAction("GetCars");
        }

		[Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if(id == 0)
            {
                return View();
            }

            var response = await _carService.GetCar(id);

            if(response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
            {
                return RedirectToAction("Error");
            }

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model); 
            }

            var response = await _carService.UpdateCar(model);
			if (response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
            {
                return RedirectToAction("Error");
            }

			return RedirectToAction("GetCars");
		}
		
        [Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
			var response = await _carService.CreateCar(model);
			if (response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
			{
				return RedirectToAction("Error");
			}

			return RedirectToAction("GetCars");
		}
	}
}
