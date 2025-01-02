using System;

namespace APIPCHY_PhanQuyen.Models.QLKC.QLKC_C4_CHITIET_QUYETTOANCHI
{
    public class QLKC_C4_CHITIET_QUYETTOANCHI_Model
    {
        public int ID { get; set; } // ID: NUMBER
        public int ID_GIAONHAN_TEMCHI { get; set; } // ID_GIAONHAN_TEMCHI: NUMBER
        public string MA_KHACH_HANG { get; set; } // MA_KHACH_HANG: NVARCHAR2(13)
        public string TEN_KHACH_HANG { get; set; } // TEN_KHACH_HANG: NVARCHAR2(250)
        public int HOP { get; set; } // HOP: NUMBER
        public int COT { get; set; } // COT: NUMBER
        public string TEN_TBA { get; set; } // TEN_TBA: NVARCHAR2(250)
        public int BOOC_CONGQUANG { get; set; } // BOOC_CONGQUANG: NUMBER
        public int CUA_TU { get; set; } // CUA_TU: NUMBER
        public int CHUP_BUZI_TI_TU { get; set; } // CHUP_BUZI_TI_TU: NUMBER
        public string LY_DO { get; set; } // LY_DO: NVARCHAR2(500)
        public DateTime? NGAY_NIEM_PHONG { get; set; } // NGAY_NIEM_PHONG: DATE
    }
}
