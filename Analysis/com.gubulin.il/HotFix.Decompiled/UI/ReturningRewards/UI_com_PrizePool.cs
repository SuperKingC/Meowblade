using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_PrizePool : GComponent
{
	public Controller IsLongPress;

	public GList Prizes;

	public UI_com_Circle Circle;

	public const string URL = "ui://rx5ntv988vxl1f";

	public static string Name = "UI_com_PrizePool";

	public static string GetURL()
	{
		return "ui://rx5ntv988vxl1f";
	}

	public static UI_com_PrizePool CreateInstance()
	{
		return (UI_com_PrizePool)(object)UIPackage.CreateObject("ReturningRewards", "com_PrizePool");
	}

	public static UI_com_PrizePool CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PrizePool).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv988vxl1f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsLongPress = ((GComponent)this).GetController("IsLongPress");
		Prizes = (GList)((GComponent)this).GetChild("Prizes");
		Circle = (UI_com_Circle)(object)((GComponent)this).GetChild("Circle");
	}
}
