using EloBuddy;
using LeagueSharp.Common;
namespace ElLeeSin
{
    using System.Drawing;

    using LeagueSharp.Common;

    using Color = SharpDX.Color;

    public class InitMenu
    {
        #region Static Fields

        public static Menu Menu;

        #endregion

        #region Public Methods and Operators

        public static void Initialize()
        {
            Menu = new Menu("ElLeeSin", "LeeSin", true);
            Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));
            Program.Orbwalker = new Orbwalking.Orbwalker(Menu.SubMenu("Orbwalker"));

            Menu.AddSubMenu(new Menu("Combo", "Combo"));
            Menu.SubMenu("Combo").AddItem(new MenuItem("ElLeeSin.Combo.Q", "Use Q").SetValue(true));
            Menu.SubMenu("Combo").AddItem(new MenuItem("ElLeeSin.Combo.Q2", "Use Q2").SetValue(true));
            Menu.SubMenu("Combo").AddItem(new MenuItem("ElLeeSin.Combo.W2", "Use W").SetValue(true));
            Menu.SubMenu("Combo").AddItem(new MenuItem("ElLeeSin.Combo.E", "Use E").SetValue(true));
            Menu.SubMenu("Combo").AddItem(new MenuItem("ElLeeSin.Combo.R", "Use R").SetValue(true));
            Menu.SubMenu("Combo")
                .AddItem(new MenuItem("ElLeeSin.Combo.StarKill1", "Use BuckFrandon to kill").SetValue(false));
            Menu.SubMenu("Combo")
                .AddItem(new MenuItem("ElLeeSin.Combo.PassiveStacks", "Min Stacks").SetValue(new Slider(1, 1, 2)));

            Menu.SubMenu("Combo")
                .SubMenu("Wardjump")
                .AddItem(new MenuItem("ElLeeSin.Combo.W", "Wardjump In Combo").SetValue(false));
            Menu.SubMenu("Combo")
                .SubMenu("Wardjump")
                .AddItem(new MenuItem("ElLeeSin.Combo.Mode.WW", "Out Of AA range").SetValue(false));

            Menu.SubMenu("Combo").AddItem(new MenuItem("ElLeeSin.Combo.KS.R", "KS R").SetValue(true));
            Menu.SubMenu("Combo")
                .AddItem(
                    new MenuItem("starCombo", "Star Combo").SetValue(
                        new KeyBind("T".ToCharArray()[0], KeyBindType.Press)));

            Menu.SubMenu("Combo").AddItem(new MenuItem("ElLeeSin.Combo.AAStacks", "Wait For Passive").SetValue(false));

            var harassMenu = Menu.AddSubMenu(new Menu("Harass", "Harass"));
            {
                harassMenu.AddItem(new MenuItem("ElLeeSin.Harass.Q1", "Use Q").SetValue(true));
                harassMenu.AddItem(new MenuItem("ElLeeSin.Harass.Wardjump", "Use W").SetValue(true));
                harassMenu.AddItem(new MenuItem("ElLeeSin.Harass.E1", "Use E").SetValue(false));
                harassMenu.AddItem(
                    new MenuItem("ElLeeSin.Harass.PassiveStacks", "Min Stacks").SetValue(new Slider(1, 1, 2)));
            }

            var kickMenu = Menu.AddSubMenu(new Menu("Kick (R)", "Kick"));
            {
                kickMenu.AddItem(new MenuItem("ElLeeSin.Combo.New", "Kick Multiple Targets:").SetValue(true));
                kickMenu.AddItem(
                    new MenuItem("ElLeeSin.Combo.R.Count", "R Target Hit Count").SetValue(new Slider(3, 2, 4)));
                kickMenu.AddItem(new MenuItem("ElLeeSin.Combo.New.R.Kill", "Kill Enemy Behind").SetValue(false));
            }

            var waveclearMenu = Menu.AddSubMenu(new Menu("Clear", "Clear"));
            {
                waveclearMenu.AddItem(new MenuItem("Sep111", "Wave Clear"));
                waveclearMenu.AddItem(new MenuItem("ElLeeSin.Lane.Q", "Use Q").SetValue(true));
                waveclearMenu.AddItem(new MenuItem("ElLeeSin.Lane.E", "Use E").SetValue(true));

                waveclearMenu.AddItem(new MenuItem("sep222", "Jungle Clear"));

                waveclearMenu.AddItem(new MenuItem("ElLeeSin.Jungle.Q", "Use Q").SetValue(true));
                waveclearMenu.AddItem(new MenuItem("ElLeeSin.Jungle.W", "Use W").SetValue(true));
                waveclearMenu.AddItem(new MenuItem("ElLeeSin.Jungle.E", "Use E").SetValue(true));
            }

