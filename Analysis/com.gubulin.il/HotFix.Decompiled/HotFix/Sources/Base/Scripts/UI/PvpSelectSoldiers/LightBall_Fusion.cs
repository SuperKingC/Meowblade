using Assets.Scripts.UI;
using FairyGUI;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.UI.PvpSelectSoldiers;

internal class LightBall_Fusion
{
	public GGraph Container;

	public GameObject FxFusion;

	public LightBall_Fusion(Vector2 pos, float size = 10f, float scale = 1f)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		Container = new GGraph();
		((GObject)Container).SetPivot(0.5f, 0.5f);
		((GObject)Container).SetSize(1f, 1f, true);
		Container.DrawRect(1f, 1f, 0, Color.white, Color.white);
		((GObject)Container).SetPosition(pos.x, pos.y, 0f);
		FxFusion = FGUIManager.Instance.AddTextSpecialEffects(Container, "ui_transform_pvp_army", new Vector3(size, size, size));
	}

	public void Destroy()
	{
		UiHelper.DestoryUiSfx(Container, FxFusion, 0f);
	}
}
