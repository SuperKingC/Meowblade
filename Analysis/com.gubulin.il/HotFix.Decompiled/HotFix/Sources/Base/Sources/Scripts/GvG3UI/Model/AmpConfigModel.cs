using System;
using System.Collections.Generic;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class AmpConfigModel
{
	public Dictionary<string, AmplifierModel> AllAmplifiers_Dict = new Dictionary<string, AmplifierModel>();

	public Dictionary<int, AmplifierModel> NormalAmplifiers_Dict = new Dictionary<int, AmplifierModel>();

	public Dictionary<int, AmplifierModel> AmplifierTemplates_Dict = new Dictionary<int, AmplifierModel>();

	public Dictionary<string, AmplifierFormulaModel> Formulas_Dict = new Dictionary<string, AmplifierFormulaModel>();

	public List<AmplifierFormulaModel> AlwaysShowFormulas_List = new List<AmplifierFormulaModel>();

	public HashSet<string> AlwaysShowFormulasIds_HashSet = new HashSet<string>();

	public List<string> Modifiers_List = new List<string>();

	public List<GvGAmplifierSourceJumpData> AmplifierJumpData_List = new List<GvGAmplifierSourceJumpData>(3);

	private T TryGet<T, K>(Dictionary<K, T> dict, K id)
	{
		if (dict.TryGetValue(id, out var value))
		{
			return value;
		}
		throw new Exception($"[AmpConfigModel] 找不到 id = {id} 的 {typeof(T).Name}");
	}

	public AmplifierModel TryGetAmplifier(string id)
	{
		return TryGet(AllAmplifiers_Dict, id);
	}

	public AmplifierModel TryGetNormalAmplifier(int idx)
	{
		return TryGet(NormalAmplifiers_Dict, idx);
	}

	public AmplifierModel TryGetAmplifierTemplates(int idx)
	{
		return TryGet(AmplifierTemplates_Dict, idx);
	}
}
