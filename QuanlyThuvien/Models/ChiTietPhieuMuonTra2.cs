    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanlyThuvien.Models
{
    public class ChiTietPhieuMuonTra2
    {
        [Key]
        public int MaChiTiet { get; set; }

        [Required]
        public int MaMuonTra { get; set; }

        [Required]
        public int MaSach { get; set; }

        [Required]
        public DateTime NgayMuon { get; set; }

        public DateTime? NgayTra { get; set; }

        public string TinhTrang { get; set; }

        public string GhiChu { get; set; }

        // Navigation properties
        public virtual MuonTra MuonTra { get; set; }
        public virtual Sach Sach { get; set; }
    }
}