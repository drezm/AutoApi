using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Contracts.Role;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public PracticeContext Context { get; }
        public RoleController(PracticeContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Вывод всех записей о ролях
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        /// </remarks>
        /// <param name="model">Роли</param>
        /// <returns></returns>
        /// 
        // GET api/<RoleController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Role> roles = Context.Roles.ToList();
            return Ok(roles);
        }
        /// <summary>
        /// Создание новой роли
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Name" : "Введите название новой роли"
        ///         }
        /// </remarks>
        /// <param name="model">Создание новой роли</param>
        /// <returns></returns>
        // GET api/<RoleController>
        [HttpPost]
        public IActionResult Add(CreateRoleDto role)
        {
            Role newRole = new Role()
            {

                Name = role.Name

            };
            Context.Roles.Add(newRole);
            Context.SaveChanges();
            return Ok(role);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id роли
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о ролях</param>
        /// <returns></returns>
        // GET api/<RoleController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Role? roles = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(roles);
        }
        /// <summary>
        /// Обновление существующеЙ роли
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "RoleId" : "Ввести id роли, информацию о котой нужно изменить"
        ///             "Name" : "Название роли, которую меняете "
        ///         }
        /// </remarks>
        /// <param name="model">Обновление существующеЙ роли</param>
        /// <returns></returns>
        // PUT api/RoleController>
        [HttpPut]
        public IActionResult Update(UpdateRoleDto role)
        {
            Role newRole = new Role()
            {

                RoleId = role.RoleId,
                Name = role.Name,

            };
            Context.Roles.Update(newRole);
            Context.SaveChanges();
            return Ok(newRole);
        }
        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id роли пользователя,  которую нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление владельца</param>
        /// <returns></returns>
        // DELETE api/<RoleController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Role? role = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Roles.Remove(role);
            Context.SaveChanges();
            return Ok();
        }
    }
}