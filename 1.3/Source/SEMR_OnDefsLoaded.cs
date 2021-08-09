using Verse;

namespace SE_MiscRobots
{
    [StaticConstructorOnStartup]
    public class SEMR_OnDefsLoaded
    {
        static SEMR_OnDefsLoaded()
        {
            ApplySettingsToDefs();
        }

        public static void ApplySettingsToDefs()
        {
            SEMR_Settings.Settings.BuilderData.ApplySettingsToDefs();
            SEMR_Settings.Settings.CleanerData.ApplySettingsToDefs();
            SEMR_Settings.Settings.CrafterData.ApplySettingsToDefs();
            SEMR_Settings.Settings.HaulerData.ApplySettingsToDefs();
            SEMR_Settings.Settings.KitchenData.ApplySettingsToDefs();
            SEMR_Settings.Settings.MedicData.ApplySettingsToDefs();
        }
    }
}
