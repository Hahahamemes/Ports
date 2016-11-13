using EloBuddy; 
 using LeagueSharp.Common; 
 namespace ReformedAIO.Champions.Ezreal.Drawings
{
    using System;
    using System.Drawing;

    using LeagueSharp;
    using LeagueSharp.Common;

    using ReformedAIO.Champions.Ezreal.Core.Spells;

    using RethoughtLib.FeatureSystem.Abstract_Classes;

    internal sealed class WDraw : ChildBase
    {
        public override string Name { get; set; } = "W";

        private readonly WSpell wSpell;

        public WDraw(WSpell wSpell)
        {
            this.wSpell = wSpell;
        }

        public void OnDraw(EventArgs args)
        {
            if (ObjectManager.Player.IsDead)
            {
                return;
            }

            Render.Circle.DrawCircle(ObjectManager.Player.Position, wSpell.Spell.Range, wSpell.Spell.IsReady()
                ? Color.Cyan
                : Color.DarkSlateGray,
                4, true);
        }

        protected override void OnDisable(object sender, FeatureBaseEventArgs eventArgs)
        {
            Drawing.OnDraw -= OnDraw;
        }

        protected override void OnEnable(object sender, FeatureBaseEventArgs eventArgs)
        {
            Drawing.OnDraw += OnDraw;
        }

        protected override void OnLoad(object sender, FeatureBaseEventArgs eventArgs)
        {
        }
    }
}
