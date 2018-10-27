using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Entity
{
    public class Blog : BaseEntity, ISoftDleteBaseEntity
    {
        private Blog() { }

        public Blog(string url)
        {
            _url = url;
            _status = "Active";
        }
        public string Name { get; set; }
        private string _status = string.Empty;
        private string _url;
        public string URL => _url;
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public IEnumerable<Post> Posts {get;set;}
        public bool IsDeleted { get ; set ; }
    }
}
