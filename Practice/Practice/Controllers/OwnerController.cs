using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Contracts.Owner;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public PracticeContext Context { get; }
        public OwnerController(PracticeContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Вывод всех записей о владельцах
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        /// </remarks>
        /// <param name="model">Владельцы</param>
        /// <returns></returns>
        /// 
        // GET api/<OwnerController>
        [HttpGet]
        public IActionResult GetAll(GetOwnerDto owner)
        {
            List<Owner> owners = Context.Owners.ToList();
            return Ok(owners);
        }
        /// <summary>
        /// Создание нового владельца
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "TenurePeriodFrom" : "Начало владения транспортом 31.09.2020"
        ///             "TenurePeriodTo" : "Окончание владения транспортом 31.12.2022"
        ///             "CarId" : "ID машины, которая пренадлежит владельцу "
        ///         }
        /// </remarks>
        /// <param name="model">Создание нового владельца</param>
        /// <returns></returns>
        // GET api/<OwnerController>
        [HttpPost]
        public IActionResult Add(CreateOwnerDto owner)
        {
            Owner newOwner = new Owner()
            {

                UserId = 0,
                CarId = owner.CarId,
                TenurePeriodFrom = owner.TenurePeriodFrom,
                TenurePeriodTo = owner.TenurePeriodTo
            };
            Context.Owners.Add(newOwner);
            Context.SaveChanges();
            return Ok(owner);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id владельца"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о владельце</param>
        /// <returns></returns>
        // GET api/<OwnerController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {

            Owner? owners = Context.Owners.Where(x => x.OwnnerId == id).FirstOrDefault();
            if (owners == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(owners);
        }
        /// <summary>
        /// Обновление существующего владеельца
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "OwnnerId" : "Ввести id владельца, информацию о которых нужно изменить"
        ///             "TenurePeriodFrom" : "Начало владения транспортом 31.09.2020"
        ///             "TenurePeriodTo" : "Окончание владения транспортом 31.12.2022"
        ///             "CarId" : "ID машины, которая пренадлежит владельцу "
        ///         }
        /// </remarks>
        /// <param name="model">Обновление существующего владеельца</param>
        /// <returns></returns>
        // GET api/<OwnerController>
        [HttpPut]
        public IActionResult Update(UpdateOwnerDto owner)
        {
            Owner newOwner = new Owner()
            {

                OwnnerId = owner.OwnnerId,
                UserId = 0,
                TenurePeriodFrom = owner.TenurePeriodFrom,
                TenurePeriodTo = owner.TenurePeriodTo,
                CarId = owner.CarId


            };
            Context.Owners.Update(newOwner);
            Context.SaveChanges();
            return Ok(newOwner);
        }
        /// <summary>
        /// Удаление владельца
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id владельца машины, которого нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление владельца</param>
        /// <returns></returns>
        // GET api/<OwnerController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Owner? owner = Context.Owners.Where(x => x.OwnnerId == id).FirstOrDefault();
            if (owner == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Owners.Remove(owner);
            Context.SaveChanges();
            return Ok();
        }
    }
}
