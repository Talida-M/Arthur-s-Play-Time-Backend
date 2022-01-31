//using ProiectASP.Data;
//using ProiectASP.Repositories.SessionTokenRepository;
//using ProiectASP.Repositories.UserRepository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ProiectASP.Repositories
//{
//    public class RepositoryWrapper : IRepositoryWrapper
//    {
//        private readonly Context _context;
//        private IUserRepository _user;
//        private ISessionTokenRepository _sessionToken;
//        public RepositoryWrapper(Context context)
//        {
//            _context = context;
//        }

//        public IUserRepository User
//        {
//            get
//            {
//                if (_user == null) _user = new UserRepository(_context);
//                return _user;
//            }
//        }

//        public ISessionTokenRepository SessionToken
//        {
//            get
//            {
//                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
//                return _sessionToken;
//            }
//        }

//        public async Task SaveAsync()
//        {
//            await _context.SaveChangesAsync();
//        }
//    }
//}
