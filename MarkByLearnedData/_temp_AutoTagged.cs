using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deepbio.Domain.Entities;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace MarkByLearnedData
{
    public class _temp_AutoTagged :  IAggregateRoot
    {
        [Column(IsPrimary = true)]
        public long articleid { get; set; }
        public string doi { get; set; }
        public string AptamerType { get; set; }
        public string AptamerType_state { get; set; }
        public string AptamerName { get; set; }
        public string AptamerName_state { get; set; }
        public string Target { get; set; }
        public string Target_state { get; set; }
        public string Affinity { get; set; }
        public string Affinity_state { get; set; }
        public string Sequence { get; set; }
        public string Sequence_state { get; set; }
        public string Sample { get; set; }
        public string Sample_state { get; set; }
        public string ScreenMethod { get; set; }
        public string ScreenMethod_state { get; set; }
        public string BindingBuffer { get; set; }
        public string BindingBuffer_state { get; set; }
        public string Application { get; set; }
        public string Application_state { get; set; }
        public string ScreenCondition { get; set; }
        public string ScreenCondition_state { get; set; }
        public string state { get; set; }
    }
}
