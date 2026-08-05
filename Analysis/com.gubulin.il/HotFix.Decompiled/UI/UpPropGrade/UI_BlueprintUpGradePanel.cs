using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.UpPropGrade;

public class UI_BlueprintUpGradePanel : GComponent, IUiController
{
	public UI_BlueprintDialog Dialog;

	public Transition popup;

	public const string URL = "ui://blindbbgio2yr";

	public static string Name = "UI_BlueprintUpGradePanel";

	private List<string> textureList = new List<string>();

	private Tuple<string, string, int, Dictionary<string, string>> BlueprintInfo;

	private string _productItemId;

	public static string GetURL()
	{
		return "ui://blindbbgio2yr";
	}

	public static UI_BlueprintUpGradePanel CreateInstance()
	{
		return (UI_BlueprintUpGradePanel)(object)UIPackage.CreateObject("UpPropGrade", "BlueprintUpGradePanel");
	}

	public static UI_BlueprintUpGradePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BlueprintUpGradePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgio2yr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Dialog = (UI_BlueprintDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("BlueprintInfo", out var value))
		{
			BlueprintInfo = (Tuple<string, string, int, Dictionary<string, string>>)value;
		}
		else
		{
			End();
		}
		((GObject)this).sortingOrder = 1;
		_productItemId = BlueprintInfo.Item1;
		RenderMainUi();
	}

	public void OnShow()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		popup.Play();
		((GComponent)(object)this).SetTimeout(1.33f).OnComplete(new GTweenCallback(PlayUpgradeSfx));
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.BlueprintUpGradeBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.BlueprintUpGradeBtn).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void RenderMainUi()
	{
		int num = Item.Level(GameManagers.Instance, _productItemId);
		int num2 = num - BlueprintInfo.Item3;
		((GObject)Dialog.RightContent.Name_t).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, _productItemId);
		((GObject)Dialog.RightContent.CurrentLevel_t).text = string.Format("{0}{1}", num2, LanguagesManager.GetDesc("CsharpCodeZhTcText124"));
		((GObject)Dialog.RightContent.NextLevel_t).text = string.Format("{0}{1}", num, LanguagesManager.GetDesc("CsharpCodeZhTcText124"));
		Dialog.RightContent.Status.selectedIndex = ((num2 < 0) ? 1 : 0);
		int weaponEvoLevel = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(_productItemId);
		weaponEvoLevel = ((weaponEvoLevel <= 0) ? 1 : weaponEvoLevel);
		Dialog.LeftContent.Product.Frame.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, weaponEvoLevel);
		Dialog.LeftContent.Product.Icon.url = "ui://PublicResources/" + UiHelper.GetIconPath(_productItemId, weaponEvoLevel);
		string item = BlueprintInfo.Item2;
		UI_Material uI_Material = ((GComponent)Dialog.LeftContent).GetChild($"MaterialItem{0}") as UI_Material;
		((GObject)uI_Material.Requirement).visible = false;
		int level = Item.Rarity(item);
		GLoader icon = uI_Material.Icon;
		FGUIManager.Instance.SetItemIconAndFrame(icon, item, textureList, UiHelper.GetIconFrameBorder(2, level));
		Dictionary<string, string> item2 = BlueprintInfo.Item4;
		if (BlueprintInfo.Item4.Count == 0)
		{
			((GObject)Dialog.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText629");
		}
		Dictionary<string, string> itemBonus = Item.GetItemBonus(GameManagers.Instance, _productItemId);
		Dialog.RightContent.PropertyList.RemoveChildrenToPool();
		int num3 = 0;
		if (item2 != null)
		{
			if (item2.Count == 0)
			{
				foreach (KeyValuePair<string, string> item3 in itemBonus)
				{
					GComponent asCom = Dialog.RightContent.PropertyList.AddItemFromPool().asCom;
					((GObject)asCom).visible = true;
					asCom.GetChild("title").text = item3.Key ?? "";
					((GObject)asCom.GetChild("Current_t").asTextField).text = $"+{0}";
					num3++;
				}
			}
			else
			{
				foreach (KeyValuePair<string, string> item4 in item2)
				{
					GComponent asCom2 = Dialog.RightContent.PropertyList.AddItemFromPool().asCom;
					((GObject)asCom2).visible = true;
					asCom2.GetChild("title").text = item4.Key ?? "";
					((GObject)asCom2.GetChild("Current_t").asTextField).text = "+" + item4.Value;
					num3++;
				}
			}
		}
		num3 = 0;
		if (itemBonus != null)
		{
			foreach (KeyValuePair<string, string> item5 in itemBonus)
			{
				GComponent asCom3 = ((GComponent)Dialog.RightContent.PropertyList).GetChildAt(num3).asCom;
				((GObject)asCom3).visible = true;
				((GObject)asCom3.GetChild("Next_t").asTextField).text = "+" + item5.Value;
				num3++;
			}
		}
		if (Dialog.RightContent.PropertyList.numItems > 2)
		{
			Dialog.RightContent.PropertyList.ResizeToFit(Dialog.RightContent.PropertyList.numItems);
		}
	}

	private void PlayUpgradeSfx()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		GGraph aimSfxBack = ((GComponent)Dialog.LeftContent).GetChild("Product").asCom.GetChild("SfxBack").asGraph;
		Vector2 xy = ((GObject)aimSfxBack).xy;
		for (int i = 0; i < 3; i++)
		{
			GGraph SfxBack = ((GComponent)Dialog.LeftContent).GetChild($"MaterialItem{i}").asCom.GetChild("SfxBack").asGraph;
			FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "item_missile", new Vector3(100f, 100f, 100f));
			Vector2 val = ((GObject)((GComponent)Dialog.LeftContent).GetChild("Product").asCom).TransformPoint(xy, (GObject)(object)((GComponent)Dialog.LeftContent).GetChild($"MaterialItem{i}").asCom);
			((GObject)SfxBack).TweenMove(val, 0.25f).OnComplete((GTweenCallback)delegate
			{
				((GObject)SfxBack).SetXY(45f, 47f);
			});
		}
		((GComponent)(object)this).SetTimeout(0.25f).OnComplete((GTweenCallback)delegate
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			((GObject)aimSfxBack).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(aimSfxBack, "activating_white", new Vector3(235f, 235f, 235f));
		});
		((GComponent)(object)this).SetTimeout(0.3f).OnComplete((GTweenCallback)delegate
		{
			int weaponEvoLevel = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(_productItemId);
			weaponEvoLevel = ((weaponEvoLevel <= 0) ? 1 : weaponEvoLevel);
			Dialog.LeftContent.Product.Frame.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, weaponEvoLevel);
			Dialog.LeftContent.Product.Icon.url = "ui://PublicResources/" + UiHelper.GetIconPath(_productItemId, weaponEvoLevel);
		});
	}
}
