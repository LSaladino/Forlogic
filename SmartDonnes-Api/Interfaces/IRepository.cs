namespace SmartDonnes_Api.Models
{
    public interface IRepository
    {
        void CreateData<T>(T entity) where T : class;
        void UpdateData<T>(T entity) where T : class;
        void DeleteData<T>(T entity) where T : class;
        Task<bool> SaveDataAsynch();

        // Cliente
        Task<Cliente[]> GetAllClientAsynch(bool IncludeAvaliacao);
        Task<Cliente[]> GetAllClientTwoFieldsAsynch(bool IncludeAvaliacao);
        Task<Cliente> GetClientAsynckById(int ClienteId, bool IncludeAvaliacao);
        Task<Cliente> GetClientAsyncByCnpj(string cnpjNumber);

        // Avaliacao
        Task<Avaliacao[]> GetAllAvalAsynch(bool IncludeCliente);
        Task<Avaliacao> GetAvalAsynchById(int AvaliacaoId, bool IncludeCliente);
    }
}