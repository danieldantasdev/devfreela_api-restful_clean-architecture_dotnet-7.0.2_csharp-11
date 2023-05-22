namespace DevFreela.Core.Dtos.Projects;

public class PaymentInfoDto
{
    public int Id { get; private set; }
    public string CreditCardNumber { get; private set; }
    public string Cvv { get; private set; }
    public string ExpiresAt { get; private set; }
    public string FullName { get; private set; }

    public PaymentInfoDto(int id, string creditCardNumber, string cvv, string expiresAt, string fullName)
    {
        Id = id;
        CreditCardNumber = creditCardNumber;
        Cvv = cvv;
        ExpiresAt = expiresAt;
        FullName = fullName;
    }
}