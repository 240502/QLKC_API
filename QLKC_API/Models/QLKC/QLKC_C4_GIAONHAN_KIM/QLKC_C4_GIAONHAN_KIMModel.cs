using Org.BouncyCastle.Asn1.Cms;
using System;

namespace APIPCHY.Models.QUAN_TRI.QLKC_C4_GIAONHAN_KIM
{
    public class QLKC_C4_GIAONHAN_KIM_Model
    {
        public string? ID { get; set; }
        public int? SO_LUONG_GIAO { get; set; }
        public int? SO_LUONG_TRA { get; set; }
        public int? SO_LUONG_THUHOI { get; set; }
        public string? LOAI { get; set; }
        public string? DONVI_TINH { get; set; }
        public string? DON_VI_GIAO { get; set; }
        public string? DON_VI_NHAN { get; set; }
        public string? NGUOI_NHAN { get; set; }
        public string? NGUOI_GIAO { get; set; }
        public DateTime? NGAY_GIAO { get; set; }
        public DateTime? NGAY_NHAN { get; set; }
        public int? TRANG_THAI { get; set; }
        public int? LOAI_BBAN { get; set; }
        public string? NOI_DUNG { get; set; }
        public string? ID_KIM { get; set; }

        public DateTime? NGAY_TRA { get; set; }
        public string? MADONVIQLY { get; set; }
    }
}