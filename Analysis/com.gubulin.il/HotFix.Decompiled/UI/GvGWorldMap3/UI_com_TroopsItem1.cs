using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_TroopsItem1 : GComponent
{
	public Controller Type;

	public GImage n3;

	public UI_com_TroopItemContent FrameLoader;

	public const string URL = "ui://4eq8fgd2ds7l6z";

	public static string Name = "UI_com_TroopsItem1";

	public static string GetURL()
	{
		return "ui://4eq8fgd2ds7l6z";
	}

	public static UI_com_TroopsItem1 CreateInstance()
	{
		return (UI_com_TroopsItem1)(object)UIPackage.CreateObject("GvGWorldMap3", "com_TroopsItem1");
	}

	public static UI_com_TroopsItem1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TroopsItem1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ds7l6z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		FrameLoader = (UI_com_TroopItemContent)(object)((GComponent)this).GetChild("FrameLoader");
	}
}
