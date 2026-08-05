using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;

public static class CampAreaHelper
{
	private static readonly Dictionary<int, string> CampAreaMatKey_Dict = new Dictionary<int, string>
	{
		{ 0, "GvG/Materials/GradientRed.mat" },
		{ 1, "GvG/Materials/GradientGreen.mat" },
		{ 2, "GvG/Materials/GradientBlue.mat" },
		{ 3, "GvG/Materials/GradientRed.mat" },
		{ 4, "GvG/Materials/GradientGreen.mat" }
	};

	private static readonly Dictionary<int, int> CampAreaLayer_Dict = new Dictionary<int, int>
	{
		{
			0,
			LayerMask.NameToLayer("AreaGroup0")
		},
		{
			1,
			LayerMask.NameToLayer("AreaGroup0")
		},
		{
			2,
			LayerMask.NameToLayer("AreaGroup0")
		},
		{
			3,
			LayerMask.NameToLayer("AreaGroup1")
		},
		{
			4,
			LayerMask.NameToLayer("AreaGroup1")
		}
	};

	private static Dictionary<int, Material> _CampAreaMaterial_Dict;

	private static Dictionary<int, Material> CampAreaMaterial_Dict
	{
		get
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			if (_CampAreaMaterial_Dict == null)
			{
				_CampAreaMaterial_Dict = new Dictionary<int, Material>();
				foreach (KeyValuePair<int, string> item in CampAreaMatKey_Dict)
				{
					Material value = Addressables.LoadAssetAsync<Material>((object)item.Value).WaitForCompletion();
					_CampAreaMaterial_Dict.Add(item.Key, value);
				}
			}
			return _CampAreaMaterial_Dict;
		}
	}

	public static void SetCampArea(int campId, MeshRenderer mr)
	{
		if (CampAreaMaterial_Dict.TryGetValue(campId, out var value))
		{
			((Renderer)mr).material = value;
			((Component)mr).gameObject.layer = CampAreaLayer_Dict[campId];
		}
		else
		{
			ILRuntimeDebug.LogError($"[CampAreaHelper] 错误 campId = {campId}");
		}
	}
}
