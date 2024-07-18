using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanlyThuvien.Models
{
    public class TimKiemSach
    {
        public string Keyword { get; set; }
        public List<Sach> Results { get; set; }
    }
}