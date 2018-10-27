using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Entity
{
    public class Post:BaseEntity, ISoftDleteBaseEntity
    {
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual string BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public bool IsDeleted { get; set ; }
    }
}
