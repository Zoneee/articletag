using Deepbio.Domain.Entities;
using Entity.Interfaces;

namespace Entity.Entities
{
    /// <summary>
    /// 标记实体表
    /// </summary>
    /// <remarks>Tag 模块</remarks>
    public class TagEntitiy : EntityBase<long>, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
