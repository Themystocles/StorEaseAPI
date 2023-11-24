public interface IHistoricoDoisRepository{
    List<HistoricoDoisModel> Get();
    HistoricoDoisModel Get(int id);

    void Add(HistoricoDoisModel historicoDois);
    void Update(HistoricoDoisModel historicoDois);

    void Delete(int id);

}