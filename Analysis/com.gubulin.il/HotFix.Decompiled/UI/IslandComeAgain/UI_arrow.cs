using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_arrow : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://k2sprg26in7b36";

	public static string Name = "UI_arrow";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b36";
	}

	public static UI_arrow CreateInstance()
	{
		return (UI_arrow)(object)UIPackage.CreateObject("IslandComeAgain", "arrow");
	}

	public static UI_arrow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_arrow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b36", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
