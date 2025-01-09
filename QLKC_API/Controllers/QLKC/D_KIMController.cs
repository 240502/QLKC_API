using API_PCHY.Models.QLKC.D_KIM;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
namespace API_PCHY.Controllers.QLKC
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class D_KIMController : ControllerBase
    {
        private D_KIMManager db = new D_KIMManager();
        [Route("get_ALL_D_KIMTTByMA_DVIQLY1")]
        [HttpGet]
        public IActionResult get_ALL_D_KIMTTByMA_DVIQLY1(string ma_Dviqly)
        {
            try
            {



                var results = db.get_ALL_D_KIMTTByMA_DVIQLY1(ma_Dviqly);
                return results != null ? Ok(results) : NotFound("No data found!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [Route("getD_KimInTable")]
        [HttpGet]
        public IActionResult getD_KimInTable()
        {
            List<D_KIMModel> list = db.getD_KimInTable();
            return list != null ? Ok(list) : NotFound();
        }
        [Route("get-by-ma-dviqly")]
        [HttpPost]
        public IActionResult getD_KIMByMA_DVIQLY(string ma_dviqly)
        {
            try
            {
                List<D_KIMModel> list = db.get_D_KIMByMA_DVIQLY(ma_dviqly);
                return list != null ? Ok(list) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("getAll_D_KIM")]
        public ActionResult Get()
        {
            try
            {
                List<D_KIMModel> result = db.getALL_D_KIM();

                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("insert_D_KIM")]
        [HttpPost]
        public IActionResult insert_D_KIM([FromBody] D_KIMModel d_KIM)
        {
            string result = db.insert_QLKC_D_KIM(d_KIM);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(new { message=result });
        }

        [Route("update_D_KIM")]
        [HttpPut]
        public IActionResult update_D_KIM([FromBody] D_KIMModel d_KIM)
        {
            string result = db.update_QLKC_D_KIM(d_KIM);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(new { message = result });
        }

        [Route("delete_D_KIM")]
        [HttpDelete]
        public IActionResult delete_D_KIM(int id_kim)
        {
            string result = db.delete_QLKC_D_KIM(id_kim);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        [Route("get_D_KIM_ByID")]
        [HttpGet]
        public IActionResult get_D_KIM(int id_kim)
        {
            D_KIMModel result = db.get_D_KIM_ByID(id_kim);
            return result != null ? Ok(result) : NotFound();
        }
        [Route("get_ALL_D_KIMTTByMA_DVIQLY")]
        [HttpPost]
        public IActionResult get_ALL_D_KIMTTByMA_DVIQLY([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                string? ma_dviqly = formData.ContainsKey("ma_dviqly") && !string.IsNullOrEmpty(formData["ma_dviqly"]?.ToString())
                    ? formData["ma_dviqly"].ToString()
                    : null;

                string? iD_KIM = formData.ContainsKey("iD_KIM") && !string.IsNullOrEmpty(formData["iD_KIM"]?.ToString())
                    ? formData["iD_KIM"].ToString()
                    : null;

                var results = db.get_ALL_D_KIMTTByMA_DVIQLY(ma_dviqly, iD_KIM);
                return results != null ? Ok(results) : NotFound("No data found!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [Route("get_D_KIMByMA_DVIQLY")]
        [HttpPost]
        public IActionResult get_ALL_D_KIMByMA_DVIQLY([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                string? ma_dviqly = null; string? kimIds = null;
                if (formData.Keys.Contains("ma_dviqly") && !string.IsNullOrEmpty(formData["ma_dviqly"].ToString()))
                {
                    ma_dviqly = formData["ma_dviqly"].ToString();
                }
                if (formData.Keys.Contains("kimIds") && !string.IsNullOrEmpty(formData["kimIds"].ToString()))
                {
                    kimIds = formData["kimIds"].ToString();
                }

                List<D_KIMModel> results = db.get_ALL_D_KIMByMA_DVIQLY(ma_dviqly, kimIds);

                return results != null ? Ok(results) : NotFound("not found!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("update_MA_DVIQLY")]
        [HttpPost]
        public IActionResult update_MADVIQLY_D_KIM([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                string? ht_nguoidung_id = null;
                string? ma_dvigiao = null;
                string? id_kim = null;
                if (formData.Keys.Contains("ht_nguoidung_id") && !string.IsNullOrEmpty(formData["ht_nguoidung_id"].ToString()))
                {
                    ht_nguoidung_id = formData["ht_nguoidung_id"].ToString();

                }
                if (formData.Keys.Contains("ma_dvigiao") && !string.IsNullOrEmpty(formData["ma_dvigiao"].ToString()))
                {
                    ma_dvigiao = formData["ma_dvigiao"].ToString();

                }
                if (formData.Keys.Contains("id_kim") && !string.IsNullOrEmpty(formData["id_kim"].ToString()))
                {
                    id_kim = formData["id_kim"].ToString();

                }
                string result = db.update_MADVIQLY_D_KIM(ht_nguoidung_id, id_kim, ma_dvigiao);
                return string.IsNullOrEmpty(result) ? Ok("Success") : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("search_D_KIM")]
        [HttpPost]
        public IActionResult search_D_KIM_ByID([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
                string? nguoi_tao = null;
                int? loai_ma_kim = null;
                int? trang_thai = null;
                string? ma_dviqly = null;

                if (formData.Keys.Contains("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.Keys.Contains("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());
                }
                if (formData.Keys.Contains("nguoiTao") && !string.IsNullOrEmpty(formData["nguoiTao"].ToString()))
                {
                    nguoi_tao = formData["nguoiTao"].ToString();
                }
                if (formData.Keys.Contains("maDviqly") && !string.IsNullOrEmpty(formData["maDviqly"].ToString()))
                {
                    ma_dviqly = formData["maDviqly"].ToString();
                }
                if (formData.Keys.Contains("loaiMaKim") && !string.IsNullOrEmpty(formData["loaiMaKim"].ToString()))
                {
                    loai_ma_kim = int.Parse(formData["loaiMaKim"].ToString());
                }
                if (formData.Keys.Contains("trangThai") && !string.IsNullOrEmpty(formData["trangThai"].ToString()))
                {
                    trang_thai = int.Parse(formData["trangThai"].ToString());
                }

                int totalItems = 0;
                List<D_KIMModel> result = db.search_QLKC_D_KIM(pageSize, pageIndex, nguoi_tao, loai_ma_kim, trang_thai,ma_dviqly, out totalItems);
                return result != null ? Ok(new
                {
                    page = pageIndex,
                    pageSize = pageSize,
                    totalItems = totalItems,
                    data = result,
                    nguoi_tao = nguoi_tao,
                    loai_ma_kim = loai_ma_kim,
                    trang_thai = trang_thai,
                    ma_dviqly= ma_dviqly
                }) : NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
