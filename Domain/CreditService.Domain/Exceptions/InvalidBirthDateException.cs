namespace CreditService.Domain.Exceptions;

public class InvalidBirthDateException(Client client, DateTime birthDate)
    : ArgumentException($"The birth date {birthDate:dd.MM.yyyy} of client {client.FullName} is not correct")
{
    public Client Client => client;
    public DateTime BirthDate => birthDate;
}

