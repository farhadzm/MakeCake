
using MakeCake.WebApplication.Data;
using MakeCake.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCake.WebApplication.Services
{
    public interface IMakeCakeService
    {
        Task<CakeState> MakeCakeLongPolling();
        Task MakeCakeShortPolling(string token);
        List<CakeState> GetCakeState(string token);
    }
    public class MakeCakeService : IMakeCakeService
    {
        public List<CakeState> GetCakeState(string token)
        {
            return CakeStateDate.GetCakeStatus(token);
        }

        public async Task<CakeState> MakeCakeLongPolling()
        {
            await Task.Delay(2000);
            Console.WriteLine("Added cake mix");
            await Task.Delay(3000);
            Console.WriteLine("Added milk");
            await Task.Delay(1000);
            Console.WriteLine("Added eggs");
            await Task.Delay(1000);
            Console.WriteLine("Cake ingredients mixed");
            await Task.Delay(6000);
            Console.WriteLine("Oven is ready");
            Console.WriteLine("Baking cake...");
            await Task.Delay(2000);
            Console.WriteLine("Cake is ready");
            return new CakeState { IsFinish = true, State = "Cake is ready" };
        }
        public async Task MakeCakeShortPolling(string token)
        {
            await Task.Delay(2000);
            CakeStateDate.AddCakeState(new CakeState
            {
                IsFinish = false,
                State = "Added cake mix",
                Token = token
            });
            await Task.Delay(3000);
            CakeStateDate.AddCakeState(new CakeState
            {
                IsFinish = false,
                State = "Added milk",
                Token = token
            });
            await Task.Delay(3000);
            CakeStateDate.AddCakeState(new CakeState
            {
                IsFinish = false,
                State = "Added eggs",
                Token = token
            });
            await Task.Delay(1000);
            CakeStateDate.AddCakeState(new CakeState
            {
                IsFinish = false,
                State = "Cake ingredients mixed",
                Token = token
            });
            await Task.Delay(1000);
            CakeStateDate.AddCakeState(new CakeState
            {
                IsFinish = false,
                State = "Oven is ready",
                Token = token
            });
            CakeStateDate.AddCakeState(new CakeState
            {
                IsFinish = false,
                State = "Baking cake...",
                Token = token
            });
            await Task.Delay(6000);
            CakeStateDate.AddCakeState(new CakeState
            {
                IsFinish = true,
                State = "Cake is ready",
                Token = token
            });
        }
    }
}
