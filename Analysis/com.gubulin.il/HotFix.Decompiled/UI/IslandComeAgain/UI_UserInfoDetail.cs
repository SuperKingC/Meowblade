using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_UserInfoDetail : GComponent
{
	public Controller Type;

	public GImage n4;

	public GTextField n1;

	public GImage n2;

	public GImage n3;

	public const string URL = "ui://k2sprg26in7b2g";

	public static string Name = "UI_UserInfoDetail";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b2g";
	}

	public static UI_UserInfoDetail CreateInstance()
	{
		return (UI_UserInfoDetail)(object)UIPackage.CreateObject("IslandComeAgain", "UserInfoDetail");
	}

	public static UI_UserInfoDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserInfoDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b2g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://k2sprg26in7b2g".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
