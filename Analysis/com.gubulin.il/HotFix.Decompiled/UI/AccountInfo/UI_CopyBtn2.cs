using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_CopyBtn2 : GButton
{
	public Controller button;

	public GImage n0;

	public GLoader n1;

	public const string URL = "ui://b9yxt7u0h9f86c";

	public static string Name = "UI_CopyBtn2";

	public static string GetURL()
	{
		return "ui://b9yxt7u0h9f86c";
	}

	public static UI_CopyBtn2 CreateInstance()
	{
		return (UI_CopyBtn2)(object)UIPackage.CreateObject("AccountInfo", "CopyBtn2");
	}

	public static UI_CopyBtn2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CopyBtn2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0h9f86c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
	}
}
