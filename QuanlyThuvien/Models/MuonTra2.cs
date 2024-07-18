using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanlyThuvien.Models
{
    public class MuonTra2
    {
        public int MaMuonTra { get; set; }

        [Required]
        public int MaDocGia { get; set; }

        [Required]
        public DateTime NgayMuon { get; set; }

        public DateTime? NgayTra { get; set; }

        public string TinhTrang { get; set; }

        // Navigation properties
        public virtual DocGia DocGia { get; set; }
        public virtual ICollection<ChiTietPhieuMuonTra> ChiTietPhieuMuonTras { get; set; }
    }
}