using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;

namespace UI.GvGPurification3;

public class UI_main_GvG3Purification : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_Purification PopUp;

	public const string URL = "ui://v7vqvgvm1146l5";

	public static string Name = "UI_main_GvG3Purification";

	private readonly List<PollutantModel> _allPollutants = new List<PollutantModel>(18);

	private string _costItemId;

	private const string GvG3PurifyNoPollutantTip = "GvG3_Purify_No_Pollutant_Tip";

	private const string GvG3PurifyCostItemNotEnoughTip = "GvG3_Purify_CostItem_Not_Enough_Tip";

	public static string GetURL()
	{
		return "ui://v7vqvgvm1146l5";
	}

	public static UI_main_GvG3Purification CreateInstance()
	{
		return (UI_main_GvG3Purification)(object)UIPackage.CreateObject("GvGPurification3", "main_GvG3Purification");
	}

	public static UI_main_GvG3Purification CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3Purification).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvm1146l5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_Purification)(object)((GComponent)this).GetChild("PopUp");
	}

	public void BeforeDestroy()
	{
		Singleton<GvG3PurifyManager>.Instance.Destroy();
		for (int i = 0; i < ((GComponent)PopUp.Pollutants).numChildren; i++)
		{
			if (((GComponent)PopUp.Pollutants).GetChildAt(i) is UI_btn_Pollutant uI_btn_Pollutant)
			{
				uI_btn_Pollutant.Model = null;
			}
		}
		_allPollutants.Clear();
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		Singleton<GvG3PurifyManager>.Instance.Init();
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			LoadData();
			Render();
			PopUp.SelectAll.State.selectedIndex = 1;
			UpdatePurifyState();
		});
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)PopUp.Close).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.Purify).onClick.Set(new EventCallback0(Purify));
		((GObject)PopUp.SelectAll).onClick.Set(new EventCallback0(OnSelectAllClick));
		GvG3PurifyManager instance = Singleton<GvG3PurifyManager>.Instance;
		instance.UpdatePollutantsList = (Action)Delegate.Combine(instance.UpdatePollutantsList, new Action(Update));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Close).onClick.Clear();
		((GObject)PopUp.Purify).onClick.Clear();
		((GObject)PopUp.SelectAll).onClick.Clear();
		GvG3PurifyManager instance = Singleton<GvG3PurifyManager>.Instance;
		instance.UpdatePollutantsList = (Action)Delegate.Remove(instance.UpdatePollutantsList, new Action(Update));
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void LoadData()
	{
		_allPollutants.Clear();
		foreach (string item in ConfigDataManager.ItemsByType[ItemType.GvGServer_CollectingMaterial_Polluted])
		{
			if (string.IsNullOrEmpty(_costItemId))
			{
				PollutantModel pollutantModel = new PollutantModel(item);
				_costItemId = pollutantModel.CostItemId;
			}
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(item, includingGSStock: true);
			if (itemCount > 0)
			{
				_allPollutants.Add(new PollutantModel(item));
			}
		}
	}

	private void Render()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		FGUIManager.Instance.SetItemIconAndFrame(PopUp.CostIcon, _costItemId, null, "", frameVisible: false);
		PopUp.Pollutants.itemRenderer = new ListItemRenderer(PollutantRenderer);
		PopUp.Pollutants.numItems = _allPollutants.Count;
	}

	private void PollutantRenderer(int index, GObject obj)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		UI_btn_Pollutant btn = obj as UI_btn_Pollutant;
		if (btn != null)
		{
			btn.Model = _allPollutants[index];
			btn.Init();
			btn.Update();
			((GObject)btn).onClick.Set(new EventCallback0(PollutantSelected));
		}
		void PollutantSelected()
		{
			btn.Selected = !btn.Selected;
			UpdatePurifyState();
			OnItemSelected();
		}
	}

	private void Update()
	{
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			LoadData();
			Render();
			PopUp.SelectAll.State.selectedIndex = 1;
			UpdatePurifyState();
			PollutantsUpdate();
		});
		void PollutantsUpdate()
		{
			for (int i = 0; i < ((GComponent)PopUp.Pollutants).numChildren; i++)
			{
				if (((GComponent)PopUp.Pollutants).GetChildAt(i) is UI_btn_Pollutant uI_btn_Pollutant)
				{
					uI_btn_Pollutant.Update();
				}
			}
		}
	}

	private void OnSelectAllClick()
	{
		PopUp.SelectAll.State.selectedIndex = 1 - PopUp.SelectAll.State.selectedIndex;
		bool selected = PopUp.SelectAll.State.selectedIndex == 1;
		for (int i = 0; i < ((GComponent)PopUp.Pollutants).numChildren; i++)
		{
			if (((GComponent)PopUp.Pollutants).GetChildAt(i) is UI_btn_Pollutant uI_btn_Pollutant)
			{
				uI_btn_Pollutant.Selected = selected;
			}
		}
		UpdatePurifyState();
	}

	private void OnItemSelected()
	{
		bool flag = true;
		for (int i = 0; i < ((GComponent)PopUp.Pollutants).numChildren; i++)
		{
			if (((GComponent)PopUp.Pollutants).GetChildAt(i) is UI_btn_Pollutant { Selected: false })
			{
				flag = false;
				break;
			}
		}
		PopUp.SelectAll.State.selectedIndex = (flag ? 1 : 0);
	}

	private void Purify()
	{
		if (PopUp.Status.selectedIndex == 0)
		{
			((GObject)PopUp.Purify).data?.ToString().ToShowLanguageTip();
			return;
		}
		List<RItem> list = new List<RItem>(24);
		for (int i = 0; i < ((GComponent)PopUp.Pollutants).numChildren; i++)
		{
			GObject childAt = ((GComponent)PopUp.Pollutants).GetChildAt(i);
			UI_btn_Pollutant btn = childAt as UI_btn_Pollutant;
			if (btn != null && btn.Selected && !list.Exists((RItem r) => r.ItemId == btn.Model.PollutantItem.ItemId))
			{
				list.Add(btn.Model.PollutantItem);
			}
		}
		Singleton<GvG3PurifyManager>.Instance.Purify(list);
		Singleton<GvG3PurifyManager>.Instance.PlayPurificationEffect();
	}

	private void UpdatePurifyState()
	{
		int num = 0;
		int stock = GameManagers.Instance.StockController.GetStock(_costItemId);
		for (int i = 0; i < ((GComponent)PopUp.Pollutants).numChildren; i++)
		{
			if (((GComponent)PopUp.Pollutants).GetChildAt(i) is UI_btn_Pollutant { Selected: not false } uI_btn_Pollutant)
			{
				num += uI_btn_Pollutant.Model.PermitCostNumber;
			}
		}
		((GObject)PopUp.Stock).text = stock.ToString();
		((GObject)PopUp.CostNumber).text = $"/{num}";
		if (num <= 0)
		{
			PopUp.Status.SetSelectedIndex(0);
			((GObject)PopUp.Purify).data = "GvG3_Purify_No_Pollutant_Tip";
		}
		else if (stock < num)
		{
			PopUp.Status.SetSelectedIndex(0);
			((GObject)PopUp.Purify).data = "GvG3_Purify_CostItem_Not_Enough_Tip";
		}
		else
		{
			PopUp.Status.SetSelectedIndex(1);
		}
	}
}
