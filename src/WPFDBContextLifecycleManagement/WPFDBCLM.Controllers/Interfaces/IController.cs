﻿namespace WPFDBCLM.Controllers
{
    using System;

    /// <summary>
    /// Common facade for all the controllers of the application
    /// DON'T CUSTOMIZE THIS
    /// </summary>
    public interface IController
    {
        ///// <summary>
        ///// The good way to call a method
        ///// </summary>
        ///// <param name="Type">Type of the controller to call</param>
        ///// <typeparam name="T">Type of return you expect</typeparam>
        ///// <param name="ope">Name of operation your need to execute</param>
        ///// <returns></returns>
        T Invoke<T>(Type controller, Enum ope);

        ///// <summary>
        ///// The good way to call a method
        ///// </summary>
        ///// <param name="Type">Type of the controller to call</param>
        ///// <typeparam name="T">Type of return you expect</typeparam>
        ///// <param name="ope">Name of operation your need to execute</param>
        ///// <param name="p">Parameters to pass to the method</param>
        ///// <returns></returns>
        T Invoke<T>(Type controller, Enum ope, object[] p);
    }
}