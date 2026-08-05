using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_CommonLoginTypeBtn : GButton
{
	public Controller button;

	public GLoader BtnLoader;

	public const string URL = "ui://47lbpgx9kcpqtbc";

	public static string Name = "UI_CommonLoginTypeBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9kcpqtbc";
	}

	public static UI_CommonLoginTypeBtn CreateInstance()
	{
		return (UI_CommonLoginTypeBtn)(object)UIPackage.CreateObject("Tips", "CommonLoginTypeBtn");
	}

	public static UI_CommonLoginTypeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CommonLoginTypeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9kcpqtbc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		BtnLoader = (GLoader)((GComponent)this).GetChild("BtnLoader");
	}
}
