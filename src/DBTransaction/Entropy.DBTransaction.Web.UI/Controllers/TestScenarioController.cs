using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entropy.DBTransaction.BusinessLogic;
using Entropy.DBTransaction.Web.UI.Models.TestScenarioViewModels;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Entropy.DBTransaction.Web.UI.Controllers
{
    [Route("tests")]
    public class TestScenarioController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService1 _service1;
        private readonly IService2 _service2;
        private readonly IService3 _service3;

        public TestScenarioController(
            ILoggerFactory loggerFactory
            , IService1 service1
            , IService2 service2
            , IService3 service3)
        {
            _logger = loggerFactory.CreateLogger<TestScenarioController>();
            _service1 = service1;
            _service2 = service2;
            _service3 = service3;
        }

        /// <summary>
        /// On enregistre la valeur puis on déclenche une exception
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpGet]
        [Route("scenario1")]
        public JsonResult Create_ThrowExceptionAfterSaveChanges()
        {
            Guid k = Guid.NewGuid();
            ReportViewModel model = new ReportViewModel(k);

            try
            {

                _service1.Create_ThrowExceptionAfterSaveChanges(k);

            }
            catch (Exception ex)
            {
                model.Exception = ex;
                model.ExceptionMessage = ex.Message;
            }

            return new JsonResult(model);
        }

        /// <summary>
        /// On enregistre la valeur par un repo, puis un deuxième et après avoir sauvegardé le deuxième, on déclenche une exception
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("scenario2")]
        public JsonResult Create_ThrowExceptionAfterSecondSaveChanges()
        {
            Guid k = Guid.NewGuid();
            ReportViewModel model = new ReportViewModel(k);

            try
            {

                _service3.Create_ThrowExceptionAfterSecondSaveChanges(k);

            }
            catch (Exception ex)
            {
                model.Exception = ex;
                model.ExceptionMessage = ex.Message;
            }

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("scenario3")]
        public JsonResult CreateInBoth1()
        {
            Guid k = Guid.NewGuid();
            ReportViewModel model = new ReportViewModel(k);

            try
            {

                _service1.Create(k);
                _service2.Create(k);

            }
            catch (Exception ex)
            {
                model.Exception = ex;
                model.ExceptionMessage = ex.Message;
            }

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("scenario4")]
        public async Task<JsonResult> CreateInBothAsync()
        {
            Guid k = Guid.NewGuid();
            ReportViewModel model = new ReportViewModel(k);

            try
            {

                _service1.CreateAsync(k);
                _service2.CreateAsync(k);

            }
            catch (Exception ex)
            {
                model.Exception = ex;
                model.ExceptionMessage = ex.Message;
            }

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("scenario5")]
        public async Task<JsonResult> Create_ThrowExceptionAfterSecondSaveChangesWithScope()
        {
            Guid k = Guid.NewGuid();
            ReportViewModel model = new ReportViewModel(k);

            try
            {

                _service3.Create_ThrowExceptionAfterSecondSaveChangesWithScope(k);

            }
            catch (Exception ex)
            {
                model.Exception = ex;
                model.ExceptionMessage = ex.Message;
            }

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("scenario6")]
        public async Task<JsonResult> CreateInBoth()
        {
            Guid k = Guid.NewGuid();
            ReportViewModel model = new ReportViewModel(k);

            try
            {

                _service3.CreateInBoth(k);

            }
            catch (Exception ex)
            {
                model.Exception = ex;
                model.ExceptionMessage = ex.Message;
            }

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("scenario7")]
        public async Task<JsonResult> Create_ThrowExceptionAfterSecondSaveChangesWithScope(Guid k)
        {
            ReportViewModel model = new ReportViewModel(k);

            try
            {

                _service3.Create_ThrowExceptionAfterSecondSaveChangesWithScope(k);

            }
            catch (Exception ex)
            {
                model.Exception = ex;
                model.ExceptionMessage = ex.Message;
            }

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("scenario8")]
        public async Task<JsonResult> CreateInBoth(Guid k)
        {
            ReportViewModel model = new ReportViewModel(k);

            try
            {

                _service3.CreateInBoth(k);

            }
            catch (Exception ex)
            {
                model.Exception = ex;
                model.ExceptionMessage = ex.Message;
            }

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("scenario9")]
        public async Task<IActionResult> CreateMultiple(int? count)
        {
            if (!count.HasValue || count.Value <= 0)
                count = 15;

            List<Guid> l = new List<Guid>();
            for (int i = 0; i < count.Value; i++)
                l.Add(Guid.NewGuid());
            return View(l);
        }

        // https://docs.microsoft.com/en-us/ef/core/saving/transactions

        // https://github.com/aspnet/EntityFramework/issues/5595

        // https://github.com/dotnet/corefx/issues/12534
    }
}