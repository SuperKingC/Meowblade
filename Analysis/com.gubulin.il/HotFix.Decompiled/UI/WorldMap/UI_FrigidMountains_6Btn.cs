using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_FrigidMountains_6Btn : GButton
{
	public Controller button;

	public UI_segment line;

	public GImage icon;

	public const string URL = "ui://c9n2h0ksm7wz81";

	public static string Name = "UI_FrigidMountains_6Btn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz81";
	}

	public static UI_FrigidMountains_6Btn CreateInstance()
	{
		return (UI_FrigidMountains_6Btn)(object)UIPackage.CreateObject("WorldMap", "FrigidMountains_6Btn");
	}

	public static UI_FrigidMountains_6Btn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FrigidMountains_6Btn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz81", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		line = (UI_segment)(object)((GComponent)this).GetChild("line");
		icon = (GImage)((GComponent)this).GetChild("icon");
	}
}
