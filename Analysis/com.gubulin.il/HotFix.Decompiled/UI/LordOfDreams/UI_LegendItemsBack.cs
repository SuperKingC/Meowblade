using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_LegendItemsBack : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n1;

	public const string URL = "ui://0i520nzmtlapo7s";

	public static string Name = "UI_LegendItemsBack";

	public static string GetURL()
	{
		return "ui://0i520nzmtlapo7s";
	}

	public static UI_LegendItemsBack CreateInstance()
	{
		return (UI_LegendItemsBack)(object)UIPackage.CreateObject("LordOfDreams", "LegendItemsBack");
	}

	public static UI_LegendItemsBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemsBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtlapo7s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
