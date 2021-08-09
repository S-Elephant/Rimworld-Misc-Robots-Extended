using Verse;

namespace SE_MiscRobots
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public static class SE_Helper
    {
        private static void LogError(string defName)
        {
            Log.Error("Unable to find Def: " + defName);
        }

        public static ThingDef GetThingDef(string thingDefName)
        {
            ThingDef def = DefDatabase<ThingDef>.GetNamed(thingDefName);
            if (def != null)
                return def;

            LogError(thingDefName);
            return null;
        }

        public static void SetThingMaxHP(string thingDefName, int newHP)
        {
            SetThingStat(thingDefName, "MaxHitPoints", newHP);
        }

        public static void SetThingStat(string thingDefName, string statDefName, float newValue)
        {
            ThingDef def = GetThingDef(thingDefName);
            if (def != null)
                def.statBases.Find(s => s.stat.defName == statDefName).value = newValue;
        }
    }
}
