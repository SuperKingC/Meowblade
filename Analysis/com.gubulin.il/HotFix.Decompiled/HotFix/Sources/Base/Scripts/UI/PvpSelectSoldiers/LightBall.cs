using Assets.Scripts.UI;
using FairyGUI;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.UI.PvpSelectSoldiers;

internal class LightBall
{
	private float _scale = 1f;

	public GGraph Container;

	public GameObject FxBall;

	public float X => ((GObject)Container).position.x;

	public float Y => ((GObject)Container).position.y;

	public Vector2 Position
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return Vector2.op_Implicit(((GObject)Container).position);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			((GObject)Container).position = Vector2.op_Implicit(value);
		}
	}

	public float Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			_scale = value;
			((GObject)Container).scale = new Vector2(value, value);
		}
	}

	public LightBall(Vector2 pos, float size = 10f, float scale = 1f)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Container = new GGraph();
		((GObject)Container).SetPivot(0.5f, 0.5f);
		((GObject)Container).SetSize(1f, 1f, true);
		Container.DrawRect(1f, 1f, 0, Color.white, Color.white);
		((GObject)Container).SetPosition(pos.x, pos.y, 0f);
		FxBall = FGUIManager.Instance.AddTextSpecialEffects(Container, "exp_missile_yellow", new Vector3(size, size, size));
		Scale = scale;
	}

	public void SetPosition(float x, float y)
	{
		((GObject)Container).SetPosition(x, y, 0f);
	}

	public void Destroy()
	{
		UiHelper.DestoryUiSfx(Container, FxBall, 0f);
	}
}
