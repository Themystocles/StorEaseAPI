public interface IHistoricoRepository{
    List<HistoricoModel> Get();

       void Add(HistoricoModel historico);
        void Update(HistoricoModel historico);

        void Delete(int id);

}