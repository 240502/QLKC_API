using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;
using APIPCHY_PhanQuyen.Models.QLKC.QLKC_NHAP_CHI_TEM;

namespace APIPCHY_PhanQuyen.Models.QLKC.QLKC_C4_CHITIET_QUYETTOANCHI
{
    public class QLKC_C4_CHITIET_QUYETTOANCHI_Manager
    {
         DataHelper helper = new DataHelper();
        public List<QLKC_C4_CHITIET_QUYETTOANCHI_Model> search_QLKC_C4_CHITIET_QUYETTOANCHI(int? pageIndex, int? pageSize, string maKhachHang, string tenKhachHang,string tenTBA,string idGiaoNhanTemChi, out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable ds = helper.ExcuteReader(
                    "PKG_QLKC_CHIEN.search_QLKC_C4_CHITIET_QUYETTOANCHI",
                    "p_page_index", "p_page_size",
                    "p_MA_KHACH_HANG", "p_TEN_KHACH_HANG",
                    "p_TEN_TBA", "p_ID_GIAONHAN_TEMCHI",
                    pageIndex,
                    pageSize,
                    string.IsNullOrEmpty(maKhachHang) ? DBNull.Value : (object)maKhachHang,
                    string.IsNullOrEmpty(tenKhachHang) ? DBNull.Value : (object)tenKhachHang,
                    string.IsNullOrEmpty(tenTBA) ? DBNull.Value : (object)tenTBA,
                    string.IsNullOrEmpty(idGiaoNhanTemChi) ? DBNull.Value : (object)idGiaoNhanTemChi
                );

                // Lấy tổng số items
                totalItems = ds.Rows.Count > 0 ? int.Parse(ds.Rows[0]["RECORDCOUNT"].ToString()) : 0;

                // Tạo danh sách kết quả
                List<QLKC_C4_CHITIET_QUYETTOANCHI_Model> result = new List<QLKC_C4_CHITIET_QUYETTOANCHI_Model>();

                // Duyệt và ánh xạ dữ liệu
                foreach (DataRow dr in ds.Rows)
                {
                    result.Add(new QLKC_C4_CHITIET_QUYETTOANCHI_Model
                    {
                        ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0,
                        ID_GIAONHAN_TEMCHI = dr["ID_GIAONHAN_TEMCHI"] != DBNull.Value ? Convert.ToInt32(dr["ID_GIAONHAN_TEMCHI"]) : 0,
                        MA_KHACH_HANG = dr["MA_KHACH_HANG"] != DBNull.Value ? dr["MA_KHACH_HANG"].ToString() : string.Empty,
                        TEN_KHACH_HANG = dr["TEN_KHACH_HANG"] != DBNull.Value ? dr["TEN_KHACH_HANG"].ToString() : string.Empty,
                        HOP = dr["HOP"] != DBNull.Value ? Convert.ToInt32(dr["HOP"]) : 0,
                        COT = dr["COT"] != DBNull.Value ? Convert.ToInt32(dr["COT"]) : 0,
                        TEN_TBA = dr["TEN_TBA"] != DBNull.Value ? dr["TEN_TBA"].ToString() : string.Empty,
                        BOOC_CONGQUANG = dr["BOOC_CONGQUANG"] != DBNull.Value ? Convert.ToInt32(dr["BOOC_CONGQUANG"]) : 0,
                        CUA_TU = dr["CUA_TU"] != DBNull.Value ? Convert.ToInt32(dr["CUA_TU"]) : 0,
                        CHUP_BUZI_TI_TU = dr["CHUP_BUZI_TI_TU"] != DBNull.Value ? Convert.ToInt32(dr["CHUP_BUZI_TI_TU"]) : 0,
                        LY_DO = dr["LY_DO"] != DBNull.Value ? dr["LY_DO"].ToString() : string.Empty,
                        NGAY_NIEM_PHONG = dr["NGAY_NIEM_PHONG"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_NIEM_PHONG"]) : (DateTime?)null,
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<QLKC_C4_CHITIET_QUYETTOANCHI_Model> get_CHITIET_QUYETTOANCHI_byID_GIAONHAN_TEMCHI(int idGiaoNhanTemChi)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<QLKC_C4_CHITIET_QUYETTOANCHI_Model>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLKC_CHIEN.get_CHITIET_QUYETTOANCHI_byID_GIAONHAN_TEMCHI";
                cmd.Parameters.Add("p_ID_GIAONHAN_TEMCHI", OracleDbType.Int32).Value = idGiaoNhanTemChi;
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<QLKC_C4_CHITIET_QUYETTOANCHI_Model> result = new List<QLKC_C4_CHITIET_QUYETTOANCHI_Model>();

                // Đọc dữ liệu từ DataSet
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    QLKC_C4_CHITIET_QUYETTOANCHI_Model ctqt = new QLKC_C4_CHITIET_QUYETTOANCHI_Model();
                    ctqt.ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                    ctqt.ID_GIAONHAN_TEMCHI = dr["ID_GIAONHAN_TEMCHI"] != DBNull.Value ? Convert.ToInt32(dr["ID_GIAONHAN_TEMCHI"]) : 0;
                    ctqt.MA_KHACH_HANG = dr["MA_KHACH_HANG"] != DBNull.Value ? dr["MA_KHACH_HANG"].ToString() : string.Empty;
                    ctqt.TEN_KHACH_HANG = dr["TEN_KHACH_HANG"] != DBNull.Value ? dr["TEN_KHACH_HANG"].ToString() : string.Empty;
                    ctqt.HOP = dr["HOP"] != DBNull.Value ? Convert.ToInt32(dr["HOP"]) : 0;
                    ctqt.COT = dr["COT"] != DBNull.Value ? Convert.ToInt32(dr["COT"]) : 0;
                    ctqt.TEN_TBA = dr["TEN_TBA"] != DBNull.Value ? dr["TEN_TBA"].ToString() : string.Empty;
                    ctqt.BOOC_CONGQUANG = dr["BOOC_CONGQUANG"] != DBNull.Value ? Convert.ToInt32(dr["BOOC_CONGQUANG"]) : 0;
                    ctqt.CUA_TU = dr["CUA_TU"] != DBNull.Value ? Convert.ToInt32(dr["CUA_TU"]) : 0;
                    ctqt.CHUP_BUZI_TI_TU = dr["CHUP_BUZI_TI_TU"] != DBNull.Value ? Convert.ToInt32(dr["CHUP_BUZI_TI_TU"]) : 0;
                    ctqt.LY_DO = dr["LY_DO"] != DBNull.Value ? dr["LY_DO"].ToString() : string.Empty;
                    ctqt.NGAY_NIEM_PHONG = dr["NGAY_NIEM_PHONG"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_NIEM_PHONG"]) : (DateTime?)null;
                    result.Add(ctqt);
                }
                return result;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi truy vấn
                throw ex;
            }
            finally
            {
                // Đảm bảo kết nối được đóng
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }


        // Phương thức tìm kiếm QLKC_C4_CHITIET_QUYETTOANCHI
        public List<QLKC_C4_CHITIET_QUYETTOANCHI_Model> search_QLKC_C4_CHITIET_QUYETTOANCHI(int? pageIndex, int? pageSize, string maKhachHang, out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable ds = helper.ExcuteReader(
                    "PKG_QLKC_CHIEN.search_QLKC_C4_CHITIET_QUYETTOANCHI",
                    "p_page_index", "p_page_size",
                    "p_MA_KHACH_HANG",
                    pageIndex,
                    pageSize,
                    string.IsNullOrEmpty(maKhachHang) ? DBNull.Value : (object)maKhachHang
                );

                // Lấy tổng số items
                totalItems = ds.Rows.Count > 0 ? int.Parse(ds.Rows[0]["RECORDCOUNT"].ToString()) : 0;

                // Tạo danh sách kết quả
                List<QLKC_C4_CHITIET_QUYETTOANCHI_Model> result = new List<QLKC_C4_CHITIET_QUYETTOANCHI_Model>();

                // Duyệt và ánh xạ dữ liệu
                foreach (DataRow dr in ds.Rows)
                {
                    result.Add(new QLKC_C4_CHITIET_QUYETTOANCHI_Model
                    {
                        ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0,
                        MA_KHACH_HANG = dr["MA_KHACH_HANG"] != DBNull.Value ? dr["MA_KHACH_HANG"].ToString() : string.Empty,
                        TEN_KHACH_HANG = dr["TEN_KHACH_HANG"] != DBNull.Value ? dr["TEN_KHACH_HANG"].ToString() : string.Empty,
                        HOP = dr["HOP"] != DBNull.Value ? Convert.ToInt32(dr["HOP"]) : 0,
                        COT = dr["COT"] != DBNull.Value ? Convert.ToInt32(dr["COT"]) : 0,
                        TEN_TBA = dr["TEN_TBA"] != DBNull.Value ? dr["TEN_TBA"].ToString() : string.Empty,
                        BOOC_CONGQUANG = dr["BOOC_CONGQUANG"] != DBNull.Value ? Convert.ToInt32(dr["BOOC_CONGQUANG"]) : 0,
                        CUA_TU = dr["CUA_TU"] != DBNull.Value ? Convert.ToInt32(dr["CUA_TU"]) : 0,
                        CHUP_BUZI_TI_TU = dr["CHUP_BUZI_TI_TU"] != DBNull.Value ? Convert.ToInt32(dr["CHUP_BUZI_TI_TU"]) : 0,
                        LY_DO = dr["LY_DO"] != DBNull.Value ? dr["LY_DO"].ToString() : string.Empty,
                        NGAY_NIEM_PHONG = dr["NGAY_NIEM_PHONG"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_NIEM_PHONG"]) : (DateTime?)null
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Phương thức thêm một bản ghi QLKC_C4_CHITIET_QUYETTOANCHI
        public QLKC_C4_CHITIET_QUYETTOANCHI_Model create_C4_CHITIET_QUYETTOANCHI(QLKC_C4_CHITIET_QUYETTOANCHI_Model qlKC)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.create_QLKC_C4_CHITIET_QUYETTOANCHI";
                cmd.Parameters.Add("p_ID_GIAONHAN_TEMCHI", qlKC.ID_GIAONHAN_TEMCHI);
                cmd.Parameters.Add("p_MA_KHACH_HANG", qlKC.MA_KHACH_HANG);
                cmd.Parameters.Add("p_TEN_KHACH_HANG", qlKC.TEN_KHACH_HANG);
                cmd.Parameters.Add("p_HOP", qlKC.HOP);
                cmd.Parameters.Add("p_COT", qlKC.COT);
                cmd.Parameters.Add("p_TEN_TBA", qlKC.TEN_TBA);
                cmd.Parameters.Add("p_BOOC_CONGQUANG", qlKC.BOOC_CONGQUANG);
                cmd.Parameters.Add("p_CUA_TU", qlKC.CUA_TU);
                cmd.Parameters.Add("p_CHUP_BUZI_TI_TU", qlKC.CHUP_BUZI_TI_TU);
                cmd.Parameters.Add("p_LY_DO", qlKC.LY_DO);
                cmd.Parameters.Add("p_NGAY_NIEM_PHONG", qlKC.NGAY_NIEM_PHONG);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return qlKC;
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

        // Phương thức sửa một bản ghi QLKC_C4_CHITIET_QUYETTOANCHI
        public QLKC_C4_CHITIET_QUYETTOANCHI_Model update_QLKC_C4_CHITIET_QUYETTOANCHI(QLKC_C4_CHITIET_QUYETTOANCHI_Model qlKC)
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
                cmd.CommandText = @"PKG_QLKC_CHIEN.update_QLKC_C4_CHITIET_QUYETTOANCHI";
                cmd.Parameters.Add("p_ID", qlKC.ID);
                cmd.Parameters.Add("p_ID_GIAONHAN_TEMCHI", qlKC.ID_GIAONHAN_TEMCHI);
                cmd.Parameters.Add("p_MA_KHACH_HANG", qlKC.MA_KHACH_HANG);
                cmd.Parameters.Add("p_TEN_KHACH_HANG", qlKC.TEN_KHACH_HANG);
                cmd.Parameters.Add("p_HOP", qlKC.HOP);
                cmd.Parameters.Add("p_COT", qlKC.COT);
                cmd.Parameters.Add("p_TEN_TBA", qlKC.TEN_TBA);
                cmd.Parameters.Add("p_BOOC_CONGQUANG", qlKC.BOOC_CONGQUANG);
                cmd.Parameters.Add("p_CUA_TU", qlKC.CUA_TU);
                cmd.Parameters.Add("p_CHUP_BUZI_TI_TU", qlKC.CHUP_BUZI_TI_TU);
                cmd.Parameters.Add("p_LY_DO", qlKC.LY_DO);
                cmd.Parameters.Add("p_NGAY_NIEM_PHONG", qlKC.NGAY_NIEM_PHONG);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return qlKC;
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

        // Phương thức xóa một bản ghi QLKC_C4_CHITIET_QUYETTOANCHI
        public bool delete_QLKC_C4_CHITIET_QUYETTOANCHI(int id)
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
                    cmd.CommandText = @"PKG_QLKC_CHIEN.delete_QLKC_C4_CHITIET_QUYETTOANCHI";
                    cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id;
                    cmd.Parameters.Add("p_Error", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
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
        }
    }
}
