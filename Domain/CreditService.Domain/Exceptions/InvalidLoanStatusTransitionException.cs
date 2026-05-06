namespace CreditService.Domain.Exceptions;

public class InvalidLoanStatusTransitionException(Loan loan, LoanStatus currentStatus, LoanStatus targetStatus)
    : InvalidOperationException($"The loan (id = {loan.Id}) can't be moved from status \"{currentStatus}\" to \"{targetStatus}\".")
{
    public Loan Loan => loan;
    public LoanStatus CurrentStatus => currentStatus;
    public LoanStatus TargetStatus => targetStatus;
}

