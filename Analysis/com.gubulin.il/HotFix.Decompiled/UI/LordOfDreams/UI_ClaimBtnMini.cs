using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ClaimBtnMini : GButton
{
	public Controller button;

	public GImage n9;

	public GTextField title;

	public const string URL = "ui://0i520nzme91so94";

	public static string Name = "UI_ClaimBtnMini";

	public static string GetURL()
	{
		return "ui://0i520nzme91so94";
	}

	public static UI_ClaimBtnMini CreateInstance()
	{
		return (UI_ClaimBtnMini)(object)UIPackage.CreateObject("LordOfDreams", "ClaimBtnMini");
	}

	public static UI_ClaimBtnMini CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClaimBtnMini).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzme91so94", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://0i520nzme91so94".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