            var insecMenu = Menu.AddSubMenu(new Menu("Insec", "Insec").SetFontStyle(FontStyle.Bold, Color.Aqua));
            {
                insecMenu.AddItem(
                    new MenuItem("InsecEnabled", "Insec key:").SetValue(
                        new KeyBind("Y".ToCharArray()[0], KeyBindType.Press)));
                insecMenu.AddItem(new MenuItem("rnshsasdhjk", "Insec Mode:"))
                    .SetFontStyle(FontStyle.Bold, Color.BlueViolet);
                insecMenu.AddItem(new MenuItem("insecMode", "Left click target to Insec").SetValue(true));
                insecMenu.AddItem(new MenuItem("insecOrbwalk", "Orbwalking").SetValue(true));
                insecMenu.AddItem(new MenuItem("ElLeeSin.Flash.Insec", "Flash Insec When No Ward").SetValue(false));
                insecMenu.AddItem(new MenuItem("waitForQBuff", "Wait For Q").SetValue(false));
                insecMenu.AddItem(new MenuItem("checkOthers2", "Use Units To Insec").SetValue(true));
                insecMenu.AddItem(new MenuItem("clickInsec", "Click Insec").SetValue(true));
                insecMenu.AddItem(new MenuItem("bonusRangeA", "Ally Bonus Range").SetValue(new Slider(0, 0, 1000)));
                insecMenu.AddItem(new MenuItem("bonusRangeT", "Towers Bonus Range").SetValue(new Slider(0, 0, 1000)));

                insecMenu.SubMenu("Insec Modes")
                    .AddItem(new MenuItem("ElLeeSin.Insec.Ally", "Insec To Allies").SetValue(true));
                insecMenu.SubMenu("Insec Modes")
                    .AddItem(new MenuItem("ElLeeSin.Insec.Tower", "Insec To Tower").SetValue(false));
                insecMenu.SubMenu("Insec Modes")
                    .AddItem(new MenuItem("ElLeeSin.Insec.Original.Pos", "Insec To Original Pos").SetValue(true));
                insecMenu.AddItem(
                    new MenuItem("ElLeeSin.Insec.UseInstaFlash", "Flash + R").SetValue(
                        new KeyBind("G".ToCharArray()[0], KeyBindType.Press)));
            }

            var wardjumpMenu = Menu.AddSubMenu(new Menu("Wardjump and Escape", "Wardjump"));
            {
                wardjumpMenu.AddItem(
                    new MenuItem("ElLeeSin.Escape", "Escape Key").SetValue(
                        new KeyBind("A".ToCharArray()[0], KeyBindType.Press)));
                wardjumpMenu.AddItem(new MenuItem("escapeMode", "Enable Jungle Escape").SetValue(true));
                wardjumpMenu.AddItem(
                    new MenuItem("ElLeeSin.Wardjump", "Wardjump Key").SetValue(
                        new KeyBind("G".ToCharArray()[0], KeyBindType.Press)));
                wardjumpMenu.AddItem(
                    new MenuItem("ElLeeSin.Wardjump.MaxRange", "Ward Jump On Max Range").SetValue(false));
                wardjumpMenu.AddItem(new MenuItem("ElLeeSin.Wardjump.Mouse", "Jump To Mouse").SetValue(true));
                wardjumpMenu.AddItem(new MenuItem("ElLeeSin.Wardjump.Minions", "Jump To Minions").SetValue(true));
                wardjumpMenu.AddItem(new MenuItem("ElLeeSin.Wardjump.Champions", "Jump To Champions").SetValue(true));
            }

            var drawMenu = Menu.AddSubMenu(new Menu("Drawings", "Drawings"));
            {
                drawMenu.AddItem(new MenuItem("DrawEnabled", "Draw Enabled").SetValue(true));
                drawMenu.AddItem(new MenuItem("Draw.Insec.Lines", "Draw Insec lines").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.Insec.Text", "Draw Insec text").SetValue(false));
                drawMenu.AddItem(new MenuItem("drawOutLineST", "Draw Outline").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.Insec", "Draw Insec").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.WJDraw", "Draw WardJump").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.Q", "Draw Q").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.W", "Draw W").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.E", "Draw E").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.R", "Draw R").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.Escape", "Draw Escape Spots").SetValue(false));
                drawMenu.AddItem(new MenuItem("ElLeeSin.Draw.Q.Width", "Draw Escape Q Width").SetValue(false));
            }

            var miscMenu = Menu.AddSubMenu(new Menu("Misc", "Misc"));
            {
                miscMenu.AddItem(new MenuItem("Combo.Use.items", "Use Items").SetValue(true));
                miscMenu.AddItem(new MenuItem("ElLeeSin.Ignite.KS", "Use Ignite").SetValue(true));
                miscMenu.AddItem(new MenuItem("ElLeeSin.Smite.KS", "Use Smite").SetValue(true));
                miscMenu.AddItem(new MenuItem("ElLeeSin.Smite.Q", "Smite Q!").SetValue(false)); //qSmite
            }

            Menu.AddToMainMenu();
        }

        #endregion
    }
}