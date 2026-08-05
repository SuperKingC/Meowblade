using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivityMainCity;

public class UI_QQGameBigPlayerBtn : GComponent
{
	public GImage n1;

	public GImage red;

	public const string URL = "ui://z947bpf8mzr9v45r";

	public static string Name = "UI_QQGameBigPlayerBtn";

	public static string GetURL()
	{
		return "ui://z947bpf8mzr9v45r";
	}

	public static UI_QQGameBigPlayerBtn CreateInstance()
	{
		return (UI_QQGameBigPlayerBtn)(object)UIPackage.CreateObject("QQGameActivityMainCity", "QQGameBigPlayerBtn");
	}

	public static UI_QQGameBigPlayerBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QQGameBigPlayerBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8mzr9v45r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		red = (GImage)((GComponent)this).GetChild("red");
	}
}
