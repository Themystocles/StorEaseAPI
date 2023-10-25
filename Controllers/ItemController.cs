using Microsoft.AspNetCore.Mvc;

namespace StorEaseAPI.Controllers;

[ApiController]
[Route("api/Itens")]
public class ItemController : ControllerBase
{
   private readonly IItemRepository _ItemRepository;    
   public ItemController(IItemRepository itemRepository){
    _ItemRepository = itemRepository;

   }
    // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<ItemModel>> Get()
        {
            var Item = _ItemRepository.Get();
            return Ok(Item);
        }



}
