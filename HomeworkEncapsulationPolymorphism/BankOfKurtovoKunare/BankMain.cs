namespace BankOfKurtovoKunare
{
    using System;
    using Accounts;
    using Custumers;
    using Interfaces;

    public class BankMain
    {
        public static void Main()
        {
            ICustumer pesho = new Individual("Pesho Peshev");
            ICustumer gosho = new Individual("Georgi Serev");
            ICustumer softUni = new Company("Software University");

            IAccount depositIndividual = new Deposit(pesho, 1500, 2);
            IAccount mortgageIndividual = new Mortgage(gosho, 17465, 3);
            IAccount loanIndividual = new Loan(pesho, 35467225, 1);

            IAccount depositCompany = new Deposit(softUni, 376254672354672354, 10);
            IAccount mortgageCompany = new Mortgage(softUni, 96540, 7);
            IAccount loanCompany = new Loan(softUni, 30000, 5);

            Console.WriteLine(depositIndividual.CalculateInterest(17));
            Console.WriteLine(depositIndividual.CalculateInterest(1));
            Console.WriteLine(depositCompany.CalculateInterest(25));
            Console.WriteLine(depositCompany.CalculateInterest(6));

            Console.WriteLine(mortgageIndividual.CalculateInterest(34));
            Console.WriteLine(mortgageIndividual.CalculateInterest(3));
            Console.WriteLine(mortgageCompany.CalculateInterest(87));
            Console.WriteLine(mortgageCompany.CalculateInterest(4));

            Console.WriteLine(loanIndividual.CalculateInterest(76));
            Console.WriteLine(loanIndividual.CalculateInterest(2));
            Console.WriteLine(loanCompany.CalculateInterest(67));
            Console.WriteLine(loanCompany.CalculateInterest(7));
        }
    }
}
