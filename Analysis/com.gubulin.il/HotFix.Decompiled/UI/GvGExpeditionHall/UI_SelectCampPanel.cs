using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.GvGServer.Models.Map;

namespace UI.GvGExpeditionHall;

public class UI_SelectCampPanel : GComponent, IGvGExpeditionPopup
{
	public Controller IsShow;

	public GGraph Mask;

	public UI_com_SelectCampDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://k19peou7dnvl28";

	public static string Name = "UI_SelectCampPanel";

	public Action<int> OnConfirm = delegate
	{
	};

	public Dictionary<string, GvGMode3CampInfo> CampInfos;

	private GvGExpeditionHallModel Data;

	private UI_GvGExpeditionHallPanel ParentPanel;

	private int SelectedCamp => ((UI_btn_CampSelectItem)(object)((GComponent)Dialog.CampList).GetChildAt(Dialog.CampList.selectedIndex)).CampId.selectedIndex;

	public static string GetURL()
	{
		return "ui://k19peou7dnvl28";
	}

	public static UI_SelectCampPanel CreateInstance()
	{
		return (UI_SelectCampPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "SelectCampPanel");
	}

	public static UI_SelectCampPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectCampPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShow = ((GComponent)this).GetController("IsShow");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_SelectCampDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(GvGExpeditionHallModel data, UI_GvGExpeditionHallPanel parentPanel)
	{
		Data = data;
		ParentPanel = parentPanel;
		RefreshConfirmEnabled();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(OnInactivate));
		((GObject)Dialog.CloseBtn).onClick.Set(new EventCallback0(OnInactivate));
		((GObject)Dialog.ConfirmCampBtn).onClick.Set(new EventCallback1(OnConfirmCampBtn));
		Dialog.CampList.onClickItem.Set(new EventCallback1(OnSelectCampItem));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Dialog.CloseBtn).onClick.Clear();
		((GObject)Dialog.ConfirmCampBtn).onClick.Clear();
		Dialog.CampList.onClickItem.Clear();
	}

	private void RefreshConfirmEnabled()
	{
		((GObject)Dialog.ConfirmCampBtn).enabled = Dialog.CampList.selectedIndex >= 0;
	}

	private void OnConfirmCampBtn(EventContext context)
	{
		if (SelectedCamp == 0)
		{
			List<string> arg = new List<string> { "GvGNoCampSelectedTips".ToLanguage() };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
		}
		else if (((GObject)Dialog.ConfirmCampBtn).grayed)
		{
			List<string> arg2 = new List<string> { "GvGCampFullTips".ToLanguage() };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, ((GObject)this).sortingOrder, arg3: false);
		}
		else
		{
			OnConfirm?.Invoke(SelectedCamp);
			OnInactivate();
		}
	}

	private void OnSelectCampItem(EventContext context)
	{
		RefreshConfirmEnabled();
		if (SelectedCamp != 0 && CampInfos.TryGetValue(SelectedCamp.ToString(), out var value))
		{
			bool flag = value.UserCount < value.UserLimit;
			((GObject)Dialog.ConfirmCampBtn).grayed = !flag;
		}
	}

	public void OnActivate()
	{
		Dialog.CampList.selectedIndex = -1;
		RefreshConfirmEnabled();
	}

	public void OnInactivate()
	{
		IsShow.selectedIndex = 0;
	}
}
