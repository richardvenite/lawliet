using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using lawliet.Domain;
using lawliet.Models;
using Newtonsoft.Json;

namespace lawliet.Controllers
{
    [EnableCors("*", "*", "*")]
    public class NotificationController : ApiController
    {
        [HttpPost]
        [Authorize]
        public IHttpActionResult Create([FromBody] NotificationDTO notification)
        {
            try
            {
                var result = (new Notification()).Save(notification);

                if (result)
                {
                    return Ok("Usuário inserido com sucesso.");
                }

                return BadRequest("Não conseguimos inseir o usuário. Por favor tente novamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Update([FromBody] NotificationDTO notification)
        {
            try
            {
                var result = (new Notification()).Save(notification);

                if (result)
                {
                    return Ok("Usuário atualizado com sucesso.");
                }

                return BadRequest("Não conseguimos atualizar o usuário. Por favor tente novamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete([FromBody] int idNotification)
        {
            try
            {
                var result = (new Notification()).Delete(idNotification);

                if (result)
                {
                    return Ok("Usuário removido com sucesso.");
                }
                
                return BadRequest("Não conseguimos remover o usuário. Por favor tente novamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Find([FromBody] int idNotification)
        {
            try
            {
                var notification = (new Notification()).Find(idNotification);
                if (notification != null)
                {
                    var serializeNotification = JsonConvert.SerializeObject(notification);
                    return Ok(serializeNotification);
                }
                
                return BadRequest("Nenhum usuário foi encontrado com esse ID, por favor, tente novamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult FindAll()
        {
            try
            {
                var notifications = (new Notification()).FindAll();

                if (notifications != null)
                {
                    var serializeNotifications = JsonConvert.SerializeObject(notifications);
                    return Ok(serializeNotifications);
                }
                
                return BadRequest("Nenhum usuário cadastrado!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
