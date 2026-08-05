using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ChangeTroops : GButton
{
	public Controller button;

	public Controller Type;

	public GTextField n3;

	public GImage n5;

	public const string URL = "ui://k2sprg26in7b2v";

	public static string Name = "UI_ChangeTroops";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b2v";
	}

	public static UI_ChangeTroops CreateInstance()
	{
		return (UI_ChangeTroops)(object)UIPackage.CreateObject("IslandComeAgain", "ChangeTroops");
	}

	public static UI_ChangeTroops CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangeTroops).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b2v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://k2sprg26in7b2v".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
