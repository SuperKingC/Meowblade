using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_ProfileDisplayAmpLeft : GComponent
{
	public Controller Style;

	public Controller TxtChange;

	public GList Medals;

	public UI_com_ShipAvatar Avatar;

	public GTextField PlayerName;

	public GTextField n3;

	public GGroup n4;

	public const string URL = "ui://kt6rg65oigs2v4nz";

	public static string Name = "UI_com_ProfileDisplayAmpLeft";

	public static string GetURL()
	{
		return "ui://kt6rg65oigs2v4nz";
	}

	public static UI_com_ProfileDisplayAmpLeft CreateInstance()
	{
		return (UI_com_ProfileDisplayAmpLeft)(object)UIPackage.CreateObject("PublicResources", "com_ProfileDisplayAmpLeft");
	}

	public static UI_com_ProfileDisplayAmpLeft CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProfileDisplayAmpLeft).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oigs2v4nz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Style = ((GComponent)this).GetController("Style");
		TxtChange = ((GComponent)this).GetController("TxtChange");
		Medals = (GList)((GComponent)this).GetChild("Medals");
		Avatar = (UI_com_ShipAvatar)(object)((GComponent)this).GetChild("Avatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://kt6rg65oigs2v4nz".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GGroup)((GComponent)this).GetChild("n4");
	}
}
