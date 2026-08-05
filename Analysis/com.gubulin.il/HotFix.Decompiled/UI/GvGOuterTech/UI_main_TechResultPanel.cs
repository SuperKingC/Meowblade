using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using Shift.Legion.Common.Services;

namespace UI.GvGOuterTech;

public class UI_main_TechResultPanel : GComponent, IUiController
{
	private enum eState
	{
		New,
		LevelUp,
		ToPiece
	}

	private class DrawResultItem
	{
		public readonly TechData TechData;

		public readonly RarityData RarityData;

		public eState State;

		public DrawResultItem(TechData techData, RarityData rarityData)
		{
			TechData = techData;
			RarityData = rarityData;
		}
	}

	public GGraph back;

	public UI_com_TechResultDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://th385mttlgfv29";

	public static string Name = "UI_main_TechResultPanel";

	private List<DrawResultItem> DrawResults;

	private UICallbackParam<Action> OnClose;

	public static string GetURL()
	{
		return "ui://th385mttlgfv29";
	}

	public static UI_main_TechResultPanel CreateInstance()
	{
		return (UI_main_TechResultPanel)(object)UIPackage.CreateObject("GvGOuterTech", "main_TechResultPanel");
	}

	public static UI_main_TechResultPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_TechResultPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttlgfv29", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_TechResultDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		OnClose = (parameters.TryGetValue("OnClose", out var value) ? ((UICallbackParam<Action>)value) : null);
		object value2;
		List<DrawTechItem> list = (parameters.TryGetValue("DrawItems", out value2) ? ((List<DrawTechItem>)value2) : new List<DrawTechItem>());
		Dictionary<int, RarityData> dictionary = new Dictionary<int, RarityData>();
		DrawResults = new List<DrawResultItem>();
		foreach (DrawTechItem item in list)
		{
			bool flag = item.LastLevel == 0;
			if (!dictionary.TryGetValue(item.TechData.Rarity, out var value3))
			{
				value3 = new RarityData(item.TechData.Rarity);
				dictionary[item.TechData.Rarity] = value3;
			}
			int num = 0;
			if (flag)
			{
				num = 1;
				DrawResults.Add(new DrawResultItem(item.TechData, value3)
				{
					State = eState.New
				});
			}
			for (int i = num; i < item.DrawCount; i++)
			{
				bool flag2 = i + 1 + item.LastLevel > item.TechData.MaxLevel;
				DrawResults.Add(new DrawResultItem(item.TechData, value3)
				{
					State = ((!flag2) ? eState.LevelUp : eState.ToPiece)
				});
			}
		}
		DrawResults = DrawResults.OrderByDescending((DrawResultItem r) => r.TechData.ItemId).ToList();
		Render();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(End));
	}

	private void Render()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		Dialog.List.SetVirtual();
		Dialog.List.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderTechSlot(i, (UI_btn_TechSlotSmall)(object)o);
		};
		Dialog.List.numItems = DrawResults.Count;
	}

	private void RenderTechSlot(int i, UI_btn_TechSlotSmall slot)
	{
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		DrawResultItem data = DrawResults[i];
		slot.Rarity.selectedIndex = data.TechData.Rarity;
		((GObject)slot.TechName).text = data.TechData.Name;
		slot.TechIcon.url = data.TechData.TechIconUrl;
		slot.State.selectedIndex = (int)data.State;
		if (data.State == eState.ToPiece)
		{
			((GObject)slot.ToPieceCount).text = $"{data.RarityData.ToPieceProduce}";
			slot.PieceIcon.url = data.RarityData.PieceItemIconUrl;
		}
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnClickTechSlot(data.TechData);
		});
	}

	private void OnClickTechSlot(TechData data)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_TechUpgradePanel.Name, new Dictionary<string, object>
		{
			{ "TechData", data },
			{ "ConsumeStatePage", 0 }
		});
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		OnClose?.Callback?.Invoke();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
