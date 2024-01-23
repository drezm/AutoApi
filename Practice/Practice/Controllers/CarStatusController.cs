using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.CarStatus;
using Practice.Contracts.Owner;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarStatusController : ControllerBase
    {
        public PracticeContext Context { get; }
        public CarStatusController(PracticeContext context)
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
        // GET api/<CarStatusController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CarStatus> status = Context.CarStatuses.ToList();
            return Ok(status);


        }
        /// <summary>
        /// Создание нового статуса
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "StatusName" : "Введите название статуса"
        ///         }
        /// </remarks>
        /// <param name="model">Создание нового статуса</param>
        /// <returns></returns>
        // GET api/<CarStatusController>
        [HttpPost]
        public IActionResult Add(CreateCarStatusDto CarStatus)
        {
            CarStatus newStatus = new CarStatus()
            {
                StatusName = CarStatus.StatusName
            };
            Context.CarStatuses.Add(newStatus);
            Context.SaveChanges();
            return Ok(CarStatus);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id статуса машины"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о статусах</param>
        /// <returns></returns>
        // GET api/<CarStatusController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {

            CarStatus? status = Context.CarStatuses.Where(x => x.CarStatusId == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(status);
        }
        /// <summary>
        /// Обновление существующего статуса
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "CarStatusId" : "Id статуса, который нужно изменить"
        ///             "StatusName" : "Название статуса"
        ///         }
        /// </remarks>
        /// <param name="model">Изменение статуса</param>
        /// <returns></returns>
        // GET api/<CarSttatusController>
        [HttpPut]
        public IActionResult Update(UpdateCarStatusDto status)
        {
            CarStatus newStatus = new CarStatus()
            {
                CarStatusId = status.CarStatusId,
                StatusName = status.StatusName
            };
            Context.CarStatuses.Update(newStatus);
            Context.SaveChanges();
            return Ok(newStatus);
        }
        /// <summary>
        /// Удаление статуса
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id записи статуса, который нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление статуса</param>
        /// <returns></returns>
        // GET api/<CarStatusController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            CarStatus? status = Context.CarStatuses.Where(x => x.CarStatusId == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.CarStatuses.Remove(status);
            Context.SaveChanges();
            return Ok();
        }

    }
}
