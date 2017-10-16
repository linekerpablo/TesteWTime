using TesteWTime.Domain.Entities;
using System.Collections.Generic; 
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System;

namespace TesteWTime.Domain.Interfaces.Services
{
    public interface IUsersService : IServiceBase<Users>
   {
        #region Methods

        Users GetByUserId(Int64 userid);

        Users GetByName(String name);

        bool ValidatedRequiredFields();

        #endregion
   }
}


