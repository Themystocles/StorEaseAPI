 public interface IItemRepository
    {
        void Add(ItemModel item);

        List<ItemModel> Get();

        ItemModel Get(int id);

        void Update(ItemModel usuario);

        void Delete(int id);

        

    }