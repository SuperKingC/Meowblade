using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Spine.Unity;
using UnityEngine;

namespace UI.Contract;

public class UI_RookieSoldierLoader : GButton
{
	public Controller button;

	public GLoader icon;

	public GImage newIcon;

	public GImage upLogo;

	public GGraph specialEffectsBack;

	public Transition bounce;

	public Transition overturn0;

	public Transition overturn1;

	public Transition overturn2;

	public Transition ShowUpLogo;

	public const string URL = "ui://avplaivdi16ctkt";

	public static string Name = "UI_RookieSoldierLoader";

	private const string LaunchName = "card_launch_gold";

	private const string ExplosionName = "card_explosion_gold";

	private ModelsBonus bonus { get; set; }

	public string itemId { get; set; }

	private int itemType { get; set; }

	private int Qty { get; set; }

	private int ShiningLevel { get; set; }

	private string backUrl { get; set; }

	private string frontUrl { get; set; }

	private int potentialLevel { get; set; }

	private bool showNewIcon { get; set; }

	private UI_AirborneGubulin gubulin { get; set; }

	private bool skip { get; set; }

	public static string GetURL()
	{
		return "ui://avplaivdi16ctkt";
	}

	public static UI_RookieSoldierLoader CreateInstance()
	{
		return (UI_RookieSoldierLoader)(object)UIPackage.CreateObject("Contract", "RookieSoldierLoader");
	}

	public static UI_RookieSoldierLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RookieSoldierLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdi16ctkt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		upLogo = (GImage)((GComponent)this).GetChild("upLogo");
		specialEffectsBack = (GGraph)((GComponent)this).GetChild("specialEffectsBack");
		bounce = ((GComponent)this).GetTransition("bounce");
		overturn0 = ((GComponent)this).GetTransition("overturn0");
		overturn1 = ((GComponent)this).GetTransition("overturn1");
		overturn2 = ((GComponent)this).GetTransition("overturn2");
		ShowUpLogo = ((GComponent)this).GetTransition("ShowUpLogo");
	}

	public void SoldierLoaderInit(ModelsBonus bonusData)
	{
		((GObject)this).alpha = 1f;
		bonus = bonusData;
		itemId = bonus.ItemId;
		itemType = Shift.Legion.Common.Models.Item.ItemType(itemId);
		Qty = bonus.Qty;
		ShiningLevel = bonus.IsShining;
		((GObject)newIcon).visible = false;
		((GObject)newIcon).visible = false;
		((GObject)this).SetScale(0.68f, 0.68f);
		((GObject)icon).SetScale(1f, 1f);
		icon.fill = (FillType)1;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
		if (list[0].PayloadDictionary.TryGetValue("PotentialLevel", out var value))
		{
			potentialLevel = int.Parse(value.ToString());
		}
		icon.fill = (FillType)1;
		backUrl = "ui://avplaivdmxsj21";
		frontUrl = "ui://avplaivdmxsj20";
		icon.url = backUrl;
		showNewIcon = true;
		((GObject)icon).alpha = 0f;
	}

	public IEnumerator ShowSoldierCard(bool immediatelyShow = false)
	{
		skip = immediatelyShow;
		if (skip)
		{
			((GObject)icon).alpha = 1f;
			yield break;
		}
		gubulin = UI_AirborneGubulin.CreateInstance_ILRuntime();
		Vector2 startPos = new Vector2(((GObject)this).LocalToGlobal(new Vector2(((GObject)this).width, ((GObject)this).height) / 2f).x, 103f);
		gubulin.Gubulin_Init(startPos, "card_launch_gold", SoulStoneAppear);
	}

	public void SoulStoneAppear()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (!((GObject)this).isDisposed && !skip)
		{
			FGUIManager.Instance.AddTextSpecialEffects(specialEffectsBack, "card_explosion_gold", new Vector3(100f, 100f, 100f));
			((GObject)icon).alpha = 1f;
		}
	}

	public void StopPlayAnimation()
	{
		if (!((GObject)this).isDisposed)
		{
			skip = true;
			((GObject)icon).alpha = 1f;
			gubulin?.Destroy();
		}
	}

	public void FlipSoulStone(bool isSlow = false)
	{
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		string text = "";
		text = ShiningLevel switch
		{
			2 => "overturn2", 
			1 => "overturn1", 
			_ => "overturn0", 
		};
		Soldier soldier = GameManagers.Instance.SoldierManager.Get("S" + itemId.Substring(3));
		Dictionary<string, int>.KeyCollection keys = GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true).Keys;
		showNewIcon = !keys.Contains(soldier.Id);
		GameObject canvasObject1 = default(GameObject);
		ref GameObject reference = ref canvasObject1;
		Object obj = Object.Instantiate(Resources.Load("SpineTest"));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		SkeletonAnimation animation = canvasObject1.GetComponent<SkeletonAnimation>();
		SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldier.Id}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if ((Object)(object)animation != (Object)null && (Object)(object)asset != (Object)null && !((GObject)this).isDisposed)
			{
				((SkeletonRenderer)animation).skeletonDataAsset = asset;
				((SkeletonRenderer)animation).initialSkinName = $"skin{potentialLevel}";
				((SkeletonRenderer)animation).Initialize(true);
				animation.AnimationState.AddAnimation(1, "idle", true, 0f);
			}
		});
		Vector3 zero = Vector3.zero;
		if (soldier.Id == "S001" || soldier.Id == "S002" || soldier.Id == "S003" || soldier.Id == "S004" || soldier.Id == "S035" || soldier.Id == "S038")
		{
			((Vector3)(ref zero))._002Ector(55f, 55f, 55f);
		}
		else
		{
			((Vector3)(ref zero))._002Ector(40f, 40f, 40f);
		}
		canvasObject1.transform.localScale = zero * 0.58f;
		canvasObject1.transform.localPosition = -new Vector3(0f, 0f, 0f);
		canvasObject1.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		((GComponent)this).GetTransition(text).Play((PlayCompleteCallback)delegate
		{
			if (showNewIcon)
			{
				((GObject)newIcon).visible = true;
				bounce.Play();
			}
		});
		((GComponent)this).GetTransition(text).SetHook("middle", (TransitionHook)delegate
		{
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			((GObject)icon).SetScale(-1f, 1f);
			icon.url = frontUrl;
			GComponent component = icon.component;
			component.GetChild("soldierGroup").visible = true;
			component.GetChild("chipContent").visible = false;
			component.GetChild("soldierName").text = soldier.Name;
			component.GetChild("soldierName").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
			component.GetChild("curLevel").asCom.GetController("Level").selectedIndex = potentialLevel;
			GoWrapper val = new GoWrapper(canvasObject1);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			component.GetChild("soldier").asGraph.SetNativeObject((DisplayObject)(object)val);
			((GObject)component.GetChild("soldier").asGraph).SetXY(102f, 244f);
		});
		if (isSlow)
		{
			((GComponent)this).GetTransition(text).Stop(true, true);
		}
	}

	public void SoldierBtnDisAppear()
	{
		((GObject)this).alpha = 0f;
	}
}
