namespace Enes_Api.Tools
{
    //Bu sınıf, JWT token'ın geçerliliği ve güvenliği için kullanılan varsayılan değerleri tanımlar (örneğin, geçerli audience, issuer, güvenlik anahtarı ve geçerlilik süresi).
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        //Bu, token'ı alacak geçerli hedef kitlenin (audience) URL'sini belirtir
        public const string ValidIssuer = "https://localhost";
        //Bu, token'ı oluşturan geçerli vericinin (issuer) URL'sini belirtir. 
        public const string Key = "REALestate..0102030405Asp.NetCore8.0.1+-*/";
        //Bu, token'ın imzasını doğrulamak ve şifrelemek için kullanılan gizli anahtardır. 
        public const int Expire = 5;
        //Bu, token'ın kaç dakika süreyle geçerli olacağını belirtir.
    }
}

//(JWT Çalışması)