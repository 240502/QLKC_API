﻿using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;
using APIPCHY_PhanQuyen.Models.QLKC.HT_PHANQUYEN;
using Microsoft.OpenApi.Any;
using System.Linq;

namespace APIPCHY_PhanQuyen.Models.QLKC.QLKC_NHAP_CHI_TEM
{
    public class QLKC_NHAP_CHI_TEM_Manager
    {
        DataHelper helper = new DataHelper();

        public List<QLKC_NHAP_CHI_TEMGroupRes> get_QLKC_NHAP_CHI_TEMGroup()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("PKG_QLKC_SANG.get_QLKC_NHAP_CHI_TEMGroup");
                if (tb != null)
                {
                    Dictionary<string, QLKC_NHAP_CHI_TEMGroupRes> results = new Dictionary<string, QLKC_NHAP_CHI_TEMGroupRes>();

                    foreach (DataRow row in tb.Rows)
                    {
                        string ma_dviqly = row["MA_DVIQLY"] != DBNull.Value ? row["MA_DVIQLY"].ToString() : null;
                        if (!string.IsNullOrEmpty(ma_dviqly))
                        {
                            // Nếu chưa có trong dictionary, tạo mới đối tượng
                            if (!results.ContainsKey(ma_dviqly))
                            {
                                results[ma_dviqly] = new QLKC_NHAP_CHI_TEMGroupRes { ma_dviqly = ma_dviqly };
                            }

                            // Cập nhật giá trị tùy theo loại
                            var model = results[ma_dviqly];
                            if (row["LOAI"].ToString() == "chi")
                            {
                                model.so_luong_chi = row["SO_LUONG"] != DBNull.Value ? (int?)int.Parse(row["SO_LUONG"].ToString()) : null;
                            }
                            else
                            {
                                model.so_luong_tem = row["SO_LUONG"] != DBNull.Value ? (int?)int.Parse(row["SO_LUONG"].ToString()) : null;
                            }
                        }
                    }

                    return results.Values.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<QLKC_NHAP_CHI_TEM_Model> search_QLKC_NHAP_CHI_TEM(int? pageIndex, int? pageSize, string loai, string donViTinh, out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable ds = helper.ExcuteReader(
                    "PKG_QLKC_CHIEN.search_QLKC_NHAP_CHI_TEM",
                    "p_page_index", "p_page_size",
                    "p_LOAI", "p_DON_VI_TINH",
                    pageIndex,
                    pageSize,
                    string.IsNullOrEmpty(loai) ? DBNull.Value : (object)loai,
                    string.IsNullOrEmpty(donViTinh) ? DBNull.Value : (object)donViTinh
                );

                // Lấy tổng số items
                totalItems = ds.Rows.Count > 0 ? int.Parse(ds.Rows[0]["RECORDCOUNT"].ToString()) : 0;

                // Tạo danh sách kết quả
                List<QLKC_NHAP_CHI_TEM_Model> result = new List<QLKC_NHAP_CHI_TEM_Model>();

                // Duyệt và ánh xạ dữ liệu
                foreach (DataRow dr in ds.Rows)
                {
                    result.Add(new QLKC_NHAP_CHI_TEM_Model
                    {
                        ID_BIENBAN = dr["ID_BIENBAN"] != DBNull.Value ? Convert.ToInt32(dr["ID_BIENBAN"]) : 0,
                        LOAI = dr["LOAI"] != DBNull.Value ? dr["LOAI"].ToString() : string.Empty,
                        SO_LUONG = dr["SO_LUONG"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG"]) : 0,
                        DON_VI_TINH = dr["DON_VI_TINH"] != DBNull.Value ? dr["DON_VI_TINH"].ToString() : string.Empty,
                        NGUOI_TAO = dr["NGUOI_TAO"] != DBNull.Value ? dr["NGUOI_TAO"].ToString() : string.Empty,
                        NGAY_TAO = dr["NGAY_TAO"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_TAO"]) : DateTime.MinValue,
                        NGUOI_SUA = dr["NGUOI_SUA"] != DBNull.Value ? dr["NGUOI_SUA"].ToString() : string.Empty,
                        NGAY_SUA = dr["NGAY_SUA"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_SUA"]) : DateTime.MinValue
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<QLKC_NHAP_CHI_TEM_Model> get_BBAN_NHAP_CHI_TEM(int id_bienBan)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<QLKC_NHAP_CHI_TEM_Model>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.get_BBAN_NHAP_CHI_TEM";
                cmd.Parameters.Add("p_ID_BIENBAN", OracleDbType.Int32).Value = id_bienBan;
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<QLKC_NHAP_CHI_TEM_Model> result = new List<QLKC_NHAP_CHI_TEM_Model>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    QLKC_NHAP_CHI_TEM_Model nctm = new QLKC_NHAP_CHI_TEM_Model();
                    nctm.ID_BIENBAN = dr["ID_BIENBAN"] != DBNull.Value ? Convert.ToInt32(dr["ID_BIENBAN"]) : 0;
                    nctm.LOAI = dr["LOAI"] != DBNull.Value ? dr["LOAI"].ToString() : string.Empty;
                    nctm.SO_LUONG = dr["SO_LUONG"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG"]) : 0; ;
                    nctm.DON_VI_TINH = dr["DON_VI_TINH"] != DBNull.Value ? dr["DON_VI_TINH"].ToString() : string.Empty;
                    nctm.NGAY_TAO = dr["NGAY_TAO"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_TAO"]) : DateTime.MinValue;
                    nctm.NGUOI_TAO = dr["NGUOI_TAO"] != DBNull.Value ? dr["NGUOI_TAO"].ToString() : string.Empty;
                    nctm.NGAY_SUA = dr["NGAY_SUA"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_SUA"]) : DateTime.MinValue;
                    nctm.NGUOI_SUA = dr["NGUOI_SUA"] != DBNull.Value ? dr["NGUOI_SUA"].ToString() : string.Empty;
                    result.Add(nctm);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public string update_SO_LUONG_NHAP_TEM_CHI(int id_bienban, int? so_luong)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.update_SO_LUONG_NHAP_TEM_CHI", "p_Error", "p_ID_BIENBAN", "p_SO_LUONG",id_bienban,so_luong);
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public QLKC_NHAP_CHI_TEM_Model get_NHAP_CHI_TEMByMA_DVIQLYANDLOAI(string ma_dviqly, string loai)
        {
           
            try
            {
              
                DataTable dr = helper.ExcuteReader("PKG_QLKC_SANG.get_NHAP_CHI_TEMByMA_DVIQLYANDLOAI","p_MA_DVIQLY","p_LOAI",ma_dviqly,loai);

                if(dr != null)
                {
                 
                        QLKC_NHAP_CHI_TEM_Model nctm = new QLKC_NHAP_CHI_TEM_Model();
                        nctm.ID_BIENBAN = dr.Rows[0]["ID_BIENBAN"] != DBNull.Value ? Convert.ToInt32(dr.Rows[0]["ID_BIENBAN"]) : 0;
                        nctm.LOAI = dr.Rows[0]["LOAI"] != DBNull.Value ? dr.Rows[0]["LOAI"].ToString() : string.Empty;
                        nctm.SO_LUONG = dr.Rows[0]["SO_LUONG"] != DBNull.Value ? Convert.ToInt32(dr.Rows[0]["SO_LUONG"]) : 0; ;
                        nctm.DON_VI_TINH = dr.Rows[0]["DON_VI_TINH"] != DBNull.Value ? dr.Rows[0]["DON_VI_TINH"].ToString() : string.Empty;
                        nctm.NGAY_TAO = dr.Rows[0]["NGAY_TAO"] != DBNull.Value ? Convert.ToDateTime(dr.Rows[0]["NGAY_TAO"]) : DateTime.MinValue;
                        nctm.NGUOI_TAO = dr.Rows[0]["NGUOI_TAO"] != DBNull.Value ? dr.Rows[0]["NGUOI_TAO"].ToString() : string.Empty;
                        nctm.NGAY_SUA = dr.Rows[0]["NGAY_SUA"] != DBNull.Value ? Convert.ToDateTime(dr.Rows[0]["NGAY_SUA"]) : DateTime.MinValue;
                        nctm.NGUOI_SUA = dr.Rows[0]["NGUOI_SUA"] != DBNull.Value ? dr.Rows[0]["NGUOI_SUA"].ToString() : string.Empty;
                        nctm.MA_DVIQLY = dr.Rows[0]["MA_DVIQLY"] != DBNull.Value ? dr.Rows[0]["MA_DVIQLY"].ToString() : string.Empty;
                return nctm;

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
        public List<QLKC_NHAP_CHI_TEM_Model> getAll_QLKC_NHAP_CHI_TEM()
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<QLKC_NHAP_CHI_TEM_Model>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.getAll_QLKC_NHAP_CHI_TEM"; 
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<QLKC_NHAP_CHI_TEM_Model> result = new List<QLKC_NHAP_CHI_TEM_Model>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    QLKC_NHAP_CHI_TEM_Model nctm = new QLKC_NHAP_CHI_TEM_Model();
                    nctm.ID_BIENBAN = dr["ID_BIENBAN"] != DBNull.Value ? Convert.ToInt32(dr["ID_BIENBAN"]) : 0;
                    nctm.LOAI = dr["LOAI"] != DBNull.Value ? dr["LOAI"].ToString() : string.Empty;
                    nctm.SO_LUONG = dr["SO_LUONG"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG"]) : 0; ;
                    nctm.DON_VI_TINH = dr["DON_VI_TINH"] != DBNull.Value ? dr["DON_VI_TINH"].ToString() : string.Empty;
                    nctm.NGAY_TAO = dr["NGAY_TAO"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_TAO"]) : DateTime.MinValue;
                    nctm.NGUOI_TAO = dr["NGUOI_TAO"] != DBNull.Value ? dr["NGUOI_TAO"].ToString() : string.Empty;
                    nctm.NGAY_SUA = dr["NGAY_SUA"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_SUA"]) : DateTime.MinValue;
                    nctm.NGUOI_SUA = dr["NGUOI_SUA"] != DBNull.Value ? dr["NGUOI_SUA"].ToString() : string.Empty;
                    nctm.MA_DVIQLY = dr["MA_DVIQLY"] != DBNull.Value ? dr["MA_DVIQLY"].ToString() : string.Empty;

                    result.Add(nctm);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
        public QLKC_NHAP_CHI_TEM_Model insert_QLKC_NHAP_CHI_TEM(QLKC_NHAP_CHI_TEM_Model nct)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return null;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.insert_QLKC_NHAP_CHI_TEM";
                cmd.Parameters.Add("p_ID_BIENBAN", nct.ID_BIENBAN);
                cmd.Parameters.Add("p_LOAI", nct.LOAI);
                cmd.Parameters.Add("p_SO_LUONG", nct.SO_LUONG);
                cmd.Parameters.Add("p_DON_VI_TINH", nct.DON_VI_TINH);
                cmd.Parameters.Add("p_NGUOI_TAO", nct.NGUOI_TAO);
                cmd.Parameters.Add("p_NGAY_TAO", nct.NGAY_TAO);
                cmd.Parameters.Add("p_NGUOI_SUA", nct.NGUOI_SUA);
                cmd.Parameters.Add("p_NGAY_SUA", nct.NGAY_SUA);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return nct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public QLKC_NHAP_CHI_TEM_Model update_QLKC_NHAP_CHI_TEM(QLKC_NHAP_CHI_TEM_Model nct)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return null;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_QLKC_NHAP_CHI_TEM";
                cmd.Parameters.Add("p_ID_BIENBAN", nct.ID_BIENBAN);
                cmd.Parameters.Add("p_LOAI", nct.LOAI);
                cmd.Parameters.Add("p_SO_LUONG", nct.SO_LUONG);
                cmd.Parameters.Add("p_DON_VI_TINH", nct.DON_VI_TINH);
                cmd.Parameters.Add("p_NGUOI_TAO", nct.NGUOI_TAO);
                cmd.Parameters.Add("p_NGAY_TAO", nct.NGAY_TAO);
                cmd.Parameters.Add("p_NGUOI_SUA", nct.NGUOI_SUA);
                cmd.Parameters.Add("p_NGAY_SUA", nct.NGAY_SUA);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return nct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public bool delete_BBAN_NHAP_CHI_TEM(int id)
        {
            string strErr = "";
            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleTransaction transaction = cn.BeginTransaction();
                cmd.Transaction = transaction;

                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"PKG_QLKC_CHIEN.delete_BBAN_NHAP_CHI_TEM";
                    cmd.Parameters.Add("p_ID_BIENBAN", OracleDbType.Int32).Value = id;
                    cmd.Parameters.Add("p_Error", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex; // Hoặc xử lý lỗi theo cách bạn muốn
                }
                finally
                {
                    if (cn.State != ConnectionState.Closed)
                    {
                        cn.Close();
                    }
                }
            }
        }
    }
}
