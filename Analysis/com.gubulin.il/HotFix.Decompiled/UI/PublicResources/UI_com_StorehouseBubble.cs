using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_StorehouseBubble : GComponent
{
	public GImage n2;

	public GLoader Icon;

	public Transition t1;

	public const string URL = "ui://kt6rg65obr8fv4sn";

	public static string Name = "UI_com_StorehouseBubble";

	public static string GetURL()
	{
		return "ui://kt6rg65obr8fv4sn";
	}

	public static UI_com_StorehouseBubble CreateInstance()
	{
		return (UI_com_StorehouseBubble)(object)UIPackage.CreateObject("PublicResources", "com_StorehouseBubble");
	}

	public static UI_com_StorehouseBubble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StorehouseBubble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65obr8fv4sn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
