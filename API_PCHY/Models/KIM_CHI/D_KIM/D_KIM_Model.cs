using System;

namespace APIPCHY_PhanQuyen.Models.QLKC.D_KIM
{
    public class D_KIM_Model
    {
        public int? id_kim { get; set; }
        public int? loai_ma_kim { get; set; }
        public DateTime? thoi_han { get; set; }
        public int? trang_thai { get; set; }
        public string? ma_hieu { get; set; }
        public string? nguoi_tao { get; set; }
        public string? ma_dviqly { get; set; }
        public DateTime? ngay_tao { get; set; }
        public string? nguoi_sua { get; set; }
        public DateTime? ngay_sua { get; set; }
    }
}
