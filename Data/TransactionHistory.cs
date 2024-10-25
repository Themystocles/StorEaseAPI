

public class transactionHistory : ITransactionHistory
{
    private readonly ConnectionContext _context;
    public void Add(TransactionHistory transactionHistory)
    {
        _context.TransactionHistory.Add(transactionHistory);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<TransactionHistory> Get()
    {
        return _context.TransactionHistory.ToList();
    }

    public TransactionHistory Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(TransactionHistory transactionHistory)
    {
        throw new NotImplementedException();
    }
}
