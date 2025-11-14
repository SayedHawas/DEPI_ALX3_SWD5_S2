using Day4WebApiWithDataDemo.UnitOfWorks;

namespace Day4WebApiWithDataDemo.Services.Impelement
{
    public class ServiceClient : IServiceClient
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceClient(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Client> GetClients()
        {
            var result = _unitOfWork.ClientRepository.GetAll();
            return result;
        }
        public Client GetClientByID(int id)
        {
            var result = _unitOfWork.ClientRepository.GetByID(id);
            return result;
        }
        public void AddClient(Client client)
        {
            _unitOfWork.ClientRepository.Add(client);
            _unitOfWork.Complete();
        }
        public void UpdateClient(Client client)
        {
            _unitOfWork.ClientRepository.Update(client);
            _unitOfWork.Complete();
        }
        public void DeleteClient(int id)
        {
            var department = _unitOfWork.ClientRepository.GetByID(id);
            if (department != null)
            {
                _unitOfWork.ClientRepository.Delete(id);
                _unitOfWork.Complete();
            }
        }
        public int GetClientCounter()
        {
            return _unitOfWork.ClientRepository.RowCount();
        }
        public IEnumerable<Client> GetAllWithPagnation(int page = 1, int pageSize = 10)
        {
            var result = _unitOfWork.ClientRepository.GetAllWithPagnation(page, pageSize);
            return result;
        }
    }
}
