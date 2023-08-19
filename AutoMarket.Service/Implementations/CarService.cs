using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Enum;
using AutoMarket.Domain.Interfaces;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Service.Implementations
{
	public class CarService : ICarService
	{
		private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

		public async Task<BaseResponse<List<Car>>> GetCars()
		{
			var response = new BaseResponse<List<Car>>();
			try
			{
				var cars = await _carRepository.GetAll();
				if(cars.Count <= 0)
				{
					response.Description = "Найдено 0 элементов";
					response.StatusCode = StatusCode.NotFound;
					return response;
				}

				response.Data = cars;
				response.StatusCode = StatusCode.OK;

			}
			catch (Exception ex)
			{
				response.Description = $"[CarService.GetCars] : {ex.Message}";
				response.StatusCode = StatusCode.InternalServerError;
			}
			return response;
		}
		public async Task<BaseResponse<Car>> GetCar(int id)
		{
			var response = new BaseResponse<Car>();
			try
			{
				var car = await _carRepository.Get(id);

				if(car == null)
				{
					response.Description = "Car not found";
					response.StatusCode = StatusCode.InternalServerError;
					return response;
				}

				response.Data = car;
				response.StatusCode = StatusCode.OK;
			}
			catch (Exception ex)
			{
				response.Description = $"[CarService.GetCar] : {ex.Message}";
				response.StatusCode = StatusCode.InternalServerError;
			}
			return response;
		}
		public async Task<BaseResponse<Car>> GetCarByName(string name)
		{
			var response = new BaseResponse<Car>();
			try
			{
				var car = await _carRepository.GetByName(name);

				if (car == null)
				{
					response.Description = "Car not found";
					response.StatusCode = StatusCode.InternalServerError;
					return response;
				}

				response.Data = car;
				response.StatusCode = StatusCode.OK;
			}
			catch (Exception ex)
			{
				response.Description = $"[CarService.GetCarByName] : {ex.Message}";
				response.StatusCode = StatusCode.InternalServerError;
			}
			return response;
		}
		public async Task<BaseResponse<bool>> DeleteCar(int id)
		{
			var response = new BaseResponse<bool>();
			try
			{
				var car = await _carRepository.Get(id);
				if (car == null)
				{
					response.Description = "Car not found";
					response.StatusCode = StatusCode.NotFound;
				}

				var result = await _carRepository.Delete(car);
				if(result == false)
				{
					response.Description = "Car wasn't deleted";
					response.StatusCode = StatusCode.InternalServerError;
				}

				response.Description = "Car was deleted";
				response.StatusCode = StatusCode.OK;
			}
			catch(Exception ex)
			{
				response.Description = $"[CarService.DeleteCar] : {ex.Message}";
				response.StatusCode = StatusCode.InternalServerError;
			}
			return response;
		}

		public async Task<BaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel)
		{
			var response = new BaseResponse<CarViewModel>();
			try
			{
				var car = new Car()
				{
					Description = carViewModel.Description,
					DateCreate = carViewModel.DateCreate,
					Speed = carViewModel.Speed,
					Model = carViewModel.Model,
					Price = carViewModel.Price,
					Name = carViewModel.Name,
					TypeCar = (TypeCar)int.Parse(carViewModel.TypeCar),
				};

				var result = await _carRepository.Create(car);
				if (result == false)
				{
					response.Description = "Car wasn't created";
					response.StatusCode = StatusCode.InternalServerError;
					return response;
				}

				response.Description = "Car was created";
				response.StatusCode = StatusCode.OK;
			}
			catch(Exception ex) 
			{
				response.Description = $"[CarService.CreateCar] : {ex.Message}";
				response.StatusCode = StatusCode.InternalServerError;
			}
			return response;
		}
	}
}
