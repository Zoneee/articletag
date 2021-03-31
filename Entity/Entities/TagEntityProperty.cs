using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deepbio.Domain.Entities;
using Entity.Interfaces;

namespace Entity.Entities
{
    public class TagEntityProperty : EntityBase<long>, IAggregateRoot
    {
        public long EntityID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
