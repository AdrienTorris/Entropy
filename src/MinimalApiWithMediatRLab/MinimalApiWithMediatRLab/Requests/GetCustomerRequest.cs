namespace MinimalApiWithMediatRLab.Requests;

public class GetCustomerRequest : IHttpRequest
{
    public int Id { get; set; }
}
