using APIPCHY.Helpers;
using System.Collections.Generic;
using System.Data;
using System;
using API_PCHY.Models.QLKC.BBAN_BANGIAO_KIM;


namespace API_PCHY.Models.QUAN_TRI.QLKC_KHO_CHI_TEM
{
    public class QLKC_KHO_CHI_TEM_Manager
    {
        DataHelper helper = new DataHelper();

        public string update_QLKC_KHO_CHI_TEM(QLKC_KHO_CHI_TEM_Model qLKC_KHO_CHI_TEM)
        {
            try
            {
                string str_id = qLKC_KHO_CHI_TEM.ID_KHO.ToString();
                     string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.update_QLKC_KHO_CHI_TEM", "p_Error",
                                                            "p_ID_KHO", "p_LOAI", "p_SO_LUONG", "p_THANG", "p_NAM", "p_DON_VI_TINH",
                                                           str_id, qLKC_KHO_CHI_TEM.LOAI, qLKC_KHO_CHI_TEM.SO_LUONG, qLKC_KHO_CHI_TEM.THANG, qLKC_KHO_CHI_TEM.NAM, qLKC_KHO_CHI_TEM.DON_VI_TINH
                                                           );
                      return result;
            }
            catch (Exception ex) {
                throw ex;
            }

        }

        public string delete_QLKC_KHO_CHI_TEM(string ID_KHO)
        {
            try
            {
                string result = helper.ExcuteNonQuery("PKG_QLKC_SANG.delete_QLKC_KHO_CHI_TEM", "p_Error",
                                                    "p_ID_KHO", ID_KHO
                                                    );
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<QLKC_KHO_CHI_TEM_Model> get_All_QLKC_KHO_CHI_TEM()
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_SANG.get_All_QLKC_KHO_CHI_TEM");
                List<QLKC_KHO_CHI_TEM_Model> list = new List<QLKC_KHO_CHI_TEM_Model>();
                if (ds != null)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        QLKC_KHO_CHI_TEM_Model model = new QLKC_KHO_CHI_TEM_Model();
                        model.ID_KHO = ds.Rows[i]["ID_KHO"].ToString();
                        model.LOAI = ds.Rows[i]["LOAI"] != DBNull.Value ? ds.Rows[i]["LOAI"].ToString() : null;
                        model.SO_LUONG = ds.Rows[i]["SO_LUONG"] != DBNull.Value ? ds.Rows[i]["SO_LUONG"].ToString() : null;
                        model.THANG = ds.Rows[i]["THANG"] != DBNull.Value ? ds.Rows[i]["THANG"].ToString() : null;
                        model.NAM = ds.Rows[i]["NAM"] != DBNull.Value ? ds.Rows[i]["NAM"].ToString() : null;
                        model.DON_VI_TINH = ds.Rows[i]["DON_VI_TINH"] != DBNull.Value ? ds.Rows[i]["DON_VI_TINH"].ToString() : null;
                        list.Add(model);
                    }
                }
                else list = null;

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

       

        public QLKC_KHO_CHI_TEM_Model get_QLKC_KHO_CHI_TEMByID_KHO(string ID_KHO)
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_SANG.get_QLKC_KHO_CHI_TEMByID_KHO", "p_ID_KHO", ID_KHO);
                if (ds != null && ds.Rows.Count > 0)
                {
                    QLKC_KHO_CHI_TEM_Model model = new QLKC_KHO_CHI_TEM_Model();
                    
                    model.ID_KHO = ds.Rows[0]["ID_KHO"].ToString();
                    model.LOAI = ds.Rows[0]["LOAI"] != DBNull.Value ? ds.Rows[0]["LOAI"].ToString() : null;
                    model.SO_LUONG = ds.Rows[0]["SO_LUONG"] != DBNull.Value ? ds.Rows[0]["SO_LUONG"].ToString() : null;
                    model.THANG = ds.Rows[0]["THANG"] != DBNull.Value ? ds.Rows[0]["THANG"].ToString() : null;
                    model.NAM = ds.Rows[0]["NAM"] != DBNull.Value ? ds.Rows[0]["NAM"].ToString() : null;
                    model.DON_VI_TINH = ds.Rows[0]["DON_VI_TINH"] != DBNull.Value ? ds.Rows[0]["DON_VI_TINH"].ToString() : null;
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


        public List<QLKC_KHO_CHI_TEM_Model> search_QLKC_KHO_CHI_TEM(int? pageIndex, int? pageSize, string? LOAI, string? THANG, int? NAM, out int totalItems)
        {
            totalItems = 0;
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_THUAN.search_QLKC_KHO_CHI_TEM", "p_page_index", "p_page_size", "p_LOAI", "p_THANG", "p_NAM", pageIndex, pageSize, LOAI, THANG, NAM);

                if (ds != null)
                {
                    totalItems = int.Parse(ds.Rows[0]["RecordCount"].ToString());
                    List<QLKC_KHO_CHI_TEM_Model> results = new List<QLKC_KHO_CHI_TEM_Model>();
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        QLKC_KHO_CHI_TEM_Model model = new QLKC_KHO_CHI_TEM_Model();
                        model.ID_KHO = ds.Rows[i]["ID_KHO"].ToString();
                        model.LOAI = ds.Rows[i]["LOAI"] != DBNull.Value ? ds.Rows[i]["LOAI"].ToString() : null;
                        model.SO_LUONG = ds.Rows[i]["SO_LUONG"] != DBNull.Value ? ds.Rows[i]["SO_LUONG"].ToString() : null;
                        model.THANG = ds.Rows[i]["THANG"] != DBNull.Value ? ds.Rows[i]["THANG"].ToString() : null;
                        model.NAM = ds.Rows[i]["NAM"] != DBNull.Value ? ds.Rows[i]["NAM"].ToString() : null;
                        model.DON_VI_TINH = ds.Rows[i]["DON_VI_TINH"] != DBNull.Value ? ds.Rows[i]["DON_VI_TINH"].ToString() : null;

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

    }


}

