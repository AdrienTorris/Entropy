namespace MinimalApiWithMediatRLab.Services;

public class CustomerService : ICustomerService
{
    private static readonly Customer[] customers =
    {
        new Customer(1, "Adrien", "Torris"),
        new Customer(2, "Scott", "Parker"),
        new Customer(3, "Bruce", "Wayne"),
        new Customer(4, "Tin", "Tin")
    };

    public async Task<Customer> GetAsync(int id)
    {
        await Task.Delay(10);
        return customers.SingleOrDefault(x => x.Id == id);
    }
}

public class Customer
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public Customer(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}
