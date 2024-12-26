using System;

namespace API_PCHY.Models.QLKC.BBAN_BANGIAO_KIM
{
    public class BBAN_BANGIAO_KIMModel
    {
        public int? id_bienban { get; set; }
        public string? id_kim { get;set; }
        public int? so_luong { get;set; }
        public string? don_vi_giao { get;set; }
        public string? don_vi_nhan { get;set; }
        public string? nguoi_giao { get;set; }
        public string? nguoi_nhan { get;set; }
        
        public DateTime? ngay_giao{ get; set; }
        public DateTime? ngay_nhan { get; set; }
        public int? loai_bban { get; set; }
        public string? noi_dung { get; set; }
        public int? trang_thai { get; set; }
        public string? ten_pb { get; set; }
        public string? ten_dv { get; set; }
    }

}
