using System.Collections.Generic;
using SquirtingElephant.Helpers;
using Verse;

namespace SE_MiscRobots
{
    public class RobotData
    {
        private readonly List<string> _defNames;
        private readonly string _settingPrefix;
        private readonly string _translationKeySingle;
        private readonly string _translationKeyPlural;
        private string _bufferHp1, _bufferHp2, _bufferHp3, _bufferHp4, _bufferHp5;

        private int _maxHp1 = Constants.DEFAULT_HP_1;
        private int _maxHp2 = Constants.DEFAULT_HP_2;
        private int _maxHp3 = Constants.DEFAULT_HP_3;
        private int _maxHp4 = Constants.DEFAULT_HP_4;
        private int _maxHp5 = Constants.DEFAULT_HP_5;

        public RobotData(List<string> defNames, string settingPrefix, string translationKeySingle, string translationKeyPlural)
        {
            this._defNames = defNames;
            this._settingPrefix = settingPrefix;
            this._translationKeySingle = translationKeySingle;
            this._translationKeyPlural = translationKeyPlural;
        }

        private void SetBuffers()
        {
            _bufferHp1 = _maxHp1.ToString();
            _bufferHp2 = _maxHp2.ToString();
            _bufferHp3 = _maxHp3.ToString();
            _bufferHp4 = _maxHp4.ToString();
            _bufferHp5 = _maxHp5.ToString();
        }

        public void CreateSettingsFields(Listing_Standard ls, ref TableData tableData, ref int rowIndex)
        {
            SetBuffers();

            // Section header.
            Widgets.Label(tableData.GetFieldRect(0, rowIndex++), $"{_translationKeyPlural.Translate()} {"SEMR_Hp".Translate()}");

            // Section settings.
            Widgets.TextFieldNumericLabeled(tableData.GetFieldRect(0, rowIndex++), GetLabelName(_translationKeySingle, 1), ref _maxHp1, ref _bufferHp1,  Constants.HP_MIN, Constants.HP_MAX);
            Widgets.TextFieldNumericLabeled(tableData.GetFieldRect(0, rowIndex++), GetLabelName(_translationKeySingle, 2), ref _maxHp2, ref _bufferHp2,  Constants.HP_MIN, Constants.HP_MAX);
            Widgets.TextFieldNumericLabeled(tableData.GetFieldRect(0, rowIndex++), GetLabelName(_translationKeySingle, 3), ref _maxHp3, ref _bufferHp3,  Constants.HP_MIN, Constants.HP_MAX);
            Widgets.TextFieldNumericLabeled(tableData.GetFieldRect(0, rowIndex++), GetLabelName(_translationKeySingle, 4), ref _maxHp4, ref _bufferHp4,  Constants.HP_MIN, Constants.HP_MAX);
            Widgets.TextFieldNumericLabeled(tableData.GetFieldRect(0, rowIndex++), GetLabelName(_translationKeySingle, 5), ref _maxHp5, ref _bufferHp5,  Constants.HP_MIN, Constants.HP_MAX);
         
            // Gap.
            rowIndex++;
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref _maxHp1, _settingPrefix + "1", Constants.DEFAULT_HP_1);
            Scribe_Values.Look(ref _maxHp2, _settingPrefix + "2", Constants.DEFAULT_HP_2);
            Scribe_Values.Look(ref _maxHp3, _settingPrefix + "3", Constants.DEFAULT_HP_3);
            Scribe_Values.Look(ref _maxHp4, _settingPrefix + "4", Constants.DEFAULT_HP_4);
            Scribe_Values.Look(ref _maxHp5, _settingPrefix + "5", Constants.DEFAULT_HP_5);
        }

        public void ApplySettingsToDefs()
        {
            SE_Helper.SetThingMaxHP(_defNames[0], _maxHp1);
            SE_Helper.SetThingMaxHP(_defNames[1], _maxHp2);
            SE_Helper.SetThingMaxHP(_defNames[2], _maxHp3);
            SE_Helper.SetThingMaxHP(_defNames[3], _maxHp4);
            SE_Helper.SetThingMaxHP(_defNames[4], _maxHp5);
        }

        private string IntToRoman(int value)
        {
            switch (value)
            {
                case 1:
                    return "I";
                case 2:
                    return "II";
                case 3:
                    return "III";
                case 4:
                    return "IV";
                case 5:
                    return "V";
                default:
                    return "ERROR: not in switch statement: " + value.ToString();
            }
        }

        private string GetLabelName(string translationKey, int tier)
        {
            return $"{"SEMR_Station_HP".Translate().CapitalizeFirst()} {translationKey.Translate()} {IntToRoman(tier)} ";
        }
    }
}
