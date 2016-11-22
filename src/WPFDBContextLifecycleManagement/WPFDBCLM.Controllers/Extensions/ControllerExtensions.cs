using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDBCLM.Controllers.Extensions
{
    /// <summary>
    /// Methods availables for all the controllers
    /// </summary>
    public static class ControllerExtensions
    {
        ///// <summary>
        ///// The good way to call a method
        ///// </summary>
        ///// <param name="Type">Type of the controller to call</param>
        ///// <typeparam name="T">Type of return you expect</typeparam>
        ///// <param name="ope">Name of operation your need to execute</param>
        ///// <returns></returns>
        public static T Invoke<T>(this IController controller, Enum ope) => controller.Invoke<T>(controller.GetType(), ope);

        ///// <summary>
        ///// The good way to call a method
        ///// </summary>
        ///// <param name="Type">Type of the controller to call</param>
        ///// <typeparam name="T">Type of return you expect</typeparam>
        ///// <param name="ope">Name of operation your need to execute</param>
        ///// <param name="p">Parameters to pass to the method</param>
        ///// <returns></returns>
        public static T Invoke<T>(this IController controller, Enum ope, object[] p) => controller.Invoke<T>(controller.GetType(), ope, p);
    }
}