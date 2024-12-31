using APIPCHY_PhanQuyen.Models.QLKC.C3_GIAONHAN_TEMCHI;
using APIPCHY_PhanQuyen.Models.QLKC.D_KIM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPCHY_PhanQuyen.Controllers.C3_GIAONHAN_TEMCHI
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
        public IActionResult insert_QLKC_C3_GIAONHAN_TEMCHI([FromBody] C3_GIAONHAN_TEMCHI_Model gntc)
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
                string don_vi_nhan = null;
                int? trang_thai = null;
                string? loai = null;
                if (formData.TryGetValue("pageIndex", out var pageIndexValue) && int.TryParse(pageIndexValue?.ToString(), out var parsedPageIndex))
                {
                    pageIndex = parsedPageIndex;
                }

                if (formData.TryGetValue("pageSize", out var pageSizeValue) && int.TryParse(pageSizeValue?.ToString(), out var parsedPageSize))
                {
                    pageSize = parsedPageSize;
                }

                if (formData.TryGetValue("don_vi_giao", out var don_vi_giao_value))
                {
                    don_vi_giao = don_vi_giao_value?.ToString();
                }

                if (formData.TryGetValue("don_vi_nhan", out var don_vi_nhan_value))
                {
                    don_vi_nhan = don_vi_nhan_value?.ToString();
                }

                if (formData.TryGetValue("trang_thai", out var trang_thai_value) && int.TryParse(trang_thai_value?.ToString(), out var parsedTrangThai))
                {
                    trang_thai = parsedTrangThai;
                }

                if (formData.TryGetValue("loai", out var loaiValue))
                {
                    loai = loaiValue?.ToString();
                }

                int totalItems = 0;
                List<C3_GIAONHAN_TEMCHI_Model> result = db.search_QLKC_C3_GIAONHAN_TEMCHI(pageIndex, pageSize, don_vi_giao, don_vi_nhan, trang_thai, loai, out totalItems);
                return result != null ? Ok(new
                {
                    page = pageIndex,
                    pageSize = pageSize,
                    totalItems = totalItems,
                    data = result,
                    don_vi_giao = don_vi_giao,
                    don_vi_nhan = don_vi_nhan,
                    trang_thai = trang_thai,
                    loai = loai
                }) : NotFound();



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("update_kyC1_PM_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC1_PM_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            try
            {
                string result = db.update_kyC1_PM_QLKC_C3_GIAONHAN_TEMCHI(id);

                return String.IsNullOrEmpty(result) ? Ok("Ký thành công") : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("update_kyC1_PQT_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC1_PQT_QLKC_C3_GIAONHAN_KIM(int id)
        {
            string result = db.update_kyC1_PQT_QLKC_C3_GIAONHAN_TEMCHI(id);

            return string.IsNullOrEmpty(result) ? Ok("Ký thành công") : BadRequest(result);
        }



        [Route("update_kyC2_PM_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC2_PM_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            string result = db.update_kyC2_PM_QLKC_C3_GIAONHAN_TEMCHI(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }


        [Route("update_kyC2_PQT_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_kyC2_PQT_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            string result = db.update_kyC2_PQT_QLKC_C3_GIAONHAN_TEMCHI(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }



        [Route("update_TL_PM_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_TL_PM_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            string result = db.update_TL_PM_QLKC_C3_GIAONHAN_TEMCHI(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }


        [Route("update_TL_PQT_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_TL_PQT_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            string result = db.update_TL_PQT_QLKC_C3_GIAONHAN_TEMCHI(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }

        [Route("update_huyPM_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_huyPM_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            string result = db.update_huyPM_QLKC_C3_GIAONHAN_TEMCHI(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }

        [Route("update_LoaiBBan_QLKC_C3_GIAONHAN_TEMCHI")]
        [HttpPut]
        public IActionResult update_LoaiBBan_QLKC_C3_GIAONHAN_TEMCHI(int id)
        {
            string result = db.update_LoaiBBan_QLKC_C3_GIAONHAN_TEMCHI(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { Error = result });
            }
        }
    }
}
