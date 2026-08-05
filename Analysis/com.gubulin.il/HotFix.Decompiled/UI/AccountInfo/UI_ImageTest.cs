using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ImageTest : GComponent
{
	public Controller isShowIcon;

	public GGraph mask;

	public GLoader icon;

	public const string URL = "ui://b9yxt7u0py323a";

	public static string Name = "UI_ImageTest";

	public static string GetURL()
	{
		return "ui://b9yxt7u0py323a";
	}

	public static UI_ImageTest CreateInstance()
	{
		return (UI_ImageTest)(object)UIPackage.CreateObject("AccountInfo", "ImageTest");
	}

	public static UI_ImageTest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ImageTest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0py323a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isShowIcon = ((GComponent)this).GetController("isShowIcon");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
