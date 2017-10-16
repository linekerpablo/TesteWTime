using TesteWTime.Domain.Entities;
using System.Collections.Generic; 
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System;
using TesteWTime.Domain.Interfaces;
using TesteWTime.Domain.Interfaces.Services;

namespace TesteWTime.Domain.Services
{
    public class UsersService : ServiceBase<Users>, IUsersService
   {
       private readonly IUsersRepository _usersRepository;

      public UsersService(IUsersRepository usersRepository)
       : base(usersRepository)
      {
          _usersRepository = usersRepository;
      }

        #region Methods

        public Users GetByUserId(Int64 userid)
      {
            return _usersRepository.GetByUserId(userid);
      }

        public Users GetByName(String name)
      {
            return _usersRepository.GetByName(name);
      }

        public bool ValidatedRequiredFields()
      {
            return false;
      }

        #endregion

        #region Custom methods

        #endregion
   }
}


