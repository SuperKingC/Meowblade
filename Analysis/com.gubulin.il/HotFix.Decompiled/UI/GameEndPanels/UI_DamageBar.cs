using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_DamageBar : GProgressBar
{
	public Controller status;

	public GImage bar;

	public GImage logo;

	public const string URL = "ui://hda5vzklrjqw3k";

	public static string Name = "UI_DamageBar";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3k";
	}

	public static UI_DamageBar CreateInstance()
	{
		return (UI_DamageBar)(object)UIPackage.CreateObject("GameEndPanels", "DamageBar");
	}

	public static UI_DamageBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DamageBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		status = ((GComponent)this).GetController("status");
		bar = (GImage)((GComponent)this).GetChild("bar");
		logo = (GImage)((GComponent)this).GetChild("logo");
	}
}
