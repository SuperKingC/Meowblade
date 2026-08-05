using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_BossCardBtn : GButton
{
	public Controller button;

	public Controller ShowCountDown;

	public GLoader Up;

	public GImage HighLight;

	public GGraph SpineLoader;

	public GLoader Down;

	public GTextField BossName;

	public UI_HealthBar2 HealthBar;

	public GTextField HealthText;

	public GTextField CountDown;

	public GImage DarkMask;

	public GGraph SfxBack;

	public Transition ZeroToOne;

	public Transition OneToZero;

	public Transition ZeroToTwo;

	public const string URL = "ui://0i520nzmb529o8f";

	public static string Name = "UI_BossCardBtn";

	private MeshRenderer SoldierRenderer;

	private MaterialPropertyBlock mpb;

	public static string GetURL()
	{
		return "ui://0i520nzmb529o8f";
	}

	public static UI_BossCardBtn CreateInstance()
	{
		return (UI_BossCardBtn)(object)UIPackage.CreateObject("LordOfDreams", "BossCardBtn");
	}

	public static UI_BossCardBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossCardBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmb529o8f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ShowCountDown = ((GComponent)this).GetController("ShowCountDown");
		Up = (GLoader)((GComponent)this).GetChild("Up");
		HighLight = (GImage)((GComponent)this).GetChild("HighLight");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		Down = (GLoader)((GComponent)this).GetChild("Down");
		BossName = (GTextField)((GComponent)this).GetChild("BossName");
		HealthBar = (UI_HealthBar2)(object)((GComponent)this).GetChild("HealthBar");
		HealthText = (GTextField)((GComponent)this).GetChild("HealthText");
		string id = "ui://0i520nzmb529o8f".Replace("ui://", "") + "-" + ((GObject)HealthText).id;
		((GObject)HealthText).text = LanguagesManager.GetDesc(id);
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		DarkMask = (GImage)((GComponent)this).GetChild("DarkMask");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		ZeroToOne = ((GComponent)this).GetTransition("ZeroToOne");
		OneToZero = ((GComponent)this).GetTransition("OneToZero");
		ZeroToTwo = ((GComponent)this).GetTransition("ZeroToTwo");
	}

	public void Init(bool isDead = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		mpb = new MaterialPropertyBlock();
		SoldierRenderer = ((Component)((GObject)SpineLoader).displayObject.gameObject.transform.Find("SpineTest(Clone)")).GetComponent<MeshRenderer>();
		if (isDead)
		{
			SoldierOpenOverlay();
		}
	}

	private void SoldierOpenOverlay()
	{
		MaterialPropertyBlock obj = mpb;
		if (obj != null)
		{
			obj.SetFloat("_IsOpenOverlay", 1f);
		}
		MeshRenderer soldierRenderer = SoldierRenderer;
		if (soldierRenderer != null)
		{
			((Renderer)soldierRenderer).SetPropertyBlock(mpb);
		}
	}

	private void SoldierCloseOverlay()
	{
		MaterialPropertyBlock obj = mpb;
		if (obj != null)
		{
			obj.SetFloat("_IsOpenOverlay", 0f);
		}
		MeshRenderer soldierRenderer = SoldierRenderer;
		if (soldierRenderer != null)
		{
			((Renderer)soldierRenderer).SetPropertyBlock(mpb);
		}
	}

	public void Disappaer()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_gvg_card_explosion_1", new Vector3(100f, 100f, 100f));
	}

	public void AppearOnStage3()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		((GObject)this).visible = true;
		((GObject)this).alpha = 0f;
		((GComponent)(object)this).SetTimeout(1.5f).OnComplete((GTweenCallback)delegate
		{
			SoldierCloseOverlay();
			ShowCountDown.selectedIndex = 0;
			((GObject)this).alpha = 1f;
			((GObject)SpineLoader).visible = true;
		});
		FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_gvg_card_reborn_2", new Vector3(100f, 100f, 100f));
	}

	public void ChangeCardType(int selectIndex)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		int selectedIndex = ShowCountDown.selectedIndex;
		if (selectIndex != selectedIndex)
		{
			if (selectedIndex == 0 && selectIndex == 1)
			{
				SoldierOpenOverlay();
			}
			if (selectedIndex == 1 && selectIndex == 0)
			{
				FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_gvg_card_reborn_1", new Vector3(100f, 100f, 100f));
				SoldierCloseOverlay();
			}
			if (selectedIndex == 0 && selectIndex == 2)
			{
				FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_gvg_card_explosion_2", new Vector3(100f, 100f, 100f));
				((GObject)this).touchable = false;
			}
			ShowCountDown.selectedIndex = selectIndex;
		}
	}

	public void SetBossDeadType()
	{
		if (!ZeroToTwo.playing && ShowCountDown.selectedIndex != 2)
		{
			ShowCountDown.selectedIndex = 2;
			((GObject)this).visible = false;
		}
	}
}
