using MediatR;

namespace MinimalApiWithMediatRLab.Requests;

public interface IHttpRequest : IRequest<IResult>
{
}