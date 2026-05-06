using CreditService.Domain;
using CreditService.ValueObjects;

namespace CreditService.DomainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fullName = new FullName("Иванов Иван Иванович");
            var passport = new PassportNumber("1234 567890");
            var birthDate = new DateTime(1990, 5, 15);


            var client = new Client(fullName, passport, birthDate);

            Console.WriteLine($"Клиент создан: {client.FullName}, паспорт: {client.PassportNumber}");

            var amount = new LoanAmount(500_000m);
            var rate = new InterestRate(12.5m);
            var term = new LoanTermMonths(36);

            var loan = client.ApplyForLoan(amount, rate, term);

            Console.WriteLine($"Заявка подана. Статус: {loan.Status}, сумма: {loan.Amount} руб., ставка: {loan.Rate}%, срок: {loan.TermMonths} мес.");

            client.ApproveLoan(loan);
            Console.WriteLine($"Заявка одобрена. Статус: {loan.Status}");

            loan.Activate();
            Console.WriteLine($"Кредит активирован. Статус: {loan.Status}");

            client.CloseLoan(loan);
            Console.WriteLine($"Кредит закрыт. Статус: {loan.Status}");
        }
    }
}
