/// <WARNING>
/// ANY ERROR HERE WILL BE FATAL FOR THE ENTIRE APPLICATION
/// </WARNING>
namespace WPFDBCLM.Controllers
{
    using System;

    /// <summary>
    /// Classe uses by all the controllers
    /// </summary>
    public abstract class BaseController : IController
    {
        protected readonly string _CONNECTION_STRING = null;

        public BaseController(string connectionString)
        {
            _CONNECTION_STRING = connectionString;
        }

        ///// <summary>
        ///// The good way to call a method
        ///// </summary>
        ///// <param name="Type">Type of the controller to call</param>
        ///// <typeparam name="T">Type of return you expect</typeparam>
        ///// <param name="ope">Name of operation your need to execute</param>
        ///// <returns></returns>
        public T Invoke<T>(Type controller, Enum ope)
        {
            using (System.Data.Common.DbConnection dbc = InitConnection())
            {
                controller.GetMethod("InitServices").Invoke(this, new[] { dbc });

                return (T)Convert.ChangeType(controller.GetMethod(ope.ToString()).Invoke(this, null), typeof(T));
            }
        }

        ///// <summary>
        ///// The good way to call a method
        ///// </summary>
        ///// <param name="Type">Type of the controller to call</param>
        ///// <typeparam name="T">Type of return you expect</typeparam>
        ///// <param name="ope">Name of operation your need to execute</param>
        ///// <param name="p">Parameters to pass to the method</param>
        ///// <returns></returns>
        public T Invoke<T>(Type controller, Enum ope, object[] p)
        {
            using (System.Data.Common.DbConnection dbc = InitConnection())
            {
                controller.GetMethod("InitServices").Invoke(this, new[] { dbc });

                return (T)Convert.ChangeType(controller.GetMethod(ope.ToString()).Invoke(this, p), typeof(T));
            }
        }

        //TODO: invoke with transaction

        public abstract void InitServices(System.Data.Common.DbConnection dbc);

        private System.Data.Common.DbConnection InitConnection()
        {
            System.Data.Common.DbConnection ret = new System.Data.SqlClient.SqlConnection(_CONNECTION_STRING);

            if (ret.State != System.Data.ConnectionState.Open)
                ret.Open();

            return ret;
        }
    }
}