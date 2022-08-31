using MediatR;
using MinimalApiWithMediatRLab.Requests;
using MinimalApiWithMediatRLab.Services;

namespace MinimalApiWithMediatRLab.Handlers;

internal class GetCustomerHandler : IRequestHandler<GetCustomerRequest, IResult>
{
    private readonly ICustomerService _customerService;

    public GetCustomerHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IResult> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        Customer customer = await _customerService.GetAsync(request.Id);

        return customer != null
            ? Results.Ok(customer)
            : Results.NotFound();
    }
}