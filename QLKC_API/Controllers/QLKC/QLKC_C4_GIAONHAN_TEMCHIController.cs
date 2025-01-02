using APIPCHY_PhanQuyen.Models.QLKC.QLKC_C4_GIAONHAN_TEMCHI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPCHY_PhanQuyen.Controllers.QLKC.QLKC_C4_GIAONHAN_TEMCHI
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class QLKC_C4_GIAONHAN_TEMCHI : ControllerBase
    {
        QLKC_C4_GIAONHAN_TEMCHI_Manager db = new QLKC_C4_GIAONHAN_TEMCHI_Manager();

        [Route("create_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPost]
        public IActionResult create_QLKC_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.create_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("create_PM_QLKC_C4_MUON_TEMCHI")]
        [HttpPost]
        public IActionResult create_PM_QLKC_C4_MUON_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.create_PM_QLKC_C4_MUON_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("create_PQT_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult create_PQT_QLKC_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.create_PQT_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("update_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_QLKC_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.update_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("update_CD_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_CD_QLKC_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.update_CD_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("update_huyPM_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_huyPM_QLKC_C4_GIAONHAN_TEMCHI(int id)
        {
            return Ok(db.update_huyPM_QLKC_C4_GIAONHAN_TEMCHI(id));
        }
        [Route("update_kyC1_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC1_QLKC_C4_GIAONHAN_TEMCHI(int id)
        {
            return Ok(db.update_kyC1_QLKC_C4_GIAONHAN_TEMCHI(id));
        }
        [Route("update_kyC2_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC2_QLKC_C4_GIAONHAN_TEMCH(int id)
        {
            return Ok(db.update_kyC2_QLKC_C4_GIAONHAN_TEMCHI(id));
        }
        [Route("update_kyC1_PM_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC1_PM_QLKC_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.update_kyC1_PM_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("update_kyC1_PQT_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC1_PQT_QLKC_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.update_kyC1_PQT_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("update_kyC2_PM_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC2_PM_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.update_kyC2_PM_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("update_kyC2_PQT_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC2_PQT_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.update_kyC2_PQT_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("update_TL_PM_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_TL_PM_QLKC_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.update_TL_PM_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("update_TL_PQT_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_TL_PQT_QLKC_C4_GIAONHAN_TEMCHI([FromBody] QLKC_C4_GIAONHAN_TEMCHI_Model QLKC_C4_GIAONHAN_TEMCHI)
        {
            return Ok(db.update_TL_PQT_QLKC_C4_GIAONHAN_TEMCHI(QLKC_C4_GIAONHAN_TEMCHI));
        }
        [Route("delete_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpDelete]
        public IActionResult delete_QLKC_C4_GIAONHAN_TEMCHI(int id)
        {
            return Ok(db.delete_QLKC_C4_GIAONHAN_TEMCHI(id));
        }
        [Route("get_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpGet]
        public IActionResult get_QLKC_C4_GIAONHAN_TEMCHI(int id)
        {
            return Ok(db.get_QLKC_C4_GIAONHAN_TEMCHI(id));
        }
        [Route("get_PM_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpGet]
        public IActionResult get_PM_QLKC_C4_GIAONHAN_TEMCHI(int id)
        {
            return Ok(db.get_PM_QLKC_C4_GIAONHAN_TEMCHI(id));
        }
        [Route("get_PQT_QLKC_C4_GIAONHAN_TEMCHI ")]
        [HttpGet]
        public IActionResult get_PQT_QLKC_C4_GIAONHAN_TEMCHI(int id)
        {
            return Ok(db.get_PQT_QLKC_C4_GIAONHAN_TEMCHI(id));
        }
        [Route("getAll_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpGet]
        public IActionResult getAll_QLKC_C4_GIAONHAN_TEMCHI()
        {
            return Ok(db.getAll_QLKC_C4_GIAONHAN_TEMCHI());
        }
        [Route("search_QLKC_C4_GIAONHAN_TEMCHI")]
        [HttpPost]
        public IActionResult search_QLKC_C4_GIAONHAN_TEMCHI([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 1;
                int? pageSize = 5;
                int? trang_thai = -1;
                int? loai_bienban = -1;
                string don_vi_giao = null;
                string don_vi_nhan = null;
                if (formData.Keys.Contains("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.Keys.Contains("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());
                }
                if (formData.Keys.Contains("loai_bienban") && !string.IsNullOrEmpty(formData["loai_bienban"].ToString()))
                {
                    loai_bienban = int.Parse(formData["loai_bienban"].ToString());
                }
                if (formData.Keys.Contains("trang_thai") && !string.IsNullOrEmpty(formData["trang_thai"].ToString()))
                {
                    trang_thai = int.Parse(formData["trang_thai"].ToString());
                }
                if (formData.Keys.Contains("don_vi_giao") && !string.IsNullOrEmpty(formData["don_vi_giao"].ToString()))
                {
                    don_vi_giao = formData["don_vi_giao"].ToString();
                }
                if (formData.Keys.Contains("don_vi_nhan") && !string.IsNullOrEmpty(formData["don_vi_nhan"].ToString()))
                {
                    don_vi_nhan = formData["don_vi_nhan"].ToString();
                }
                int totalItems = 0;
                List<QLKC_C4_GIAONHAN_TEMCHI_Model> result = db.search_QLKC_C4_GIAONHAN_TEMCHI(pageIndex, pageSize, trang_thai, loai_bienban,don_vi_giao, don_vi_nhan, out totalItems);
                // Nếu không có kết quả, trả về mảng trống
                if (result == null || result.Count == 0)
                {
                    return Ok(new
                    {
                        page = pageIndex,
                        pageSize = pageSize,
                        totalItems = 0,
                        data = new List<QLKC_C4_GIAONHAN_TEMCHI_Model>(), // Trả về mảng trống

                    });
                }

                // Nếu có kết quả, trả về dữ liệu như bình thường
                return Ok(new
                {
                    page = pageIndex,
                    pageSize = pageSize,
                    totalItems = totalItems,
                    data = result,

                });

            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    page = 0,
                    pageSize = 0,
                    totalItems = 0,
                    data = new List<QLKC_C4_GIAONHAN_TEMCHI_Model>(), // Trả về mảng trống

                });
                //throw ex;
            }
        }
        [Route("get_HT_NGUOIDUNGbyMA_DVIQLY")]
        [HttpGet]
        public IActionResult get_HT_NGUOIDUNGbyMA_DVIQLY(string ma_dviqly)
        {
            return Ok(db.get_HT_NGUOIDUNGbyMA_DVIQLY(ma_dviqly));
        }
    }
    
}
