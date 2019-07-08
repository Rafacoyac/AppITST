using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model.Api
{
    public class TokenModel
    {
        public string user { get; set; }
        public string pass{ get; set; }
        public string Token { get; set; }
        public TimeSpan inssued { get; set; }
        public TimeSpan deleted { get; set; }
        public string status { get; set; }
    }
}