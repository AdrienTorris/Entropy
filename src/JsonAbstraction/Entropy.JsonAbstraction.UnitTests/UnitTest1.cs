using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Entropy.JsonAbstraction.UnitTests.Models;
using System.Linq;

namespace Entropy.JsonAbstraction.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadDeclarations()
        {
            string json = null, filepath = null;
            JObject jo;
            IEnumerable<JToken> decs;
            List<DeclarationModel> _decs;

            try
            {
                filepath = @"jsons/sample1.json";

                Assert.IsTrue(File.Exists(filepath));

                using (FileStream fs = File.OpenRead(filepath))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        json = sr.ReadToEnd();
                    }
                }

                Assert.IsNotNull(json);
                Assert.AreNotEqual<string>(string.Empty, json);

                jo = JObject.Parse(json);

                Assert.IsNotNull(jo);

                decs = jo.SelectTokens("declarations").Children();

                Assert.IsNotNull(decs);

                _decs = new List<DeclarationModel>();

                foreach (JToken dec in decs)
                {
                    DeclarationModel _dec = dec.ToObject<DeclarationModel>();

                    Assert.IsNotNull(_dec);
                    Assert.AreNotEqual<Guid>(Guid.Empty, _dec.Id);
                    Assert.AreNotEqual<int>(0, _dec.Type);

                    _decs.Add(_dec);
                }

                Assert.IsNotNull(_decs);
                Assert.IsFalse(_decs.Count == 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                json = null;
                jo = null;
                decs = null;
                filepath = null;
                _decs = null;
            }
        }

        [TestMethod]
        public void LoadImplementations()
        {
            string json = null, filepath = null;
            JObject jo;
            IEnumerable<JToken> decs;
            List<DeclarationModel> _decs;
            IEnumerable<JToken> impls;
            List<ImplementationModel> _impls;

            try
            {
                filepath = @"jsons/sample1.json";

                Assert.IsTrue(File.Exists(filepath));

                using (FileStream fs = File.OpenRead(filepath))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        json = sr.ReadToEnd();
                    }
                }

                Assert.IsNotNull(json);
                Assert.AreNotEqual<string>(string.Empty, json);

                jo = JObject.Parse(json);

                Assert.IsNotNull(jo);

                // Load declarations first

                decs = jo.SelectTokens("declarations").Children();

                Assert.IsNotNull(decs);

                _decs = new List<DeclarationModel>();

                foreach (JToken dec in decs)
                {
                    DeclarationModel _dec = dec.ToObject<DeclarationModel>();

                    Assert.IsNotNull(_dec);
                    Assert.AreNotEqual<Guid>(Guid.Empty, _dec.Id);
                    Assert.AreNotEqual<int>(0, _dec.Type);

                    _decs.Add(_dec);
                }

                Assert.IsNotNull(_decs);
                Assert.IsFalse(_decs.Count == 0);

                // Foreach declaration, we load the implementation

                impls = jo.SelectTokens("implementations").Children();

                _impls = new List<ImplementationModel>();

                foreach (JObject _token in impls)
                {
                    ImplementationModel impl = new ImplementationModel();

                    foreach (JProperty _jprop in _token.Properties())
                    {
                        if (_jprop.Name == "id")
                        {
                            impl.Id = _jprop.Value.ToObject<Guid>();
                        }
                        else if (_jprop.Name == "content")
                        {
                            List<IImplementationContent> _implContent = new List<IImplementationContent>();

                            switch (_decs.Where(x => x.Id == impl.Id).Select(x => x.Type).First())
                            {
                                case 1:
                                    IEnumerable<BlogPostDetailsImplementationContent> _ctn = _jprop.Value.ToObject<IEnumerable<BlogPostDetailsImplementationContent>>();
                                    _implContent.AddRange(_ctn);
                                    _ctn = null;
                                    break;
                                case 2:
                                    IEnumerable<BlogPostListImplementationContent> _ctn2 = _jprop.Value.ToObject<IEnumerable<BlogPostListImplementationContent>>();
                                    _implContent.AddRange(_ctn2);
                                    _ctn2 = null;
                                    break;
                                default:
                                    Assert.Fail("Unkow type");
                                    break;
                            }
                            impl.Content = _implContent;

                            _implContent = null;
                        }
                    }

                    _impls.Add(impl);

                    impl = null;
                }

                Assert.IsNotNull(_impls);
                Assert.IsFalse(_impls.Count == 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                json = null;
                jo = null;
                decs = null;
                filepath = null;
                _decs = null;
                _impls = null;
            }
        }
    }
}