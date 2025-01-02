using APIPCHY_PhanQuyen.Models.QLKC.QLKC_C4_CHITIET_QUYETTOANCHI;
using APIPCHY_PhanQuyen.Models.QLKC.QLKC_C4_GIAONHAN_TEMCHI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_PCHY.Controllers.QLKC.QLKC_C4_CHITIET_QUYETTOANCHI
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class QLKC_C4_CHITIET_QUYETTOANCHIController : ControllerBase
    {
        QLKC_C4_CHITIET_QUYETTOANCHI_Manager db = new QLKC_C4_CHITIET_QUYETTOANCHI_Manager();
        [Route("create_C4_CHITIET_QUYETTOANCHI")]
        [HttpPost]
        public IActionResult create_C4_CHITIET_QUYETTOANCHI([FromBody] QLKC_C4_CHITIET_QUYETTOANCHI_Model QLKC_C4_CHITIET_QUYETTOANCHI)
        {
            return Ok(db.create_C4_CHITIET_QUYETTOANCHI(QLKC_C4_CHITIET_QUYETTOANCHI));
        }

        [Route("update_QLKC_C4_CHITIET_QUYETTOANCHI")]
        [HttpPut]
        public IActionResult update_QLKC_C4_CHITIET_QUYETTOANCHI([FromBody] QLKC_C4_CHITIET_QUYETTOANCHI_Model QLKC_C4_CHITIET_QUYETTOANCHI)
        {
            return Ok(db.update_QLKC_C4_CHITIET_QUYETTOANCHI(QLKC_C4_CHITIET_QUYETTOANCHI));
        }

        [Route("delete_QLKC_C4_CHITIET_QUYETTOANCHI")]
        [HttpDelete]
        public IActionResult delete_QLKC_C4_CHITIET_QUYETTOANCHI(int id)
        {
            return Ok(db.delete_QLKC_C4_CHITIET_QUYETTOANCHI(id));
        }

        [Route("get_CHITIET_QUYETTOANCHI_byID_GIAONHAN_TEMCHI")]
        [HttpGet]
        public IActionResult get_CHITIET_QUYETTOANCHI_byID_GIAONHAN_TEMCHI(int id)
        {
            return Ok(db.get_CHITIET_QUYETTOANCHI_byID_GIAONHAN_TEMCHI(id));
        }

        [Route("search_QLKC_C4_CHITIET_QUYETTOANCHI")]
        [HttpPost]
        public IActionResult search_QLKC_C4_CHITIET_QUYETTOANCHI([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 1;
                int? pageSize = 5;
                string maKhachHang = null;
                string tenKhachHang = null;
                string tenTBA = null;
                string idGiaoNhanTemChi = null;

                if (formData.Keys.Contains("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.Keys.Contains("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());
                }
                if (formData.Keys.Contains("mA_KHACH_HANG") && !string.IsNullOrEmpty(formData["mA_KHACH_HANG"].ToString()))
                {
                    maKhachHang = (formData["mA_KHACH_HANG"].ToString());
                }
                if (formData.Keys.Contains("teN_KHACH_HANG") && !string.IsNullOrEmpty(formData["teN_KHACH_HANG"].ToString()))
                {
                    tenKhachHang = (formData["teN_KHACH_HANG"].ToString());
                }
                if (formData.Keys.Contains("teN_TBA") && !string.IsNullOrEmpty(formData["teN_TBA"].ToString()))
                {
                    tenTBA = (formData["teN_TBA"].ToString());
                }
                if (formData.Keys.Contains("iD_GIAONHAN_TEMCHI") && !string.IsNullOrEmpty(formData["iD_GIAONHAN_TEMCHI"].ToString()))
                {
                    idGiaoNhanTemChi = (formData["iD_GIAONHAN_TEMCHI"].ToString());
                }
                int totalItems = 0;
                List<QLKC_C4_CHITIET_QUYETTOANCHI_Model> result = db.search_QLKC_C4_CHITIET_QUYETTOANCHI(pageIndex, pageSize, maKhachHang, tenKhachHang, tenTBA, idGiaoNhanTemChi, out totalItems);
                // Nếu không có kết quả, trả về mảng trống
                if (result == null || result.Count == 0)
                {
                    return Ok(new
                    {
                        page = pageIndex,
                        pageSize = pageSize,
                        totalItems = 0,
                        data = new List<QLKC_C4_CHITIET_QUYETTOANCHI_Model>(), // Trả về mảng trống

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
                //return Ok(new
                //{
                //    page = 0,
                //    pageSize = 0,
                //    totalItems = 0,
                //    data = new List<QLKC_C4_GIAONHAN_TEMCHI_Model>(), // Trả về mảng trống

                //});
                throw ex;
            }
        }
    }
}
