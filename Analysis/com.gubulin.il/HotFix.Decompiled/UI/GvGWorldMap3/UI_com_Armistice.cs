using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Services;

namespace UI.GvGWorldMap3;

public class UI_com_Armistice : GComponent, IUiController
{
	public GGraph back;

	public GImage n0;

	public GTextField n1;

	public GTextField Tip;

	public UI_btn_yes Confirm;

	public GGroup n7;

	public const string URL = "ui://4eq8fgd2kszvs98";

	public static string Name = "UI_com_Armistice";

	private Action _onClickConfirm;

	public static string GetURL()
	{
		return "ui://4eq8fgd2kszvs98";
	}

	public static UI_com_Armistice CreateInstance()
	{
		return (UI_com_Armistice)(object)UIPackage.CreateObject("GvGWorldMap3", "com_Armistice");
	}

	public static UI_com_Armistice CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Armistice).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kszvs98", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4eq8fgd2kszvs98".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		Confirm = (UI_btn_yes)(object)((GComponent)this).GetChild("Confirm");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters != null)
		{
			_onClickConfirm = (parameters.TryGetValue("ConfirmAction", out var value) ? ((Action)value) : null);
		}
		((GObject)Tip).text = "GvG3IslandAttackActionCheck".ToLanguage();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Confirm).onClick.Set(new EventCallback0(OnConfirmClick));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Confirm).onClick.Clear();
	}

	private void OnConfirmClick()
	{
		_onClickConfirm?.Invoke();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
