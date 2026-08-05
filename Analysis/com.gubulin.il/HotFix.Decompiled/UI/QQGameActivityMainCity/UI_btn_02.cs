using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivityMainCity;

public class UI_btn_02 : GButton
{
	public GTextField n3;

	public GGraph n5;

	public const string URL = "ui://z947bpf8rbbwv45x";

	public static string Name = "UI_btn_02";

	public static string GetURL()
	{
		return "ui://z947bpf8rbbwv45x";
	}

	public static UI_btn_02 CreateInstance()
	{
		return (UI_btn_02)(object)UIPackage.CreateObject("QQGameActivityMainCity", "btn_02");
	}

	public static UI_btn_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8rbbwv45x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://z947bpf8rbbwv45x".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n5 = (GGraph)((GComponent)this).GetChild("n5");
	}
}
