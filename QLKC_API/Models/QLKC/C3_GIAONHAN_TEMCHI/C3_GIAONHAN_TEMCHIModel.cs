using System;

namespace QLKC_API.Models.QLKC.C3_GIAONHAN_TEMCHI
{
    public class C3_GIAONHAN_TEMCHI_Model
    {
        public int? id { get; set; }
        public int? soluong { get; set; }
        public string? loai { get; set; }
        public string? donvi_tinh { get; set; }
        public string? don_vi_giao { get; set; }
        public string? don_vi_nhan { get; set; }
        public string? nguoi_nhan { get; set; }
        public string? nguoi_giao { get; set; }
        public DateTime? ngay_giao { get; set; }
        public DateTime? ngay_nhan { get; set; }
        public int? trang_thai { get; set; }
        public int? loai_bban { get; set; }
        public string? ten_pb { get; set; }
        public string? ten_dv { get; set; }
    }
}