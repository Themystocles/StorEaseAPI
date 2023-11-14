 public interface IItemRepository
    {
        void Add(ItemModel item);

        List<ItemModel> Get();

        ItemModel Get(int id);

        void Update(ItemModel item);

        void Delete(int id);

        

    }