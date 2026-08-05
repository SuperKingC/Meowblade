using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ReceivedBtn : GButton
{
	public Controller button;

	public Controller PageController;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public Transition stamp;

	public const string URL = "ui://kt6rg65ooa38q";

	public static string Name = "UI_ReceivedBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65ooa38q";
	}

	public static UI_ReceivedBtn CreateInstance()
	{
		return (UI_ReceivedBtn)(object)UIPackage.CreateObject("PublicResources", "ReceivedBtn");
	}

	public static UI_ReceivedBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReceivedBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ooa38q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		PageController = ((GComponent)this).GetController("PageController");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		stamp = ((GComponent)this).GetTransition("stamp");
	}
}
