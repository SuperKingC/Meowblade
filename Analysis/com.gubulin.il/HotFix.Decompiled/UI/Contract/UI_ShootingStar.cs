using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.Contract;

public class UI_ShootingStar : GButton
{
	public Controller button;

	public GGraph SfxBack;

	public const string URL = "ui://avplaivdi7untkr";

	public static string Name = "UI_ShootingStar";

	public static string GetURL()
	{
		return "ui://avplaivdi7untkr";
	}

	public static UI_ShootingStar CreateInstance()
	{
		return (UI_ShootingStar)(object)UIPackage.CreateObject("Contract", "ShootingStar");
	}

	public static UI_ShootingStar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShootingStar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdi7untkr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}

	public void StarShoot(Vector2 startPos, Vector2 endPos)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		((GComponent)UnityUiService.Instance.maskCover).AddChild((GObject)(object)this);
		Vector2 val = TransformLocalPos(startPos);
		Vector2 val2 = TransformLocalPos(endPos);
		((GObject)this).SetXY(val.x, val.y);
		FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "exp_missile_green", Vector3.zero);
		((GObject)this).TweenMove(val2, 0.5f);
		UiAudioManager.Instance.PlaySoundEffect("Missile");
		Destroy();
	}

	private Vector2 TransformLocalPos(Vector2 localPos)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return localPos;
	}

	private void Destroy()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			((GComponent)UnityUiService.Instance.maskCover).RemoveChild((GObject)(object)this, true);
		});
	}
}
