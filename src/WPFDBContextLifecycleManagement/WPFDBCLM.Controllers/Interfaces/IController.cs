namespace WPFDBCLM.Controllers
{
    using System;

    /// <summary>
    /// Common facade for all the controllers of the application
    /// DON'T CUSTOMIZE THIS
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// The good way to call a method
        /// </summary>
        /// <typeparam name="T">Type of return you expect</typeparam>
        /// <param name="ope">Name of operation your need to execute</param>
        /// <returns></returns>
        T Invoke<T>(Enum ope);
    }
}