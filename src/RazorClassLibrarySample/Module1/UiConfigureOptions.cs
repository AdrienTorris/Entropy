namespace Module1
{
    using Microsoft.AspNetCore.Hosting;
    using ModularizationCore.Mvc;

    public sealed class UiConfigureOptions : BaseModuleUiConfigureOptions
    {
        public UiConfigureOptions(IHostingEnvironment environment)
            : base(environment)
        {
        }
    }
}