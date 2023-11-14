
public class itemRepository : IItemRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();

    public void Add(ItemModel item)
    {
        _context.Item.Add(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        ItemModel itemparaexcluir = _context.Item.FirstOrDefault(u => u.Id == id);
        if (itemparaexcluir != null)
            {
                // O Item foi encontrado, então podemos excluí-lo
                _context.Item.Remove(itemparaexcluir);
                _context.SaveChanges();
            }
    }



    public List<ItemModel> Get()
    {
        return _context.Item.ToList();
    }

    public ItemModel Get(int id)
    {
       return _context.Item.FirstOrDefault(u => u.Id == id);
    }

    public void Update(ItemModel item)
    {
        var existingUsuarios = _context.Item.Find(item.Id);

            if (existingUsuarios != null)
            {
               
                existingUsuarios.Nome = item.Nome;
                existingUsuarios.Quantidade = item.Quantidade;
                existingUsuarios.Preco = item.Preco;
                

                _context.SaveChanges();
            }
           
    }
}
