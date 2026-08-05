using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Extension;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.Oem;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class AmplifierFormulaModel
{
	public GDEFormulaData Data;

	public Dictionary<string, int> Input_Dict;

	public string OutputAmpId;

	public AmplifierModel OutputAmplifier;

	private Dictionary<string, string> _extraData;

	private List<FormulaOemUiBonus> _uiBonus;

	private FormulaOemMission _formulaOemMission;

	public string Key => Data?.Key;

	public int Rarity => Data.Rarity;

	public eFormulaType Type => (eFormulaType)Data.Type;

	public string ReelItemId { get; set; }

	public string UnlockText => ExtraData["Unlocking"].ToLanguage();

	public Dictionary<string, string> ExtraData
	{
		get
		{
			if (_extraData != null)
			{
				return _extraData;
			}
			_extraData = (string.IsNullOrEmpty(Data.Data) ? new Dictionary<string, string>() : JsonHelper.ToObject<Dictionary<string, string>>(Data.Data));
			return _extraData;
		}
	}

	public List<FormulaOemUiBonus> UiBonus => _uiBonus ?? (_uiBonus = FormulaOemMission?.ReadFormulaOemUiBonus(OutputAmplifier.ContributionPoint));

	public FormulaOemMission FormulaOemMission => _formulaOemMission ?? (_formulaOemMission = (string.IsNullOrEmpty(Data?.Data) ? null : JsonHelper.ToObject<FormulaOemMission>(Data.Data)));
}
