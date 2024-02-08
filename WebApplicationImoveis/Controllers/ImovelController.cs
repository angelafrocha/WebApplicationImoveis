using Microsoft.AspNetCore.Mvc;
using WebApplicationImoveis.Models;
using WebApplicationImoveis.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationImoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ImovelController : ControllerBase
    {
  
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ImovelRepository.GetImoveis());
        }

        // GET api/<ImovelController>/5
        [HttpGet("{id}")]
        public ActionResult<Imovel> Get(int id)
        {
            var imovel = ImovelRepository.GetImovelId(id);
            return Ok(imovel);
           
        }

        // POST api/<ImovelController>
        [HttpPost]
        public ActionResult<Imovel> Post([FromBody] Imovel imovel)
        {
            ImovelRepository.AddImovel(imovel);
            return Ok(imovel);
        }

        //PACH
        //add Patch aqui

        // PUT api/<ImovelController>/5
        [HttpPut("{id}")]
        public ActionResult<Imovel> Put(int id, [FromBody] Imovel updatedImovel)
        {
            var imovel = ImovelRepository.GetImovelId(id);
            if (imovel == null)
        {
                return NotFound();
            }

            imovel.Tipo = updatedImovel.Tipo;
            imovel.Status = updatedImovel.Status;

            return Ok(imovel);
        }

        // DELETE api/<ImovelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(ImovelRepository.DeleteImovel(id));
        }
    }
}
