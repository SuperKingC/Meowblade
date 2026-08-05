using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_worker : GButton
{
	public Controller button;

	public GLoader icon;

	public GGraph main;

	public GGraph sack;

	public const string URL = "ui://avplaivdnae816";

	public static string Name = "UI_worker";

	public static string GetURL()
	{
		return "ui://avplaivdnae816";
	}

	public static UI_worker CreateInstance()
	{
		return (UI_worker)(object)UIPackage.CreateObject("Contract", "worker");
	}

	public static UI_worker CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_worker).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnae816", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		main = (GGraph)((GComponent)this).GetChild("main");
		sack = (GGraph)((GComponent)this).GetChild("sack");
	}
}
