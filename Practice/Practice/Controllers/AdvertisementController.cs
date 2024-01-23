using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.AdStatus;
using Practice.Contracts.Advertisement;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        public PracticeContext Context { get; }
        public AdvertisementController(PracticeContext context)
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
        // GET api/<AdvertisementController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Advertisement> advertisements = Context.Advertisements.ToList();
            return Ok(advertisements);
        }

        /// <summary>
        /// Создание нового объявления
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "StatusName" : "Снято с публикации"
        ///             "UserId" : "Например пользователь с id: 1 пользователь которому принадлежит объявление"
        ///             "CarId" : "Id машины, которая в объявлении"
        ///             "AdStatusId" : "id статуса объяввление (Актуально)"
        ///             "Title" : "Название для объявления "Lada Granta""
        ///             "Discription" : "Описания для описания (Новая без царапин, некрашена)"
        ///             "EditBy" : "ID пользователя, который изменил объявление"
        ///             "EditTime" : "Вреия изменения 17:00:00""AdId" : "Id объявления, которое нужно изменения"
        ///             "UserId" : "Например пользователь с id: 1 пользователь которому принадлежит объявление"
        ///             "CarId" : "Id машины, которая в объявлении"
        ///             "AdStatusId" : "id статуса объяввление (Актуально)"
        ///             "Title" : "Название для объявления "Lada Granta""
        ///             "Discription" : "Описания для описания (Новая без царапин, некрашена)"
        ///             "AddedBy" : "ID пользователя, который изменил объявление"
        ///             "AddedTime" : "Время добавления 17:00:00"
        ///         }
        /// </remarks>
        /// <param name="model">Добавление объявления</param>
        /// <returns></returns>
        // GET api/<AdvertisementController>
        [HttpPost]
        public IActionResult Add(CreateAdvertisementDto Advert)
        {
            Advertisement newAdvert = new Advertisement()
            {
                Title = Advert.Title,
                Discription = Advert.Discription,
                UserId = Advert.UserId,
                CarId = Advert.CarId,
                AdStatusId = Advert.AdStatusId,
                AddedBy = Advert.AddedBy,
                AddedTime = Advert.AddedTime
            };
            Context.Advertisements.Add(newAdvert);
            Context.SaveChanges();
            return Ok(newAdvert);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id объявления"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации об объявлении</param>
        /// <returns></returns>
        // GET api/<AdvertisementController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {

            Advertisement? advert = Context.Advertisements.Where(x => x.AdStatusId == id).FirstOrDefault();
            if (advert == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(advert);
        }
        /// /// <summary>
        /// Создание нового объявления
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "AdId" : "Id объявления, которое нужно измененить"
        ///             "UserId" : "Например пользователь с id: 1 пользователь которому принадлежит объявление"
        ///             "CarId" : "Id машины, которая в объявлении"
        ///             "AdStatusId" : "id статуса объяввление (Актуально)"
        ///             "Title" : "Название для объявления "Lada Granta""
        ///             "Discription" : "Описания для описания (Новая без царапин, некрашена)"
        ///             "EditBy" : "ID пользователя, который изменил объявление"
        ///             "EditTime" : "Вреия изменения 17:00:00"
        ///         }
        /// </remarks>
        /// <param name="model">Добавление объявления</param>
        /// <returns></returns>
        // GET api/<AdvertisementController>
        [HttpPut]
        public IActionResult Update(UpdateAdvertisementDto Advert)
        {
            Advertisement newAdvert = new Advertisement()
            {
                AdId = Advert.AdId,
                Title = Advert.Title,
                Discription = Advert.Discription,
                UserId = Advert.UserId,
                CarId = Advert.CarId,
                AdStatusId = Advert.AdStatusId,
                EditBy = Advert.EditBy,
                EditTime = Advert.EditTime
            };
            Context.Advertisements.Update(newAdvert);
            Context.SaveChanges();
            return Ok(newAdvert);
        }
        /// <summary>
        /// Удаление обновления
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id записи объявления, который нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление объявления</param>
        /// <returns></returns>
        // GET api/<AdvertisementController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Advertisement? ad = Context.Advertisements.Where(x => x.AdId == id).FirstOrDefault();
            if (ad == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Advertisements.Remove(ad);
            Context.SaveChanges();
            return Ok();
        }
    }
}
