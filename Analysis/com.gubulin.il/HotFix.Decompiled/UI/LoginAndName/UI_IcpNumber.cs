using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_IcpNumber : GButton
{
	public Controller layout;

	public GTextField n1;

	public GTextField n2;

	public GTextField IcpHomeUrl;

	public GTextField CopyRightInfo;

	public const string URL = "ui://yb3s7uv7b1ou5w";

	public static string Name = "UI_IcpNumber";

	public static string GetURL()
	{
		return "ui://yb3s7uv7b1ou5w";
	}

	public static UI_IcpNumber CreateInstance()
	{
		return (UI_IcpNumber)(object)UIPackage.CreateObject("LoginAndName", "IcpNumber");
	}

	public static UI_IcpNumber CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IcpNumber).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7b1ou5w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		layout = ((GComponent)this).GetController("layout");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://yb3s7uv7b1ou5w".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://yb3s7uv7b1ou5w".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		IcpHomeUrl = (GTextField)((GComponent)this).GetChild("IcpHomeUrl");
		CopyRightInfo = (GTextField)((GComponent)this).GetChild("CopyRightInfo");
		string id3 = "ui://yb3s7uv7b1ou5w".Replace("ui://", "") + "-" + ((GObject)CopyRightInfo).id;
		((GObject)CopyRightInfo).text = LanguagesManager.GetDesc(id3);
	}
}
