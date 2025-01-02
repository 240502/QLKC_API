using API_PCHY.Models.QLKC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using API_PCHY.Models.QUAN_TRI.QLKC_C4_GIAONHAN_KIM;
using Newtonsoft.Json.Linq;
using API_PCHY.Models.QUAN_TRI.QLKC_KHO_CHI_TEM;
using System.Linq;
using APIPCHY.Models.QUAN_TRI.QLKC_C4_GIAONHAN_KIM;

namespace API_PCHY.Controllers.QUAN_TRI.QLKC_C4_GIAONHAN_KIM
{
    [Route("APIPCHY/[controller]")]
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

        [Route("get_PM_QLKC_C4_GIAONHAN_KIM")]
        [HttpGet]
        public IActionResult get_PM_QLKC_C4_GIAONHAN_KIM(int ID)
        {
            QLKC_C4_GIAONHAN_KIM_Model result = db.get_PM_QLKC_C4_GIAONHAN_KIM(ID.ToString());
            return result != null ? Ok(result) : NotFound();
        }




        [Route("update_kyC1_PM_QLKC_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_kyC1_PM_QLKC_C4_GIAONHAN_KIM(int id)
        {
            try
            {
                string result = db.update_kyC1_PM_QLKC_C4_GIAONHAN_KIM(id);
                return String.IsNullOrEmpty(result) ? Ok("Ký thành công") : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("update_KIM_TRANGTHAI")]
        [HttpPut]
        public IActionResult update_KIM_TRANGTHAI(string iD_KIM, int trangThai) // Thêm tham số trạng thái
        {
            try
            {
                // Kiểm tra nếu iD_KIM null hoặc rỗng
                if (string.IsNullOrWhiteSpace(iD_KIM))
                {
                    return BadRequest("ID_KIM không được để trống.");
                }

                // Tách và kiểm tra các giá trị ID nếu cần
                var ids = iD_KIM.Trim('"') // Loại bỏ dấu " nếu có
                                .Split(',') // Tách các giá trị
                                .Select(id => id.Trim()) // Xóa khoảng trắng thừa
                                .Where(id => !string.IsNullOrWhiteSpace(id)) // Loại bỏ giá trị rỗng
                                .ToList();

                if (!ids.Any())
                {
                    return BadRequest("ID_KIM không hợp lệ.");
                }

                // Gọi hàm xử lý trong cơ sở dữ liệu
                string result = db.update_KIM_TRANGTHAI(string.Join(",", ids), trangThai); // Gọi hàm với tham số trạng thái

                // Kiểm tra kết quả
                if (string.IsNullOrEmpty(result))
                {
                    return Ok("Cập nhật thành công!");
                }
                else
                {
                    return BadRequest($"Có lỗi xảy ra: {result}");
                }
            }
            catch (Exception ex)
            {
                // Bắt và ghi log lỗi nếu cần
                return StatusCode(500, $"Lỗi hệ thống: {ex.Message}");
            }
        }


        [Route("update_kyC1_PQT_QLKC_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_kyC1_PQT_QLKC_C4_GIAONHAN_KIM(int id)
        {
            string result = db.update_kyC1_PQT_QLKC_C4_GIAONHAN_KIM(id);

            return string.IsNullOrEmpty(result) ? Ok("Ký thành công") : BadRequest(result);
        }



        [Route("update_kyC2_PQT_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_kyC2_PQT_C4_GIAONHAN_KIM(int id)
        {
            string result = db.update_kyC2_PQT_C4_GIAONHAN_KIM(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }


        [Route("update_kyC2_PM_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_kyC2_PM_C4_GIAONHAN_KIM(int id)
        {
            string result = db.update_kyC2_PM_C4_GIAONHAN_KIM(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }



        [Route("update_TL_PM_QLKC_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_TL_PM_QLKC_C4_GIAONHAN_KIM(int id)
        {
            string result = db.update_TL_PM_QLKC_C4_GIAONHAN_KIM(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }


        [Route("update_TL_PQT_QLKC_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_TL_PQT_QLKC_C4_GIAONHAN_KIM(int id)
        {
            string result = db.update_TL_PQT_QLKC_C4_GIAONHAN_KIM(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }


        [Route("update_huyPM_QLKC_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_huyPM_QLKC_C4_GIAONHAN_KIM(int id)
        {
            string result = db.update_huyPM_QLKC_C4_GIAONHAN_KIM(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { error = result });
            }
        }

        [Route("update_loaiBBan_QLKC_C4_GIAONHAN_KIM")]
        [HttpPut]
        public IActionResult update_loaiBBan_QLKC_C4_GIAONHAN_KIM(int id)
        {
            string result = db.update_loaiBBan_QLKC_C4_GIAONHAN_KIM(id);

            if (string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return BadRequest(new { Error = result });
            }
        }

        [Route("search_C4_GIAONHAN_KIM")]
        [HttpPost]
        public IActionResult search_C4_GIAONHAN_KIM([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
                string doN_VI_GIAO = null;
                string doN_VI_NHAN = null;
                int? tranG_THAI = null;
                string? loai = null;

                DateTime? ngaY_GIAO = null;
                DateTime? ngaY_NHAN = null;
                string? userId = null;
                string? ma_dviqly = null;

                if (formData.TryGetValue("pageIndex", out var pageIndexValue) && int.TryParse(pageIndexValue?.ToString(), out var parsedPageIndex))
                {
                    pageIndex = parsedPageIndex;
                }

                if (formData.TryGetValue("pageSize", out var pageSizeValue) && int.TryParse(pageSizeValue?.ToString(), out var parsedPageSize))
                {
                    pageSize = parsedPageSize;
                }

                if (formData.TryGetValue("doN_VI_GIAO", out var doN_VI_GIAO_Value))
                {
                    doN_VI_GIAO = doN_VI_GIAO_Value?.ToString();
                }

                if (formData.TryGetValue("doN_VI_NHAN", out var doN_VI_NHAN_Value))
                {
                    doN_VI_NHAN = doN_VI_NHAN_Value?.ToString();
                }

                if (formData.TryGetValue("tranG_THAI", out var tranG_THAI_Value) && int.TryParse(tranG_THAI_Value?.ToString(), out var parsedTrangThai))
                {
                    tranG_THAI = parsedTrangThai;
                }

                if (formData.TryGetValue("loai", out var loaiValue))
                {
                    loai = loaiValue?.ToString();
                }
                if (formData.TryGetValue("ngaY_GIAO", out var ngaY_GIAOValue))
                {
                    ngaY_GIAO = DateTime.Parse(ngaY_GIAOValue?.ToString()); // Gán giá trị cho ngaY_GIAO
                }

                if (formData.TryGetValue("ngaY_NHAN", out var ngaY_NHANValue))
                {
                    ngaY_NHAN = DateTime.Parse(ngaY_NHANValue?.ToString()); // Gán giá trị cho ngaY_NHAN
                }
                if (formData.TryGetValue("userId", out var userIdValue)) // Lấy userId từ formData
                {
                    userId = userIdValue?.ToString();
                }
                if (formData.TryGetValue("ma_dviqly", out var ma_dviqlyValue)) // Lấy userId từ formData
                {
                    ma_dviqly = ma_dviqlyValue?.ToString();
                }



                int totalItems = 0;
                List<QLKC_C4_GIAONHAN_KIM_Model> result = db.search_C4_GIAONHAN_KIM(pageIndex, pageSize, doN_VI_GIAO, doN_VI_NHAN, tranG_THAI, loai, ngaY_GIAO, ngaY_NHAN, userId, ma_dviqly, out totalItems);

                return result != null ? Ok(new
                {
                    page = pageIndex,
                    pageSize = pageSize,
                    totalItems = totalItems,
                    data = result,
                    doN_VI_GIAO = doN_VI_GIAO,
                    doN_VI_NHAN = doN_VI_NHAN,
                    tranG_THAI = tranG_THAI,
                    loai = loai,

                    ngaY_GIAO = ngaY_GIAO,
                    ngaY_NHAN = ngaY_NHAN,
                    ma_dviqly = ma_dviqly,

                }) : NotFound();



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
