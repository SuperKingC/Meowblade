using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using Shift.Legion.Rank.Helpers;
using UnityEngine;

namespace UI.ReturningRewards;

public class UI_main_ReturningFirstTimeFX : GComponent, IUiController
{
	public GImage Box;

	public GGraph Mask;

	public GImage n1;

	public GImage n2;

	public Transition CheckRewards;

	public const string URL = "ui://rx5ntv98pyne2f";

	public static string Name = "UI_main_ReturningFirstTimeFX";

	private const float TRANSITION_TIME = 3.5f;

	private const int SHOOT_WAVE = 4;

	private const int SHOOT_WAVE_NUM = 16;

	private const string SHOOT_PARTICLE = "SHOOT_PARTICLE";

	public const string MISSILE_NAME = "exp_missile_yellow";

	private List<PreviewRewardEffect> _previewRewardEffects;

	public static string GetURL()
	{
		return "ui://rx5ntv98pyne2f";
	}

	public static UI_main_ReturningFirstTimeFX CreateInstance()
	{
		return (UI_main_ReturningFirstTimeFX)(object)UIPackage.CreateObject("ReturningRewards", "main_ReturningFirstTimeFX");
	}

	public static UI_main_ReturningFirstTimeFX CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ReturningFirstTimeFX).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98pyne2f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Box = (GImage)((GComponent)this).GetChild("Box");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		CheckRewards = ((GComponent)this).GetTransition("CheckRewards");
	}

	public static void Open(List<PreviewRewardEffect> effects)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object> { { "SHOOT_PARTICLE", effects } });
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_previewRewardEffects = (parameters.TryGetValue("SHOOT_PARTICLE", out var value) ? ((List<PreviewRewardEffect>)value) : new List<PreviewRewardEffect>());
	}

	public void OnShow()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		for (int i = 1; i <= 4; i++)
		{
			string text = $"Shoot{i}";
			CheckRewards.SetHook(text, new TransitionHook(PlayMissileEffect));
		}
		CheckRewards.Play();
		((GComponent)(object)this).SetTimeout(3.5f).OnComplete(new GTweenCallback(End));
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void PlayMissileEffect()
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		if (_previewRewardEffects.Count == 0)
		{
			return;
		}
		_previewRewardEffects = _previewRewardEffects.Where((PreviewRewardEffect e) => !e.IsCreated).ToList();
		List<PreviewRewardEffect> list = _previewRewardEffects.Choose(16);
		Vector2 val = default(Vector2);
		Vector2 val2 = default(Vector2);
		foreach (PreviewRewardEffect item in list)
		{
			item.IsCreated = true;
			UI_com_MissileWrapper missile = CreateMissileWrapper();
			((GObject)missile).SetPivot(0.5f, 0.5f, true);
			((Vector2)(ref val))._002Ector(item.X, item.Y);
			((Vector2)(ref val2))._002Ector(((GObject)Box).x, ((GObject)Box).y);
			float num = Vector2.Distance(val2, val);
			float num2 = num / 500f;
			GTweenCallback val3 = default(GTweenCallback);
			((GObject)missile).TweenMove(val, num2).OnComplete((GTweenCallback)delegate
			{
				//IL_0034: Unknown result type (might be due to invalid IL or missing references)
				//IL_0039: Unknown result type (might be due to invalid IL or missing references)
				//IL_003b: Expected O, but got Unknown
				//IL_0040: Expected O, but got Unknown
				missile.Explode.Play();
				GTweener obj = ((GComponent)(object)missile).SetTimeout(0.8f);
				GTweenCallback obj2 = val3;
				if (obj2 == null)
				{
					GTweenCallback val4 = delegate
					{
						((GObject)missile).visible = false;
					};
					GTweenCallback val5 = val4;
					val3 = val4;
					obj2 = val5;
				}
				obj.OnComplete(obj2);
			});
		}
	}

	private UI_com_MissileWrapper CreateMissileWrapper()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		UI_com_MissileWrapper uI_com_MissileWrapper = UI_com_MissileWrapper.CreateInstance_ILRuntime();
		FGUIManager.Instance.AddTextSpecialEffects(uI_com_MissileWrapper.SfxBack, "exp_missile_yellow", Vector3.one * 75f);
		((GComponent)this).AddChild((GObject)(object)uI_com_MissileWrapper);
		((GObject)uI_com_MissileWrapper).SetXY(((GObject)Box).x, ((GObject)Box).y);
		return uI_com_MissileWrapper;
	}
}
