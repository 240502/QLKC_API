using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace APIPCHY_PhanQuyen.Models.QLKC.QLKC_C4_GIAONHAN_TEMCHI
{
    public class QLKC_C4_GIAONHAN_TEMCHI_Model
    {
       
        public int ID { get; set; }
      
        public int SO_LUONG_GIAO { get; set; }
      
        public int SO_LUONG_TRA { get; set; }

        public int SO_LUONG_THUHOI { get; set; }

        public string LOAI { get; set; }

        public string DONVI_TINH { get; set; }

        public string DON_VI_GIAO { get; set; }

        public string DON_VI_NHAN { get; set; }

        public string NGUOI_NHAN { get; set; }

        public string NGUOI_GIAO { get; set; }

        public DateTime NGAY_GIAO { get; set; }

        public DateTime NGAY_NHAN { get; set; }

        public int LOAI_BBAN { get; set; }

        public string NOI_DUNG { get; set; }

        public int TRANG_THAI { get; set; }
    }
}
