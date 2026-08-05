using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_main_GvG3Chat : GComponent, IUiController
{
	public Controller Status;

	public Controller Type;

	public UI_btn_ClickGraph ClickGraph;

	public UI_btn_MessageBubble MessageBubble;

	public UI_com_Chat Chat;

	public Transition t0;

	public const string URL = "ui://e3rxkbapyfd30";

	public static string Name = "UI_main_GvG3Chat";

	public static string GetURL()
	{
		return "ui://e3rxkbapyfd30";
	}

	public static UI_main_GvG3Chat CreateInstance()
	{
		return (UI_main_GvG3Chat)(object)UIPackage.CreateObject("GvGChat", "main_GvG3Chat");
	}

	public static UI_main_GvG3Chat CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3Chat).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapyfd30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		ClickGraph = (UI_btn_ClickGraph)(object)((GComponent)this).GetChild("ClickGraph");
		MessageBubble = (UI_btn_MessageBubble)(object)((GComponent)this).GetChild("MessageBubble");
		Chat = (UI_com_Chat)(object)((GComponent)this).GetChild("Chat");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		Chat.OnDestroy();
		MessageBubble.OnDestroy();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		Chat.OnInit(this);
		MessageBubble.OnInit(this);
		Type.selectedIndex = 1;
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Status.onChanged.Add(new EventCallback0(OnStatusChange));
		SharedMessenger.AddListener<bool>("ON_GVG3_MAINUI_OPERATION_MODE", OnMainUiChangeMode);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Status.onChanged.Remove(new EventCallback0(OnStatusChange));
		SharedMessenger.RemoveListener<bool>("ON_GVG3_MAINUI_OPERATION_MODE", OnMainUiChangeMode);
	}

	private void OnStatusChange()
	{
		bool arg = Status.selectedIndex != 1;
		SharedMessenger.Broadcast("ON_GVG3_CHATPAGE_CHANGE", arg);
	}

	private void OnMainUiChangeMode(bool show)
	{
		Type.selectedIndex = (show ? 1 : 0);
	}
}
