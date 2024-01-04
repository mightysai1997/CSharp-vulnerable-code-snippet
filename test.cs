using System;

public class CreditCardData
{
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
    // Other sensitive credit card information fields...
}

public class InsecurePaymentProcessor
{
    // Simulating an insecure payment processor with a static instance holding credit card data
    private static CreditCardData insecureCreditCardData;

    public static void ProcessPayment(string cardNumber, string expiryDate, string cvv)
    {
        // Insecurely storing credit card data without encryption or secure storage measures
        insecureCreditCardData = new CreditCardData
        {
            CardNumber = cardNumber,
            ExpiryDate = expiryDate,
            CVV = cvv
            // Other sensitive credit card information...
        };
    }

    public static CreditCardData GetStoredCreditCardData()
    {
        // Simulating an insecure retrieval of stored credit card data
        return insecureCreditCardData;
    }
}

public class Program
{
    public static void Main()
    {
        // Simulating a scenario where an unauthorized actor retrieves stored credit card data
        CreditCardData exposedCreditCardData = InsecurePaymentProcessor.GetStoredCreditCardData();

        // Displaying exposed credit card data (for educational purposes only)
        Console.WriteLine("Unauthorized Access: Exposed Credit Card Data");
        Console.WriteLine($"Card Number - {exposedCreditCardData.CardNumber}");
        Console.WriteLine($"Expiry Date - {exposedCreditCardData.ExpiryDate}");
        Console.WriteLine($"CVV - {exposedCreditCardData.CVV}");
        // Displaying other sensitive credit card information...
    }
}
