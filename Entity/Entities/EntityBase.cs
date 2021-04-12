using System;
using IdGen;

namespace Deepbio.Domain.Entities
{
    public abstract class EntityBase<T> where T : struct
    {
        private static Lazy<IdGenerator> _idGenerator = new Lazy<IdGenerator>(() => new IdGenerator(0));

        public T ID { get; set; }

        protected long NewId()
        {
            return _idGenerator.Value.CreateId();
        }
    }
}
