using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGTalentUiModel
{
	private readonly GDEGvGTalentConfigData _data;

	public int Idx => _data?.Idx ?? 0;

	public int Type => _data.Type;

	public int Quality => _data.Quality;

	public string Icon => _data?.Icon ?? string.Empty;

	public string Border => _data?.Border;

	public string Name => _data.Name;

	public string Desc => _data.Desc;

	public string TypeName => $"GvGTalentTypeName_{Type}".ToLanguage();

	public List<int> ParentTalent { get; }

	public bool Effective { get; set; }

	public GvGTalentUiModel(GDEGvGTalentConfigData data)
	{
		if (data == null)
		{
			ParentTalent = new List<int> { 311, 911, 611, 1211 };
		}
		else
		{
			_data = data;
			ParentTalent = JsonHelper.ToObject<List<int>>(data.ParentTalent);
		}
	}
}
