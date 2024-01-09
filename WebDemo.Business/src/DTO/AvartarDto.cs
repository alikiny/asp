using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Business.src.DTO
{
    public class AvartarCreateDto
    {
        public byte[] Data { get; set; }
        public Guid UserId { get; set; }
    }
}