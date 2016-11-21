using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entropy.DBTransaction.Web.UI.Models.TestScenarioViewModels
{
    public sealed class ReportViewModel
    {
        public Guid Key { get; set; }
        public Exception Exception { get; set; }
        public string ExceptionMessage { get; set; }

        public ReportViewModel()
        { }

        public ReportViewModel(Guid key)
        {
            Key = key;
        }
    }
}