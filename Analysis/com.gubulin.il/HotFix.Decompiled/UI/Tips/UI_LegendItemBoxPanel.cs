using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.LegendItemBlueprint;
using UI.LegendItemInfo;
using UnityEngine;

namespace UI.Tips;

public class UI_LegendItemBoxPanel : GComponent, IUiController
{
	public Controller Type;

	public Controller AlphaController;

	public GGraph mask;

	public GMovieClip CommonBox;

	public GMovieClip AdvancedBox;

	public GGraph shiningSfxBack;

	public UI_LegendItemBoxDialog Content;

	public GGraph openSfxBack;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public const string URL = "ui://47lbpgx9rv9z54";

	public static string Name = "UI_LegendItemBoxPanel";

	private List<string> _textureList = new List<string>();

	private List<LegendItemUi> legendItems = new List<LegendItemUi>();

	private List<Blueprint> blueprints = new List<Blueprint>();

	private const string MissileSfx = "Missile";

	private const string ExpMissileGreen = "exp_missile_green";

	private const string TreasureShining = "treasure_shining";

	private const string BoxFlashing = "BoxFlashing";

	private const string UiFullscreenTreasureIdentify = "ui_fullscreen_treasure_identify";

	private const float DelayTime = 0.6f;

	private const int MaxShowNum = 8;

	public static string GetURL()
	{
		return "ui://47lbpgx9rv9z54";
	}

	public static UI_LegendItemBoxPanel CreateInstance()
	{
		return (UI_LegendItemBoxPanel)(object)UIPackage.CreateObject("Tips", "LegendItemBoxPanel");
	}

	public static UI_LegendItemBoxPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemBoxPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9rv9z54", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		AlphaController = ((GComponent)this).GetController("AlphaController");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		CommonBox = (GMovieClip)((GComponent)this).GetChild("CommonBox");
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		shiningSfxBack = (GGraph)((GComponent)this).GetChild("shiningSfxBack");
		Content = (UI_LegendItemBoxDialog)(object)((GComponent)this).GetChild("Content");
		openSfxBack = (GGraph)((GComponent)this).GetChild("openSfxBack");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
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
		legendItems = (parameters.TryGetValue("LegendItems", out var value) ? (value as List<LegendItemUi>) : new List<LegendItemUi>());
		blueprints = (parameters.TryGetValue("Blueprints", out var value2) ? (value2 as List<Blueprint>) : new List<Blueprint>());
		if (parameters.TryGetValue("SortingOrder", out var value3))
		{
			((GObject)this).sortingOrder = (int)value3;
		}
		else
		{
			((GObject)this).sortingOrder = 100;
		}
		if (parameters.TryGetValue("ItemId", out var value4))
		{
			string itemId = value4.ToString();
			switch (Item.IsShining(itemId))
			{
			case 2:
				Type.selectedIndex = 1;
				break;
			case 1:
				Type.selectedIndex = 0;
				break;
			}
			((GObject)Content.Title).text = Item.Name(GameManagers.Instance, itemId);
		}
		else
		{
			Type.selectedIndex = 0;
		}
		Content.Type.selectedIndex = ((legendItems.Count <= 0) ? 1 : 0);
		RenderLegendItems();
		RenderBlueprints();
	}

	public void OnShow()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		LoadOpenSfx();
		((GComponent)(object)this).SetTimeout(0.6f).OnComplete((GTweenCallback)delegate
		{
			AlphaController.selectedIndex = 1;
			LoadShiningSfx();
		});
		if (legendItems == null && blueprints == null)
		{
			End();
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Content.confirmBtn).onClick.Add(new EventCallback0(PlayMissileSfx));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Content.confirmBtn).onClick.Remove(new EventCallback0(PlayMissileSfx));
	}

	private void ShuffleItemsOrder(List<LegendItemUi> list)
	{
		Random random = new Random();
		for (int num = list.Count - 1; num > 0; num--)
		{
			LegendItemUi value = list[num];
			int index = random.Next(num + 1);
			list[num] = list[index];
			list[index] = value;
		}
	}

	private void RenderLegendItems()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		if (legendItems != null && legendItems.Count > 0)
		{
			ShuffleItemsOrder(legendItems);
			Content.Items.SetVirtual();
			if (legendItems.Count <= 4)
			{
				Content.Items.align = (AlignType)1;
				Content.Items.verticalAlign = (VertAlignType)1;
			}
			else
			{
				Content.Items.align = (AlignType)0;
				Content.Items.verticalAlign = (VertAlignType)0;
			}
			Content.Items.itemRenderer = new ListItemRenderer(RenderItem);
			Content.Items.numItems = legendItems.Count;
		}
	}

	private void RenderItem(int index, GObject obj)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		LegendItemUi legendItemUi = legendItems[index];
		UiHelper.TextColorType colorType = UiHelper.TextColorType.Dark;
		GButton asButton2 = ((GComponent)asButton).GetChild("Content").asButton;
		UiHelper.RenderLegendItem(asButton2, legendItemUi, colorType, _textureList);
		((GObject)asButton).data = legendItemUi;
		((GObject)asButton).onClick.Set(new EventCallback1(CheckLegendItemInfo));
	}

	private void CheckLegendItemInfo(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		LegendItemUi item = ((GObject)context.sender).data as LegendItemUi;
		UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(item);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
	}

	public void RenderBlueprints()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		if (blueprints != null && blueprints.Count > 0)
		{
			blueprints = (from _blue in blueprints
				orderby _blue.EvoId descending, _blue.CreateTimestamp descending
				select _blue).ToList();
			Content.BlueprintList.SetVirtual();
			Content.BlueprintList.itemRenderer = new ListItemRenderer(BlueprintItemRender);
			Content.BlueprintList.numItems = blueprints.Count;
		}
	}

	private void BlueprintItemRender(int index, GObject obj)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		if (asButton != null)
		{
			Blueprint blueprint = blueprints[index];
			((GComponent)asButton).GetChild("frame").asLoader.url = "ui://PublicResources/kuang_round 2_lv6";
			((GComponent)asButton).GetChild("max").visible = false;
			((GComponent)asButton).GetChild("icon").asLoader.LoadBlueprintIcon(blueprint.GetIconName());
			((GComponent)asButton).GetChild("name").text = blueprint.GetNameTwoRows();
			((GObject)asButton).data = blueprint;
			((GObject)asButton).onClick.Set(new EventCallback1(ShowBlueprintInfo));
		}
	}

	private void ShowBlueprintInfo(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)context.sender).data is Blueprint value)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintInfoPanel.Name, new Dictionary<string, object>
			{
				{ "BlueprintData", value },
				{ "Type", 1 }
			});
		}
	}

	private void PlayMissileSfx()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		if (!((GObject)shiningSfxBack).displayObject.isDisposed)
		{
			((GObject)shiningSfxBack).displayObject.Dispose();
		}
		((GObject)missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		FGUIManager.Instance.AddTextSpecialEffects(missibleSfxBack, "exp_missile_green", Vector3.zero);
		((GObject)missibleSfxBack).TweenMove(((GObject)missbleEndPos).xy, 0.5f);
		UiAudioManager.Instance.PlaySoundEffect("Missile");
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			End();
		});
	}

	private void LoadShiningSfx()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(shiningSfxBack, "treasure_shining", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureShining)
		{
			UiAudioManager.Instance.LoadSoundsForSfx(treasureShining, "BoxFlashing", playLoop: true);
		});
	}

	private void LoadOpenSfx()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(openSfxBack, "ui_fullscreen_treasure_identify", new Vector3(100f, 100f, 100f));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < _textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(_textureList[i]);
		}
	}
}
