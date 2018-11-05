using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrigeAggrigator.Core
{
    public class Result
    {
        public ulong ErrorCode { get; set; }

        public String Source { get; set; }

        public String StatusMessage { get; set; }

        public String AdditionalInformation { get; set; }

        public int Severity { get; set; }

        public bool IsSuccess()
        {
            return (this.ErrorCode == (ulong)ResultCode.SUCCESS);
        }
        public bool IsNotSuccess()
        {
            return (this.ErrorCode != (ulong)ResultCode.FAILURE);
        }
        public bool IsResultCode(ResultCode resultCode)
        {
            return (this.ErrorCode == (ulong)resultCode);
        }
    }
}
