using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_btn_AmplifierWrapper : GButton
{
	public Controller button;

	public UI_com_AmplifierSlot AmplifierItem;

	public const string URL = "ui://800w3r8rq2d9l";

	public static string Name = "UI_btn_AmplifierWrapper";

	public static string GetURL()
	{
		return "ui://800w3r8rq2d9l";
	}

	public static UI_btn_AmplifierWrapper CreateInstance()
	{
		return (UI_btn_AmplifierWrapper)(object)UIPackage.CreateObject("UseItemResult", "btn_AmplifierWrapper");
	}

	public static UI_btn_AmplifierWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AmplifierWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rq2d9l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		AmplifierItem = (UI_com_AmplifierSlot)(object)((GComponent)this).GetChild("AmplifierItem");
	}
}
