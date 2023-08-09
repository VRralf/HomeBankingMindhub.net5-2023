﻿namespace AplicationNet6.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}
