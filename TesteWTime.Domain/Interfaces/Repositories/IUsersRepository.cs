using TesteWTime.Domain.Entities;
using System; 
using System.Collections.Generic;
using TesteWTime.Domain.Interfaces.Repositories;

namespace TesteWTime.Domain.Interfaces
{
    public interface IUsersRepository : IRepositoryBase<Users>
   {
        #region Methods

        Users GetByUserId(Int64 userid);
        Users GetByName(String name);

        bool ValidatedRequiredFields();

        #endregion
   }
}


