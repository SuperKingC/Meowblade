using HotFix.Sources.Base.Scripts.Helper;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class ShipSkinConfigModel
{
	public string Icon;

	public string Spine;

	public string SimpleSpine;

	public string MiniIcon_CampId;

	public string MiningComp;

	public string MiniPrefab_CampId;

	public string IconUrl => Icon.ToPublicResourcesRgbIcon();

	public string MiningCompUrl => MiningComp.ToPublicResourcesRgbIcon();

	public string GetMiniIconUrlByCamId(int campId)
	{
		return MiniIcon_CampId.Format(campId).ToPublicResourcesRgbIcon();
	}

	public string GetMiniPrefabNameByCampId(int campId)
	{
		return MiniPrefab_CampId.Format(campId);
	}
}
