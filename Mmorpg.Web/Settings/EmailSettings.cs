namespace Mmorpg.Web.Settings
{
    public class EmailSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 587;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool UseSsl { get; set; } = true;
        public string FromName { get; set; } = "MMORPG";
        public string FromAddress { get; set; } = string.Empty;
    }
}
