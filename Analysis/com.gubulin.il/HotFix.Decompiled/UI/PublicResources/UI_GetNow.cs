using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_GetNow : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://kt6rg65ovha9v9b";

	public static string Name = "UI_GetNow";

	public static string GetURL()
	{
		return "ui://kt6rg65ovha9v9b";
	}

	public static UI_GetNow CreateInstance()
	{
		return (UI_GetNow)(object)UIPackage.CreateObject("PublicResources", "GetNow");
	}

	public static UI_GetNow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GetNow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovha9v9b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
