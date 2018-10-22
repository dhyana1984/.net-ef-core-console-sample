using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Entity
{
  public  class Blog
    {
        private Blog() { }

        public Blog(string url)
        {
            _url = url;
            _status = "Active";
        }
        public string Name { get; set; }
        private string _status = string.Empty;
        public int Id { get; set; }
        private string _url;
        public string URL => _url;
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
    }
}
