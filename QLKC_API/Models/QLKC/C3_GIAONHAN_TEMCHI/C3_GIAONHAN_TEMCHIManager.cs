using APIPCHY.Helpers;
using System.Collections.Generic;
using System.Data;
using System;

namespace QLKC_API.Models.QLKC.C3_GIAONHAN_TEMCHI
{
    public class C3_GIAONHAN_TEMCHI_Manager

    {
        DataHelper helper = new DataHelper();
        public List<C3_GIAONHAN_TEMCHI_Model> getALL_QLKC_C3_GIAONHAN_TEMCHI()
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_SANG.getAll_QLKC_C3_GIAONHAN_TEMCHI");
                List<C3_GIAONHAN_TEMCHI_Model> result = new List<C3_GIAONHAN_TEMCHI_Model>();
                if (ds != null)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        C3_GIAONHAN_TEMCHI_Model tcgn = new C3_GIAONHAN_TEMCHI_Model();

                        tcgn.id = int.Parse(ds.Rows[i]["ID"].ToString());

                        tcgn.soluong = ds.Rows[i]["SOLUONG"] != DBNull.Value ? int.Parse(ds.Rows[i]["SOLUONG"].ToString()) : null;
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
                        tcgn.ten_dv = ds.Rows[i]["TEN_DV"] != DBNull.Value ? ds.Rows[i]["TEN_DV"].ToString() : null;
                        tcgn.ten_pb = ds.Rows[i]["TEN_PB"] != DBNull.Value ? ds.Rows[i]["TEN_PB"].ToString() : null;

                        result.Add(tcgn);
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
        public string insert_QLKC_C3_GIAONHAN_TEMCHI(C3_GIAONHAN_TEMCHI_Model tcgn)
        {
            try
            {
                Console.WriteLine("test");
                Guid id = Guid.NewGuid();
                string str_id = id.ToString();
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.create_PM_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                    "p_SOLUONG", "p_LOAI", "p_DONVI_TINH", "p_DON_VI_GIAO", "p_DON_VI_NHAN", "p_NGUOI_NHAN",
                                                    "p_NGUOI_GIAO", "p_NGAY_GIAO", "p_NGAY_NHAN", "p_TRANG_THAI", "p_LOAI_BBAN",
                                                    tcgn.soluong, tcgn.loai, tcgn.donvi_tinh, tcgn.don_vi_giao, tcgn.don_vi_nhan, tcgn.nguoi_nhan,
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
                                                      tcgn.id, tcgn.soluong, tcgn.loai, tcgn.donvi_tinh, tcgn.don_vi_giao, tcgn.don_vi_nhan, tcgn.nguoi_nhan,
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


        public List<C3_GIAONHAN_TEMCHI_Model> search_QLKC_C3_GIAONHAN_TEMCHI(int? pageIndex, int? pageSize, string? don_vi_giao, string? don_vi_nhan, int? trang_thai, string? loai, out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable db = helper.ExcuteReader("PKG_QLKC_HUYEN.search_QLKC_C3_GIAONHAN_TEMCHI", "p_page_index", "p_page_size", "p_don_vi_giao", "p_don_vi_nhan", "p_trang_thai", "p_loai", pageIndex, pageSize, don_vi_giao, don_vi_nhan, trang_thai, loai);

                if (db != null)
                {
                    totalItems = int.Parse(db.Rows[0]["RecordCount"].ToString());
                    List<C3_GIAONHAN_TEMCHI_Model> results = new List<C3_GIAONHAN_TEMCHI_Model>();
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        C3_GIAONHAN_TEMCHI_Model model = new C3_GIAONHAN_TEMCHI_Model();

                        model.id = int.Parse(db.Rows[i]["ID"].ToString());

                        model.soluong = db.Rows[i]["SOLUONG"] != DBNull.Value ? int.Parse(db.Rows[i]["SOLUONG"].ToString()) : null;
                        model.loai = db.Rows[i]["LOAI"] != DBNull.Value ? db.Rows[i]["LOAI"].ToString() : null;
                        model.donvi_tinh = db.Rows[i]["DONVI_TINH"] != DBNull.Value ? db.Rows[i]["DONVI_TINH"].ToString() : null;
                        model.don_vi_giao = db.Rows[i]["DON_VI_GIAO"] != DBNull.Value ? db.Rows[i]["DON_VI_GIAO"].ToString() : null;
                        model.don_vi_nhan = db.Rows[i]["DON_VI_NHAN"] != DBNull.Value ? db.Rows[i]["DON_VI_NHAN"].ToString() : null;
                        model.nguoi_nhan = db.Rows[i]["NGUOI_NHAN"] != DBNull.Value ? db.Rows[i]["NGUOI_NHAN"].ToString() : null;
                        model.nguoi_giao = db.Rows[i]["NGUOI_GIAO"] != DBNull.Value ? db.Rows[i]["NGUOI_GIAO"].ToString() : null;
                        model.ngay_giao = db.Rows[i]["NGAY_GIAO"] != DBNull.Value ? DateTime.Parse(db.Rows[i]["NGAY_GIAO"].ToString()) : null;
                        model.ngay_nhan = db.Rows[i]["NGAY_NHAN"] != DBNull.Value ? DateTime.Parse(db.Rows[i]["NGAY_NHAN"].ToString()) : null;
                        model.trang_thai = db.Rows[i]["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(db.Rows[i]["TRANG_THAI"]) : 0;
                        model.loai_bban = db.Rows[i]["LOAI_BBAN"] != DBNull.Value ? Convert.ToInt32(db.Rows[i]["LOAI_BBAN"]) : 0;
                        model.ten_dv = db.Rows[i]["TEN_DV"] != DBNull.Value ? db.Rows[i]["TEN_DV"].ToString() : null;
                        model.ten_pb = db.Rows[i]["TEN_PB"] != DBNull.Value ? db.Rows[i]["TEN_PB"].ToString() : null;


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

        public C3_GIAONHAN_TEMCHI_Model get_QLKC_C3_GIAONHAN_TEMCHI_ByID(int id)
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_SANG.get_QLKC_C3_GIAONHAN_TEMCHI_byID", "p_ID", id);

                if (ds != null)
                {
                    C3_GIAONHAN_TEMCHI_Model tcgn = new C3_GIAONHAN_TEMCHI_Model();

                    tcgn.id = int.Parse(ds.Rows[0]["ID"].ToString());
                    tcgn.soluong = ds.Rows[0]["SOLUONG"] != DBNull.Value ? int.Parse(ds.Rows[0]["SOLUONG"].ToString()) : null;
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

        public string update_kyC1_PM_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.update_kyC1_PM_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string update_kyC2_PM_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.update_kyC2_PM_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string update_TL_PM_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.update_TL_PM_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string update_kyC1_PQT_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.update_kyC1_PQT_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string update_kyC2_PQT_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.update_kyC2_PQT_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string update_TL_PQT_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.update_TL_PQT_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string update_huyPM_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.update_huyPM_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string update_LoaiBBan_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_HUYEN.update_loaiBBan_QLKC_C3_GIAONHAN_TEMCHI", "p_Error",
                                                      "p_ID", id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}