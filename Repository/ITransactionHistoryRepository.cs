public interface ITransactionHistory
{
    List<TransactionHistory> Get();
    TransactionHistory Get(int id);

    void Add(TransactionHistory historicoDois);
    void Update(TransactionHistory historicoDois);

    void Delete(int id);

}