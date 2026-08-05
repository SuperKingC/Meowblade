using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_BossCardGoldBtn : GButton
{
	public Controller button;

	public GLoader Up;

	public GGraph SpineLoader;

	public GLoader Down;

	public GTextField BossName;

	public UI_HealthBar HealthBar;

	public GTextField HealthText;

	public GGraph SfxBack;

	public const string URL = "ui://0i520nzmb529o8g";

	public static string Name = "UI_BossCardGoldBtn";

	public bool needPlayDeadSfx;

	public static string GetURL()
	{
		return "ui://0i520nzmb529o8g";
	}

	public static UI_BossCardGoldBtn CreateInstance()
	{
		return (UI_BossCardGoldBtn)(object)UIPackage.CreateObject("LordOfDreams", "BossCardGoldBtn");
	}

	public static UI_BossCardGoldBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossCardGoldBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmb529o8g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Up = (GLoader)((GComponent)this).GetChild("Up");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		Down = (GLoader)((GComponent)this).GetChild("Down");
		BossName = (GTextField)((GComponent)this).GetChild("BossName");
		HealthBar = (UI_HealthBar)(object)((GComponent)this).GetChild("HealthBar");
		HealthText = (GTextField)((GComponent)this).GetChild("HealthText");
		string id = "ui://0i520nzmb529o8g".Replace("ui://", "") + "-" + ((GObject)HealthText).id;
		((GObject)HealthText).text = LanguagesManager.GetDesc(id);
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}

	public void SetNeedPlayDeadSfx(bool playValue)
	{
		needPlayDeadSfx = playValue;
	}

	public void AppearOnStage3()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		((GComponent)(object)this).SetTimeout(1.5f).OnComplete((GTweenCallback)delegate
		{
			((GObject)this).alpha = 1f;
			((GObject)this).touchable = true;
			((GObject)SpineLoader).visible = true;
		});
		FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_gvg_card_reborn_2", new Vector3(120f, 120f, 120f));
	}

	public void PlayBossDead()
	{
		if (needPlayDeadSfx)
		{
			PlayBossDeadSfx();
		}
		else
		{
			SetBossDeadType();
		}
	}

	private void SetBossDeadType()
	{
		if (((GObject)this).data != null && (bool)((GObject)this).data && (((GObject)this).touchable || ((GObject)SpineLoader).visible))
		{
			((GObject)this).touchable = false;
			((GObject)this).alpha = 0f;
			((GObject)SpineLoader).visible = false;
		}
	}

	public void PlayBossDeadSfx()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		SetNeedPlayDeadSfx(playValue: false);
		((GObject)this).touchable = false;
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			((GObject)this).alpha = 0f;
			((GObject)SpineLoader).visible = false;
		});
		FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_gvg_card_explosion_2", new Vector3(100f, 100f, 100f));
	}
}
