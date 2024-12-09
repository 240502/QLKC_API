﻿using API_PCHY.Models.QLKC.D_KIM;
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
            D_KIMManager db = new D_KIMManager();
            [Route("insert_D_KIM")]
            [HttpPost]
            public IActionResult insert_D_KIM([FromBody] D_KIMModel d_KIM)
            {
                string result = db.insert_QLKC_D_KIM(d_KIM);
                return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
            }

            [Route("update_D_KIM")]
            [HttpPut]
            public IActionResult update_D_KIM([FromBody] D_KIMModel d_KIM)
            {
                string result = db.update_QLKC_D_KIM(d_KIM);
                return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
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

            [Route("search_D_KIM")]
            [HttpPost]
            public IActionResult search_D_KIM_ByID([FromBody] Dictionary<string, object> formData)
            {
                try
                {
                    int? pageIndex = 0;
                    int? pageSize = 0;
                    string nguoi_tao = null;
                    int? loai_ma_kim = null;
                    int? trang_thai = null;
                    if (formData.Keys.Contains("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                    {
                        pageIndex = int.Parse(formData["pageIndex"].ToString());
                    }
                    if (formData.Keys.Contains("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                    {
                        pageSize = int.Parse(formData["pageSize"].ToString());
                    }
                    if (formData.Keys.Contains("nguoi_tao") && !string.IsNullOrEmpty(formData["nguoi_tao"].ToString()))
                    {
                        nguoi_tao = formData["nguoi_tao"].ToString();
                    }
                    if (formData.Keys.Contains("loai_ma_kim") && !string.IsNullOrEmpty(formData["loai_ma_kim"].ToString()))
                    {
                        loai_ma_kim = int.Parse(formData["loai_ma_kim"].ToString());
                    }
                    if (formData.Keys.Contains("trang_thai") && !string.IsNullOrEmpty(formData["trang_thai"].ToString()))
                    {
                        trang_thai = int.Parse(formData["trang_thai"].ToString());
                    }

                    int totalItems = 0;
                    List<D_KIMModel> result = db.search_QLKC_D_KIM(pageIndex, pageSize, nguoi_tao, loai_ma_kim, trang_thai, out totalItems);
                    return result != null ? Ok(new
                    {
                        page = pageIndex,
                        pageSize = pageSize,
                        totalItems = totalItems,
                        data = result,
                        nguoi_tao = nguoi_tao,
                        loai_ma_kim = loai_ma_kim,
                        trang_thai = trang_thai
                    }) : NotFound();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    }
}
