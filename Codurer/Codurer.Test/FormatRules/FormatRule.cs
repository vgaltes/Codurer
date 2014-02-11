using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodurerApp.Test.FormatRules
{
    public interface FormatRule
    {
        bool IsSatisfied(DateTime now, DateTime postingTime);

        string Format(string messageText, DateTime now, DateTime postingTime);
    }
}
