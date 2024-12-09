using APIPCHY.Helpers;
using System.Collections.Generic;
using System;
using API_PCHY.Models.QLKC;
using System.Data;

namespace API_PCHY.Models.QUAN_TRI.QLKC_C4_GIAONHAN_KIM
{
    public class QLKC_C4_GIAONHAN_KIM_Manager
    {
        DataHelper helper = new DataHelper();

        public string update_CD_QLKC_C4_GIAONHAN_KIM(QLKC_C4_GIAONHAN_KIM_Model qLKC_C4_GIAONHAN_KIM)
        {
            try
            {
                string str_id = qLKC_C4_GIAONHAN_KIM.ID.ToString();
                string result = helper.ExcuteNonQuery("PKG_QLKC_THUAN.update_CD_QLKC_C4_GIAONHAN_KIM", "p_Error", "p_ID",
                                                        "p_SO_LUONG_GIAO", "p_SO_LUONG_TRA", "p_SO_LUONG_THUHOI", "p_DON_VI_GIAO", "p_DON_VI_NHAN", "p_NGUOI_NHAN", "p_NGUOI_GIAO", "p_NGAY_GIAO", "p_NGAY_NHAN", "p_NOIDUNG",
                                                       str_id, qLKC_C4_GIAONHAN_KIM.SO_LUONG_GIAO, qLKC_C4_GIAONHAN_KIM.SO_LUONG_TRA, qLKC_C4_GIAONHAN_KIM.SO_LUONG_THUHOI, qLKC_C4_GIAONHAN_KIM.DON_VI_GIAO, qLKC_C4_GIAONHAN_KIM.DON_VI_NHAN, qLKC_C4_GIAONHAN_KIM.NGUOI_NHAN, qLKC_C4_GIAONHAN_KIM.NGUOI_GIAO, qLKC_C4_GIAONHAN_KIM.NGAY_GIAO, qLKC_C4_GIAONHAN_KIM.NGAY_NHAN, qLKC_C4_GIAONHAN_KIM.NOI_DUNG
                                                      );
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string create_PM_QLKC_C4_GIAONHAN_KIM(QLKC_C4_GIAONHAN_KIM_Model qLKC_C4_GIAONHAN_KIM)
        {
            try
            {
                Guid id = Guid.NewGuid();
                string str_id = id.ToString();
                string result = helper.ExcuteNonQuery("PKG_QLKC_THUAN.create_PM_QLKC_C4_GIAONHAN_KIM", "p_Error",
                                                        "p_SO_LUONG_GIAO", "p_SO_LUONG_TRA", "p_SO_LUONG_THUHOI", "p_LOAI", "p_DONVI_TINH", "p_DON_VI_GIAO", "p_DON_VI_NHAN", "p_NGUOI_NHAN", "p_NGUOI_GIAO", "p_NGAY_GIAO", "p_NGAY_NHAN", "p_TRANG_THAI", "p_LOAI_BBAN", "p_NOIDUNG",
                                                       qLKC_C4_GIAONHAN_KIM.SO_LUONG_GIAO, qLKC_C4_GIAONHAN_KIM.SO_LUONG_TRA, qLKC_C4_GIAONHAN_KIM.SO_LUONG_THUHOI, qLKC_C4_GIAONHAN_KIM.LOAI, qLKC_C4_GIAONHAN_KIM.DONVI_TINH, qLKC_C4_GIAONHAN_KIM.DON_VI_GIAO, qLKC_C4_GIAONHAN_KIM.DON_VI_NHAN, qLKC_C4_GIAONHAN_KIM.NGUOI_NHAN, qLKC_C4_GIAONHAN_KIM.NGUOI_GIAO, qLKC_C4_GIAONHAN_KIM.NGAY_GIAO, qLKC_C4_GIAONHAN_KIM.NGAY_NHAN, qLKC_C4_GIAONHAN_KIM.TRANG_THAI, qLKC_C4_GIAONHAN_KIM.LOAI_BBAN, qLKC_C4_GIAONHAN_KIM.NOI_DUNG
                                                      );
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string delete_QLKC_C4_GIAONHAN_KIM(string ID)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_THUAN.delete_QLKC_C4_GIAONHAN_KIM", "p_Error",
"p_ID", ID
                                                    );
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public QLKC_C4_GIAONHAN_KIM_Model get_PQT_QLKC_C4_GIAONHAN_KIM(string ID)
        {
            try
            {
                DataTable db = helper.ExcuteReader("PKG_QLKC_THUAN.get_PQT_QLKC_C4_GIAONHAN_KIM", "p_ID", ID);
                if (db != null && db.Rows.Count > 0)
                {
                    QLKC_C4_GIAONHAN_KIM_Model model = new QLKC_C4_GIAONHAN_KIM_Model();

                    model.ID = db.Rows[0]["ID"].ToString();
                    model.SO_LUONG_GIAO = db.Rows[0]["SO_LUONG_GIAO"] != DBNull.Value ? Convert.ToInt32(db.Rows[0]["SO_LUONG_GIAO"]) : 0;
                    model.SO_LUONG_TRA = db.Rows[0]["SO_LUONG_TRA"] != DBNull.Value ? Convert.ToInt32(db.Rows[0]["SO_LUONG_TRA"]) : 0;
                    model.SO_LUONG_THUHOI = db.Rows[0]["SO_LUONG_THUHOI"] != DBNull.Value ? Convert.ToInt32(db.Rows[0]["SO_LUONG_THUHOI"]) : 0;
                    model.LOAI = db.Rows[0]["LOAI"] != DBNull.Value ? db.Rows[0]["LOAI"].ToString() : null;
                    model.DONVI_TINH = db.Rows[0]["DONVI_TINH"] != DBNull.Value ? db.Rows[0]["DONVI_TINH"].ToString() : null;
                    model.DON_VI_GIAO = db.Rows[0]["DON_VI_GIAO"] != DBNull.Value ? db.Rows[0]["DON_VI_GIAO"].ToString() : null;
                    model.DON_VI_NHAN = db.Rows[0]["DON_VI_NHAN"] != DBNull.Value ? db.Rows[0]["DON_VI_NHAN"].ToString() : null;
                    model.NGUOI_NHAN = db.Rows[0]["NGUOI_NHAN"] != DBNull.Value ? db.Rows[0]["NGUOI_NHAN"].ToString() : null;
                    model.NGUOI_GIAO = db.Rows[0]["NGUOI_GIAO"] != DBNull.Value ? db.Rows[0]["NGUOI_GIAO"].ToString() : null;
                    model.NGAY_GIAO = db.Rows[0]["NGAY_GIAO"] != DBNull.Value ? Convert.ToDateTime(db.Rows[0]["NGAY_GIAO"]) : (DateTime?)null;
                    model.NGAY_NHAN = db.Rows[0]["NGAY_NHAN"] != DBNull.Value ? Convert.ToDateTime(db.Rows[0]["NGAY_NHAN"]) : (DateTime?)null;
                    model.TRANG_THAI = db.Rows[0]["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(db.Rows[0]["TRANG_THAI"]) : 0;
                    model.LOAI_BBAN = db.Rows[0]["LOAI_BBAN"] != DBNull.Value ? Convert.ToInt32(db.Rows[0]["LOAI_BBAN"]) : 0;
                    model.NOI_DUNG = db.Rows[0]["NOI_DUNG"] != DBNull.Value ? db.Rows[0]["NOI_DUNG"].ToString() : null;
                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}