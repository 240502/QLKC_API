using APIPCHY.Helpers;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.util.collections;

namespace API_PCHY.Models.QLKC.BBAN_BANGIAO_KIM
{
    public class BBAN_BANGIAO_KIMManager
    {
        DataHelper helper = new DataHelper();

        public List<BBAN_BANGIAO_KIMModel> search_BBAN_BANGIAO_KIM(int? pageIndex,int? pageSize, string? don_vi_giao, string? don_vi_nhan, int? trang_thai, string don_vi,int? loai_bban,out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable tb = helper.ExcuteReader("PKG_QLKC_SANG.search_BBAN_BANGIAO_KIM", "p_page_index","p_page_size", "p_DON_VI_GIAO", "p_DON_VI_NHAN", "p_TRANG_THAI","p_DON_VI", "p_LOAI_BBAN",pageIndex,pageSize,don_vi_giao,don_vi_nhan,trang_thai,don_vi,loai_bban);

                if (tb != null)
                {
                    totalItems = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    List<BBAN_BANGIAO_KIMModel> results = new List<BBAN_BANGIAO_KIMModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        BBAN_BANGIAO_KIMModel model = new BBAN_BANGIAO_KIMModel();
                        model.id_bienban = int.Parse(tb.Rows[i]["ID_BIENBAN"].ToString());
                        model.id_kim = tb.Rows[i]["ID_KIM"] != DBNull.Value ? tb.Rows[i]["ID_KIM"].ToString() : null;
                        model.so_luong = tb.Rows[i]["SO_LUONG"] != DBNull.Value ? int.Parse(tb.Rows[i]["SO_LUONG"].ToString()) : null;
                        model.don_vi_giao = tb.Rows[i]["DON_VI_GIAO"] != DBNull.Value ? tb.Rows[i]["DON_VI_GIAO"].ToString() : null;
                        model.don_vi_nhan = tb.Rows[i]["DON_VI_NHAN"] != DBNull.Value ? tb.Rows[i]["DON_VI_NHAN"].ToString() : null;
                        model.nguoi_nhan= tb.Rows[i]["NGUOI_NHAN"] != DBNull.Value ? tb.Rows[i]["NGUOI_NHAN"].ToString() : null;
                        model.nguoi_giao = tb.Rows[i]["NGUOI_GIAO"] != DBNull.Value ? tb.Rows[i]["NGUOI_GIAO"].ToString() : null;
                        model.ngay_giao = tb.Rows[i]["NGAY_GIAO"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["NGAY_GIAO"].ToString()) : null;
                        model.ngay_nhan = tb.Rows[i]["NGAY_NHAN"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["NGAY_NHAN"].ToString()) : null;
                        model.loai_bban = tb.Rows[i]["LOAI_BBAN"] != DBNull.Value ? int.Parse(tb.Rows[i]["LOAI_BBAN"].ToString()) : null;
                        model.noi_dung = tb.Rows[i]["NOI_DUNG"] != DBNull.Value ? tb.Rows[i]["NOI_DUNG"].ToString() : null;
                        model.trang_thai = tb.Rows[i]["TRANG_THAI"] != DBNull.Value ? int.Parse(tb.Rows[i]["TRANG_THAI"].ToString()) : null;
                        model.ten_dv = tb.Rows[i]["TEN_DV"] != DBNull.Value ? tb.Rows[i]["TEN_DV"].ToString() : null;
                        model.ten_pb = tb.Rows[i]["TEN_PB"] != DBNull.Value ? tb.Rows[i]["TEN_PB"].ToString() : null;

                        results.Add(model);
                    }
                   

                    return results;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BBAN_BANGIAO_KIMModel get_BBAN_BANGIAO_KIMByIdBBan(int id_bban)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("PKG_QLKC_SANG.get_BBAN_BANGIAO_KIMByIdBBan", "p_ID_BIENBAN",id_bban);
                if(tb != null)
                {
                    BBAN_BANGIAO_KIMModel model = new BBAN_BANGIAO_KIMModel();
                    model.id_bienban = int.Parse(tb.Rows[0]["ID_BIENBAN"].ToString());
                    model.id_kim= tb.Rows[0]["ID_KIM"] != DBNull.Value ? tb.Rows[0]["ID_KIM"].ToString():null;
                    model.so_luong = tb.Rows[0]["SO_LUONG"] != DBNull.Value? int.Parse(tb.Rows[0]["SO_LUONG"].ToString()):null;
                    model.don_vi_giao = tb.Rows[0]["DON_VI_GIAO"] != DBNull.Value? tb.Rows[0]["DON_VI_GIAO"].ToString():null;
                    model.don_vi_nhan = tb.Rows[0]["DON_VI_NHAN"] != DBNull.Value?tb.Rows[0]["DON_VI_NHAN"].ToString():null; 
                    model.nguoi_nhan = tb.Rows[0]["NGUOI_NHAN"] != DBNull.Value?tb.Rows[0]["NGUOI_NHAN"].ToString():null;
                    model.nguoi_giao = tb.Rows[0]["NGUOI_GIAO"] != DBNull.Value? tb.Rows[0]["NGUOI_GIAO"].ToString() : null;
                    model.ngay_giao = tb.Rows[0]["NGAY_GIAO"] != DBNull.Value? DateTime.Parse(tb.Rows[0]["NGAY_GIAO"].ToString()) : null;
                    model.ngay_nhan = tb.Rows[0]["NGAY_NHAN"] != DBNull.Value? DateTime.Parse(tb.Rows[0]["NGAY_NHAN"].ToString()) : null;
                    model.loai_bban = tb.Rows[0]["LOAI_BBAN"] != DBNull.Value?int.Parse(tb.Rows[0]["LOAI_BBAN"].ToString()) : null;
                    model.noi_dung = tb.Rows[0]["NOI_DUNG"] != DBNull.Value? tb.Rows[0]["NOI_DUNG"].ToString() : null;
                    model.trang_thai = tb.Rows[0]["TRANG_THAI"] != DBNull.Value? int.Parse(tb.Rows[0]["TRANG_THAI"].ToString()) : null;
                    return model;
                }
                else return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string insert_BBAN_BANGIAO_KIM(BBAN_BANGIAO_KIMModel bBAN_BANGIAO_KIMModel)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.insert_QLKC_BBAN_BANGIAO_KIM", "p_Error",
                                                        "p_ID_KIM", "p_SO_LUONG", "p_DON_VI_GIAO", "p_DON_VI_NHAN", "p_NGUOI_NHAN", "p_NGUOI_GIAO", "p_NOI_DUNG", "p_LOAI_BBAN",
                                                        bBAN_BANGIAO_KIMModel.id_kim, bBAN_BANGIAO_KIMModel.so_luong, bBAN_BANGIAO_KIMModel.don_vi_giao,
                                                        bBAN_BANGIAO_KIMModel.don_vi_nhan,bBAN_BANGIAO_KIMModel.nguoi_nhan, 
                                                        bBAN_BANGIAO_KIMModel.nguoi_giao, bBAN_BANGIAO_KIMModel.noi_dung,bBAN_BANGIAO_KIMModel.loai_bban);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string update_NguoiNhan_BBAN_BANGGIAO_KIM(string? ht_nguoidung_id, int? bienban_id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.update_NguoiNhan_BBAN_BANGGIAO_KIM", "p_Error", "p_ht_nguoidung_id", "p_bienban_id",
                                    ht_nguoidung_id,bienban_id);
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public string update_QLKC_BBAN_BANGIAO_KIMChoDuyet(BBAN_BANGIAO_KIMModel bBAN_BANGIAO_KIMModel)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.update_QLKC_BBAN_BANGIAO_KIMChoDuyet", "p_Error",
                                                        "p_ID_BIENBAN", "p_ID_KIM", "p_SO_LUONG", "p_DON_VI_GIAO", "p_DON_VI_NHAN", "p_NGUOI_NHAN", "p_NGUOI_GIAO", "p_NGAY_GIAO", "p_NOI_DUNG",
                                                        bBAN_BANGIAO_KIMModel.id_bienban, bBAN_BANGIAO_KIMModel.id_kim, bBAN_BANGIAO_KIMModel.so_luong, bBAN_BANGIAO_KIMModel.don_vi_giao,
                                                        bBAN_BANGIAO_KIMModel.don_vi_nhan, bBAN_BANGIAO_KIMModel.nguoi_nhan,
                                                        bBAN_BANGIAO_KIMModel.nguoi_giao, bBAN_BANGIAO_KIMModel.ngay_giao, bBAN_BANGIAO_KIMModel.noi_dung);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string delete_QLKC_BBAN_BANGIAO_KIM(int id_bban)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.delete_QLKC_BBAN_BANGIAO_KIM", "p_Error",
                                                        "p_ID_BIENBAN",
                                                        id_bban);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string update_QLKC_BBAN_BANGIAO_KIMKyC1(int id_bban)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.update_QLKC_BBAN_BANGIAO_KIMKyC1", "p_Error",
                                                        "p_ID_BIENBAN",
                                                        id_bban);
                return result;
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
        public string update_QLKC_BBAN_BANGIAO_KIMTraLai(int id_bban)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.update_QLKC_BBAN_BANGIAO_KIMTraLai", "p_Error",
                                                        "p_ID_BIENBAN",
                                                        id_bban);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string update_QLKC_BBAN_BANGIAO_KIMKyC2(int id_bban)
        {
            try
            {
                BBAN_BANGIAO_KIMModel model = get_BBAN_BANGIAO_KIMByIdBBan(id_bban);
                if(model.trang_thai == 1)
                {
                    string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.update_QLKC_BBAN_BANGIAO_KIMKyC2", "p_Error",
                                                       "p_ID_BIENBAN",
                                                       id_bban);
                    return result;
                }
                else
                {
                    return "Vui lòng ký cấp 1 trước";
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string cancel_QLKC_BBAN_BANGIAO_KIM(int id_bban)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.cancel_QLKC_BBAN_BANGIAO_KIM", "p_Error",
                                                        "p_ID_BIENBAN",
                                                        id_bban);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
