using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItems;

public class UI_BlueprintSplit : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n5;

	public GImage n4;

	public const string URL = "ui://l6qef30p99khp";

	public static string Name = "UI_BlueprintSplit";

	public static string GetURL()
	{
		return "ui://l6qef30p99khp";
	}

	public static UI_BlueprintSplit CreateInstance()
	{
		return (UI_BlueprintSplit)(object)UIPackage.CreateObject("LegendItems", "BlueprintSplit");
	}

	public static UI_BlueprintSplit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BlueprintSplit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30p99khp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
