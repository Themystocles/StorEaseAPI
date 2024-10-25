using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StorEaseAPI.Controllers
{
    [ApiController]
    [Route("api/itens")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IHistoricoRepository _historicoRepository;
        private readonly ITransactionHistory _transactionHistory;

        public ItemController(IItemRepository itemRepository, IHistoricoRepository historicoRepository, ITransactionHistory transactionHistory)
        {
            _itemRepository = itemRepository;
            _historicoRepository = historicoRepository;
            _transactionHistory = transactionHistory;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<ItemModel>> GetAllItems()
        {
            var items = _itemRepository.Get();
            return Ok(items);
        }
        [Authorize]
        [HttpGet("historicodois")]
        public ActionResult<IEnumerable<TransactionHistory>> GetTransactionHistory()
        {
            var transactionHistory = _transactionHistory.Get().ToList();
            return Ok(transactionHistory);
        }
        [Authorize]
        [HttpGet("historico")]
        public ActionResult<IEnumerable<HistoricoModel>> GetHistorico()
        {
            var historico = _historicoRepository.Get().ToList();
            return Ok(historico);
        }
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<ItemModel> GetItemById(int id)
        {
            var item = _itemRepository.Get(id);
            if (item == null)
            {
                return NotFound("Item não encontrado.");
            }
            return Ok(item);
        }
        [Authorize]
        [HttpPost("historicoDois")]
        public ActionResult PostTransactionHistory(TransactionHistory transaction)
        {
            if (transaction == null)
            {
                return BadRequest("Nenhum item foi cadastrado. Opção cancelada.");
            }

            _transactionHistory.Add(transaction);
            return CreatedAtAction(nameof(GetItemById), new { id = transaction.Id }, transaction);
        }
        [Authorize]
        [HttpPost]
        public ActionResult PostItem(ItemModel itemModel)
        {
            if (itemModel == null)
            {
                return BadRequest("Nenhum item foi cadastrado. Opção cancelada.");
            }

            _itemRepository.Add(itemModel);

            var historicoItem = new HistoricoModel
            {
                Item = itemModel.Nome,
                Operacao = "ADICIONADO",
                DataHoraRegistro = DateTime.Now
            };
            _historicoRepository.Add(historicoItem);

            return CreatedAtAction(nameof(GetItemById), new { id = itemModel.Id }, itemModel);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _itemRepository.Get(id);
            if (item == null)
            {
                return NotFound("Item não encontrado.");
            }

            var historicoItem = new HistoricoModel
            {
                Item = item.Nome,
                Operacao = "DELETADO",
                DataHoraRegistro = DateTime.Now
            };
            _historicoRepository.Add(historicoItem);

            _itemRepository.Delete(id);
            return NoContent();
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, ItemModel item)
        {
            if (item == null)
            {
                return BadRequest("O item não pode ser nulo.");
            }

            var existingItem = _itemRepository.Get(id);
            if (existingItem == null)
            {
                return NotFound("Item não encontrado.");
            }

            item.Id = id;
            _itemRepository.Update(item);

            var historicoItem = new HistoricoModel
            {
                Item = item.Nome,
                Operacao = "ALTERADO",
                DataHoraRegistro = DateTime.Now
            };
            _historicoRepository.Add(historicoItem);

            return NoContent();
        }
    }
}
