﻿namespace Base.Configuration.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpirationTime { get; set; }
        public string Issuer { get; set; }
        public string ValidIn { get; set; }
    }
}
