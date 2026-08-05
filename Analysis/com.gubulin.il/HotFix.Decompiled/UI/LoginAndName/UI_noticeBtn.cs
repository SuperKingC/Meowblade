using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_noticeBtn : GButton
{
	public Controller button;

	public GImage n5;

	public GImage n6;

	public GImage n7;

	public GTextField n4;

	public const string URL = "ui://yb3s7uv7bw1c27";

	public static string Name = "UI_noticeBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7bw1c27";
	}

	public static UI_noticeBtn CreateInstance()
	{
		return (UI_noticeBtn)(object)UIPackage.CreateObject("LoginAndName", "noticeBtn");
	}

	public static UI_noticeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_noticeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7bw1c27", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://yb3s7uv7bw1c27".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}
