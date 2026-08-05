using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorkShop;

public class UI_btn_ItemSort : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n6;

	public GImage n3;

	public GTextField n4;

	public GImage n5;

	public const string URL = "ui://k6y9jq3aa9te3n";

	public static string Name = "UI_btn_ItemSort";

	public static string GetURL()
	{
		return "ui://k6y9jq3aa9te3n";
	}

	public static UI_btn_ItemSort CreateInstance()
	{
		return (UI_btn_ItemSort)(object)UIPackage.CreateObject("WorkShop", "btn_ItemSort");
	}

	public static UI_btn_ItemSort CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ItemSort).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k6y9jq3aa9te3n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://k6y9jq3aa9te3n".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
