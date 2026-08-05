using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Battle_PauseSetEffect;

public class UI_Battle_PauseSetEffect : GComponent, IUiController
{
	public Controller c1;

	public UI_Race_0 n0;

	public UI_Race_1 n1;

	public UI_Race_2 n2;

	public const string URL = "ui://e9jxbc7wqx4jm";

	public static string Name = "UI_Battle_PauseSetEffect";

	private bool hasPause = false;

	public static string GetURL()
	{
		return "ui://e9jxbc7wqx4jm";
	}

	public static UI_Battle_PauseSetEffect CreateInstance()
	{
		return (UI_Battle_PauseSetEffect)(object)UIPackage.CreateObject("Battle_PauseSetEffect", "Battle_PauseSetEffect");
	}

	public static UI_Battle_PauseSetEffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Battle_PauseSetEffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e9jxbc7wqx4jm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n0 = (UI_Race_0)(object)((GComponent)this).GetChild("n0");
		n1 = (UI_Race_1)(object)((GComponent)this).GetChild("n1");
		n2 = (UI_Race_2)(object)((GComponent)this).GetChild("n2");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		hasPause = false;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)n0).touchable = false;
		((GObject)n1).touchable = false;
		((GObject)n2).touchable = false;
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)n0).onClick.Add(new EventCallback1(_onClick));
		((GObject)n1).onClick.Add(new EventCallback1(_onClick));
		((GObject)n2).onClick.Add(new EventCallback1(_onClick));
		SharedMessenger.AddListener<string>("ON_FULL_SCREEN_EFFECT_SHOW", onFullScreenEffectShow);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)n0).onClick.Remove(new EventCallback1(_onClick));
		((GObject)n1).onClick.Remove(new EventCallback1(_onClick));
		((GObject)n2).onClick.Remove(new EventCallback1(_onClick));
		SharedMessenger.RemoveListener<string>("ON_FULL_SCREEN_EFFECT_SHOW", onFullScreenEffectShow);
	}

	private void pauseGame(IPauseSetEffect pause)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		hasPause = true;
		GameController.Contexts.Service<ReplayPlayerService>().Pause();
		Time.timeScale = 0f;
		pause.Animation.SetHook("CanClick", (TransitionHook)delegate
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			((GObject)(GComponent)pause).touchable = true;
		});
		pause.Animation.SetHook("Finish", (TransitionHook)delegate
		{
			_onClick(null);
		});
		pause.Animation.Play();
	}

	private void _onClick(EventContext eventContext)
	{
		Time.timeScale = 1f;
		GameController.Contexts.Service<ReplayPlayerService>().Play();
		ThinkingDataHelper.Instance.ClickQTE();
		End();
	}

	private void onFullScreenEffectShow(string effectName)
	{
		if (!hasPause)
		{
			switch (effectName)
			{
			case "skill_devil_race_fullscreen_red":
				c1.SetSelectedIndex(3);
				pauseGame(n2);
				break;
			case "skill_fullscreen_fake_race0":
				c1.SetSelectedIndex(1);
				pauseGame(n0);
				break;
			case "skill_bonedragon_shadow_l2r":
			case "skill_bonedragon_shadow_r2l":
				c1.SetSelectedIndex(2);
				pauseGame(n1);
				break;
			}
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
