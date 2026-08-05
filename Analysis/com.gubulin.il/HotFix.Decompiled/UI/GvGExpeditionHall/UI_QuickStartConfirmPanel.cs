using System;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;

namespace UI.GvGExpeditionHall;

public class UI_QuickStartConfirmPanel : GComponent
{
	public GGraph mask;

	public GImage back;

	public GTextField title;

	public GTextField n7;

	public UI_btn_Cancel Cancel;

	public UI_btn_Confirm Confirm;

	public UI_btn_02 NoRemind;

	public GGroup n12;

	public const string URL = "ui://k19peou795pe6p8z";

	public static string Name = "UI_QuickStartConfirmPanel";

	private const string QUICK_START = "QUICK_START";

	private const string QUICK_START_NO_REMIND = "QUICK_START_NO_REMIND";

	private Action _onConfirm;

	public static string GetURL()
	{
		return "ui://k19peou795pe6p8z";
	}

	public static UI_QuickStartConfirmPanel CreateInstance()
	{
		return (UI_QuickStartConfirmPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "QuickStartConfirmPanel");
	}

	public static UI_QuickStartConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QuickStartConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou795pe6p8z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://k19peou795pe6p8z".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://k19peou795pe6p8z".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		Cancel = (UI_btn_Cancel)(object)((GComponent)this).GetChild("Cancel");
		Confirm = (UI_btn_Confirm)(object)((GComponent)this).GetChild("Confirm");
		NoRemind = (UI_btn_02)(object)((GComponent)this).GetChild("NoRemind");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Cancel).onClick.Set(new EventCallback0(Close));
		((GObject)Confirm).onClick.Set(new EventCallback0(OnConfirmClick));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Cancel).onClick.Clear();
		((GObject)Confirm).onClick.Clear();
	}

	private void Close()
	{
		((GObject)this).visible = false;
	}

	private void OnConfirmClick()
	{
		int curIZId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
		GameLocalDataManager.SetInt(string.Format("{0}_{1}", "QUICK_START", curIZId), 1);
		if (((GButton)NoRemind).selected)
		{
			GameLocalDataManager.SetInt(string.Format("{0}_{1}", "QUICK_START_NO_REMIND", curIZId), 1);
		}
		_onConfirm?.Invoke();
		((GObject)this).visible = false;
	}

	public void Init(bool noRemind, Action onConfirm = null)
	{
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GButton)NoRemind).selected = noRemind;
		((GObject)this).visible = true;
		_onConfirm = onConfirm;
	}
}
