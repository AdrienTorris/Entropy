/// <WARNING>
/// ANY ERROR HERE WILL BE FATAL FOR THE ENTIRE APPLICATION
/// </WARNING>
namespace WPFDBCLM.Controllers
{
    using System;

    /// <summary>
    /// Classe uses by all the controllers
    /// </summary>
    public abstract class BaseController
    {
        protected readonly string _CONNECTION_STRING = null;

        public BaseController(string connectionString)
        {
            _CONNECTION_STRING = connectionString;
        }

        protected T Invoke<T>(Type controller, Enum ope)
        {
            using (System.Data.Common.DbConnection dbc = InitConnection())
            {
                controller.GetMethod("InitServices").Invoke(this, new[] { dbc });

                return (T)Convert.ChangeType(controller.GetMethod(ope.ToString()).Invoke(this, null), typeof(T));
            }
        }

        public abstract void InitServices(System.Data.Common.DbConnection dbc);

        private System.Data.Common.DbConnection InitConnection()
        {
            System.Data.SqlClient.SqlConnection ret = new System.Data.SqlClient.SqlConnection(_CONNECTION_STRING);

            if (ret.State != System.Data.ConnectionState.Open)
                ret.Open();

            return ret;
        }
    }
}