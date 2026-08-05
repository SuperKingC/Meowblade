using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.GameActivity;
using UI.Tips;

namespace UI.WeekActivity;

public class UI_popup_SpinActivityResult : GComponent, IUiController
{
	public Controller ResultType;

	public Controller PageType;

	public GGraph Mask;

	public UI_com_SpinActivityResultContent Content;

	public GLoader n4;

	public GLoader flyAnim;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://jl0c82y5fmsk0";

	public static string Name = "UI_popup_SpinActivityResult";

	public const string Parent = "Parent";

	public const string Config = "Config";

	public const string DrawResult = "DrawResult";

	public const string OnClose = "OnClose";

	private DrawSpinWeeklyResponse _response;

	private GetWeeklyActivityResponse _config;

	private ISpinWheelPage _parent;

	private Action _onClickClose;

	private List<Tuple<int, int>> _displayModels = new List<Tuple<int, int>>();

	public static string GetURL()
	{
		return "ui://jl0c82y5fmsk0";
	}

	public static UI_popup_SpinActivityResult CreateInstance()
	{
		return (UI_popup_SpinActivityResult)(object)UIPackage.CreateObject("WeekActivity", "popup_SpinActivityResult");
	}

	public static UI_popup_SpinActivityResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_popup_SpinActivityResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5fmsk0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ResultType = ((GComponent)this).GetController("ResultType");
		PageType = ((GComponent)this).GetController("PageType");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Content = (UI_com_SpinActivityResultContent)(object)((GComponent)this).GetChild("Content");
		n4 = (GLoader)((GComponent)this).GetChild("n4");
		flyAnim = (GLoader)((GComponent)this).GetChild("flyAnim");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)Content.confirmBtn).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Content.confirmBtn).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_parent = (ISpinWheelPage)parameters["Parent"];
		_config = (GetWeeklyActivityResponse)parameters["Config"];
		_response = (DrawSpinWeeklyResponse)parameters["DrawResult"];
		if (parameters.TryGetValue("OnClose", out var value))
		{
			_onClickClose = (Action)value;
		}
		bool flag = _response.DrawResult.Count > 1;
		Content.ResultType.SetSelectedIndex(flag ? 1 : 0);
		int activityType = (int)_config.ActivityType;
		PageType.SetSelectedIndex(activityType);
		Content.PageType.SetSelectedIndex(activityType);
		string ticketId = _config.ActivityConfig.ExchangeItemId;
		Content.ticketIcon.url = UiHelper.GetItemIconPath(ticketId);
		StockChangeRecord stockChangeRecord = _response.StockChangeRecords.Find((StockChangeRecord x) => x.ItemId == ticketId);
		((GObject)Content.ticketGetCount).text = ((stockChangeRecord == null) ? "0" : stockChangeRecord.Offset.ToString());
		if (!flag)
		{
			int index = _response.DrawResult[0];
			SpinWeekActivityPayload.ExhibitPrize exhibitPrize = _config.ActivityConfig.ExhibitPrizes[index];
			KeyValuePair<string, int> keyValuePair = exhibitPrize.PrizeContent.First();
			RenderSingleResult(Content.resultIcon, keyValuePair.Key, keyValuePair.Value, exhibitPrize.Rarity);
		}
		else
		{
			RenderMultiMode();
		}
	}

	private void RenderMultiMode()
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		_displayModels.Clear();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int item in _response.DrawResult)
		{
			if (dictionary.ContainsKey(item))
			{
				dictionary[item]++;
			}
			else
			{
				dictionary[item] = 1;
			}
		}
		foreach (KeyValuePair<int, int> item2 in dictionary)
		{
			_displayModels.Add(new Tuple<int, int>(item2.Key, item2.Value));
		}
		Content.resultList.itemRenderer = new ListItemRenderer(ItemRenderer);
		Content.resultList.SetVirtual();
		Content.resultList.numItems = _displayModels.Count;
	}

	private void ItemRenderer(int index, GObject item)
	{
		UI_com_spinResultIcon result = (UI_com_spinResultIcon)(object)item;
		Tuple<int, int> tuple = _displayModels[index];
		int item2 = tuple.Item1;
		int item3 = tuple.Item2;
		SpinWeekActivityPayload.ExhibitPrize exhibitPrize = _config.ActivityConfig.ExhibitPrizes[item2];
		KeyValuePair<string, int> keyValuePair = exhibitPrize.PrizeContent.First();
		RenderSingleResult(result, keyValuePair.Key, keyValuePair.Value, exhibitPrize.Rarity, item3);
	}

	private void RenderSingleResult(UI_com_spinResultIcon result, string itemId, int itemCount, int rarity, int multiple = 1)
	{
		FGUIManager.Instance.SetItemIconAndFrame(result.rewardIcon, itemId, null, "", frameVisible: false);
		result.rewardIcon.InitMaterialIntroductionBtn(itemId);
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		((GObject)result.itemName).text = gDEItemData.Name;
		itemCount *= multiple;
		((GObject)result.Num).text = itemCount.ToString();
		bool flag = rarity == 0;
		result.FrameType.SetSelectedIndex(flag ? 1 : 0);
		result.Type.SetSelectedIndex(1);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void End()
	{
		UI_com_SpinWeekHelper.ShowFlyAnim(_parent, Content.ticketIcon);
		foreach (StockChangeRecord stockChangeRecord in _response.StockChangeRecords)
		{
			if (stockChangeRecord.Offset > 0)
			{
				ILRequestHelper.ShowMessage($"{Item.Name(GameManagers.Instance, stockChangeRecord.ItemId)}+{stockChangeRecord.Offset}");
			}
		}
		_onClickClose?.Invoke();
		UnityUiService.Instance.ClosePanel(Name);
	}
}
