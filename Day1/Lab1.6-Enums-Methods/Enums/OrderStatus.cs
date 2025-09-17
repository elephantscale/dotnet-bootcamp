namespace Lab1_6.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3,
        Cancelled = 4,
        Returned = 5
    }

    public enum Priority
    {
        Low = 1,
        Normal = 2,
        High = 3,
        Critical = 4
    }

    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        PayPal,
        BankTransfer,
        Cash,
        Cryptocurrency
    }

    [Flags]
    public enum DeliveryOptions
    {
        None = 0,
        StandardShipping = 1,
        ExpressShipping = 2,
        OvernightShipping = 4,
        SignatureRequired = 8,
        InsuranceIncluded = 16,
        TrackingIncluded = 32
    }
}