using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BattlefieldAnimWrapper : GComponent
{
	public UI_BattlefieldScreenAdaptWrapper BattlefieldScreenAdaptWrapper;

	public const string URL = "ui://0i520nzm121eo58";

	public static string Name = "UI_BattlefieldAnimWrapper";

	public static string GetURL()
	{
		return "ui://0i520nzm121eo58";
	}

	public static UI_BattlefieldAnimWrapper CreateInstance()
	{
		return (UI_BattlefieldAnimWrapper)(object)UIPackage.CreateObject("LordOfDreams", "BattlefieldAnimWrapper");
	}

	public static UI_BattlefieldAnimWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BattlefieldAnimWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm121eo58", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		BattlefieldScreenAdaptWrapper = (UI_BattlefieldScreenAdaptWrapper)(object)((GComponent)this).GetChild("BattlefieldScreenAdaptWrapper");
	}
}
