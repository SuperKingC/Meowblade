using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_RookieDrawCard : GComponent
{
	public Controller Type;

	public Controller State;

	public GImage back;

	public UI_RookieSoldierLoader NewSoldier;

	public GList SoulStoneList;

	public GButton FreeToReceive;

	public GGraph SfxBack;

	public const string URL = "ui://avplaivdnle7tkm";

	public static string Name = "UI_RookieDrawCard";

	public static string GetURL()
	{
		return "ui://avplaivdnle7tkm";
	}

	public static UI_RookieDrawCard CreateInstance()
	{
		return (UI_RookieDrawCard)(object)UIPackage.CreateObject("Contract", "RookieDrawCard");
	}

	public static UI_RookieDrawCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RookieDrawCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnle7tkm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		back = (GImage)((GComponent)this).GetChild("back");
		NewSoldier = (UI_RookieSoldierLoader)(object)((GComponent)this).GetChild("NewSoldier");
		SoulStoneList = (GList)((GComponent)this).GetChild("SoulStoneList");
		FreeToReceive = (GButton)((GComponent)this).GetChild("FreeToReceive");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
