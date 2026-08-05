using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_InvitationPanel : GComponent
{
	public GGraph mask;

	public UI_InvitationDialog Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://b9yxt7u0t1jro";

	public static string Name = "UI_InvitationPanel";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jro";
	}

	public static UI_InvitationPanel CreateInstance()
	{
		return (UI_InvitationPanel)(object)UIPackage.CreateObject("AccountInfo", "InvitationPanel");
	}

	public static UI_InvitationPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitationPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jro", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_InvitationDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}
}
