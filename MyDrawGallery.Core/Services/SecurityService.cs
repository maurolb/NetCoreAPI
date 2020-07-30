using MyDrawGallery.Core.Entitites;
using MyDrawGallery.Core.Interfaces;
using System.Threading.Tasks;

namespace MyDrawGallery.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginCredentials(UserLogin userlogin)
        {
            return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userlogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.SecurityRepository.Add(security);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
