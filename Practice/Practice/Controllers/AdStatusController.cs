using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.AdStatus;
using Practice.Contracts.Owner;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdStatusController : ControllerBase
    {

        public PracticeContext Context { get; }
        public AdStatusController(PracticeContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Вывод всех записей об объявлениях
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "StatusName" : "Снято с публикации"
        ///         }
        /// </remarks>
        /// <param name="model">Статус объявления</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<AdStatus> status = Context.AdStatuses.ToList();
            return Ok(status);
        }


        // GET api/<AdStatusConroller>

        /// <summary>
        /// Добавление новой записи о статусе объявления
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "StatusName" : "Снято с публикации"
        ///         }
        /// </remarks>
        /// <param name="model">Статус объявления</param>
        /// <returns></returns>
        /// 
         // POST api/<AdStatusConroller>
        [HttpPost]
        public IActionResult Add(CreateAdStatusDto AdStatus)
        {
            AdStatus newStatus = new AdStatus()
            {
                StatusName = AdStatus.StatusName
            };
            Context.AdStatuses.Add(newStatus);
            Context.SaveChanges();
            return Ok(AdStatus);
        }
        /// <summary>
        /// Поиск записи по id о статусе объявления
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "Ввести id для вывода информации"
        ///         }
        /// </remarks>
        /// <param name="model">Статус объявления</param>
        /// <returns></returns>
        /// 

        // GET api/<AdStatusConroller>

        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {

            AdStatus? status = Context.AdStatuses.Where(x => x.AdStatusId == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(status);
        }
        /// <summary>
        /// Обновление записи о статусе объявления
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "StatusName" : "Снято с публикации"
        ///         }
        /// </remarks>
        /// <param name="model">Статус объявления</param>
        /// <returns></returns>
        /// 
         // PUT api/<AdStatusConroller>
        [HttpPut]
        public IActionResult Update(UpdateAdStatusDto AdStatus)
        {
            AdStatus newStatus = new AdStatus()
            {
                AdStatusId = AdStatus.AdStatusId,
                StatusName = AdStatus.StatusName
            };
            Context.AdStatuses.Update(newStatus);
            Context.SaveChanges();
            return Ok(newStatus);
        }
        /// <summary>
        /// Удаление записи о статусе объявления
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             Ввести id записи о статусе, которые нужно удалить
        ///         }
        /// </remarks>
        /// <param name="model">Статус объявления</param>
        /// <returns></returns>
        /// 
         // DELETE api/<AdStatusConroller>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            AdStatus? status = Context.AdStatuses.Where(x => x.AdStatusId == id).FirstOrDefault();
            if (status == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.AdStatuses.Remove(status);
            Context.SaveChanges();
            return Ok();
        }
    }
}

