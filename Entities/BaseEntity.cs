using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreBaseRepo.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
