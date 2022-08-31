using MinimalApiWithMediatRLab.Requests;
using MediatR;

internal static class MediatRExtensions
{
    internal static WebApplication MediateGet<TRequest>(this WebApplication app, string template) where TRequest : IHttpRequest
    {
        app.MapGet(template, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }

    internal static WebApplication MediatePost<TRequest>(this WebApplication app, string template) where TRequest : IHttpRequest
    {
        app.MapPost(template, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }
}