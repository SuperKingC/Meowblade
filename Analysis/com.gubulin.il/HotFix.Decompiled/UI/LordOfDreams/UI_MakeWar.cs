using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_MakeWar : GButton
{
	public Controller button;

	public GImage n13;

	public GImage n9;

	public const string URL = "ui://0i520nzmtlapo7b";

	public static string Name = "UI_MakeWar";

	public static string GetURL()
	{
		return "ui://0i520nzmtlapo7b";
	}

	public static UI_MakeWar CreateInstance()
	{
		return (UI_MakeWar)(object)UIPackage.CreateObject("LordOfDreams", "MakeWar");
	}

	public static UI_MakeWar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MakeWar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtlapo7b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
