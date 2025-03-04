namespace Enes_Api.Tools
{
    public class GetCheckAppUserViewModel
    {
        public  int Id { get; set; }
        public  string Username { get; set; }
        public  string Role { get; set; }
        public  bool IsExist { get; set; }
    }
}

//(JWT Çalışması) Login işlemi sırasındaki 4 adet parametremiz.