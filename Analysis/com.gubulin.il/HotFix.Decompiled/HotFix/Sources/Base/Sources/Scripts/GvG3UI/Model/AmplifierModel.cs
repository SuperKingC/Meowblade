using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class AmplifierModel
{
	public GDEGvGAmplifierConfigData Data;

	private eRace _AffectedRace;

	private string _Name;

	private string _EffectRangeDesc;

	private Dictionary<string, string> _Props;

	private List<KeyValuePair<string, float>> _Desc;

	private Dictionary<string, ePropType> _DescType;

	public Dictionary<string, string> Desc2PropsKey = new Dictionary<string, string>();

	private string _TemplateDesc;

	private bool _IsInitProps = false;

	public int Idx => Data.Idx;

	public int Quality => Data.Quality;

	public string Icon => Data.Icon;

	public eAmplifierTag Tag => (eAmplifierTag)Data.tag;

	public eAmplifierType Type => (eAmplifierType)Data.Type;

	public string AffectedFaction => Data.AffectedFaction;

	public string AffectedSoldier => Data.AffectedSoldier;

	public int Score => Data.Score;

	public int SettlementScore => (int)Data.SettlementScore;

	public bool IsAmplifierTemplate => Data.tag == 2;

	public float ContributionPoint
	{
		get
		{
			if (WorldMapConfigHelper.Configs.IsBrawlEvent())
			{
				return Data.ContributionPoint_1;
			}
			return Data.ContributionPoint;
		}
	}

	public eRace AffectedRace
	{
		get
		{
			if (_AffectedRace == eRace.Invalid)
			{
				_AffectedRace = (string.IsNullOrEmpty(Data.AffectedFaction) ? eRace.全种族 : RaceHelper.FactionToRaceEnum(Data.AffectedFaction));
			}
			return _AffectedRace;
		}
	}

	public string Name => _Name ?? (_Name = Data.Name.ToLanguage());

	public string EffectRangeDesc => _EffectRangeDesc ?? (_EffectRangeDesc = Data.EffectRangeDesc.ToLanguage());

	public Dictionary<string, string> Props => EnsureInitProps()._Props;

	public List<KeyValuePair<string, float>> Desc => EnsureInitProps()._Desc;

	public Dictionary<string, ePropType> DescType => EnsureInitProps()._DescType;

	public string TemplateDesc => EnsureInitProps()._TemplateDesc;

	public AmplifierModel(GDEGvGAmplifierConfigData data)
	{
		Data = data;
		_AffectedRace = eRace.Invalid;
	}

	private AmplifierModel EnsureInitProps()
	{
		if (_IsInitProps)
		{
			return this;
		}
		_IsInitProps = true;
		if (IsAmplifierTemplate)
		{
			_TemplateDesc = Data.Desc.ToLanguage();
		}
		else
		{
			_Props = JsonHelper.ToObject<Dictionary<string, string>>(Data.Effect);
			_Desc = new List<KeyValuePair<string, float>>();
			_DescType = new Dictionary<string, ePropType>();
			List<Dictionary<string, float>> list = JsonHelper.ToObject<List<Dictionary<string, float>>>(Data.Desc);
			foreach (Dictionary<string, float> item in list)
			{
				foreach (KeyValuePair<string, float> item2 in item)
				{
					string key = item2.Key.ToLanguage();
					_Desc.Add(new KeyValuePair<string, float>(key, item2.Value));
					Desc2PropsKey[key] = item2.Key;
					ePropType value = ePropType.Add;
					foreach (KeyValuePair<string, string> prop in _Props)
					{
						if (item2.Key.Contains(prop.Key))
						{
							if (Modifier.IsDRAttr(prop.Key))
							{
								value = ePropType.DRSum;
							}
							break;
						}
					}
					_DescType.Add(key, value);
				}
			}
		}
		return this;
	}

	public static string GetQualityName(int quality)
	{
		return quality switch
		{
			1 => "GvG3AmplifierQuality1".ToLanguage(), 
			2 => "GvG3AmplifierQuality2".ToLanguage(), 
			3 => "GvG3AmplifierQuality3".ToLanguage(), 
			4 => "GvG3AmplifierQuality4".ToLanguage(), 
			5 => "GvG3AmplifierQuality5".ToLanguage(), 
			_ => string.Empty, 
		};
	}
}
