using System;

public class CapitalGain
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }

    public CapitalGain(decimal amount, DateTime date, string type)
    {
        Amount = amount;
        Date = date;
        Type = type;
    }
}