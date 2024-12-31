using APIPCHY.Helpers;
using System.Collections.Generic;
using System.Data;
using System;
using APIPCHY_PhanQuyen.Models.QLKC.HT_NHOMQUYEN;

namespace APIPCHY_PhanQuyen.Models.QLKC.D_KIM
{
    public class D_KIM_Manager
    {
        DataHelper helper = new DataHelper();
        public string insert_QLKC_D_KIM(D_KIM_Model d_KIM)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_NGOCANH.insert_QLKC_D_KIM", "p_Error",
                                                    "p_LOAI_MA_KIM", "p_THOI_HAN", "p_TRANG_THAI", "p_MA_HIEU", "p_NGUOI_TAO",
                                                    "p_MA_DVIQLY", "p_NGAY_TAO", "p_NGUOI_SUA", "p_NGAY_SUA",
                                                    d_KIM.loai_ma_kim, d_KIM.thoi_han, d_KIM.trang_thai, d_KIM.ma_hieu, d_KIM.nguoi_tao,
                                                    d_KIM.ma_dviqly, d_KIM.ngay_tao, d_KIM.nguoi_sua, d_KIM.ngay_sua);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string update_QLKC_D_KIM(D_KIM_Model d_KIM)
        {
            try
            {
                string str_id = d_KIM.id_kim.ToString();
                string result = helper.ExcuteNonQuery(
                    "PKG_QLKC_NGOCANH.update_QLKC_D_KIM", "p_Error",
                    "p_ID_KIM", "p_LOAI_MA_KIM", "p_THOI_HAN", "p_TRANG_THAI", "p_MA_HIEU", "p_NGUOI_TAO",
                    "p_MA_DVIQLY", "p_NGAY_TAO", "p_NGUOI_SUA", "p_NGAY_SUA",
                    d_KIM.id_kim, d_KIM.loai_ma_kim, d_KIM.thoi_han, d_KIM.trang_thai, d_KIM.ma_hieu, d_KIM.nguoi_tao,
                    d_KIM.ma_dviqly, d_KIM.ngay_tao, d_KIM.nguoi_sua, d_KIM.ngay_sua);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string delete_QLKC_D_KIM(int id_kim)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_NGOCANH.delete_QLKC_D_KIM", "p_Error","p_ID_KIM", id_kim);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<D_KIM_Model> search_QLKC_D_KIM(int? pageSize, int? pageIndex, string? nguoi_tao, int? loai_ma_kim, int?trang_thai, out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_NGOCANH.search_QLKC_D_KIM", "p_page_index", "p_page_size",
                                                   "p_NGUOI_TAO", "p_LOAI_MA_KIM", "p_TRANG_THAI", pageIndex, pageSize, nguoi_tao, loai_ma_kim, trang_thai);
                var count = ds.Rows.Count;

                if (pageSize > 0 && pageIndex > 0 && count > 0)
                {
                    totalItems = int.Parse(ds.Rows[0]["RecordCount"].ToString());
                }
                if (ds == null || ds.Rows.Count == 0)
                {
                    totalItems = 0;
                    return new List<D_KIM_Model>();
                }


                List<D_KIM_Model> list = new List<D_KIM_Model>();
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    D_KIM_Model d = new D_KIM_Model();
                    d.id_kim = int.Parse(ds.Rows[i]["ID_KIM"].ToString());
                    d.loai_ma_kim = ds.Rows[i]["LOAI_MA_KIM"] != DBNull.Value ? int.Parse(ds.Rows[i]["LOAI_MA_KIM"].ToString()) : null;
                    d.thoi_han = ds.Rows[i]["THOI_HAN"] != DBNull.Value ? DateTime.Parse(ds.Rows[i]["THOI_HAN"].ToString()) : null;
                    d.trang_thai = ds.Rows[i]["TRANG_THAI"] != DBNull.Value ? int.Parse(ds.Rows[i]["TRANG_THAI"].ToString()) : null;
                    d.ma_hieu = ds.Rows[i]["MA_HIEU"] != DBNull.Value ? ds.Rows[i]["MA_HIEU"].ToString() : null;
                    d.nguoi_tao = ds.Rows[i]["NGUOI_TAO"] != DBNull.Value ? ds.Rows[i]["NGUOI_TAO"].ToString() : null;
                    d.ma_dviqly = ds.Rows[i]["MA_DVIQLY"] != DBNull.Value ? ds.Rows[i]["MA_DVIQLY"].ToString() : null;
                    d.ngay_tao = ds.Rows[i]["NGAY_TAO"] != DBNull.Value ? DateTime.Parse(ds.Rows[i]["NGAY_TAO"].ToString()) : null;
                    d.nguoi_sua = ds.Rows[i]["NGUOI_SUA"] != DBNull.Value ? ds.Rows[i]["NGUOI_SUA"].ToString() : null;
                    d.ngay_sua = ds.Rows[i]["NGAY_SUA"] != DBNull.Value ? DateTime.Parse(ds.Rows[i]["NGAY_SUA"].ToString()) : null;

                    list.Add(d);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public D_KIM_Model get_D_KIM_ByID(int id_kim)
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_NGOCANH.get_QLKC_D_KIM_byID", "p_ID_KIM", id_kim);

                if (ds != null)
                {
                    D_KIM_Model d_KIM = new D_KIM_Model();

                    d_KIM.id_kim = int.Parse(ds.Rows[0]["ID_KIM"].ToString());
                    d_KIM.loai_ma_kim = ds.Rows[0]["LOAI_MA_KIM"] != DBNull.Value ? int.Parse(ds.Rows[0]["LOAI_MA_KIM"].ToString()) : null;
                    d_KIM.thoi_han = ds.Rows[0]["THOI_HAN"] != DBNull.Value ? DateTime.Parse(ds.Rows[0]["THOI_HAN"].ToString()) : null;
                    d_KIM.trang_thai = ds.Rows[0]["TRANG_THAI"] != DBNull.Value ? int.Parse(ds.Rows[0]["TRANG_THAI"].ToString()) : null;
                    d_KIM.ma_hieu = ds.Rows[0]["MA_HIEU"] != DBNull.Value ? ds.Rows[0]["MA_HIEU"].ToString() : null;
                    d_KIM.nguoi_tao = ds.Rows[0]["NGUOI_TAO"] != DBNull.Value ? ds.Rows[0]["NGUOI_TAO"].ToString() : null;
                    d_KIM.ma_dviqly = ds.Rows[0]["MA_DVIQLY"] != DBNull.Value ? ds.Rows[0]["MA_DVIQLY"].ToString() : null;
                    d_KIM.ngay_tao = ds.Rows[0]["NGAY_TAO"] != DBNull.Value ? DateTime.Parse(ds.Rows[0]["NGAY_TAO"].ToString()) : null;
                    d_KIM.nguoi_sua = ds.Rows[0]["NGUOI_SUA"] != DBNull.Value ? ds.Rows[0]["NGUOI_SUA"].ToString() : null;
                    d_KIM.ngay_sua = ds.Rows[0]["NGAY_SUA"] != DBNull.Value ? DateTime.Parse(ds.Rows[0]["NGAY_SUA"].ToString()) : null;

                    return d_KIM;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<D_KIM_Model> getALL_D_KIM()
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_NGOCANH.getAll_QLKC_D_KIM");
                List<D_KIM_Model> result = new List<D_KIM_Model>();
                if (ds != null)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        D_KIM_Model d = new D_KIM_Model();

                        d.id_kim = int.Parse(ds.Rows[i]["ID_KIM"].ToString());

                        d.loai_ma_kim = ds.Rows[i]["LOAI_MA_KIM"] != DBNull.Value ? int.Parse(ds.Rows[i]["LOAI_MA_KIM"].ToString()) : null;
                        d.thoi_han = ds.Rows[i]["THOI_HAN"] != DBNull.Value ? DateTime.Parse(ds.Rows[i]["THOI_HAN"].ToString()) : null;
                        d.trang_thai = ds.Rows[i]["TRANG_THAI"] != DBNull.Value ? int.Parse(ds.Rows[i]["TRANG_THAI"].ToString()) : null;
                        d.ma_hieu = ds.Rows[i]["MA_HIEU"] != DBNull.Value ? ds.Rows[i]["MA_HIEU"].ToString() : null;
                        d.nguoi_tao = ds.Rows[i]["NGUOI_TAO"] != DBNull.Value ? ds.Rows[i]["NGUOI_TAO"].ToString() : null;
                        d.ma_dviqly = ds.Rows[i]["MA_DVIQLY"] != DBNull.Value ? ds.Rows[i]["MA_DVIQLY"].ToString() : null;
                        d.ngay_tao = ds.Rows[i]["NGAY_TAO"] != DBNull.Value ? DateTime.Parse(ds.Rows[i]["NGAY_TAO"].ToString()) : null;
                        d.nguoi_sua = ds.Rows[i]["NGUOI_SUA"] != DBNull.Value ? ds.Rows[i]["NGUOI_SUA"].ToString() : null;
                        d.ngay_sua = ds.Rows[i]["NGAY_SUA"] != DBNull.Value ? DateTime.Parse(ds.Rows[i]["NGAY_SUA"].ToString()) : null;

                        result.Add(d);
                    }
                }
                else
                {
                    result = null;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}


