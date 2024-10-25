

using Microsoft.VisualBasic;

public class HistoricoRepository : IHistoricoRepository
{

    private readonly ConnectionContext _context;

    public HistoricoRepository(ConnectionContext context)
    {
        _context = context;
    }



    public void Add(HistoricoModel historico)
    {
        _context.Historicos.Add(historico);
        _context.SaveChanges();

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<HistoricoModel> Get()
    {
        return _context.Historicos.ToList();
    }

    public void Update(HistoricoModel historico)
    {
        throw new NotImplementedException();
    }
}
