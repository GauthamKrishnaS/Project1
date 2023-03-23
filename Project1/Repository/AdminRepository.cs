using Project1.Models;

namespace Project1.Repository {
    public class AdminRepository : IAdminRepository {
        private SMSDBContext _context;
        public AdminRepository(SMSDBContext context)
        {
            _context = context;
        }

        public bool Login(Admin admin)
        {
            return true;
            throw new NotImplementedException();
        }
    }
}
