using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Core.src.Entity
{
    public class OwnerContainer : BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}