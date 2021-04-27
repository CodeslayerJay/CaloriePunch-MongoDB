using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Services.Common
{
    public class PagingModel : IPagingModel
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Index { get; set; }
    }
}
