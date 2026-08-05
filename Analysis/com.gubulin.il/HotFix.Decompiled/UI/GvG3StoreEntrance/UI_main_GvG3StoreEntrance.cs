using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GVGStore;
using UI.SoulKeyStore;
using UI.StellarKeyStore;

namespace UI.GvG3StoreEntrance;

public class UI_main_GvG3StoreEntrance : GComponent, IUiController
{
	public GLoader background;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GList EntryList;

	public const string URL = "ui://6ccguk4firuhf";

	public static string Name = "UI_main_GvG3StoreEntrance";

	private List<EntryBtn> Entries;

	public static string GetURL()
	{
		return "ui://6ccguk4firuhf";
	}

	public static UI_main_GvG3StoreEntrance CreateInstance()
	{
		return (UI_main_GvG3StoreEntrance)(object)UIPackage.CreateObject("GvG3StoreEntrance", "main_GvG3StoreEntrance");
	}

	public static UI_main_GvG3StoreEntrance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3StoreEntrance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4firuhf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		EntryList = (GList)((GComponent)this).GetChild("EntryList");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		Entries = new List<EntryBtn>();
		if (Singleton<GvG3StoreManager>.Instance.IsStellarKeyStoreActive)
		{
			Entries.Add(UI_btn_StellarKeyEntry.CreateInstance_ILRuntime());
		}
		Entries.Add(UI_btn_StoreEntry.CreateInstance_ILRuntime());
		Entries.Add(UI_btn_SoulkeyEntry.CreateInstance_ILRuntime());
		foreach (EntryBtn btn in Entries)
		{
			btn.Init();
			GObject val = (GObject)btn;
			val.onClick.Set((EventCallback0)delegate
			{
				btn.OnClick();
				HideBtns();
			});
			((GComponent)EntryList).AddChild((GObject)btn);
		}
		if (Entries.Count > 2)
		{
			EntryList.columnGap = 90;
		}
	}

	public void Destroy()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		foreach (EntryBtn entry in Entries)
		{
			entry.Destroy();
			((GComponent)EntryList).RemoveChild((GObject)entry, true);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUIClosed);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUIClosed);
	}

	public void BeforeDestroy()
	{
	}

	public void OnShow()
	{
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OnUIClosed(string uiName)
	{
		if (uiName == UI_main_GVGStorePanel.Name || uiName == UI_main_StellarKeyStorePanel.Name || uiName == UI_SoulKeyStorePanel.Name)
		{
			ShowBtns();
		}
	}

	private void HideBtns()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		foreach (EntryBtn entry in Entries)
		{
			GObject val = (GObject)entry;
			val.visible = false;
		}
	}

	private void ShowBtns()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		foreach (EntryBtn entry in Entries)
		{
			GObject val = (GObject)entry;
			val.visible = true;
		}
	}
}
