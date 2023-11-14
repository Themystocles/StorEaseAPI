using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace StorEaseAPI.Controllers;
[ApiController]
[Route("api/historico")]
public class HistoricoController : ControllerBase
{
    private readonly IHistoricoRepository _historicorepository;

    public HistoricoController(IHistoricoRepository historicorepository)
    {
        _historicorepository = historicorepository;
    }

    [HttpGet]
    public ActionResult<List<HistoricoModel>> GetHistory()
    {
        var historico = _historicorepository.Get();
        return Ok(historico);
    }
    [HttpPost]
        public ActionResult Post(HistoricoModel historicoModel)
        {
            if (historicoModel == null)
            {
                return BadRequest("Nenhum item foi cadastrado. opção cancelada."); // Retorna 400 Bad Request se o objeto for nulo.
            }

            _historicorepository.Add(historicoModel);
            return CreatedAtAction("Get", new { id = historicoModel.Id }, historicoModel); // Retorna 201 Created.
        }

}