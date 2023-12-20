using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        int CommitChanges();
    }
}
