using TesteWTime.Domain.Entities;
using System.Collections.Generic; 
using TesteWTime.Domain.Interfaces;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System;

namespace TesteWTime.Infra.Repositories
{
    public class UsersRepository : RepositoryBase<Users>, IUsersRepository
   {
        #region Methods

        public Users GetByUserId(Int64 userid)
      {
            return Db.Userss.Where(p => p.UserId.Equals(userid)).FirstOrDefault();
      }

        public Users GetByName(String name)
      {
            return Db.Userss.Where(p => p.Name.Equals(name)).FirstOrDefault();
      }

        public bool ValidatedRequiredFields()
      {
            return false;
      }

        #endregion
   }
}


