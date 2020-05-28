using Apprenticeship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface IFriendlyUser
    {
        User GetUser(string id);
    }
}
