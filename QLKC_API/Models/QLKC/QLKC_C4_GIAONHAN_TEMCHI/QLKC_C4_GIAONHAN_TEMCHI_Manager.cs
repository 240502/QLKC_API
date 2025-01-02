using APIPCHY.Helpers;
using APIPCHY_PhanQuyen.Models.QLKC.QLKC_C4_GIAONHAN_TEMCHI;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;
using APIPCHY_PhanQuyen.Models.QLKC.QLKC_NHAP_CHI_TEM;
using APIPCHY_PhanQuyen.Models.QLKC.HT_NGUOIDUNG;

namespace APIPCHY_PhanQuyen.Models.QLKC.QLKC_C4_GIAONHAN_TEMCHI
{
    public class QLKC_C4_GIAONHAN_TEMCHI_Manager
    {
        DataHelper helper = new DataHelper();
        public List<QLKC_C4_GIAONHAN_TEMCHI_Model> search_QLKC_C4_GIAONHAN_TEMCHI(int? pageIndex, int? pageSize, int? trang_thai, int? loai_bienban,string don_vi_giao, string don_vi_nhan, out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_CHIEN.search_QLKC_C4_GIAONHAN_TEMCHI",
                                                   "p_page_index", "p_page_size",
                                                   "p_TRANG_THAI", "p_LOAI_BBAN",
                                                   "p_DONVI_GIAO","p_DONVI_NHAN ",
                                                   pageIndex, pageSize,
                                                   trang_thai == -1 ? DBNull.Value : trang_thai,
                                                   loai_bienban == -1 ? DBNull.Value : loai_bienban,
                                                   don_vi_giao == "" ? DBNull.Value : don_vi_giao,
                                                   don_vi_nhan == "" ? DBNull.Value : don_vi_nhan);

                var count = ds.Rows.Count;
                totalItems = int.Parse(ds.Rows[0]["RECORDCOUNT"].ToString());

