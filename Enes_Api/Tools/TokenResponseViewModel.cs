namespace Enes_Api.Tools
{
    public class TokenResponseViewModel
    {
        public TokenResponseViewModel(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        } // Constructor oluşturuyoruz, token ve geçerlilik süresi bu yapılandırıcıya atanıyor.

        public string Token { get; set; } // Oluşturulan JWT token.
        public DateTime ExpireDate { get; set; } // Tokenin geçerlilik süresi.
    }
}

// (JWT Çalışması)
