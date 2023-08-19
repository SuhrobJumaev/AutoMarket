using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;

namespace AutoMarket.Service.Interfaces
{
	public interface ICarService
	{
		Task<BaseResponse<List<Car>>> GetCars();
		Task<BaseResponse<Car>> GetCar(int id);
		Task<BaseResponse<Car>> GetCarByName(string name);
		Task<BaseResponse<bool>> DeleteCar(int id);
		Task<BaseResponse<CarViewModel>> CreateCar(CarViewModel car);
	}
}
