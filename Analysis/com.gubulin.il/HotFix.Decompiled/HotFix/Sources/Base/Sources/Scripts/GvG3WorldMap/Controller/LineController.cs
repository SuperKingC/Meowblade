using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public class LineController : MonoBehaviour
{
	public bool IsLoading;

	public string LineId;

	private void Awake()
	{
	}

	public void Load(string lineId)
	{
		IsLoading = true;
		RenderStaticData(lineId);
		IsLoading = false;
	}

	public void Unload()
	{
	}

	private void RenderStaticData(string lineId)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		LineId = lineId;
		((Object)((Component)this).gameObject).name = lineId ?? "";
		NavLineConfigData navLineConfigData = WorldMapConfigHelper.Configs.TryGetNavLine(lineId);
		((Component)this).transform.localPosition = navLineConfigData.Start;
		((Component)this).transform.localScale = navLineConfigData.Scale;
		((Component)this).transform.rotation = navLineConfigData.Rotation;
	}
}
