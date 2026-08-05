using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_AgreementBtn : GButton
{
	public Controller button;

	public GTextField n3;

	public const string URL = "ui://yb3s7uv7ithf2v";

	public static string Name = "UI_AgreementBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7ithf2v";
	}

	public static UI_AgreementBtn CreateInstance()
	{
		return (UI_AgreementBtn)(object)UIPackage.CreateObject("LoginAndName", "AgreementBtn");
	}

	public static UI_AgreementBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AgreementBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ithf2v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://yb3s7uv7ithf2v".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
	}
}
