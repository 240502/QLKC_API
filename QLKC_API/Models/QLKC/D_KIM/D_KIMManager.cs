﻿using APIPCHY.Helpers;
using System.Collections.Generic;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace API_PCHY.Models.QLKC.D_KIM
{
    public class D_KIMManager
    {
        DataHelper helper = new DataHelper();
        public string insert_QLKC_D_KIM(D_KIMModel d_KIM)
        {
            try
            {
                Console.WriteLine("test");
                Guid id = Guid.NewGuid();
                string str_id = id.ToString();
                string result = helper.ExcuteNonQuery("PKG_QLKC_NGOCANH.insert_QLKC_D_KIM", "p_Error",
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

        public string update_QLKC_D_KIM(D_KIMModel d_KIM)
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
                string result = helper.ExcuteNonQuery("PKG_QLKC_NGOCANH.delete_QLKC_D_KIM", "p_Error", "p_ID_KIM", id_kim);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string update_MADVIQLY_D_KIM(string htNguoiDungId, string idKim , string ma_dvigiao)
        {
            try
            {
                string result = helper.ExcuteNonQuery(
                  "PKG_QLKC_SANG.update_MADVIQLY_D_KIM", "p_Error", "p_HT_NGUOIDUNG_ID", "p_ID_KIM", "p_MADVI_GIAO", htNguoiDungId,idKim,ma_dvigiao
                  );
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<D_KIMModel> get_ALL_D_KIMByMA_DVIQLY(string? ma_dviqly,string kimIds )
        {
            try
            {
              
                DataTable ds = helper.ExcuteReader("PKG_QLKC_SANG.get_ALL_D_KIMByMA_DVIQLY", "p_MA_DVIQLY", ma_dviqly);
                if(ds.Rows.Count > 0)
                {
                    List<D_KIMModel> list = new List<D_KIMModel>();
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        D_KIMModel d = new D_KIMModel();
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
                    // Lọc các kìm có id_kim nằm trong mảng id kìm
                    List<D_KIMModel> results = new List<D_KIMModel>();

                    if (ma_dviqly == null)
                    {
                        string[] stringArray;
                        int[] intKimIdArray;
                        stringArray = kimIds.Split(',');
                            // Chuyển đổi mảng chuỗi thành mảng số nguyên
                        intKimIdArray = stringArray.Select(int.Parse).ToArray();
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            var a = intKimIdArray.Contains(list[i].id_kim);
                            var b = list[i].ma_dviqly == "PA23";
                            if (intKimIdArray.Contains(list[i].id_kim) || list[i].ma_dviqly == "PA23")
                            {
                                results.Add(list[i]);
                            }

                        }
                    }
                    
                    return ma_dviqly == null ? results : list;
                }
                else { return null; }
            }
            catch (Exception ex) { 
                throw ex;
            }
        }


        public List<D_KIMModel> search_QLKC_D_KIM(int? pageSize, int? pageIndex, string? nguoi_tao, int? loai_ma_kim, int? trang_thai, out int totalItems)
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
                    return new List<D_KIMModel>();
                }


                List<D_KIMModel> list = new List<D_KIMModel>();
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    D_KIMModel d = new D_KIMModel();
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
        public List<D_KIMModel> getALL_D_KIM()
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_NGOCANH.getAll_QLKC_D_KIM");
                List<D_KIMModel> result = new List<D_KIMModel>();
                if (ds != null)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        D_KIMModel d = new D_KIMModel();

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
        public D_KIMModel get_D_KIM_ByID(int id_kim)
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_NGOCANH.get_QLKC_D_KIM_byID", "p_ID_KIM", id_kim);

                if (ds != null)
                {
                    D_KIMModel d_KIM = new D_KIMModel();

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
    }
}
