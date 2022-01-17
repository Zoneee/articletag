using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deepbio.Domain.Entities;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace Entity.Entities
{
    public class BatchProcessHst : EntityBase<long>, IAggregateRoot
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public long ID { get; set; }
        public long TheID { get; set; }
        public string Catalog { get; set; }
        public DateTime _timestamp { get; set; }
        public int Modified { get; set; }
    }
}
