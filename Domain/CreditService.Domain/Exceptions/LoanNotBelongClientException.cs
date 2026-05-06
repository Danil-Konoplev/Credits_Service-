namespace CreditService.Domain.Exceptions;

public class LoanNotBelongClientException(Loan loan, Client client)
    : InvalidOperationException($"The loan (id = {loan.Id}) is not in the client's loan list (client {client.FullName}, id = {client.Id}).")
{
    public Loan Loan => loan;
    public Client Client => client;
}

