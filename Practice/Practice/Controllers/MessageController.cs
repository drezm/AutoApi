using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.Message;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public PracticeContext Context { get; }
        public MessageController(PracticeContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Вывод всех сообщениях
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        /// </remarks>
        /// <param name="model">Сообщения</param>
        /// <returns></returns>
        /// 
        // GET api/<MessageController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Message> messages = Context.Messages.ToList();
            return Ok(messages);
        }
        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "UserId" : "ID польщоывтеля, кому пренадлежит сообщение"
        ///             "AddedBy" : "ID пользователя кем добавлено сообщение"
        ///             "AddedTime" : "Время добавления сообщения (23:51:00)"
        ///             "Contents" : "Содержимое сообщения (Привет, как дела?)"
        ///             "ChatId" : "ID чата, к которому принадлежит сообщение"
        ///         }
        /// </remarks>
        /// <param name="model">Создание нового сообщения</param>
        /// <returns></returns>
        // GET api/<MessageController>
        [HttpPost]
        public IActionResult Add(CreateMessageDto message)
        {
            Message newMessage = new Message()
            {

                ChatId = message.ChatId,
                Contents = message.Contents,
                AddedBy = message.AddedBy,
                AddedTime = message.AddedTime,
                UserId = message.UserId

            };
            Context.Messages.Add(newMessage);
            Context.SaveChanges();
            return Ok(message);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id сообщения"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о сообщении</param>
        /// <returns></returns>
        // GET api/<MessageController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Message? messages = Context.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            if (messages == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(messages);
        }
        /// <summary>
        /// Изменение существующего сообщения
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "MessageId" :  "Id сообщения, которое нужно изменить"
        ///             "UserId" : "ID польщоывтеля, кому пренадлежит сообщение"
        ///             "AddedBy" : "ID пользователя кем добавлено сообщение"
        ///             "AddedTime" : "Время добавления сообщения (23:51:00)"
        ///             "Contents" : "Содержимое сообщения (Привет, как дела?)"
        ///             "ChatId" : "ID чата, к которому принадлежит сообщение"
        ///         }
        /// </remarks>
        /// <param name="model">Изменение существующего сообщения</param>
        /// <returns></returns>
        // GET api/<MessageController>
        [HttpPut]
        public IActionResult Update(UpgradeMessageDto message)
        {
            Message newMessage = new Message()
            {
                MessageId = message.MessageId,
                ChatId = message.ChatId,
                Contents = message.Contents,
                EditTime = message.EditTime,
                UserId = message.UserId,
                EditBy = message.EditBy


            };
            Context.Messages.Update(newMessage);
            Context.SaveChanges();
            return Ok(newMessage);
        }
        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id сообщения, которое нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление сообщения</param>
        /// <returns></returns>
        // GET api/<CarController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Message? message = Context.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            if (message == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Messages.Remove(message);
            Context.SaveChanges();
            return Ok();
        }
    }
}
