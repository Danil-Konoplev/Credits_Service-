namespace CreditService.Domain.Exceptions;

public class InvalidLoanDateException(Loan loan, DateTime date)
    : ArgumentException($"The date {date:dd.MM.yyyy HH:mm} is not correct for loan (id = {loan.Id})")
{
    public Loan Loan => loan;
    public DateTime Date => date;
}

