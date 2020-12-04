using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCake.WebApplication.Models
{
    public class CakeState
    {
        public string Token { get; set; }
        public string State { get; set; }
        public bool IsFinish { get; set; }
    }
}
