using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.GvGBattlePass3;

namespace UI.GVGStore;

public class UI_main_GVGStoreJumpPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_JumpDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://fvc33k3gnf4q17";

	public static string Name = "UI_main_GVGStoreJumpPanel";

	private const string _GVG3_STORE_BATTLE_PASS_UNAVAILABLE = "GvG3Store_BattlePass_Unavailable";

	private StoreActivateMode _activateMode = StoreActivateMode.Ongoing;

	private List<GvGStoreJumpData> _jumpData = new List<GvGStoreJumpData>();

	public static string GetURL()
	{
		return "ui://fvc33k3gnf4q17";
	}

	public static UI_main_GVGStoreJumpPanel CreateInstance()
	{
		return (UI_main_GVGStoreJumpPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreJumpPanel");
	}

	public static UI_main_GVGStoreJumpPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreJumpPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gnf4q17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_JumpDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
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
		if (parameters != null)
		{
			_activateMode = (parameters.TryGetValue("StoreActivateMode", out var value) ? ((StoreActivateMode)value) : StoreActivateMode.Ongoing);
		}
		RenderDialog();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderDialog()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		_jumpData = GameManagers.Instance.UserArchiveManager.GetJumpData();
		if (_jumpData != null && _jumpData.Count > 0)
		{
			Dialog.JumpContext.itemRenderer = new ListItemRenderer(RenderJumpItem);
			Dialog.JumpContext.numItems = _jumpData.Count;
		}
	}

	private void RenderJumpItem(int index, GObject obj)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		if (obj is UI_com_JumpContent uI_com_JumpContent)
		{
			GvGStoreJumpData jumpData = _jumpData[index];
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_JumpContent.Icon, jumpData.ItemId, null, "", frameVisible: false);
			((GObject)uI_com_JumpContent.Icon).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(jumpData.ItemId, 1, noCheckBtn: true);
			});
			((GObject)uI_com_JumpContent.Title).text = jumpData.Title;
			((GObject)uI_com_JumpContent.Tip).text = jumpData.Cycle;
			((GObject)uI_com_JumpContent.Jump).visible = !string.IsNullOrEmpty(jumpData.JumpContext);
			if (jumpData.NumLimit > 0)
			{
				int stock = GameManagers.Instance.StockController.GetStock(jumpData.ItemId);
				string arg = ((stock < jumpData.NumLimit) ? "#1F8C15" : "#ff1a1a");
				((GObject)uI_com_JumpContent.Num).text = $"[color={arg}]{GameManagers.Instance.StockController.GetStock(jumpData.ItemId)}/{jumpData.NumLimit}[/color]";
			}
			if (jumpData.JumpContext == UI_main_GvG3BattlePass.Name)
			{
				jumpData.CheckGoToCondition = CheckGoToBattlePassCondition;
			}
			((GObject)uI_com_JumpContent.Jump).onClick.Set(new EventCallback0(jumpData.GoToRelativeUi));
		}
	}

	private bool CheckGoToBattlePassCondition()
	{
		if (_activateMode == StoreActivateMode.Ongoing)
		{
			return true;
		}
		"GvG3Store_BattlePass_Unavailable".ToShowLanguageTip();
		return false;
	}
}
