using System;
using System.Collections.Generic;
using System.Text;
using Deepbio.Domain.Entities.ArticleTagAggregateRoot;
using FreeSql;

namespace Entity.Repositories
{
    public class TagUserRepository : BaseRepository<User, long>
    {
        public TagUserRepository(IFreeSql freeSql) : base(freeSql, null)
        {

        }
    }
}
