using System;

namespace APIPCHY_PhanQuyen.Models.QLKC.QLKC_NHAP_CHI_TEM
{
    public class QLKC_NHAP_CHI_TEM_Model
    {
        public int ID_BIENBAN { get; set; } // ID_BIENBAN: NUMBER
        public string DON_VI_TINH { get; set; } // DON_VI_TINH: NVARCHAR2 (20)
        public string LOAI { get; set; } // LOAI: NVARCHAR2 (10)
        public string NGUOI_SUA { get; set; } // NGUOI_SUA: NVARCHAR2 (50)
        public DateTime? NGAY_SUA { get; set; } // NGAY_SUA: DATE
        public string NGUOI_TAO { get; set; } // NGUOI_TAO: NVARCHAR2 (50)
        public DateTime? NGAY_TAO { get; set; } // NGAY_TAO: DATE
        public int SO_LUONG { get; set; } // SO_LUONG: NUMBER
    }
}
