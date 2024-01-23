using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.Car;
using Practice.Models;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public PracticeContext Context { get; }
        public CarController(PracticeContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Вывод всех записей о объявлениях
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        /// </remarks>
        /// <param name="model">Объявление</param>
        /// <returns></returns>
        /// 
        // GET api/<CarController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Car> cars = Context.Cars.ToList();
            return Ok(cars);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id машины"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о машине</param>
        /// <returns></returns>
        // GET api/<CarController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Car? car = Context.Cars.Where(x => x.CarId == id).FirstOrDefault();
            if (car == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(car);
        }
        /// <summary>
        /// Создание новой машины
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "ModelId" : "ID модели автомобиля"
        ///             "CarStatusId" : "ID статуса автомобиля (новое)"
        ///             "UserId" : "Например пользователь с id: 1 пользователь которому принадлежит машина"
        ///             "ManufacturingYear" : "Год выпуска автомобиля (2020)"
        ///             "Mileage" : "Пробег автомобился (45000)"
        ///             "Price" : "Цена автомобиля (1200000)"
        ///             "Image" : "URL для  картинки"
        ///             "Description" : "Описание машины (новая, мультимедия CarPlay)"
        ///             "Color" : "Код цвета #fffff"
        ///         }
        /// </remarks>
        /// <param name="model">Создание новой машины</param>
        /// <returns></returns>
        // GET api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateCarDto cars)
        {
            var Car = cars.Adapt<Car>();
            Context.Cars.Add(Car);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Обновление существующей машины
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "CarId" : "Id машины, которую нужно изменить"
        ///             "ModelId" : "ID модели автомобиля"
        ///             "CarStatusId" : "ID статуса автомобиля (новое)"
        ///             "UserId" : "Например пользователь с id: 1 пользователь которому принадлежит машина"
        ///             "ManufacturingYear" : "Год выпуска автомобиля (2020)"
        ///             "Mileage" : "Пробег автомобился (45000)"
        ///             "Price" : "Цена автомобиля (1200000)"
        ///             "Image" : "URL для  картинки"
        ///             "Description" : "Описание машины (новая, мультимедия CarPlay)"
        ///             "Color" : "Код цвета #fffff"
        ///         }
        /// </remarks>
        /// <param name="model">Добавление объявления</param>
        /// <returns></returns>
        // GET api/<AdvertisementController>
        [HttpPut]
        public IActionResult Update(UpdateCarDto car)
        {
            Car newCar = new Car()
            {
                CarId = car.CarId,
                ModelId = car.ModelId,
                CarStatusId = car.CarStatusId,
                UserId = car.UserId,
                ManufacturingYear = car.ManufacturingYear,
                Mileage = car.Mileage,
                Price = car.Price,
                Image = car.Image,
                Description = car.Description,
                Color = car.Color,
            };
            Context.Cars.Update(newCar);
            Context.SaveChanges();
            return Ok(newCar);

        }
        /// <summary>
        /// Удаление машины
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id записи машины, которую нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление машины</param>
        /// <returns></returns>
        // GET api/<CarController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Car? car = Context.Cars.Where(x => x.CarId == id).FirstOrDefault();
            if (car == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Cars.Remove(car);
            Context.SaveChanges();
            return Ok();
        }

    }
}
