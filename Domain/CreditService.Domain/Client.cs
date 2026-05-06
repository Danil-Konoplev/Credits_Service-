using CreditService.Domain.Base;
using CreditService.Domain.Exceptions;
using CreditService.ValueObjects;

namespace CreditService.Domain
{
    public class Client : Entity<Guid>
    {
        private readonly List<Loan> _loans = [];

        public FullName FullName { get; private set; } = default!;

        public PassportNumber PassportNumber { get; } = default!;


        public DateTime BirthDate { get; }

        public IReadOnlyList<Loan> Loans => _loans.AsReadOnly();

        protected Client() : base(Guid.Empty) { }

        public Client(FullName fullName, PassportNumber passportNumber, DateTime birthDate)
            : this(Guid.NewGuid(), fullName, passportNumber, birthDate) { }

        protected Client(Guid id, FullName fullName, PassportNumber passportNumber, DateTime birthDate)
            : base(id)
        {
            FullName = fullName ?? throw new ArgumentNullValueException(nameof(fullName));
            PassportNumber = passportNumber ?? throw new ArgumentNullValueException(nameof(passportNumber));

            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(this, birthDate);

            BirthDate = birthDate;
        }

        public bool UpdateFullName(FullName newFullName)
        {
            if (newFullName == null) throw new ArgumentNullValueException(nameof(newFullName));
            if (FullName == newFullName) return false;
            FullName = newFullName;
            return true;
        }

        public Loan ApplyForLoan(LoanAmount amount, InterestRate rate, LoanTermMonths termMonths)
        {
            var loan = new Loan(this, amount, rate, termMonths, DateTime.UtcNow);
            _loans.Add(loan);
            return loan;
        }

        public void ApproveLoan(Loan loan)
        {
            if (loan.Client != this) throw new LoanNotBelongClientException(loan, this);
            if (!_loans.Contains(loan)) throw new LoanNotBelongClientException(loan, this);

            loan.Approve();
        }

        public void RejectLoan(Loan loan)
        {
            if (loan.Client != this) throw new LoanNotBelongClientException(loan, this);
            if (!_loans.Contains(loan)) throw new LoanNotBelongClientException(loan, this);

            loan.Reject();
        }

        public void CloseLoan(Loan loan)
        {
            if (loan.Client != this) throw new LoanNotBelongClientException(loan, this);
            if (!_loans.Contains(loan)) throw new LoanNotBelongClientException(loan, this);

            loan.Close();
        }
    }
}
