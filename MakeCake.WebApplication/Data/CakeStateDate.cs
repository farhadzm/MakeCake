using MakeCake.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCake.WebApplication.Data
{
    public static class CakeStateDate
    {
        private static readonly List<CakeState> CakeStates = new List<CakeState>();
        public static List<CakeState> GetCakeStatus(string token)
        {
            return CakeStates.Where(a => a.Token == token).ToList();
        }
        public static void AddCakeState(CakeState cakeState)
        {
            Console.WriteLine(cakeState.State);
            CakeStates.Add(cakeState);
        }
    }
}
