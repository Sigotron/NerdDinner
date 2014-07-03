using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class ControllerHelpers
    {
        public static void AddRuleViolations(ModelStateDictionary modelState, IEnumerable<RuleViolation> errors)
        {
            foreach (RuleViolation issue in errors)
            {
                modelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
            }
        }
    }

}
