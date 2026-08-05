using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_btn_SendMessage : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n5;

	public GImage n3;

	public GTextField Time;

	public const string URL = "ui://e3rxkbaprb0ji";

	public static string Name = "UI_btn_SendMessage";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0ji";
	}

	public static UI_btn_SendMessage CreateInstance()
	{
		return (UI_btn_SendMessage)(object)UIPackage.CreateObject("GvGChat", "btn_SendMessage");
	}

	public static UI_btn_SendMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SendMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0ji", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Time = (GTextField)((GComponent)this).GetChild("Time");
	}
}
