using APIPCHY_PhanQuyen.Models.QLKC.QLKC_NHAP_CHI_TEM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPCHY_PhanQuyen.Controllers.QLKC.QLKC_NHAP_CHI_TEM
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class QLKC_NHAP_CHI_TEMController : ControllerBase
    {
        QLKC_NHAP_CHI_TEM_Manager db = new QLKC_NHAP_CHI_TEM_Manager();

        [Route("insert_QLKC_NHAP_CHI_TEM")]
        [HttpPost]
        public IActionResult insert_QLKC_NHAP_CHI_TEM([FromBody] QLKC_NHAP_CHI_TEM_Model QLKC_NHAP_CHI_TEM)
        {
            return Ok(db.insert_QLKC_NHAP_CHI_TEM(QLKC_NHAP_CHI_TEM));
        }
      
        [Route("update_QLKC_NHAP_CHI_TEM")]
        [HttpPut]
        public IActionResult update_QLKC_NHAP_CHI_TEM([FromBody] QLKC_NHAP_CHI_TEM_Model QLKC_NHAP_CHI_TEM)
        {
            return Ok(db.update_QLKC_NHAP_CHI_TEM(QLKC_NHAP_CHI_TEM));
        }

        [Route("delete_QLKC_NHAP_CHI_TEM")]
        [HttpDelete]
        public IActionResult delete_QLKC_NHAP_CHI_TEM(int id)
        {
            return Ok(db.delete_BBAN_NHAP_CHI_TEM(id));
        }

        [Route("get_BBan_NHAP_CHI_TEM")]
        [HttpGet]
        public IActionResult get_BBAN_NHAP_CHI_TEM(int id)
        {
            return Ok(db.get_BBAN_NHAP_CHI_TEM(id));
        }
        [Route("getAll_QLKC_NHAP_CHI_TEM")]
        [HttpGet]
        public IActionResult getAll_QLKC_NHAP_CHI_TEM()
        {
            return Ok(db.getAll_QLKC_NHAP_CHI_TEM());
        }
        [Route("search_QLKC_NHAP_CHI_TEM")]
        [HttpPost]
        public IActionResult search_QLKC_NHAP_CHI_TEM([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 1;
                int? pageSize = 5;
                //string ten = null;
                //string ma = null;
                string? don_vi_tinh = null;
                string? loai = null;
                if (formData.Keys.Contains("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.Keys.Contains("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());
                }
                if (formData.Keys.Contains("doN_VI_TINH") && !string.IsNullOrEmpty(formData["doN_VI_TINH"].ToString()))
                {
                    don_vi_tinh = formData["doN_VI_TINH"].ToString();
                }
                if (formData.Keys.Contains("loai") && !string.IsNullOrEmpty(formData["loai"].ToString()))
                {
                    loai = formData["loai"].ToString();
                }


                int totalItems = 0;
                List<QLKC_NHAP_CHI_TEM_Model> result = db.search_QLKC_NHAP_CHI_TEM(pageIndex, pageSize, loai, don_vi_tinh, out totalItems);
                // Nếu không có kết quả, trả về mảng trống
                if (result == null || result.Count == 0)
                {
                    return Ok(new
                    {
                        page = pageIndex,
                        pageSize = pageSize,
                        totalItems = 0,
                        data = new List<QLKC_NHAP_CHI_TEM_Model>(), // Trả về mảng trống

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
                    data = new List<QLKC_NHAP_CHI_TEM_Model>(), // Trả về mảng trống

                });
                //throw ex;
            }
        }
    }
}
