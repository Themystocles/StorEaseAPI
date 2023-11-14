using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace StorEaseAPI.Controllers;

[ApiController]
[Route("api/Itens")]
public class ItemController : ControllerBase
{
   private readonly IItemRepository _ItemRepository;  
   private readonly IHistoricoRepository _historyrepository;
   
   public ItemController(IItemRepository itemRepository, IHistoricoRepository historicoRepository){
    _ItemRepository = itemRepository;
    _historyrepository = historicoRepository;

   }
    // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<ItemModel>> Get()
        {
            var Item = _ItemRepository.Get();
            return Ok(Item);
        }
      [HttpGet("{id}")]
        public ActionResult<ItemModel> Get(int id)
        {
            var Item = _ItemRepository.Get(id);
            if (Item == null)
            {
                return NotFound("Usuário não encontrado"); // Retorna 404 Not Found se o usuário não for encontrado.
            }
            return Ok(Item);
        }

        [HttpPost]
        public ActionResult Post(ItemModel itemModel)
        {
            if (itemModel == null)
            {
                return BadRequest("Nenhum item foi cadastrado. opção cancelada."); // Retorna 400 Bad Request se o objeto for nulo.
            }

            _ItemRepository.Add(itemModel);

            var HistoricoItem = new HistoricoModel{
                Item = itemModel.Nome,
                Operacao = "ADICIONADO",
                DataHoraRegistro = DateTime.Now
                
            };
             _historyrepository.Add(HistoricoItem);

 
            return CreatedAtAction("Get", new { id = itemModel.Id }, itemModel); // Retorna 201 Created.
        }
       [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var item = _ItemRepository.Get(id);

    if (item == null)
    {
        return NotFound(); // Retorna um código 404 Not Found se o item não for encontrado.
    }
       var HistoricoItem = new HistoricoModel{
                Item = item.Nome,
                Operacao = "DELETADO",
                DataHoraRegistro = DateTime.Now
     };
       _historyrepository.Add(HistoricoItem);
    

    _ItemRepository.Delete(id);
    // Adicione a lógica para copiar os dados do item excluído para a tabela de histórico, se necessário.
    
   

    
    return NoContent(); // Retorna um código 204 No Content para indicar que a exclusão foi bem-sucedida.
}
[HttpPut("{id}")]
        public ActionResult Put(int id, ItemModel item)
        {
            if (item == null)
            {
                return BadRequest(); // Retorna 400 Bad Request se o objeto for nulo.
            }

            var existingUsuario = _ItemRepository.Get(id);

            if (existingUsuario == null)
            {
                return NotFound(); // Retorna 404 Not Found se o usuário não for encontrado.
            }

            item.Id = id; // Certifica-se de que o ID do usuário corresponda ao parâmetro de rota.

            _ItemRepository.Update(item);

              var HistoricoItem = new HistoricoModel{
                Item = item.Nome,
                Operacao = "ALTERADO",
                DataHoraRegistro = DateTime.Now
     };
       _historyrepository.Add(HistoricoItem);
            return NoContent(); // Retorna 204 No Content.
            

            
        }
}
        





