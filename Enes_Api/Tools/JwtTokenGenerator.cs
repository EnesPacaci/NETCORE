using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Enes_Api.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model) // Statik metod tanımlıyoruz (direkt sınıf üzerinden erişim sağlanabilir)
        {
            var claims=new List<Claim>(); // JWT için kullanıcıya atanacak talepler (claims) listesi oluşturuyoruz.
            if (!string.IsNullOrWhiteSpace(model.Role)) // İçerisinde bir değer varsa (Kullanıcının rolü varsa)

                claims.Add(new Claim(ClaimTypes.Role, model.Role)); 
                // Yukarıda oluşturulan claimin içerisine Role eklemesi

                claims.Add(new Claim(ClaimTypes.NameIdentifier,model.Id.ToString()));
                // Yukarıda oluşturulan claimin içerisine Id eklemesi

            if (!string.IsNullOrWhiteSpace(model.Username))

                claims.Add(new Claim("Username",model.Username)); 
            // Yukarıda oluşturulan claimin içerisine Username eklemesi

            // Tokenin oluşturulması
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)); // Token imzası için güvenlik anahtarını oluşturuyoruz. SymmetricSecurityKey, anahtarı şifreleme algoritmasında kullanmak için gereklidir.
            var signinCredentials =new SigningCredentials(key,SecurityAlgorithms.HmacSha256); // Token imzalamak için HMACSHA256 algoritmasını kullanarak kimlik doğrulama bilgilerini oluşturuyoruz.
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire); // Tokenin geçerlilik süresi

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims, notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: signinCredentials);
            // Yeni bir JWT token oluşturuyoruz. Bu token, issuer, audience, claims, geçerlilik süresi ve imzalama bilgilerini içeriyor.

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            // JWT token'ı işleyip yazdırmak için JwtSecurityTokenHandler sınıfını kullanıyoruz.

            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
            // Tokeni yazdırıyor ve TokenResponseViewModel ile geri döndürüyoruz.
        }
    }
}

// (JWT Çalışması)
