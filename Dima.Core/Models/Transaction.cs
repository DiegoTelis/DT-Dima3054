﻿using Dima.Core.Enums;
using System.Text.Json.Serialization;

namespace Dima.Core.Models;

public class Transaction
{ 
    public long Id { get; set; }
    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? PaidOrReceiveAt { get; set; }
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    [JsonIgnore]
    public string UserId { get; set; } = string.Empty;
}
