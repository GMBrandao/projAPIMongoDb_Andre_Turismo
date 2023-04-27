using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projAPIMongoDb_Andre_Turismo.Models;
using projAPIMongoDb_Andre_Turismo.Services;

namespace projAPIMongoDb_Andre_Turismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public AddressController(AddressService addressService, CityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);
            if (address == null) return NotFound();
            return address;
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            address.City = (string.IsNullOrEmpty(address.City.Id)) ? _cityService.Create(address.City) : _cityService.Get(address.City.Id);
            return _addressService.Create(address);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Address address)
        {
            var c = _addressService.Get(id);
            if (c == null) return NotFound();

            _addressService.Update(id, address);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            _addressService.Delete(id);
            return Ok();
        }
    }
}
