using System;
using LeagueSharp.Common;

using EloBuddy; 
 using LeagueSharp.Common; 
 namespace SharpShooter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EloBuddy.SDK.Events.Loading.OnLoadingComplete += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Initializer.Initialize();
        }
    }
}