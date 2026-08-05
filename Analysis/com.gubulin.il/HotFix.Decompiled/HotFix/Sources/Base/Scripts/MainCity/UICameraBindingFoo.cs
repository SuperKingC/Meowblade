using FairyGUI;
using GameMaths;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.MainCity;

public class UICameraBindingFoo : MonoBehaviour
{
	public GObject Binding_GObject;

	public Vector3 Binding_Pos;

	public Camera Binding_Cam;

	public float Amendment;

	private bool isStart = false;

	private int Type = 0;

	public void StartBinding(int type)
	{
		isStart = true;
		Type = type;
	}

	private void Update()
	{
		if (isStart)
		{
			if (Type == 1)
			{
				CampBtnBinding();
			}
			else if (Type == 2)
			{
				FormationBtnBinding();
			}
		}
	}

	private void CampBtnBinding()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Binding_Cam.WorldToScreenPoint(Vector3.op_Implicit(Binding_Pos));
		val.y = (float)Screen.height - val.y;
		Vector3 val2 = Vector2.op_Implicit(Binding_GObject.GlobalToLocal(Vector2.op_Implicit(val)));
		Binding_GObject.SetXY(val2.x, val2.y);
	}

	private void FormationBtnBinding()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Binding_Cam.WorldToScreenPoint(Vector3.op_Implicit(Binding_Pos));
		val.y = (float)Screen.height - val.y;
		Vector2 val2 = ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val));
		val2.y -= Amendment;
		Binding_GObject.SetXY(val2.x, val2.y);
	}
}
