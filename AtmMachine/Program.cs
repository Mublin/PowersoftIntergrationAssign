using AtmMachine;
using System;
using static AtmMachine.Person;


var peopleAcct = ATMFunctionality.InitializePeople();
Console.WriteLine("Enter your Id");
string ? InputedId = Console.ReadLine();
if (InputedId != null)
{
    Person ? verifyPerson = peopleAcct.SingleOrDefault(p => p.Id == int.Parse(InputedId));
    if (verifyPerson != null)
    {
        Console.WriteLine("Enter Id pin");
        string? EnteredPin = Console.ReadLine();
        if (int.Parse(EnteredPin) == verifyPerson.Pin)
        {
            Console.WriteLine($"Welcome {verifyPerson.Name}!");
            Console.WriteLine("Please choose a service from 1 to 5. e.g 3 e.t.c");
            Console.WriteLine("1. Transfer funds");
            Console.WriteLine("2. Withdraw cash");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. Change pin");
            Console.WriteLine("5. Quit transaction");
            string? actionInput = Console.ReadLine();
            if (actionInput != null)
            {
                int no = int.Parse(actionInput);
                switch (no)
                {
                    case 1:
                        Console.WriteLine(ATMFunctionality.TransferFund(verifyPerson));
                        break;
                    case 2:
                        Console.WriteLine(ATMFunctionality.WithdrawCash(verifyPerson));
                        break;
                    case 3:
                        Console.WriteLine(ATMFunctionality.CheckBalance(verifyPerson));
                        break;
                    case 4:
                        Console.WriteLine(ATMFunctionality.ChangePin(verifyPerson));
                        break;
                    case 5:
                    default:
                        Console.WriteLine(ATMFunctionality.QuitTransaction());
                        break;
                }

            }

        }
        else
        {
            Console.WriteLine("Invalid pin");
        }
    } else
    {
        Console.WriteLine("Invalid Id");
    }
}



public class ATMFunctionality
{
    private static List<Person> PeopleAcct = new List<Person>();
    public static List<Person> InitializePeople()
    {
        PeopleAcct.Add(new Person(Id: 1, AcctNo: 12345678901, Name: "Abdul", Balance: 3546.744m, Pin: 1234));
        PeopleAcct.Add(new Person(Id: 2, AcctNo: 12345678902, Name: "Aminu", Balance: 351.744m, Pin: 1534));
        PeopleAcct.Add(new Person(Id: 3, AcctNo: 12346678901, Name: "Ameer", Balance: 1546.740m, Pin: 1235));
        return PeopleAcct;
    }
    public static string ChangePin(Person personDetail) {
        Console.WriteLine("Enter new pin");
        string? pin = Console.ReadLine();
        Console.WriteLine("Enter new pin again");
        string? pin2 = Console.ReadLine();
        if (pin != pin2)
        {
            return "Pin do not match";
        }
        int getIndex = PersonIndex(personDetail);
        PeopleAcct[getIndex] = new(Name: personDetail.Name, Id: personDetail.Id, Pin: int.Parse(pin), Balance: personDetail.Balance, AcctNo: personDetail.AcctNo);
        return "Pin successfully changed";
    }
    public static string QuitTransaction() {
        return "";
    }
    public static string CheckBalance(Person personDetail) {
        return $"Balance: {personDetail.Balance}";
    }
    public static int PersonIndex (Person person1)
    {
        return PeopleAcct.FindIndex(i => i.Id == person1.Id);
    }
    public static string WithdrawCash(Person personDetail) {
        Console.WriteLine("Enter amount you want to transfer");
        string? amount = Console.ReadLine();
        decimal updatedAmount = decimal.Parse(amount);
        if (updatedAmount > personDetail.Balance)
        {
            return "Insufficient fund";
        }
        int verifiedPersonIndex = PersonIndex(personDetail);
        PeopleAcct[verifiedPersonIndex] = new(Name: personDetail.Name, Id: personDetail.Id, Pin: personDetail.Pin, Balance: personDetail.Balance - updatedAmount, AcctNo: personDetail.AcctNo);
        return $"Successful, new balance: {PeopleAcct[verifiedPersonIndex].Balance}";
    }

    public static string TransferFund(Person personDetail)
    {
        Console.WriteLine("Enter amount you want to transfer");
        string ? amount = Console.ReadLine();
        Console.WriteLine("Enter beneficiary account number");
        string? AcctNo = Console.ReadLine();
        long InputedAcctNo = long.Parse(AcctNo);
        decimal updatedAmount = decimal.Parse(amount);
        Person? InputedAcctNoOwner = PeopleAcct.SingleOrDefault(p => p.AcctNo == InputedAcctNo);
        var errors = new Dictionary<string, string[]>();
        if (updatedAmount > personDetail.Balance)
        {
            errors.Add(nameof(personDetail.Balance), ["Insufficient funds"]);
        }
        if (InputedAcctNoOwner.AcctNo == personDetail.AcctNo)
        {
            errors.Add(nameof(personDetail.AcctNo), ["cannot send to own account"]);
        }
        if (InputedAcctNoOwner == null)
        {
            errors.Add(nameof(personDetail.AcctNo), ["Invalid account number"]);
        }
        if (errors.Count > 0)
        {
            return "Insufficient fund or invalid accountnumber";
        }
        int verifiedPersonIndex = PersonIndex(personDetail);
        int verifiedAcctPersonIndex = PersonIndex(InputedAcctNoOwner);
        PeopleAcct[verifiedAcctPersonIndex] = new (Name: InputedAcctNoOwner.Name, Id: InputedAcctNoOwner.Id, Pin: InputedAcctNoOwner.Id, Balance: InputedAcctNoOwner.Balance + updatedAmount, AcctNo: InputedAcctNoOwner.AcctNo);
        PeopleAcct[verifiedPersonIndex] = new (Name: personDetail.Name, Id: personDetail.Id, Pin: personDetail.Pin, Balance: personDetail.Balance - updatedAmount, AcctNo: personDetail.AcctNo);
        for (int i = 0; i < PeopleAcct.Count; i++)
            {
                Console.WriteLine(PeopleAcct[i].Balance);
            }
        return "Transfer is successful";
    }
}
