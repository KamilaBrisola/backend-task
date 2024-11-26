using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<ModelTask> modelTasks = new List<ModelTask>();

        [HttpGet]
        public ActionResult <List<ModelTask>> BuscarTasks ()
        {
            return Ok (modelTasks);
        }

        [HttpPost]
        public ActionResult<List<ModelTask>>        
            AddTask(ModelTask novo)
        {
            if (novo.id == 0 && modelTasks.Count > 0) 
                novo.id = modelTasks[modelTasks.Count - 1].id + 1;

            if (novo.Description.Length < 11)
                return BadRequest ("Número de caracteres inválido - Min. 10.");            

            modelTasks.Add(novo);
            return Ok (modelTasks);
        }

        [HttpDelete]
        public ActionResult DeleteTask(int id)
        {
            var pesquisa = modelTasks.Find(x => x.id == id);
            
            if (pesquisa == null)
                return NotFound("Task não encontrada.");

            modelTasks.Remove(pesquisa);
            return Ok ("Task excluída");            
            
        }
    }
}
