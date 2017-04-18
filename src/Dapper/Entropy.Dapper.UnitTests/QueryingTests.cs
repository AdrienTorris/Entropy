using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Entropy.Dapper.UnitTests
{
    /// <summary>
    /// Simple test cases about querying SQL Server data with Dapper
    /// </summary>
    /// <see cref="https://stackexchange.github.io/Dapper/"/>
    [TestClass]
    public class QueryingTests
    {
        [TestMethod]
        public void TestGetItem()
        {
            IEnumerable<Class1> ret;

            try
            {
                using (DbConnection con = new SqlConnection(ConfigurationProvider._connection_string))
                {
                    ret = con.Query<Class1>("select * from Anomalie WHERE Id = @Id", new { Id = 1 });
                }

                Assert.IsNotNull(ret);
                Assert.AreEqual<int>(1, ret.Count());
                Assert.AreEqual<int>(1, ret.First().Id);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                ret = null;
            }
        }

        [TestMethod]
        public void TestListItems()
        {
            IEnumerable<Class1> ret;

            try
            {
                using (DbConnection con = new SqlConnection(ConfigurationProvider._connection_string))
                {
                    ret = con.Query<Class1>("select * from Anomalie", new { Id = 1 });
                }

                Assert.IsNotNull(ret);
                Assert.AreNotEqual<int>(0, ret.Count());
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestGetItemWithTransaction()
        {
            IEnumerable<Class1> ret;

            try
            {
                using (DbConnection con = new SqlConnection(ConfigurationProvider._connection_string))
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    using (DbTransaction trans = con.BeginTransaction())
                    {
                        ret = con.Query<Class1>("select * from Anomalie WHERE Id = @Id", new { Id = 1 }, transaction: trans);
                    }
                }

                Assert.IsNotNull(ret);
                Assert.AreEqual<int>(1, ret.Count());
                Assert.AreEqual<int>(1, ret.First().Id);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                ret = null;
            }
        }

        public class Class1
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Label { get; set; }
        }
    }
}