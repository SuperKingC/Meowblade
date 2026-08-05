using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_ChatPages : GComponent
{
	public Controller Type;

	public GImage n0;

	public UI_com_InputChatText Input;

	public GList Messages;

	public const string URL = "ui://e3rxkbaprb0jc";

	public static string Name = "UI_com_ChatPages";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0jc";
	}

	public static UI_com_ChatPages CreateInstance()
	{
		return (UI_com_ChatPages)(object)UIPackage.CreateObject("GvGChat", "com_ChatPages");
	}

	public static UI_com_ChatPages CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ChatPages).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Input = (UI_com_InputChatText)(object)((GComponent)this).GetChild("Input");
		Messages = (GList)((GComponent)this).GetChild("Messages");
	}
}
