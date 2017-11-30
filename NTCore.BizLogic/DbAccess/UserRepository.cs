using NTCore.DataAccess.DAL;
using NTCore.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using NTCore.DataAccess;

namespace NTCore.BizLogic.DbAccess
{
    public class UserRepository : DbRepository<ActionRecordInfo>
    {
        public UserRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
