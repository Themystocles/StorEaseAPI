

public class HistoricoDoisRepository : IHistoricoDoisRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();
    public void Add(HistoricoDoisModel historicoDois)
    {
        _context.HistoricoDois.Add(historicoDois);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<HistoricoDoisModel> Get()
    {
        return _context.HistoricoDois.ToList();
    }

    public HistoricoDoisModel Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(HistoricoDoisModel historicoDois)
    {
        throw new NotImplementedException();
    }
}
