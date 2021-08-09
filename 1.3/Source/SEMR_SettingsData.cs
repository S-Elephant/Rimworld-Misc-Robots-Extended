using System.Collections.Generic;
using Verse;

namespace SE_MiscRobots
{
    public class SEMR_SettingsData : ModSettings
    {
        public RobotData BuilderData = new RobotData(new List<string>() { "RPP_RechargeStation_Builder_I", "RPP_RechargeStation_Builder_II", "RPP_RechargeStation_Builder_III", "RPP_RechargeStation_Builder_IV", "RPP_RechargeStation_Builder_V" },
            "SEMR_Builder", "SEMR_Builder", "SEMR_Builders");
        public RobotData CleanerData = new RobotData(new List<string>() { "AIRobot_RechargeStation_Cleaner", "AIRobot_RechargeStation_Cleaner_II", "AIRobot_RechargeStation_Cleaner_III", "AIRobot_RechargeStation_Cleaner_IV", "AIRobot_RechargeStation_Cleaner_V" },
            "SEMR_Cleaner", "SEMR_Cleaner", "SEMR_Cleaners");
        public RobotData CrafterData = new RobotData(new List<string>() { "RPP_RechargeStation_Crafter_I", "RPP_RechargeStation_Crafter_II", "RPP_RechargeStation_Crafter_III", "RPP_RechargeStation_Crafter_IV", "RPP_RechargeStation_Crafter_V" },
            "SEMR_Crafter", "SEMR_Crafter", "SEMR_Crafters");
        public RobotData HaulerData = new RobotData(new List<string>() { "AIRobot_RechargeStation_Hauler", "AIRobot_RechargeStation_Hauler_II", "AIRobot_RechargeStation_Hauler_III", "AIRobot_RechargeStation_Hauler_IV", "AIRobot_RechargeStation_Hauler_V" },
            "SEMR_Hauler", "SEMR_Hauler", "SEMR_Haulers");
        public RobotData KitchenData = new RobotData(new List<string>() { "RPP_RechargeStation_Kitchen_I", "RPP_RechargeStation_Kitchen_II", "RPP_RechargeStation_Kitchen_III", "RPP_RechargeStation_Kitchen_IV", "RPP_RechargeStation_Kitchen_V" },
                    "SEMR_Kitchen", "SEMR_Kitchen", "SEMR_Kitchens");
        public RobotData MedicData = new RobotData(new List<string>() { "RPP_RechargeStation_ER_I", "RPP_RechargeStation_ER_II", "RPP_RechargeStation_ER_III", "RPP_RechargeStation_ER_IV", "RPP_RechargeStation_ER_V" },
            "SEMR_Medic", "SEMR_Medic", "SEMR_Medics");

        public override void ExposeData()
        {
            BuilderData.ExposeData();
            CleanerData.ExposeData();
            CrafterData.ExposeData();
            HaulerData.ExposeData();
            KitchenData.ExposeData();
            MedicData.ExposeData();
        }
    }
}
