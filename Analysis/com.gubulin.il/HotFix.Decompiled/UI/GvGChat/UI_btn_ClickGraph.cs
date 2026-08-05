using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_btn_ClickGraph : GButton
{
	public Controller button;

	public GGraph ClickGraph;

	public const string URL = "ui://e3rxkbaprb0jg";

	public static string Name = "UI_btn_ClickGraph";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0jg";
	}

	public static UI_btn_ClickGraph CreateInstance()
	{
		return (UI_btn_ClickGraph)(object)UIPackage.CreateObject("GvGChat", "btn_ClickGraph");
	}

	public static UI_btn_ClickGraph CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ClickGraph).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ClickGraph = (GGraph)((GComponent)this).GetChild("ClickGraph");
	}
}
