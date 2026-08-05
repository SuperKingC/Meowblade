using System;
using System.Collections.Generic;
using System.Text;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGShipPopup;

public class UI_main_BuildConfirmPanel : GComponent, IUiController
{
	public class BuildParam
	{
		public eRace ShipRace;

		public int CurWorkerCount;

		public bool FastBuild;
	}

	public GGraph back;

	public UI_BuildConfirmDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://pwrbvhpvd7nm3p";

	public static string Name = "UI_main_BuildConfirmPanel";

	private UICallbackParam<Action<BuildParam>> OnConfirmCallback;

	private int ShipRace;

	private int CurWorkerCount;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private eShipBuildType BuildType;

	private bool _costSetupDone;

	private string _cost1ItemId;

	private int _cost1ReqCount;

	private string _cost2ItemId;

	private int _cost2ReqCount;

	private string _cost3ItemId;

	private int _cost3ReqCount;

	private int _fastBuildExtraCost;

	public static string GetURL()
	{
		return "ui://pwrbvhpvd7nm3p";
	}

	public static UI_main_BuildConfirmPanel CreateInstance()
	{
		return (UI_main_BuildConfirmPanel)(object)UIPackage.CreateObject("GvGShipPopup", "main_BuildConfirmPanel");
	}

	public static UI_main_BuildConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BuildConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvd7nm3p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_BuildConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		Popup.Play();
		BuildType = (parameters.TryGetValue("BuildType", out var value) ? ((eShipBuildType)value) : eShipBuildType.Building);
		if (parameters.TryGetValue("ShipType", out var value2))
		{
			ShipRace = (int)value2;
			ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(ShipRace);
			((GObject)Dialog.ShipName).text = byShipRaceType.DefaultName;
			((GObject)Dialog.RaceName).text = RaceHelper.GetRaceName(ShipRace);
			((GButton)Dialog.fastBuildCheckBox).selected = false;
			Dialog.isFastBuild.selectedIndex = 0;
			InitShipAnimation(byShipRaceType.DefaultSkinId);
			UpdateBuildTime();
			UpdateConsumptionList();
			UpdateFastBuildCost();
		}
		if (parameters.TryGetValue("OnConfirm", out var value3))
		{
			OnConfirmCallback = (UICallbackParam<Action<BuildParam>>)value3;
		}
		TechData techData = "I67207".GetTechData();
		bool flag = "I67207".IsActive();
		Dialog.hasOuterTech.SetSelectedIndex(flag ? 1 : 0);
		if (!flag)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("GvG3BuildShipTimeTipTitle".ToLanguage());
		int num = Mathf.RoundToInt(techData.EffectValue);
		stringBuilder.Append(string.Format("GvG3BuildShipTimeTip1".ToLanguage(), num));
		string tip = stringBuilder.ToString();
		((GObject)Dialog.outerTechicon).onClick.Set((EventCallback0)delegate
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			FairyGUITip.ShowTip((GObject)(object)Dialog.outerTechicon, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
			{
				((GObject)popup.title).text = tip;
			});
		});
		((GObject)Dialog.outerTechicon2).onClick.Set((EventCallback0)delegate
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			FairyGUITip.ShowTip((GObject)(object)Dialog.outerTechicon2, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
			{
				((GObject)popup.title).text = tip;
			});
		});
	}

	private void InitShipAnimation(int shipSkinId)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		ShipAnimCacheManager = new ShipAnimCacheManager();
		GameObject cache = ShipAnimCacheManager.GetCache("", shipSkinId, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "dengdai", true);
		});
		cache.transform.localScale = new Vector3(42f, 42f, 42f);
		GoWrapper val = new GoWrapper(cache);
		val.supportStencil = true;
		Dialog.SpineLoader.SetNativeObject((DisplayObject)(object)val);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		((GObject)Dialog.AddWorker).onClick.Set(new EventCallback1(OnAddWorker));
		((GObject)Dialog.ReduceWorker).onClick.Set(new EventCallback1(OnReduceWorker));
		((GObject)Dialog.ConfirmBtn).onClick.Set(new EventCallback1(OnConfirmBuild));
		((GObject)Dialog.CloseBtn).onClick.Set(new EventCallback0(End));
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GButton)Dialog.fastBuildCheckBox).onChanged.Set(new EventCallback1(OnFastBuildCheckChanged));
		Timers.inst.Add(0.8f, 0, new TimerCallback(UpdateConsumptionList));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		((GObject)Dialog.AddWorker).onClick.Clear();
		((GObject)Dialog.ReduceWorker).onClick.Clear();
		((GObject)Dialog.ConfirmBtn).onClick.Clear();
		((GObject)Dialog.CloseBtn).onClick.Clear();
		((GButton)Dialog.fastBuildCheckBox).onChanged.Clear();
		((GObject)back).onClick.Clear();
		Timers.inst.Remove(new TimerCallback(UpdateConsumptionList));
	}

	private void OnAddWorker(EventContext context)
	{
		int freeManPower = Dungeon.GetFreeManPower(GameManagers.Instance);
		if (CurWorkerCount >= 5)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText626") + "5" + LanguagesManager.GetDesc("CsharpCodeZhTcText627") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
		}
		else if (CurWorkerCount >= freeManPower)
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText628") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, ((GObject)this).sortingOrder, arg3: false);
		}
		else
		{
			CurWorkerCount++;
			Dialog.WorkersList.numItems = CurWorkerCount;
			UpdateBuildTime();
			((UI_WorkerItem)(object)((GComponent)Dialog.WorkersList).GetChildAt(Dialog.WorkersList.numItems - 1)).increase.Play();
		}
	}

	private void OnReduceWorker(EventContext context)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		if (CurWorkerCount == 0)
		{
			return;
		}
		Transition reduce = ((UI_WorkerItem)(object)((GComponent)Dialog.WorkersList).GetChildAt(Dialog.WorkersList.numItems - 1)).reduce;
		if (reduce.playing)
		{
			return;
		}
		reduce.Play((PlayCompleteCallback)delegate
		{
			CurWorkerCount--;
			if (CurWorkerCount < 0)
			{
				CurWorkerCount = 0;
			}
			Dialog.WorkersList.numItems = CurWorkerCount;
			UpdateBuildTime();
		});
	}

	private void OnConfirmBuild(EventContext context)
	{
		End();
		OnConfirmCallback.Callback?.Invoke(new BuildParam
		{
			ShipRace = (eRace)ShipRace,
			CurWorkerCount = CurWorkerCount,
			FastBuild = (Dialog.isFastBuild.selectedIndex == 1)
		});
	}

	public void UpdateConsumptionList(object parameter = null)
	{
		if (!_costSetupDone)
		{
			_costSetupDone = true;
			ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(ShipRace);
			Dictionary<string, int> dictionary = ((BuildType == eShipBuildType.Building) ? byShipRaceType.Requirement : byShipRaceType.RebuildRequirement);
			List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				if (item.Key == "Money")
				{
					_cost3ItemId = item.Key;
					_cost3ReqCount = item.Value;
				}
				else
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				_cost1ItemId = list[0].Key;
				_cost1ReqCount = list[0].Value;
				SetupCostItem(Dialog.cost1, _cost1ItemId);
			}
			if (list.Count > 1)
			{
				_cost2ItemId = list[1].Key;
				_cost2ReqCount = list[1].Value;
				SetupCostItem(Dialog.cost2, _cost2ItemId);
			}
			if (!string.IsNullOrEmpty(_cost3ItemId))
			{
				SetupCostItem(Dialog.cost3, _cost3ItemId);
			}
		}
		bool flag = true;
		if (!string.IsNullOrEmpty(_cost1ItemId))
		{
			flag &= UpdateCostItemStock(Dialog.cost1, _cost1ItemId, _cost1ReqCount);
		}
		if (!string.IsNullOrEmpty(_cost2ItemId))
		{
			flag &= UpdateCostItemStock(Dialog.cost2, _cost2ItemId, _cost2ReqCount);
		}
		if (!string.IsNullOrEmpty(_cost3ItemId))
		{
			flag &= UpdateCostItemStock(Dialog.cost3, _cost3ItemId, _cost3ReqCount);
		}
		((GObject)Dialog.ConfirmBtn).touchable = flag;
		((GObject)Dialog.ConfirmBtn).grayed = !flag;
	}

	private void SetupCostItem(UI_goodItemConsume item, string itemId)
	{
		int num = Item.Level(GameManagers.Instance, itemId);
		FGUIManager.Instance.SetItemIconAndFrame(item.icon, itemId, null, UiHelper.GetIconFrameBorder(2, (num < 1) ? 1 : num));
		GObject child = item.reqDesc.GetChild("originPrice");
		child.SetSize(0f, 0f);
		child.visible = false;
	}

	private bool UpdateCostItemStock(UI_goodItemConsume item, string itemId, int reqCount)
	{
		GTextField asTextField = item.reqDesc.GetChild("curPrice").asTextField;
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		string text = ((reqCount > stock) ? "#DC143C" : "#F6E2B2");
		string text2 = "#F6E2B2";
		((GObject)asTextField).text = "[color=" + text + "]" + stock.ShortNumberFormat() + "[/color][color=" + text2 + "]/" + reqCount.ShortNumberFormat() + "[/color]";
		return reqCount <= stock;
	}

	private void OnFastBuildCheckChanged(EventContext context)
	{
		Dialog.isFastBuild.selectedIndex = (((GButton)Dialog.fastBuildCheckBox).selected ? 1 : 0);
		UpdateFastBuildCost();
		UpdateConsumptionList();
	}

	private void UpdateFastBuildCost()
	{
		bool flag = Dialog.isFastBuild.selectedIndex == 1;
		if (flag && !string.IsNullOrEmpty(_cost3ItemId))
		{
			Dictionary<string, int> dictionary = "GvGMode3FastBuildCost".ToConfiguration<Dictionary<string, int>>();
			if (dictionary != null && dictionary.TryGetValue(_cost3ItemId, out var value))
			{
				_fastBuildExtraCost = value;
			}
			else
			{
				_fastBuildExtraCost = 0;
			}
			if (_fastBuildExtraCost > 0 && "I67207".IsActive())
			{
				float num = 1f - "I67207".GetTechData().EffectValue / 100f;
				_fastBuildExtraCost = Mathf.RoundToInt((float)_fastBuildExtraCost * num);
			}
			if (_fastBuildExtraCost > 0)
			{
				((GObject)Dialog.curPrice).text = "+" + _fastBuildExtraCost.ShortNumberFormat();
			}
			else
			{
				((GObject)Dialog.curPrice).text = string.Empty;
			}
		}
		else
		{
			_fastBuildExtraCost = 0;
		}
		if (!string.IsNullOrEmpty(_cost3ItemId))
		{
			int reqCount = _cost3ReqCount + _fastBuildExtraCost;
			UpdateCostItemStock(Dialog.cost3, _cost3ItemId, reqCount);
		}
		if (flag)
		{
			((GObject)Dialog.BuildTime2).text = UiHelper.ParseTime(1);
		}
	}

	private void UpdateBuildTime()
	{
		float num = 1f;
		if ("I67207".IsActive())
		{
			num *= 1f - "I67207".GetTechData().EffectValue / 100f;
		}
		if ("I67207".IsActive() || CurWorkerCount > 1)
		{
			((GObject)Dialog.BuildTime).grayed = false;
			int assignedWorkers = Mathf.Max(1, CurWorkerCount);
			int buildTime = ShipConfigHelper.GetBuildTime(ShipRace, assignedWorkers, num);
			int buildTime2 = ShipConfigHelper.GetBuildTime(ShipRace);
			((GObject)Dialog.BuildTime).text = UiHelper.ParseTime(buildTime) + " [color=#A5E32E](-" + UiHelper.ParseTime(buildTime2 - buildTime) + ")[/color]";
		}
		else if (CurWorkerCount == 0)
		{
			((GObject)Dialog.BuildTime).text = UiHelper.ParseTime(ShipConfigHelper.GetBuildTime(ShipRace)) ?? "";
			((GObject)Dialog.BuildTime).grayed = true;
		}
		else if (CurWorkerCount == 1)
		{
			((GObject)Dialog.BuildTime).text = UiHelper.ParseTime(ShipConfigHelper.GetBuildTime(ShipRace, CurWorkerCount)) ?? "";
			((GObject)Dialog.BuildTime).grayed = false;
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		ShipAnimCacheManager?.ClearCache();
	}

	public void Destroy()
	{
	}
}
