using SquirtingElephant.Helpers;
using UnityEngine;
using Verse;

namespace SE_MiscRobots
{
    public class SEMR_Settings : Mod
    {
        public static SEMR_SettingsData Settings;
        private Vector2 _scrollPosition = Vector2.zero;
        private const int SECTIONS_COUNT = 6;
        private const int SECTION_ROW_COUNT = 7;
        private const float ROW_HEIGHT = 32f;
        private const float SCROLL_VIEW_PADDING_HORIZONTAL = 10f;

        public static TableData Table = new TableData(
            new Vector2(10f, 0f), new Vector2(10f, 10f),
            new[] { 500f },
            new[] { ROW_HEIGHT });

        public SEMR_Settings(ModContentPack content) : base(content)
        {
            Settings = GetSettings<SEMR_SettingsData>();
        }

        private float GetScrollViewHeight() => 90f + SECTION_ROW_COUNT * SECTIONS_COUNT * ROW_HEIGHT;

        public override void DoSettingsWindowContents(Rect settingsWindowSizeRect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(settingsWindowSizeRect);
            Rect scrollViewRect = new Rect(
                SCROLL_VIEW_PADDING_HORIZONTAL,
                0f,
                settingsWindowSizeRect.width - 2 * SCROLL_VIEW_PADDING_HORIZONTAL,
                GetScrollViewHeight());
            Widgets.BeginScrollView(
                new Rect(0f, 0f, settingsWindowSizeRect.width, settingsWindowSizeRect.height),
                ref _scrollPosition,
                scrollViewRect);

            int rowIndex = 0;
            Settings.BuilderData.CreateSettingsFields(ls, ref Table, ref rowIndex);
            Settings.CleanerData.CreateSettingsFields(ls, ref Table, ref rowIndex);
            Settings.CrafterData.CreateSettingsFields(ls, ref Table, ref rowIndex);
            Settings.HaulerData.CreateSettingsFields(ls, ref Table, ref rowIndex);
            Settings.KitchenData.CreateSettingsFields(ls, ref Table, ref rowIndex);
            Settings.MedicData.CreateSettingsFields(ls, ref Table, ref rowIndex);

            SEMR_OnDefsLoaded.ApplySettingsToDefs();
            Widgets.EndScrollView();
            ls.End();

            base.DoSettingsWindowContents(settingsWindowSizeRect);
        }

        public override string SettingsCategory()
        {
            return "SEMR_SettingsCategory".Translate();
        }
    }
}
