using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_switchAccountBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GTextField n4;

	public const string URL = "ui://yb3s7uv7bw1c28";

	public static string Name = "UI_switchAccountBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7bw1c28";
	}

	public static UI_switchAccountBtn CreateInstance()
	{
		return (UI_switchAccountBtn)(object)UIPackage.CreateObject("LoginAndName", "switchAccountBtn");
	}

	public static UI_switchAccountBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_switchAccountBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7bw1c28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://yb3s7uv7bw1c28".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}
