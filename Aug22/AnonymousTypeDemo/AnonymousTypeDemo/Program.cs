class Sample
{
    public Tuple<string, int> GetPersonDetails()
    {
        return new Tuple<string, int>("bob", 24);
    }
}



class Program
{
    static void Main(string[] args)
    {
        var person = new { Name = "tim", Age = 21 }; // Anonymous type
        //Console.WriteLine(person.Name + " is " + person.Age + " years old");

        var person2 = new { Name = "John", Age = 22, Address = new { flat = 2, city = "tvl" } }; //Nested anonymous type
        //Console.WriteLine(person2.Name + " is " + person2.Age + " years old " + "residing at flat " + person2.Address.flat + " in " + person2.Address.city);

        var personList = new[]
        {
            new { Name = "tim", Age = 21 },
            new { Name = "bob", Age = 25 },
            new { Name = "alex", Age = 30 }
        };

        foreach (var x in personList)
        {
            //Console.WriteLine(x.Name + " is " + x.Age + " years old");
        }

        Tuple<string, int> p1 = new Tuple<string, int>("scott", 20);
        //p1.Item1 = "anderw"; tuple is read only
        //Console.WriteLine(p1.Item1);
        //Console.WriteLine(p1.Item2);

        //value tuple
        (int customerId, string customerName, string email) customer = (101, "Babu", "babu@gmail.com");
        Console.WriteLine(customer.customerId + "   " + customer.customerName + "   " + customer.email);

        //Deconstruction
        (int id, string name, string email) = customer;
        Console.WriteLine(id + "  " + name + "  " + email);

        //Discard
        (_, string customerName, _) = customer;
        Console.WriteLine(customerName);

        Console.WriteLine("william" == "william");
    }
}