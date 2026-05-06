using CreditService.Domain.Base;
using CreditService.Domain.Exceptions;
using CreditService.ValueObjects;

namespace CreditService.Domain
{
    public class Loan : Entity<Guid>
    {
        public Client Client { get; } = default!;

        public LoanAmount Amount { get; private set; } = default!;

        public InterestRate Rate { get; private set; } = default!;


        public LoanTermMonths TermMonths { get; private set; } = default!;

        public LoanStatus Status { get; private set; }

        public DateTime ApplicationDate { get; }

        public DateTime? ApprovalDate { get; private set; } = null;

        public DateTime? CloseDate { get; private set; } = null;

        protected Loan() : base(Guid.Empty) { }

        public Loan(Client client, LoanAmount amount, InterestRate rate, LoanTermMonths termMonths, DateTime applicationDate)
            : this(Guid.NewGuid(), client, amount, rate, termMonths, applicationDate) { }

        protected Loan(Guid id, Client client, LoanAmount amount, InterestRate rate,
            LoanTermMonths termMonths, DateTime applicationDate,
            LoanStatus status = LoanStatus.Pending,
            DateTime? approvalDate = null,
            DateTime? closeDate = null)
            : base(id)
        {
            Client = client ?? throw new ArgumentNullValueException(nameof(client));
            Amount = amount ?? throw new ArgumentNullValueException(nameof(amount));
            Rate = rate ?? throw new ArgumentNullValueException(nameof(rate));
            TermMonths = termMonths ?? throw new ArgumentNullValueException(nameof(termMonths));

            if (approvalDate is not null && approvalDate < applicationDate)
                throw new InvalidLoanDateException(this, approvalDate.Value);

            ApplicationDate = applicationDate;
            ApprovalDate = approvalDate;
            CloseDate = closeDate;
            Status = status;
        }

        internal void Approve()
        {
            if (Status != LoanStatus.Pending)
                throw new InvalidLoanStatusTransitionException(this, Status, LoanStatus.Approved);

            Status = LoanStatus.Approved;
            ApprovalDate = DateTime.UtcNow;
        }

        internal void Reject()
        {
            if (Status != LoanStatus.Pending)
                throw new InvalidLoanStatusTransitionException(this, Status, LoanStatus.Rejected);

            Status = LoanStatus.Rejected;
        }

        public void Activate()
        {
            if (Status != LoanStatus.Approved)
                throw new InvalidLoanStatusTransitionException(this, Status, LoanStatus.Active);

            Status = LoanStatus.Active;
        }

        internal void Close()
        {
            if (Status != LoanStatus.Active)
                throw new InvalidLoanStatusTransitionException(this, Status, LoanStatus.Closed);

            Status = LoanStatus.Closed;
            CloseDate = DateTime.UtcNow;
        }
    }
}
