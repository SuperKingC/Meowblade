using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoulKeyStore;

public class UI_CutTab : GComponent
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://3nd2hqkivzbkb";

	public static string Name = "UI_CutTab";

	public static string GetURL()
	{
		return "ui://3nd2hqkivzbkb";
	}

	public static UI_CutTab CreateInstance()
	{
		return (UI_CutTab)(object)UIPackage.CreateObject("SoulKeyStore", "CutTab");
	}

	public static UI_CutTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CutTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbkb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
