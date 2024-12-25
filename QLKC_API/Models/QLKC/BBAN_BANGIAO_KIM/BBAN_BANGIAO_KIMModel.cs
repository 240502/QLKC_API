using System;

namespace API_PCHY.Models.QLKC.BBAN_BANGIAO_KIM
{
    public class BBAN_BANGIAO_KIMModel
    {
        public int? ID_BIENBAN { get; set; }
        public string ID_KIM { get; set; }
        public int? SO_LUONG { get; set; }
        public string DON_VI_GIAO { get; set; }
        public string DON_VI_NHAN { get; set; }
        public string NGUOI_GIAO { get; set; }
        public string NGUOI_NHAN { get; set; }
        public DateTime? NGAY_GIAO { get; set; }
        public DateTime? NGAY_NHAN { get; set; }
        public int? LOAI_BBAN { get; set; }
        public string NOI_DUNG { get; set; }
        public int? TRANG_THAI { get; set; }
        public string TEN_PB { get; set; }
        public string TEN_DV { get; set; }
    }

}
