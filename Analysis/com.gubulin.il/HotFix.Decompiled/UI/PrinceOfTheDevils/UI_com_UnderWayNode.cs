using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_com_UnderWayNode : GComponent
{
	public Controller button;

	public GImage n3;

	public UI_indicatesBtn n4;

	public const string URL = "ui://zko5n3vemgyvfb";

	public static string Name = "UI_com_UnderWayNode";

	public static string GetURL()
	{
		return "ui://zko5n3vemgyvfb";
	}

	public static UI_com_UnderWayNode CreateInstance()
	{
		return (UI_com_UnderWayNode)(object)UIPackage.CreateObject("PrinceOfTheDevils", "com_UnderWayNode");
	}

	public static UI_com_UnderWayNode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UnderWayNode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3vemgyvfb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (UI_indicatesBtn)(object)((GComponent)this).GetChild("n4");
	}
}
