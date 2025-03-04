//using Enes_Api.Tools;
//using Microsoft.AspNetCore.Mvc;

//namespace Enes_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TokenCreateController : ControllerBase
//    {
//        [HttpPost]
//        public IActionResult CreateToken(GetCheckAppUserViewModel model)
//        {
//            // Kullanıcıdan alınan model bilgilerine göre token oluşturuluyor.
//            var values = JwtTokenGenerator.GenerateToken(model);
//            // Oluşturulan token ve bilgileri HTTP 200 OK yanıtıyla geri döndürüyoruz.
//            return Ok(values);
//        }
//    }
//    // Bu controller, API üzerinden POST isteği alarak JWT token oluşturur.
//}

// STATİK OLARAK TOKENİ FRONTENDE GÖNDERİYORUM
using Enes_Api.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Enes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCreateController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateToken()
        {
            // Sabit (statik) değerlerle yeni bir model oluşturuyoruz.
            var staticModel = new GetCheckAppUserViewModel
            {
                Id = 1, // Statik olarak atanmış ID
                Username = "ENES", // Statik olarak atanmış Username
                Role = "Admin", // Statik olarak atanmış Rol
                IsExist = true // Kullanıcının mevcut olduğunu belirten sabit değer
            };

            // Sabit değerlerle oluşturduğumuz model ile token oluşturuyoruz.
            var values = JwtTokenGenerator.GenerateToken(staticModel);

            // Oluşturulan token ve bilgileri HTTP 200 OK yanıtıyla geri döndürüyoruz.
            return Ok(values);
        }
    }
}

