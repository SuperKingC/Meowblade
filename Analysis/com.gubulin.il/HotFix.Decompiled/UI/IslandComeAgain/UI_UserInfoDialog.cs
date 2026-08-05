using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_UserInfoDialog : GComponent
{
	public GGraph n0;

	public GGraph n2;

	public GList UserInfo;

	public GTextField n3;

	public GTextField n4;

	public GTextField n5;

	public const string URL = "ui://k2sprg26in7b27";

	public static string Name = "UI_UserInfoDialog";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b27";
	}

	public static UI_UserInfoDialog CreateInstance()
	{
		return (UI_UserInfoDialog)(object)UIPackage.CreateObject("IslandComeAgain", "UserInfoDialog");
	}

	public static UI_UserInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b27", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		UserInfo = (GList)((GComponent)this).GetChild("UserInfo");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://k2sprg26in7b27".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://k2sprg26in7b27".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id3 = "ui://k2sprg26in7b27".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id3);
	}
}
