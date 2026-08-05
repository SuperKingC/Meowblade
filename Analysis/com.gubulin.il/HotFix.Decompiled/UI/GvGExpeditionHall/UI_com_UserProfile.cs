using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_UserProfile : GComponent
{
	public GImage n3;

	public GImage n5;

	public GImage n6;

	public GImage n14;

	public GImage n12;

	public GImage n11;

	public GList Medals;

	public GTextField PlayerName;

	public GComponent Avatar;

	public GImage n15;

	public const string URL = "ui://k19peou7123e6p7i";

	public static string Name = "UI_com_UserProfile";

	public static string GetURL()
	{
		return "ui://k19peou7123e6p7i";
	}

	public static UI_com_UserProfile CreateInstance()
	{
		return (UI_com_UserProfile)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_UserProfile");
	}

	public static UI_com_UserProfile CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UserProfile).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7123e6p7i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		Medals = (GList)((GComponent)this).GetChild("Medals");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		Avatar = (GComponent)((GComponent)this).GetChild("Avatar");
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}
