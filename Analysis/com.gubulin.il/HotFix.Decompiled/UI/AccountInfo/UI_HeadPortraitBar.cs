using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_HeadPortraitBar : GComponent
{
	public Controller Type;

	public GGraph mask;

	public GImage iconBack;

	public GLoader icon;

	public const string URL = "ui://b9yxt7u0k3894t";

	public static string Name = "UI_HeadPortraitBar";

	public static string GetURL()
	{
		return "ui://b9yxt7u0k3894t";
	}

	public static UI_HeadPortraitBar CreateInstance()
	{
		return (UI_HeadPortraitBar)(object)UIPackage.CreateObject("AccountInfo", "HeadPortraitBar");
	}

	public static UI_HeadPortraitBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HeadPortraitBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0k3894t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
