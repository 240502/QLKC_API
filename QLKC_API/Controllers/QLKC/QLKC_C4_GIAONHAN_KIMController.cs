using API_PCHY.Models.QLKC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using API_PCHY.Models.QUAN_TRI.QLKC_C4_GIAONHAN_KIM;

namespace API_PCHY.Controllers.QUAN_TRI.QLKC_C4_GIAONHAN_KIM
{
    [Route("API_PCHY/[controller]")]
    [ApiController]
    public class QLKC_C4_GIAONHAN_KIMController : ControllerBase
    {
        QLKC_C4_GIAONHAN_KIM_Manager db = new QLKC_C4_GIAONHAN_KIM_Manager();

        // Tạo mới
        [Route("create_PM_QLKC_C4_GIAONHAN_KIM")]
        [HttpPost]
        public IActionResult create_PM_QLKC_C4_GIAONHAN_KIM([FromBody] QLKC_C4_GIAONHAN_KIM_Model qLKC_C4_GIAONHAN_KIM)
        {
            string result = db.create_PM_QLKC_C4_GIAONHAN_KIM(qLKC_C4_GIAONHAN_KIM);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        [Route("update_CD_QLKC_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_CD_QLKC_C4_GIAONHAN_KIM([FromBody] QLKC_C4_GIAONHAN_KIM_Model qLKC_C4_GIAONHAN_KIM)
        {
            string result = db.update_CD_QLKC_C4_GIAONHAN_KIM(qLKC_C4_GIAONHAN_KIM);
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        // Xóa theo ID
        [Route("delete_QLKC_C4_GIAONHAN_KIM")]
        [HttpDelete]
        public IActionResult delete_QLKC_C4_GIAONHAN_KIM(int id)
        {
            string result = db.delete_QLKC_C4_GIAONHAN_KIM(id.ToString());
            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }


        [Route("get_PQT_QLKC_C4_GIAONHAN_KIM")]
        [HttpGet]
        public IActionResult get_PQT_QLKC_C4_GIAONHAN_KIM(int ID)
        {
            QLKC_C4_GIAONHAN_KIM_Model result = db.get_PQT_QLKC_C4_GIAONHAN_KIM(ID.ToString());
            return result != null ? Ok(result) : NotFound();
        }



    }
}