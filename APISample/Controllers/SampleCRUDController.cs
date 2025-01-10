using APISample.Interface;
using APISample.Models;
using APISample.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SampleCRUDController : ControllerBase
    {
        //private readonly DatabaseContext DB;
        //private readonly STrial crud;
        //public SampleCRUDController(DatabaseContext db)
        //{
        //    this.DB = db;
        //    crud = new STrial();
        //}
        //[HttpPost]
        //[Route("Insert")]
        //public IActionResult Insert(TrialClass TC)
        //{
        //    crud.Save(TC, DB);
        //    return Ok(1);
        //}

        private readonly ITrial crud;
        public SampleCRUDController(ITrial _crud)
        {
                crud = _crud;
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(TrialClass TC)
        {
            crud.Save(TC);
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeletebyId")]
        public IActionResult DeleteOne(string id)
        {
            int Id = Convert.ToInt32(id);
            int result = crud.DeleteOne(Id);
            return Ok(result);

        }

        [HttpGet]
        [Route("All")]
        
        public IActionResult getAll()
        {
            return Ok(crud.GetAll());
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Updateone(string id, TrialClass TC)
        {
            int Id = Convert.ToInt32(id);
            int result = crud.Update(Id, TC);
            return Ok(result);
        }
    }
}
