using API_PCHY.Models.QLKC.D_KIM;
using APIPCHY_PhanQuyen.Models.QLKC.C3_GIAONHAN_TEMCHI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace API_PCHY.Controllers.QLKC
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class C3_GIAONHAN_TEMCHIController : ControllerBase
    {
        C3_GIAONHAN_TEMCHI_Manager db = new C3_GIAONHAN_TEMCHI_Manager();

    
        [HttpGet("getAll_QLKC_C3_GIAONHAN_TEMCHI")]
        public ActionResult Get()
        {
            try
            {
                List<C3_GIAONHAN_TEMCHI_Model> result = db.getALL_QLKC_C3_GIAONHAN_TEMCHI();

                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("insert_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPost]
        public IActionResult insert_C3_GIAONHAN_TEMCHI([FromBody] C3_GIAONHAN_TEMCHI_Model gntc)
        {
            string result = db.insert_QLKC_C3_GIAONHAN_TEMCHI(gntc);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        [Route("update_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_C3_GIAONHAN_TEMCHI([FromBody] C3_GIAONHAN_TEMCHI_Model gntc)
        {
            string result = db.update_QLKC_C3_GIAONHAN_TEMCHI(gntc);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        [Route("delete_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpDelete]
        public IActionResult delete_C3_GIAONHAN_TEMCHI(int id)
        {
            string result = db.delete_QLKC_C3_GIAONHAN_TEMCHI(id);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        [Route("get_QLKC_C3_GIAONHAN_TEMCHI_ByID")]
        [HttpGet]
        public IActionResult get_C3_GIAONHAN_TEMCHI_ByID(int id)
        {
            C3_GIAONHAN_TEMCHI_Model result = db.get_QLKC_C3_GIAONHAN_TEMCHI_ByID(id);
            return result != null ? Ok(result) : NotFound();
        }

        [Route("search_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPost]
        public IActionResult search_QLKC_C3_GIAONHAN_TEMCHI([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
                string don_vi_giao = null;
                string nguoi_nhan = null;
                int? loai_bban = null;
                if (formData.Keys.Contains("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.Keys.Contains("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());
                }
                if (formData.Keys.Contains("don_vi_giao") && !string.IsNullOrEmpty(formData["don_vi_giao"].ToString()))
                {
                    don_vi_giao = formData["don_vi_giao"].ToString();
                }
                if (formData.Keys.Contains("nguoi_nhan") && !string.IsNullOrEmpty(formData["nguoi_nhan"].ToString()))
                {
                    nguoi_nhan = formData["nguoi_nhan"].ToString();
                }
                if (formData.Keys.Contains("loai_bban") && !string.IsNullOrEmpty(formData["loai_bban"].ToString()))
                {
                    loai_bban = int.Parse(formData["loai_bban"].ToString());
                }

                int totalItems = 0;
                List<C3_GIAONHAN_TEMCHI_Model> result = db.search_QLKC_C3_GIAONHAN_TEMCHI(pageIndex, pageSize, don_vi_giao, nguoi_nhan, loai_bban, out totalItems);
                return result != null ? Ok(new
                {
                    page = pageIndex,
                    pageSize = pageSize,
                    totalItems = totalItems,
                    data = result,
                    don_vi_giao = don_vi_giao,
                    nguoi_nhan = nguoi_nhan,
                    loai_bban = loai_bban
                }) : NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
