using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Medal;

public class UI_com_MedalSmall : GComponent
{
	public Controller Type;

	public GImage n3;

	public GImage n4;

	public GLoader MedalIcon;

	public GTextField MedalLevel;

	public const string URL = "ui://g5hi1peosxgwu";

	public static string Name = "UI_com_MedalSmall";

	public static string GetURL()
	{
		return "ui://g5hi1peosxgwu";
	}

	public static UI_com_MedalSmall CreateInstance()
	{
		return (UI_com_MedalSmall)(object)UIPackage.CreateObject("GvG3Medal", "com_MedalSmall");
	}

	public static UI_com_MedalSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MedalSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		MedalIcon = (GLoader)((GComponent)this).GetChild("MedalIcon");
		MedalLevel = (GTextField)((GComponent)this).GetChild("MedalLevel");
	}
}
