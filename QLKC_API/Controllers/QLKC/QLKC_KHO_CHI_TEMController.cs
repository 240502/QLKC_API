using API_PCHY.Models.QLKC;
using API_PCHY.Models.QLKC.BBAN_BANGIAO_KIM;
using API_PCHY.Models.QUAN_TRI.QLKC_KHO_CHI_TEM;
using APIPCHY_PhanQuyen.Models.QLKC.DM_DONVI;
using APIPCHY_PhanQuyen.Models.QLKC.DM_PHONGBAN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_PCHY.Controllers.QUAN_TRI.QLKC_KHO_CHI_TEM
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class QLKC_KHO_CHI_TEMController : ControllerBase
    {
        QLKC_KHO_CHI_TEM_Manager db = new QLKC_KHO_CHI_TEM_Manager();

        [Route("update_QLKC_KHO_CHI_TEM")]
        [HttpPut]
        public IActionResult update_QLKC_KHO_CHI_TEM([FromBody] QLKC_KHO_CHI_TEM_Model qLKC_KHO_CHI_TEM)
        {
            string result = db.update_QLKC_KHO_CHI_TEM(qLKC_KHO_CHI_TEM);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        [Route("delete_QLKC_KHO_CHI_TEM")]
        [HttpDelete]
        public IActionResult delete_QLKC_KHO_CHI_TEM(int ID_KHO)
        {
            string result = db.delete_QLKC_KHO_CHI_TEM(ID_KHO.ToString());
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        [Route("get_All_QLKC_KHO_CHI_TEM")]
        [HttpGet]
        public IActionResult get_All_QLKC_KHO_CHI_TEM()
        {
            List<QLKC_KHO_CHI_TEM_Model> result = db.get_All_QLKC_KHO_CHI_TEM();
            return result != null ? Ok(result) : NotFound();
        }

        [Route("get_QLKC_KHO_CHI_TEMByID_KHO")]
        [HttpGet]
        public IActionResult get_QLKC_KHO_CHI_TEMByID_KHO(int ID_KHO)
        {
            QLKC_KHO_CHI_TEM_Model result = db.get_QLKC_KHO_CHI_TEMByID_KHO(ID_KHO.ToString());
            return result != null ? Ok(result) : NotFound();
        }

        [Route("search_QLKC_KHO_CHI_TEM")]
        [HttpPost]
        public IActionResult search_QLKC_KHO_CHI_TEM([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
                string loai = null;
                string thang = null;
                int? nam = null;
                if (formData.Keys.Contains("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.Keys.Contains("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());
                }
                if (formData.Keys.Contains("loai") && !string.IsNullOrEmpty(formData["loai"].ToString()))
                {
                    loai = formData["loai"].ToString();
                }
                if (formData.Keys.Contains("thang") && !string.IsNullOrEmpty(formData["thang"].ToString()))
                {
                    thang = formData["thang"].ToString();
                }
                if (formData.Keys.Contains("nam") && !string.IsNullOrEmpty(formData["nam"].ToString()))
                {
                    nam = int.Parse(formData["nam"].ToString());
                }

                int totalItems = 0;
                List<QLKC_KHO_CHI_TEM_Model> result = db.search_QLKC_KHO_CHI_TEM(pageIndex, pageSize, loai, thang, nam, out totalItems);
                return result != null ? Ok(new
                {
                    page = pageIndex,
                    pageSize = pageSize,
                    totalItems = totalItems,
                    data = result,
                    loai = loai,
                    thang = thang,
                    nam = nam
                }) : NotFound();



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
