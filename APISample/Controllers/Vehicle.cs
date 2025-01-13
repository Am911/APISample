using APISample.Interface;
using APISample.Models;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Vehicle : ControllerBase
    {
        private readonly IVehicleType IVT;
        public Vehicle(IVehicleType _IVT)
        {
                this. IVT = _IVT;
        }

        [HttpPost]
        [Route("CreateVehicleType")]
        public IActionResult CreateVehicleType([FromBody] VehicleType VT)
        {
            int? response = IVT.Create(VT);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateVehicleType")]
        public IActionResult UpdateVehicleType([FromBody] VehicleType VT, int id)
        {
           int? Response = IVT.Update(id, VT);
           return Ok(Response);
        }

        [HttpDelete]
        [Route("DeleteVehicleType")]
        public IActionResult DeleteVehicleType([FromBody] int id)
        {
            int? response = IVT.DeleteOne(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllVehicleType")]
        public IActionResult GetAllVehicleType() {
            List<VehicleType>? response = IVT.GetAll();
            return Ok(response);
        }
    }
}
