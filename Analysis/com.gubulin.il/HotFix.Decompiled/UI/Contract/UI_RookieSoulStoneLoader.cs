using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UnityEngine;

namespace UI.Contract;

public class UI_RookieSoulStoneLoader : GButton
{
	public Controller button;

	public GLoader icon;

	public GGraph SfxBack;

	public Transition overturn0;

	public Transition overturn1;

	public Transition overturn2;

	public const string URL = "ui://avplaivdnle7tko";

	public static string Name = "UI_RookieSoulStoneLoader";

	private const string LaunchName = "card_launch";

	private const string ExplosionName = "card_explosion";

	private ModelsBonus bonus { get; set; }

	private string itemId { get; set; }

	private int itemType { get; set; }

	private int Qty { get; set; }

	private int ShiningLevel { get; set; }

	private string backUrl { get; set; }

	private string frontUrl { get; set; }

	private int potentialLevel { get; set; }

	private bool skip { get; set; }

	private UI_AirborneGubulin gubulin { get; set; }

	public static string GetURL()
	{
		return "ui://avplaivdnle7tko";
	}

	public static UI_RookieSoulStoneLoader CreateInstance()
	{
		return (UI_RookieSoulStoneLoader)(object)UIPackage.CreateObject("Contract", "RookieSoulStoneLoader");
	}

	public static UI_RookieSoulStoneLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RookieSoulStoneLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnle7tko", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		overturn0 = ((GComponent)this).GetTransition("overturn0");
		overturn1 = ((GComponent)this).GetTransition("overturn1");
		overturn2 = ((GComponent)this).GetTransition("overturn2");
	}

	public void SoulLoaderInit(ModelsBonus bonusData)
	{
		bonus = bonusData;
		itemId = bonus.ItemId;
		itemType = Shift.Legion.Common.Models.Item.ItemType(itemId);
		Qty = bonus.Qty;
		ShiningLevel = bonus.IsShining;
		((GObject)this).SetScale(1f, 1f);
		((GObject)icon).SetScale(1f, 1f);
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
		if (list[0].PayloadDictionary.TryGetValue("PotentialLevel", out var value))
		{
			potentialLevel = int.Parse(value.ToString());
		}
		icon.fill = (FillType)1;
		potentialLevel = (potentialLevel + 2) / 2;
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			backUrl = "ui://avplaivdldght5t";
			frontUrl = "ui://avplaivdldght5u";
			icon.fill = (FillType)0;
		}
		icon.url = backUrl;
		if (potentialLevel < 3 && Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			icon.component.GetController("Type").selectedIndex = potentialLevel - 1;
		}
		((GObject)icon).alpha = 0f;
	}

	public IEnumerator ShowSoulStone(bool immediatelyShow = false)
	{
		skip = immediatelyShow;
		if (skip)
		{
			((GObject)icon).alpha = 1f;
			yield break;
		}
		gubulin = UI_AirborneGubulin.CreateInstance_ILRuntime();
		Vector2 startPos = new Vector2(((GObject)this).LocalToGlobal(Vector2.one).x, 103f);
		gubulin.Gubulin_Init(startPos, "card_launch", SoulStoneAppear);
	}

	public void SoulStoneAppear()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (!((GObject)this).isDisposed && !skip)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "card_explosion", new Vector3(100f, 100f, 100f));
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
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		string text = "";
		text = ShiningLevel switch
		{
			2 => "overturn2", 
			1 => "overturn1", 
			_ => "overturn0", 
		};
		Soldier soldier = GameManagers.Instance.SoldierManager.Get("S" + itemId.Substring(3));
		((GComponent)this).GetTransition(text).Play();
		((GComponent)this).GetTransition(text).SetHook("middle", (TransitionHook)delegate
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			((GObject)icon).SetScale(-1f, 1f);
			icon.url = frontUrl;
			GComponent component = icon.component;
			component.GetController("Type").selectedIndex = potentialLevel - 1;
			component.GetChild("SoldierName").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
			component.GetChild("SoldierName").text = soldier.Name;
			FGUIManager.Instance.SetItemIconAndFrame(component.GetChild("icon").asLoader, itemId);
		});
		if (isSlow)
		{
			((GComponent)this).GetTransition(text).Stop(true, true);
		}
	}

	public void SoulStoneDisAppear()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		((GObject)this).alpha = 0f;
		UI_ShootingStar uI_ShootingStar = UI_ShootingStar.CreateInstance_ILRuntime();
		Vector2 startPos = ((GObject)this).LocalToGlobal(new Vector2(((GObject)this).width, ((GObject)this).height) / 2f);
		uI_ShootingStar.StarShoot(startPos, new Vector2(1745f, 43f));
	}
}
