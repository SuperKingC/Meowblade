using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.OuterTechConfigs;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.ClientApi.Sources.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvG3SplitBluePrint;

public class UI_main_SplitBlueprint : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_Blueprints Blueprints;

	public const string URL = "ui://7uylntmmnuv10";

	public static string Name = "UI_main_SplitBlueprint";

	private const string _EMPTY_QTY = "----";

	private bool IsOutGvG = false;

	private List<Blueprint> _blueprints;

	private Blueprint _selectedBlueprint;

	private BlueprintToBeSplitParams _params;

	private Action _onPlaySplitEffectComplete;

	private Action _onStartSplit;

	private Vector2 _endPointPos;

	private static string 蓝图分解Qty => Config.Qty.ToString();

	private static 蓝图分解Config Config => OuterTechHelper.蓝图分解Config.Value;

	private Vector2 EndPointPos
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			if (_endPointPos == default(Vector2))
			{
				_endPointPos = ((GObject)Blueprints.FragmentCount).LocalToRoot(Vector2.zero, GRoot.inst);
			}
			return _endPointPos;
		}
	}

	public static string GetURL()
	{
		return "ui://7uylntmmnuv10";
	}

	public static UI_main_SplitBlueprint CreateInstance()
	{
		return (UI_main_SplitBlueprint)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "main_SplitBlueprint");
	}

	public static UI_main_SplitBlueprint CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_SplitBlueprint).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmnuv10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Blueprints = (UI_com_Blueprints)(object)((GComponent)this).GetChild("Blueprints");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters != null && parameters.TryGetValue("IsOutGvG", out var value) && (bool)value)
		{
			IsOutGvG = true;
		}
		SetPanelSizeAndXy();
		InitAction();
		InitBlueprintsList();
		DisplayPanel();
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
		((GObject)Blueprints.Close).onClick.Set(new EventCallback0(End));
		((GObject)Blueprints.SelectedBlueprint).onClick.Set(new EventCallback0(CancelSelectedBlueprint));
		((GObject)Blueprints.Comfirm).onClick.Set(new EventCallback0(Split));
		S2COuterTechSplitBluePrint.OnPushEvent = (Action<S2COuterTechSplitBluePrint.Request>)Delegate.Combine(S2COuterTechSplitBluePrint.OnPushEvent, new Action<S2COuterTechSplitBluePrint.Request>(UpdateOnSplitFinished));
		BlueprintLockManager bpLockManager = GameManagers.Instance.BpLockManager;
		bpLockManager.EBPLockStateChange = (Action<Blueprint>)Delegate.Combine(bpLockManager.EBPLockStateChange, new Action<Blueprint>(OnBlueprintLockStateChanged));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Blueprints.Close).onClick.Clear();
		((GObject)Blueprints.SelectedBlueprint).onClick.Clear();
		((GObject)Blueprints.Comfirm).onClick.Clear();
		S2COuterTechSplitBluePrint.OnPushEvent = (Action<S2COuterTechSplitBluePrint.Request>)Delegate.Remove(S2COuterTechSplitBluePrint.OnPushEvent, new Action<S2COuterTechSplitBluePrint.Request>(UpdateOnSplitFinished));
		BlueprintLockManager bpLockManager = GameManagers.Instance.BpLockManager;
		bpLockManager.EBPLockStateChange = (Action<Blueprint>)Delegate.Remove(bpLockManager.EBPLockStateChange, new Action<Blueprint>(OnBlueprintLockStateChanged));
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void SetPanelSizeAndXy()
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
	}

	private void DisplayPanel()
	{
		LoadAllBlueprints();
		RenderAllBlueprints();
		RenderSelectedBlueprint();
		UpdateCurFragmentStock();
		UpdateConfirmBtnEnabled(btnEnabled: false);
	}

	private void UpdateBlueprints(string deleteId)
	{
		LegendItemsHelper.DeleteBlueprint(deleteId);
		LoadAllBlueprints();
	}

	private void LoadAllBlueprints()
	{
		_blueprints = (from blue in GameManagers.Instance.UserArchiveManager.GetLegendItemBlueprints().Clone().Where(delegate(Blueprint x)
			{
				GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[x.MainId];
				return !gDELegendItemData.Tags.Contains("兽族");
			})
			orderby blue.EvoId descending, blue.CreateTimestamp descending
			select blue).ToList();
		SortBlueprints();
	}

	private void SortBlueprints()
	{
		_blueprints.InsertionSort(BlueprintLockCompare);
	}

	private static int BlueprintLockCompare(Blueprint blueprint1, Blueprint blueprint2)
	{
		int num = (GameManagers.Instance.BpLockManager.GetIsLocked(blueprint1) ? 1 : 0);
		int value = (GameManagers.Instance.BpLockManager.GetIsLocked(blueprint2) ? 1 : 0);
		return num.CompareTo(value);
	}

	private void InitBlueprintsList()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		Blueprints.AllBlueprints.SetVirtual();
		Blueprints.AllBlueprints.itemRenderer = new ListItemRenderer(RenderBlueprint);
	}

	private void RenderAllBlueprints()
	{
		Blueprints.BlueprintsIsEmpty.SetSelectedIndex((_blueprints.Count <= 0) ? 1 : 0);
		Blueprints.AllBlueprints.numItems = _blueprints.Count;
	}

	private void RenderBlueprint(int index, GObject obj)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		if (!(obj is UI_btn_Blueprint uI_btn_Blueprint))
		{
			throw new Exception("UI_main_SplitBlueprint.RenderBlueprint blueprintUi is not UI_btn_Blueprint");
		}
		Blueprint blueprint = (Blueprint)(((GObject)uI_btn_Blueprint).data = _blueprints[index]);
		((GObject)uI_btn_Blueprint).onClick.Set(new EventCallback1(SelectBlueprint));
		int stateIndex = ((_selectedBlueprint?.Id == blueprint.Id) ? 1 : 0);
		uI_btn_Blueprint.Render(blueprint, stateIndex);
	}

	private void RenderSelectedBlueprint()
	{
		bool flag = _selectedBlueprint == null;
		Blueprints.BlueprintSelected.SetSelectedIndex((!flag) ? 1 : 0);
		if (!flag)
		{
			UI_goodItemLarge uI_goodItemLarge = (UI_goodItemLarge)(object)Blueprints.SelectedBlueprint.Loader;
			uI_goodItemLarge.frame.url = "ui://PublicResources/kuang_round 2_lv6";
			((GObject)uI_goodItemLarge.max).visible = false;
			uI_goodItemLarge.icon.LoadBlueprintIcon(_selectedBlueprint.GetIconName());
			((GObject)uI_goodItemLarge.name).visible = false;
		}
	}

	private void SelectBlueprint(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Blueprint blueprint = (((GObject)context.sender).data as Blueprint) ?? throw new Exception("UI_main_SplitBlueprint.SelectBlueprint blueprint is null");
		BlueprintOperationMode mode = ((blueprint.Id == _selectedBlueprint?.Id) ? BlueprintOperationMode.Dequeue : BlueprintOperationMode.Enqueue);
		UpdateSplitParams(blueprint, mode, opEnabled: true);
		OpenToBeSplitPanel();
	}

	private void CancelSelectedBlueprint()
	{
		if (Blueprints.BlueprintSelected.selectedIndex != 0 && _selectedBlueprint != null)
		{
			UpdateSplitParams(_selectedBlueprint, BlueprintOperationMode.Dequeue, opEnabled: true);
			OpenToBeSplitPanel();
		}
	}

	private void OpenToBeSplitPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BlueprintToBeSplit.Name, new Dictionary<string, object> { { "BlueprintToBeSplitParams", _params } });
	}

	private void UpdateSplitParams(Blueprint blueprint, BlueprintOperationMode mode, bool opEnabled)
	{
		EnsureCreateSplitParams();
		_params.UpdateParams(blueprint, mode, opEnabled);
	}

	private void EnsureCreateSplitParams()
	{
		if (_params == null)
		{
			_params = new BlueprintToBeSplitParams(EnqueueAction, DequeueAction, BlueprintDialogType.Left);
		}
	}

	private void EnqueueAction(string blueprintId)
	{
		ClearLeftSelectedBlueprint(_selectedBlueprint?.Id);
		_selectedBlueprint = _blueprints.Find((Blueprint b) => b.Id == blueprintId);
		UpdateConfirmBtnEnabled(btnEnabled: true);
		RenderSelectedBlueprint();
		UpdateExpectedToObtainFragmentCount(蓝图分解Qty);
		SelectBlueprint(blueprintId);
	}

	private void SelectBlueprint(string blueprintId)
	{
		UI_btn_Blueprint uI_btn_Blueprint = FindBlueprintUiBtn(blueprintId);
		uI_btn_Blueprint.UpdateState(1);
	}

	private void DequeueAction(string blueprintId)
	{
		RevertSelectedBlueprint();
		ClearLeftSelectedBlueprint(blueprintId);
		BlueprintOperationMode mode = BlueprintOperationMode.Enqueue;
		UpdateSplitParams(_selectedBlueprint, mode, opEnabled: true);
	}

	private void OnBlueprintLockStateChanged(Blueprint blueprint)
	{
		SortBlueprints();
		RenderAllBlueprints();
	}

	private void RevertSelectedBlueprint()
	{
		_selectedBlueprint = null;
		UpdateConfirmBtnEnabled(btnEnabled: false);
		RenderSelectedBlueprint();
		UpdateExpectedToObtainFragmentCount("----");
	}

	private void ClearLeftSelectedBlueprint(string blueprintId)
	{
		if (!string.IsNullOrEmpty(blueprintId))
		{
			UI_btn_Blueprint uI_btn_Blueprint = FindBlueprintUiBtn(blueprintId);
			uI_btn_Blueprint.UpdateState(0);
		}
	}

	private UI_btn_Blueprint FindBlueprintUiBtn(string blueprintId)
	{
		int num = _blueprints.FindIndex((Blueprint b) => b.Id == blueprintId);
		Blueprints.AllBlueprints.ScrollToView(num);
		int num2 = Blueprints.AllBlueprints.ItemIndexToChildIndex(num);
		return ((GComponent)Blueprints.AllBlueprints).GetChildAt(num2) as UI_btn_Blueprint;
	}

	private void UpdateConfirmBtnEnabled(bool btnEnabled)
	{
		((GObject)Blueprints.Comfirm).enabled = btnEnabled;
	}

	private void UpdateCurFragmentStock()
	{
		((GObject)Blueprints.FragmentCount).text = GameManagers.Instance.StockController.GetStock(Config.ItemId).ToString();
	}

	private void UpdateExpectedToObtainFragmentCount(string qty)
	{
		((GObject)Blueprints.ExpectedToObtain).text = qty;
	}

	private void Split()
	{
		if (string.IsNullOrEmpty(_selectedBlueprint?.Id))
		{
			return;
		}
		GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[_selectedBlueprint.EvoId];
		string nameWithoutColor = Blueprint.GetNameWithoutColor(gDELegendItemData.Name);
		string richText = "SplitBlueprintConfirmTip".ToLanguage();
		richText = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(richText, nameWithoutColor);
		richText.ToConfirmPopup(delegate
		{
			if (IsOutGvG)
			{
				Task<SplitBlueprintResponse> task = GameController.Contexts.Service<INetworkService>().SplitBlueprint(_selectedBlueprint.Id);
				task.GetAwaiter().OnCompleted(delegate
				{
					SplitBlueprintResponse result = task.Result;
					if (result.ErrorCode != 0)
					{
						ILRequestHelper.ShowErrorCode(result.ErrorCode);
					}
					else
					{
						GameManagers.Instance.StockController.ReadStockChangeRecords(result.StockChangeRecords);
						UpdateOnSplitFinished(null);
					}
				});
			}
			else
			{
				SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2SOuterTechSplitBluePrint
				{
					Req = new C2SOuterTechSplitBluePrint.Request
					{
						BluePrintId = _selectedBlueprint.Id
					}
				}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
				{
					C2SOuterTechSplitBluePrint.Response response = (C2SOuterTechSplitBluePrint.Response)contextResponse.Resp;
					if (response.ErrorCode != 0)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
				});
			}
		}, null, (AlignType)0);
	}

	private void UpdateOnSplitFinished(S2COuterTechSplitBluePrint.Request request)
	{
		if (!((GObject)this).isDisposed)
		{
			UpdateBlueprints(_selectedBlueprint?.Id);
			RevertSelectedBlueprint();
			RenderAllBlueprints();
			PlaySplitEffect();
		}
	}

	private void PlaySplitEffect()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_DisplaySplitEffect.Name, new Dictionary<string, object>
		{
			{ "OnComplete", _onPlaySplitEffectComplete },
			{ "OnStartSplit", _onStartSplit },
			{ "EndPos", EndPointPos }
		});
	}

	private void InitAction()
	{
		_onPlaySplitEffectComplete = delegate
		{
			UpdateCurFragmentStock();
			Blueprints.Split.PlayReverse();
			Blueprints.Split.Stop(true, true);
		};
		_onStartSplit = delegate
		{
			Blueprints.Split.Play();
		};
	}
}
