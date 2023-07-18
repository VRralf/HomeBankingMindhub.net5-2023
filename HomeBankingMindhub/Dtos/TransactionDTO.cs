﻿using System;
using System.Text.Json.Serialization;

namespace HomeBankingMindhub.Dtos
{
    public class TransactionDTO
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}