using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Repository
{
    public class AvartarRepo : IAvatarRepo
    {
        public Task<string> CreateAvartarAsync(Avatar avatar)
        {
            throw new NotImplementedException();
        }
    }
}