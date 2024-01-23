using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.Model;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        public PracticeContext Context { get; }
        public ModelController(PracticeContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Вывод всех записей о моделях
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        /// </remarks>
        /// <param name="model">Модели</param>
        /// <returns></returns>
        /// 
        // GET api/<ModelController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Model> model = Context.Models.ToList();
            return Ok(model);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id модели"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о моделях</param>
        /// <returns></returns>
        // GET api/<ModelController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Model? model = Context.Models.Where(x => x.ModelId == id).FirstOrDefault();
            if (model == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(model);
        }
        /// <summary>
        /// Создание новой модели машины
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Model1" : "Введите название модели (Creta)"
        ///             "Brand" : ""Введите название марку машину (Kia)"
        ///         }
        /// </remarks>
        /// <param name="model">Создание новой модели машины</param>
        /// <returns></returns>
        // GET api/<ModelController>
        [HttpPost]
        public IActionResult Add(CreateModalDto modal)
        {
            Model newModal = new Model()
            {
                Brand = modal.Brand,
                Model1 = modal.Model1

            };
            Context.Models.Add(newModal);
            Context.SaveChanges();
            return Ok(modal);
        }
        /// <summary>
        /// Обновление существующей  модели
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "ModelId" : "ID модели, которую нужно изменить"
        ///             "Model1" : "Введите название модели (Creta)"
        ///             "Brand" : ""Введите название марку машину (Kia)"
        ///         }
        /// </remarks>
        /// <param name="model">Обновление существующей  модели</param>
        /// <returns></returns>
        // GET api/<ModelController>
        [HttpPut]
        public IActionResult Update(UpdateModalDto model)
        {
            Model newModel = new Model()
            {
                ModelId = model.ModelId,
                Model1 = model.Model1,
                Brand = model.Brand

            };
            Context.Models.Update(newModel);
            Context.SaveChanges();
            return Ok(newModel);
        }
        /// <summary>
        /// Удаление модели
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id модели, которую нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление модели</param>
        /// <returns></returns>
        // GET api/<ModelController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Model? model = Context.Models.Where(x => x.ModelId == id).FirstOrDefault();
            if (model == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Models.Remove(model);
            Context.SaveChanges();
            return Ok();
        }
    }
}
