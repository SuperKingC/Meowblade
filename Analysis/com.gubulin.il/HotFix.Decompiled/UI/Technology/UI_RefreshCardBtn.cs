using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_RefreshCardBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://7ca77a3fnwky3i";

	public static string Name = "UI_RefreshCardBtn";

	public static string GetURL()
	{
		return "ui://7ca77a3fnwky3i";
	}

	public static UI_RefreshCardBtn CreateInstance()
	{
		return (UI_RefreshCardBtn)(object)UIPackage.CreateObject("Technology", "RefreshCardBtn");
	}

	public static UI_RefreshCardBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RefreshCardBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fnwky3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
