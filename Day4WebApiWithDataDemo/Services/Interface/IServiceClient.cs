namespace Day4WebApiWithDataDemo.Services.Interface
{
    public interface IServiceClient
    {
        IEnumerable<Client> GetClients();
        Client GetClientByID(int id);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        int GetClientCounter();
        IEnumerable<Client> GetAllWithPagnation(int page = 1, int pageSize = 10);
    }
}
