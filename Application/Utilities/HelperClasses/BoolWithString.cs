using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Utilities.HelperClasses
{
    public class BoolWithString
    {
        public bool IsSuccess { get; set; }
        public StringBuilder StrBuildMessage { get; set; } = new StringBuilder();
    }
}