                List<QLKC_C4_GIAONHAN_TEMCHI_Model> result = new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();

                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    QLKC_C4_GIAONHAN_TEMCHI_Model tcm = new QLKC_C4_GIAONHAN_TEMCHI_Model
                    {
                        ID = ds.Rows[i]["ID"] != DBNull.Value ? Convert.ToInt32(ds.Rows[i]["ID"]) : 0,
                        SO_LUONG_GIAO = ds.Rows[i]["SO_LUONG_GIAO"] != DBNull.Value ? Convert.ToInt32(ds.Rows[i]["SO_LUONG_GIAO"]) : 0,
                        SO_LUONG_TRA = ds.Rows[i]["SO_LUONG_TRA"] != DBNull.Value ? Convert.ToInt32(ds.Rows[i]["SO_LUONG_TRA"]) : 0,
                        SO_LUONG_THUHOI = ds.Rows[i]["SO_LUONG_THUHOI"] != DBNull.Value ? Convert.ToInt32(ds.Rows[i]["SO_LUONG_THUHOI"]) : 0,
                        LOAI = ds.Rows[i]["LOAI"] != DBNull.Value ? ds.Rows[i]["LOAI"].ToString() : string.Empty,
                        DONVI_TINH = ds.Rows[i]["DONVI_TINH"] != DBNull.Value ? ds.Rows[i]["DONVI_TINH"].ToString() : string.Empty,
                        DON_VI_GIAO = ds.Rows[i]["DON_VI_GIAO"] != DBNull.Value ? ds.Rows[i]["DON_VI_GIAO"].ToString() : string.Empty,
                        TEN_DONVI_GIAO = ds.Rows[i]["TEN_DONVI_GIAO"] != DBNull.Value ? ds.Rows[i]["TEN_DONVI_GIAO"].ToString() : string.Empty,
                        TEN_PHONGBAN_GIAO = ds.Rows[i]["TEN_PHONGBAN_GIAO"] != DBNull.Value ? ds.Rows[i]["TEN_PHONGBAN_GIAO"].ToString() : string.Empty,
                        TEN_NGUOI_GIAO = ds.Rows[i]["TEN_NGUOI_GIAO"] != DBNull.Value ? ds.Rows[i]["TEN_NGUOI_GIAO"].ToString() : string.Empty,
                        DON_VI_NHAN = ds.Rows[i]["DON_VI_NHAN"] != DBNull.Value ? ds.Rows[i]["DON_VI_NHAN"].ToString() : string.Empty,
                        NGUOI_NHAN = ds.Rows[i]["NGUOI_NHAN"] != DBNull.Value ? ds.Rows[i]["NGUOI_NHAN"].ToString() : string.Empty,
                        TEN_DONVI_NHAN = ds.Rows[i]["TEN_DONVI_NHAN"] != DBNull.Value ? ds.Rows[i]["TEN_DONVI_NHAN"].ToString() : string.Empty,
                        TEN_PHONGBAN_NHAN = ds.Rows[i]["TEN_PHONGBAN_NHAN"] != DBNull.Value ? ds.Rows[i]["TEN_PHONGBAN_NHAN"].ToString() : string.Empty,
                        TEN_NGUOI_NHAN = ds.Rows[i]["TEN_NGUOI_NHAN"] != DBNull.Value ? ds.Rows[i]["TEN_NGUOI_NHAN"].ToString() : string.Empty,
                        NGUOI_GIAO = ds.Rows[i]["NGUOI_GIAO"] != DBNull.Value ? ds.Rows[i]["NGUOI_GIAO"].ToString() : string.Empty,
                        NGAY_GIAO = ds.Rows[i]["NGAY_GIAO"] != DBNull.Value ? Convert.ToDateTime(ds.Rows[i]["NGAY_GIAO"]) : DateTime.MinValue,
                        NGAY_NHAN = ds.Rows[i]["NGAY_NHAN"] != DBNull.Value ? Convert.ToDateTime(ds.Rows[i]["NGAY_NHAN"]) : DateTime.MinValue,
                        LOAI_BBAN = ds.Rows[i]["LOAI_BBAN"] != DBNull.Value ? Convert.ToInt32(ds.Rows[i]["LOAI_BBAN"]) : 0,
                        NOI_DUNG = ds.Rows[i]["NOI_DUNG"] != DBNull.Value ? ds.Rows[i]["NOI_DUNG"].ToString() : string.Empty,
                        TRANG_THAI = ds.Rows[i]["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(ds.Rows[i]["TRANG_THAI"]) : 0
                    };

                    result.Add(tcm);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string update_NguoiNhan_QLKC_C4_GIAONHAN_TEMCHI(string? ht_nguoidung_id, int? bienban_id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_CHIEN.update_NguoiNhan_QLKC_C4_GIAONHAN_TEMCHI", "p_Error", "p_ht_nguoidung_id", "p_bienban_id",
                                    ht_nguoidung_id, bienban_id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<QLKC_C4_GIAONHAN_TEMCHI_Model> get_QLKC_C4_GIAONHAN_TEMCHI(int id_bienBan)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.get_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id_bienBan;
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<QLKC_C4_GIAONHAN_TEMCHI_Model> result = new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    QLKC_C4_GIAONHAN_TEMCHI_Model tcm = new QLKC_C4_GIAONHAN_TEMCHI_Model();
                    tcm.ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                    tcm.SO_LUONG_GIAO = dr["SO_LUONG_GIAO"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_GIAO"]) : 0;
                    tcm.SO_LUONG_TRA = dr["SO_LUONG_TRA"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_TRA"]) : 0;
                    tcm.SO_LUONG_THUHOI = dr["SO_LUONG_THUHOI"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_THUHOI"]) : 0;
                    tcm.LOAI = dr["LOAI"] != DBNull.Value ? dr["LOAI"].ToString() : string.Empty;
                    tcm.DONVI_TINH = dr["DONVI_TINH"] != DBNull.Value ? dr["DONVI_TINH"].ToString() : string.Empty;
                    tcm.DON_VI_GIAO = dr["DON_VI_GIAO"] != DBNull.Value ? dr["DON_VI_GIAO"].ToString() : string.Empty;
                    tcm.DON_VI_NHAN = dr["DON_VI_NHAN"] != DBNull.Value ? dr["DON_VI_NHAN"].ToString() : string.Empty;
                    tcm.NGUOI_NHAN = dr["NGUOI_NHAN"] != DBNull.Value ? dr["NGUOI_NHAN"].ToString() : string.Empty;
                    tcm.NGUOI_GIAO = dr["NGUOI_GIAO"] != DBNull.Value ? dr["NGUOI_GIAO"].ToString() : string.Empty;
                    tcm.NGAY_GIAO = dr["NGAY_GIAO"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_GIAO"]) : DateTime.MinValue;
                    tcm.NGAY_NHAN = dr["NGAY_NHAN"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_NHAN"]) : DateTime.MinValue;
                    tcm.LOAI_BBAN = dr["LOAI_BBAN"] != DBNull.Value ? Convert.ToInt32(dr["LOAI_BBAN"]) : 0;
                    tcm.NOI_DUNG = dr["NOI_DUNG"] != DBNull.Value ? dr["NOI_DUNG"].ToString() : string.Empty;
                    tcm.TRANG_THAI = dr["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(dr["TRANG_THAI"]) : 0;

                    result.Add(tcm);
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
        public List<QLKC_C4_GIAONHAN_TEMCHI_Model> get_PM_QLKC_C4_GIAONHAN_TEMCHI(int id_bienBan)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.get_PM_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id_bienBan;
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<QLKC_C4_GIAONHAN_TEMCHI_Model> result = new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    QLKC_C4_GIAONHAN_TEMCHI_Model tcm = new QLKC_C4_GIAONHAN_TEMCHI_Model();
                    tcm.ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                    tcm.SO_LUONG_GIAO = dr["SO_LUONG_GIAO"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_GIAO"]) : 0;
                    tcm.SO_LUONG_TRA = dr["SO_LUONG_TRA"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_TRA"]) : 0;
                    tcm.SO_LUONG_THUHOI = dr["SO_LUONG_THUHOI"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_THUHOI"]) : 0;
                    tcm.LOAI = dr["LOAI"] != DBNull.Value ? dr["LOAI"].ToString() : string.Empty;
                    tcm.DONVI_TINH = dr["DONVI_TINH"] != DBNull.Value ? dr["DONVI_TINH"].ToString() : string.Empty;
                    tcm.DON_VI_GIAO = dr["DON_VI_GIAO"] != DBNull.Value ? dr["DON_VI_GIAO"].ToString() : string.Empty;
                    tcm.DON_VI_NHAN = dr["DON_VI_NHAN"] != DBNull.Value ? dr["DON_VI_NHAN"].ToString() : string.Empty;
                    tcm.NGUOI_NHAN = dr["NGUOI_NHAN"] != DBNull.Value ? dr["NGUOI_NHAN"].ToString() : string.Empty;
                    tcm.NGUOI_GIAO = dr["NGUOI_GIAO"] != DBNull.Value ? dr["NGUOI_GIAO"].ToString() : string.Empty;
                    tcm.NGAY_GIAO = dr["NGAY_GIAO"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_GIAO"]) : DateTime.MinValue;
                    tcm.NGAY_NHAN = dr["NGAY_NHAN"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_NHAN"]) : DateTime.MinValue;
                    tcm.LOAI_BBAN = dr["LOAI_BBAN"] != DBNull.Value ? Convert.ToInt32(dr["LOAI_BBAN"]) : 0;
                    tcm.NOI_DUNG = dr["NOI_DUNG"] != DBNull.Value ? dr["NOI_DUNG"].ToString() : string.Empty;
                    tcm.TRANG_THAI = dr["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(dr["TRANG_THAI"]) : 0;

                    result.Add(tcm);
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
        public List<QLKC_C4_GIAONHAN_TEMCHI_Model> get_PQT_QLKC_C4_GIAONHAN_TEMCHI(int id_bienBan)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.get_PQT_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id_bienBan;
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<QLKC_C4_GIAONHAN_TEMCHI_Model> result = new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    QLKC_C4_GIAONHAN_TEMCHI_Model tcm = new QLKC_C4_GIAONHAN_TEMCHI_Model();
                    tcm.ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                    tcm.SO_LUONG_GIAO = dr["SO_LUONG_GIAO"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_GIAO"]) : 0;
                    tcm.SO_LUONG_TRA = dr["SO_LUONG_TRA"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_TRA"]) : 0;
                    tcm.SO_LUONG_THUHOI = dr["SO_LUONG_THUHOI"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_THUHOI"]) : 0;
                    tcm.LOAI = dr["LOAI"] != DBNull.Value ? dr["LOAI"].ToString() : string.Empty;
                    tcm.DONVI_TINH = dr["DONVI_TINH"] != DBNull.Value ? dr["DONVI_TINH"].ToString() : string.Empty;
                    tcm.DON_VI_GIAO = dr["DON_VI_GIAO"] != DBNull.Value ? dr["DON_VI_GIAO"].ToString() : string.Empty;
                    tcm.DON_VI_NHAN = dr["DON_VI_NHAN"] != DBNull.Value ? dr["DON_VI_NHAN"].ToString() : string.Empty;
                    tcm.NGUOI_NHAN = dr["NGUOI_NHAN"] != DBNull.Value ? dr["NGUOI_NHAN"].ToString() : string.Empty;
                    tcm.NGUOI_GIAO = dr["NGUOI_GIAO"] != DBNull.Value ? dr["NGUOI_GIAO"].ToString() : string.Empty;
                    tcm.NGAY_GIAO = dr["NGAY_GIAO"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_GIAO"]) : DateTime.MinValue;
                    tcm.NGAY_NHAN = dr["NGAY_NHAN"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_NHAN"]) : DateTime.MinValue;
                    tcm.LOAI_BBAN = dr["LOAI_BBAN"] != DBNull.Value ? Convert.ToInt32(dr["LOAI_BBAN"]) : 0;
                    tcm.NOI_DUNG = dr["NOI_DUNG"] != DBNull.Value ? dr["NOI_DUNG"].ToString() : string.Empty;
                    tcm.TRANG_THAI = dr["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(dr["TRANG_THAI"]) : 0;

                    result.Add(tcm);
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
        public List<QLKC_C4_GIAONHAN_TEMCHI_Model> getAll_QLKC_C4_GIAONHAN_TEMCHI()
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.getAll_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<QLKC_C4_GIAONHAN_TEMCHI_Model> result = new List<QLKC_C4_GIAONHAN_TEMCHI_Model>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    QLKC_C4_GIAONHAN_TEMCHI_Model tcm = new QLKC_C4_GIAONHAN_TEMCHI_Model();
                    tcm.ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                    tcm.SO_LUONG_GIAO = dr["SO_LUONG_GIAO"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_GIAO"]) : 0;
                    tcm.SO_LUONG_TRA = dr["SO_LUONG_TRA"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_TRA"]) : 0;
                    tcm.SO_LUONG_THUHOI = dr["SO_LUONG_THUHOI"] != DBNull.Value ? Convert.ToInt32(dr["SO_LUONG_THUHOI"]) : 0;
                    tcm.LOAI = dr["LOAI"] != DBNull.Value ? dr["LOAI"].ToString() : string.Empty;
                    tcm.DONVI_TINH = dr["DONVI_TINH"] != DBNull.Value ? dr["DONVI_TINH"].ToString() : string.Empty;
                    tcm.DON_VI_GIAO = dr["DON_VI_GIAO"] != DBNull.Value ? dr["DON_VI_GIAO"].ToString() : string.Empty;
                    tcm.DON_VI_NHAN = dr["DON_VI_NHAN"] != DBNull.Value ? dr["DON_VI_NHAN"].ToString() : string.Empty;
                    tcm.NGUOI_NHAN = dr["NGUOI_NHAN"] != DBNull.Value ? dr["NGUOI_NHAN"].ToString() : string.Empty;
                    tcm.NGUOI_GIAO = dr["NGUOI_GIAO"] != DBNull.Value ? dr["NGUOI_GIAO"].ToString() : string.Empty;
                    tcm.NGAY_GIAO = dr["NGAY_GIAO"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_GIAO"]) : DateTime.MinValue;
                    tcm.NGAY_NHAN = dr["NGAY_NHAN"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_NHAN"]) : DateTime.MinValue;
                    tcm.LOAI_BBAN = dr["LOAI_BBAN"] != DBNull.Value ? Convert.ToInt32(dr["LOAI_BBAN"]) : 0;
                    tcm.NOI_DUNG = dr["NOI_DUNG"] != DBNull.Value ? dr["NOI_DUNG"].ToString() : string.Empty;
                    tcm.TRANG_THAI = dr["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(dr["TRANG_THAI"]) : 0;
                    result.Add(tcm);
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
        public QLKC_C4_GIAONHAN_TEMCHI_Model create_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.create_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.SO_LUONG_GIAO);
                cmd.Parameters.Add("p_SO_LUONG_GIAO", tc.SO_LUONG_GIAO);
                cmd.Parameters.Add("p_SO_LUONG_TRA", tc.SO_LUONG_TRA);
                cmd.Parameters.Add("p_SO_LUONG_THUHOI", tc.SO_LUONG_THUHOI);
                cmd.Parameters.Add("p_LOAI", tc.LOAI);
                cmd.Parameters.Add("p_DONVI_TINH", tc.DONVI_TINH);
                cmd.Parameters.Add("p_DON_VI_GIAO", tc.DON_VI_GIAO);
                cmd.Parameters.Add("p_DON_VI_NHAN", tc.DON_VI_NHAN);
                cmd.Parameters.Add("p_NGUOI_NHAN", tc.NGUOI_NHAN);
                cmd.Parameters.Add("p_NGUOI_GIAO", tc.NGUOI_GIAO);
                cmd.Parameters.Add("p_NGAY_GIAO", tc.NGAY_GIAO);
                cmd.Parameters.Add("p_NGAY_NHAN", tc.NGAY_NHAN);
                cmd.Parameters.Add("p_LOAI_BBAN", tc.LOAI_BBAN);
                cmd.Parameters.Add("p_NOI_DUNG", tc.NOI_DUNG);
                cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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
        public QLKC_C4_GIAONHAN_TEMCHI_Model create_PM_QLKC_C4_MUON_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.create_PM_QLKC_C4_MUON_TEMCHI";
                cmd.Parameters.Add("p_SO_LUONG_GIAO", tc.SO_LUONG_GIAO);
                cmd.Parameters.Add("p_SO_LUONG_TRA", tc.SO_LUONG_TRA);
                cmd.Parameters.Add("p_SO_LUONG_THUHOI", tc.SO_LUONG_THUHOI);
                cmd.Parameters.Add("p_LOAI", tc.LOAI);
                cmd.Parameters.Add("p_DONVI_TINH", tc.DONVI_TINH);
                cmd.Parameters.Add("p_DON_VI_GIAO", tc.DON_VI_GIAO);
                cmd.Parameters.Add("p_DON_VI_NHAN", tc.DON_VI_NHAN);
                cmd.Parameters.Add("p_NGUOI_NHAN", tc.NGUOI_NHAN);
                cmd.Parameters.Add("p_NGUOI_GIAO", tc.NGUOI_GIAO);
                cmd.Parameters.Add("p_NGAY_GIAO", tc.NGAY_GIAO);
                cmd.Parameters.Add("p_NGAY_NHAN", tc.NGAY_NHAN);
                cmd.Parameters.Add("p_LOAI_BBAN", tc.LOAI_BBAN);
                cmd.Parameters.Add("p_NOI_DUNG", tc.NOI_DUNG);
                cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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
        public QLKC_C4_GIAONHAN_TEMCHI_Model create_PQT_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.create_PQT_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.ID);
                cmd.Parameters.Add("p_SO_LUONG_TRA", tc.SO_LUONG_TRA);
                cmd.Parameters.Add("p_SO_LUONG_THUHOI", tc.SO_LUONG_THUHOI);
                cmd.Parameters.Add("p_LOAI", tc.LOAI);
                cmd.Parameters.Add("p_DONVI_TINH", tc.DONVI_TINH);
                cmd.Parameters.Add("p_DON_VI_GIAO", tc.DON_VI_GIAO);
                cmd.Parameters.Add("p_DON_VI_NHAN", tc.DON_VI_NHAN);
                cmd.Parameters.Add("p_NGUOI_NHAN", tc.NGUOI_NHAN);
                cmd.Parameters.Add("p_NGUOI_GIAO", tc.NGUOI_GIAO);
                cmd.Parameters.Add("p_NGAY_GIAO", tc.NGAY_GIAO);
                cmd.Parameters.Add("p_NGAY_NHAN", tc.NGAY_NHAN);
                cmd.Parameters.Add("p_LOAI_BBAN", tc.LOAI_BBAN);
                cmd.Parameters.Add("p_NOI_DUNG", tc.NOI_DUNG);
                cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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
        public QLKC_C4_GIAONHAN_TEMCHI_Model update_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.ID);
                cmd.Parameters.Add("p_SO_LUONG_GIAO", tc.SO_LUONG_GIAO);
                cmd.Parameters.Add("p_SO_LUONG_TRA", tc.SO_LUONG_TRA);
                cmd.Parameters.Add("p_SO_LUONG_THUHOI", tc.SO_LUONG_THUHOI);
                cmd.Parameters.Add("p_LOAI", tc.LOAI);
                cmd.Parameters.Add("p_DONVI_TINH", tc.DONVI_TINH);
                cmd.Parameters.Add("p_DON_VI_GIAO", tc.DON_VI_GIAO);
                cmd.Parameters.Add("p_DON_VI_NHAN", tc.DON_VI_NHAN);
                cmd.Parameters.Add("p_NGUOI_NHAN", tc.NGUOI_NHAN);
                cmd.Parameters.Add("p_NGUOI_GIAO", tc.NGUOI_GIAO);
                cmd.Parameters.Add("p_NGAY_GIAO", tc.NGAY_GIAO);
                cmd.Parameters.Add("p_NGAY_NHAN", tc.NGAY_NHAN);
                cmd.Parameters.Add("p_NOI_DUNG", tc.NOI_DUNG);
                cmd.Parameters.Add("p_LOAI_BBAN", tc.LOAI_BBAN);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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
        public QLKC_C4_GIAONHAN_TEMCHI_Model update_CD_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_CD_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.ID);
                cmd.Parameters.Add("p_SO_LUONG_GIAO", tc.SO_LUONG_GIAO);
                cmd.Parameters.Add("p_SO_LUONG_TRA", tc.SO_LUONG_TRA);
                cmd.Parameters.Add("p_SO_LUONG_THUHOI", tc.SO_LUONG_THUHOI);
                cmd.Parameters.Add("p_LOAI", tc.LOAI);
                cmd.Parameters.Add("p_DONVI_TINH", tc.DONVI_TINH);
                cmd.Parameters.Add("p_DON_VI_GIAO", tc.DON_VI_GIAO);
                cmd.Parameters.Add("p_DON_VI_NHAN", tc.DON_VI_NHAN);
                cmd.Parameters.Add("p_NGUOI_NHAN", tc.NGUOI_NHAN);
                cmd.Parameters.Add("p_NGUOI_GIAO", tc.NGUOI_GIAO);
                cmd.Parameters.Add("p_NGAY_GIAO", tc.NGAY_GIAO);
                cmd.Parameters.Add("p_NGAY_NHAN", tc.NGAY_NHAN);
                //cmd.Parameters.Add("p_LOAI_BBAN", tc.LOAI_BBAN);
                cmd.Parameters.Add("p_NOI_DUNG", tc.NOI_DUNG);
                //cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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

        public QLKC_C4_GIAONHAN_TEMCHI_Model update_kyC1_PM_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_kyC1_PM_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.ID);
                cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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

        public QLKC_C4_GIAONHAN_TEMCHI_Model update_kyC1_PQT_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"update_kyC1_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = tc.ID;
                cmd.Parameters.Add("p_Error", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                string pError = cmd.Parameters["p_Error"].Value.ToString();

                if (!string.IsNullOrEmpty(pError))
                {
                    throw new Exception($"Stored procedure error: {pError}");
                }

                transaction.Commit();
                return tc;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

        }
        public QLKC_C4_GIAONHAN_TEMCHI_Model update_kyC2_PM_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_kyC2_PM_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.ID);
                cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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
        public QLKC_C4_GIAONHAN_TEMCHI_Model update_kyC2_PQT_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_kyC2_PQT_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.ID);
                cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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

        public bool update_huyPM_QLKC_C4_GIAONHAN_TEMCHI(int id)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_huyPM_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id;
                //cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG-_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
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
        public QLKC_C4_GIAONHAN_TEMCHI_Model update_TL_PM_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_TL_PM_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.ID);
                cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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
        public QLKC_C4_GIAONHAN_TEMCHI_Model update_TL_PQT_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI_Model tc)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_TL_PQT_QLKC_C4_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID", tc.ID);
                cmd.Parameters.Add("p_TRANG_THAI", tc.TRANG_THAI);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return tc;
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

        public bool delete_QLKC_C4_GIAONHAN_TEMCHI(int id)
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
                    cmd.CommandText = @"PKG_QLKC_CHIEN.delete_QLKC_C4_GIAONHAN_TEMCHI";
                    cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id;
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
        public bool update_kyC1_QLKC_C4_GIAONHAN_TEMCHI(int id)
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
                    cmd.CommandText = @"PKG_QLKC_CHIEN.update_kyC1_QLKC_C4_GIAONHAN_TEMCHI";
                    cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id;
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
        public bool update_kyC2_QLKC_C4_GIAONHAN_TEMCHI(int id)
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
                    cmd.CommandText = @"PKG_QLKC_CHIEN.update_kyC2_QLKC_C4_GIAONHAN_TEMCHI";
                    cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id;
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
        public List<HTNguoiDungDTO> get_HT_NGUOIDUNGbyMA_DVIQLY(string p_MA_DVIQLY)
        {
            List<HTNguoiDungDTO> result = new List<HTNguoiDungDTO>();

            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"PKG_QLKC_CHIEN.get_HT_NGUOIDUNGbyMA_DVIQLY";
                    cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_MA_DVIQLY", OracleDbType.Varchar2).Value = p_MA_DVIQLY;

                    OracleDataAdapter dap = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dap.Fill(ds);

                    // Xử lý dữ liệu phân trang
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            HTNguoiDungDTO user = new HTNguoiDungDTO
                            {
                                ID = dr["ID"].ToString(),
                                DM_DONVI_ID = dr["DM_DONVI_ID"].ToString(),
                                DM_PHONGBAN_ID = dr["DM_PHONGBAN_ID"].ToString(),
                                DM_CHUCVU_ID = dr["DM_CHUCVU_ID"].ToString(),
                                TEN_DANG_NHAP = dr["TEN_DANG_NHAP"].ToString(),
                                MAT_KHAU = dr["MAT_KHAU"].ToString(),
                                HO_TEN = dr["HO_TEN"].ToString(),
                                EMAIL = dr["EMAIL"].ToString(),
                                LDAP = dr["LDAP"].ToString(),
                                TRANG_THAI = dr["TRANG_THAI"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["TRANG_THAI"]),
                                NGAY_TAO = dr["NGAY_TAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NGAY_TAO"]),
                                NGUOI_TAO = dr["NGUOI_TAO"].ToString(),
                                NGAY_CAP_NHAT = dr["NGAY_CAP_NHAT"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NGAY_CAP_NHAT"]),
                                NGUOI_CAP_NHAT = dr["NGUOI_CAP_NHAT"].ToString(),
                                SO_DIEN_THOAI = dr["SO_DIEN_THOAI"].ToString(),
                                GIOI_TINH = dr["GIOI_TINH"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["GIOI_TINH"]),
                                SO_CMND = dr["SO_CMND"].ToString(),
                                TRANG_THAI_DONG_BO = dr["TRANG_THAI_DONG_BO"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["TRANG_THAI_DONG_BO"]),
                                ROLEID = dr["ROLEID"].ToString(),
                                PHONG_BAN = dr["PHONG_BAN"].ToString(),
                                ANHDAIDIEN = dr["ANHDAIDIEN"].ToString()
                            };

                            result.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while fetching data.", ex);
                }
            }

            return result;
        }

    }
}
