using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_MessageBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://72poq8plgz132z";

	public static string Name = "UI_MessageBtn";

	public static string GetURL()
	{
		return "ui://72poq8plgz132z";
	}

	public static UI_MessageBtn CreateInstance()
	{
		return (UI_MessageBtn)(object)UIPackage.CreateObject("RecyclingCenter", "MessageBtn");
	}

	public static UI_MessageBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MessageBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plgz132z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
