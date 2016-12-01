using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

using EloBuddy; 
 using LeagueSharp.Common; 
 namespace ezEvade.SpecialSpells
{
    class Lux : ChampionPlugin
    {
        static Lux()
        {

        }

        public void LoadSpecialSpell(SpellData spellData)
        {
            if (spellData.spellName == "LuxMaliceCannon")
            {
                var hero = HeroManager.AllHeroes.FirstOrDefault(h => h.ChampionName == "Lux");
                if (hero != null && hero.CheckTeam())
                {
                    ObjectTracker.HuiTrackerForceLoad();
                    GameObject.OnCreate += (obj, args) => OnCreateObj_LuxMaliceCannon(obj, args, hero, spellData);
                }
            }
        }

        private static void OnCreateObj_LuxMaliceCannon(GameObject obj, EventArgs args, AIHeroClient hero, SpellData spellData)
        {
            if (obj.Name.Contains("Lux") && obj.Name.Contains("R_mis_beam_middle"))
            {
                if (hero.IsVisible) return;

                var objList = ObjectTracker.objTracker.Values.Where(o => o.Name == "hiu");
                if (objList.Count() >= 2)
                {
                    var dir = ObjectTracker.GetLastHiuOrientation();
                    var pos1 = obj.Position.To2D() - dir * 1750;
                    var pos2 = obj.Position.To2D() + dir * 1750;

                    SpellDetector.CreateSpellData(hero, pos1.To3D(), pos2.To3D(), spellData, null, 0);

                    foreach (ObjectTrackerInfo gameObj in objList)
                    {
                        DelayAction.Add(1, () => ObjectTracker.objTracker.Remove(gameObj.obj.NetworkId));
                    }
                }
            }
        }
    }
}
