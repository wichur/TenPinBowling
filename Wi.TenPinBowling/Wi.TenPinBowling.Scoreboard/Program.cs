using Microsoft.Extensions.DependencyInjection;
using System;
using Wi.TenPinBowling.Scoreboard.Services;

namespace Wi.TenPinBowling.Scoreboard
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddTransient<IGameGovernorService, GameGovernorService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IFrameService, FrameService>();

            var provider = services.BuildServiceProvider();

            var gg = provider.GetService<IGameGovernorService>();

            gg.StartNewGame(2);

            gg.MoveToNextPlayer();
            gg.MoveToNextFrame();
            gg.MoveToNextRoll();
            gg.StoreRollOutcome(3);
            gg.MoveToNextRoll();
            gg.StoreRollOutcome(4);

        }
    }
}
