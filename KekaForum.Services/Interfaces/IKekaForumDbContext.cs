using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace KekaForum.Services.Interfaces
{
    public interface IKekaForumDbContext
    {
         public DbConnection GetDbConnection();
    }
}
