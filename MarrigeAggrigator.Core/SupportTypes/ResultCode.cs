using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrigeAggrigator.Core
{
    public enum ResultCode : ulong
    {
        SUCCESS = 0,
        UNKNOWN_RESULT_CODE = 99,
        FAILURE = 1001,
    }
}
