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
        // GET: api/<ImovelController>
        [HttpGet]
        public List<Imovel> Get()
        {
            return ImovelRepository.GetImoveis();
        }

        // GET api/<ImovelController>/5
        [HttpGet("{id}")]
        public Imovel Get(int id)
        {
            var imovel = ImovelRepository.GetImovelId(id);
            return imovel;
           
        }

        // POST api/<ImovelController>
        [HttpPost]
        public Imovel Post([FromBody] Imovel imovel)
        {
            ImovelRepository.AddImovel(imovel);
            return imovel;
        }

        //PACH
        //add Patch aqui

        // PUT api/<ImovelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ImovelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
