namespace MinimalApiWithMediatRLab.Services;

public interface ICustomerService
{
    Task<Customer> GetAsync(int id);
}

