using APIPCHY.Helpers;
using System.Collections.Generic;
using System.Data;
using System;
using APIPCHY_PhanQuyen.Models.QLKC.C3_GIAONHAN_TEMCHI;

namespace APIPCHY_PhanQuyen.Models.QLKC.C3_GIAONHAN_TEMCHI
{
    public class C3_GIAONHAN_TEMCHI_Manager
    {
        DataHelper helper = new DataHelper();
        public string insert_QLKC_C3_GIAONHAN_TEMCHI(C3_GIAONHAN_TEMCHI_Model tcgn)
        {
            try
            {
                Console.WriteLine("test");
                Guid id = Guid.NewGuid();
                string str_id = id.ToString();
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.insert_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                    "p_SOLUONG", "p_LOAI", "p_DONVI_TINH", "p_DON_VI_GIAO", "p_DON_VI_NHAN", "p_NGUOI_NHAN",
                                                    "p_NGUOI_GIAO", "p_NGAY_GIAO", "p_NGAY_NHAN", "p_TRANG_THAI", "p_LOAI_BBAN",
                                                    tcgn.so_luong, tcgn.loai, tcgn.donvi_tinh, tcgn.don_vi_giao, tcgn.don_vi_nhan, tcgn.nguoi_nhan,
                                                    tcgn.nguoi_giao, tcgn.ngay_giao, tcgn.ngay_nhan, tcgn.trang_thai, tcgn.loai_bban);


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string update_QLKC_C3_GIAONHAN_TEMCHI(C3_GIAONHAN_TEMCHI_Model tcgn)
        {
            try
            {
                string str_id = tcgn.id.ToString();
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.update_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", "p_SOLUONG", "p_LOAI", "p_DONVI_TINH", "p_DON_VI_GIAO", "p_DON_VI_NHAN", "p_NGUOI_NHAN",
                                                      "p_NGUOI_GIAO", "p_NGAY_GIAO", "p_NGAY_NHAN", "p_TRANG_THAI", "p_LOAI_BBAN",
                                                      tcgn.id, tcgn.so_luong, tcgn.loai, tcgn.donvi_tinh, tcgn.don_vi_giao, tcgn.don_vi_nhan, tcgn.nguoi_nhan,
                                                      tcgn.nguoi_giao, tcgn.ngay_giao, tcgn.ngay_nhan, tcgn.trang_thai, tcgn.loai_bban);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string delete_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.delete_QLKC_C3_GIAONHAN_TEMCHI", "p_Error", "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<C3_GIAONHAN_TEMCHI_Model> search_QLKC_C3_GIAONHAN_TEMCHI(int? pageSize, int? pageIndex, string? don_vi_giao, string? nguoi_nhan, int? loai_bban, out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_SANG.search_QLKC_C3_GIAONHAN_TEMCHI", "p_page_index", "p_page_size",
                                                   "p_DON_VI_GIAO", "p_NGUOI_NHAN", "p_LOAI_BBAN", pageIndex, pageSize, don_vi_giao, nguoi_nhan, loai_bban);
                var count = ds.Rows.Count;

                if (pageSize > 0 && pageIndex > 0 && count > 0)
                {
                    totalItems = int.Parse(ds.Rows[0]["RecordCount"].ToString());
                }
                if (ds == null || ds.Rows.Count == 0)
                {
                    totalItems = 0;
                    return new List<C3_GIAONHAN_TEMCHI_Model>();
                }


                List<C3_GIAONHAN_TEMCHI_Model> list = new List<C3_GIAONHAN_TEMCHI_Model>();
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    C3_GIAONHAN_TEMCHI_Model tcgn = new C3_GIAONHAN_TEMCHI_Model();
                    tcgn.id = int.Parse(ds.Rows[0]["ID"].ToString());
                    tcgn.so_luong = ds.Rows[i]["SOLUONG"] != DBNull.Value ? int.Parse(ds.Rows[i]["SOLUONG"].ToString()) : null;
                    tcgn.loai = ds.Rows[i]["LOAI"] != DBNull.Value ? ds.Rows[i]["LOAI"].ToString() : null;
                    tcgn.donvi_tinh = ds.Rows[i]["DONVI_TINH"] != DBNull.Value ? ds.Rows[i]["DONVI_TINH"].ToString() : null;
                    tcgn.don_vi_giao = ds.Rows[i]["DON_VI_GIAO"] != DBNull.Value ? ds.Rows[i]["DON_VI_GIAO"].ToString() : null;
                    tcgn.don_vi_nhan = ds.Rows[i]["DON_VI_NHAN"] != DBNull.Value ? ds.Rows[i]["DON_VI_NHAN"].ToString() : null;
                    tcgn.nguoi_nhan = ds.Rows[i]["NGUOI_NHAN"] != DBNull.Value ? ds.Rows[i]["NGUOI_NHAN"].ToString() : null;
                    tcgn.nguoi_giao = ds.Rows[i]["NGUOI_GIAO"] != DBNull.Value ? ds.Rows[i]["NGUOI_GIAO"].ToString() : null;
                    tcgn.ngay_giao = ds.Rows[i]["NGAY_GIAO"] != DBNull.Value ? DateTime.Parse(ds.Rows[i]["NGAY_GIAO"].ToString()) : null;
                    tcgn.ngay_nhan = ds.Rows[i]["NGAY_NHAN"] != DBNull.Value ? DateTime.Parse(ds.Rows[i]["NGAY_NHAN"].ToString()) : null;
                    tcgn.trang_thai = ds.Rows[i]["TRANG_THAI"] != DBNull.Value ? int.Parse(ds.Rows[i]["TRANG_THAI"].ToString()) : null;
                    tcgn.loai_bban = ds.Rows[i]["LOAI_BBAN"] != DBNull.Value ? int.Parse(ds.Rows[i]["LOAI_BBAN"].ToString()) : null;

                    list.Add(tcgn);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public C3_GIAONHAN_TEMCHI_Model get_QLKC_C3_GIAONHAN_TEMCHI_ByID(int id)
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_SANG.get_QLKC_C3_GIAONHAN_TEMCHI_byID", "p_ID", id);

                if (ds != null)
                {
                    C3_GIAONHAN_TEMCHI_Model tcgn = new C3_GIAONHAN_TEMCHI_Model();

                    tcgn.id = int.Parse(ds.Rows[0]["ID"].ToString());
                    tcgn.so_luong = ds.Rows[0]["SOLUONG"] != DBNull.Value ? int.Parse(ds.Rows[0]["SOLUONG"].ToString()) : null;
                    tcgn.loai = ds.Rows[0]["LOAI"] != DBNull.Value ? ds.Rows[0]["LOAI"].ToString() : null;
                    tcgn.donvi_tinh = ds.Rows[0]["DONVI_TINH"] != DBNull.Value ? ds.Rows[0]["DONVI_TINH"].ToString() : null;
                    tcgn.don_vi_giao = ds.Rows[0]["DON_VI_GIAO"] != DBNull.Value ? ds.Rows[0]["DON_VI_GIAO"].ToString() : null;
                    tcgn.don_vi_nhan = ds.Rows[0]["DON_VI_NHAN"] != DBNull.Value ? ds.Rows[0]["DON_VI_NHAN"].ToString() : null;
                    tcgn.nguoi_nhan = ds.Rows[0]["NGUOI_NHAN"] != DBNull.Value ? ds.Rows[0]["NGUOI_NHAN"].ToString() : null;
                    tcgn.nguoi_giao = ds.Rows[0]["NGUOI_GIAO"] != DBNull.Value ? ds.Rows[0]["NGUOI_GIAO"].ToString() : null;
                    tcgn.ngay_giao = ds.Rows[0]["NGAY_GIAO"] != DBNull.Value ? DateTime.Parse(ds.Rows[0]["NGAY_GIAO"].ToString()) : null;
                    tcgn.ngay_nhan = ds.Rows[0]["NGAY_NHAN"] != DBNull.Value ? DateTime.Parse(ds.Rows[0]["NGAY_NHAN"].ToString()) : null;
                    tcgn.trang_thai = ds.Rows[0]["TRANG_THAI"] != DBNull.Value ? int.Parse(ds.Rows[0]["TRANG_THAI"].ToString()) : null;
                    tcgn.loai_bban = ds.Rows[0]["LOAI_BBAN"] != DBNull.Value ? int.Parse(ds.Rows[0]["LOAI_BBAN"].ToString()) : null;

                    return tcgn;

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