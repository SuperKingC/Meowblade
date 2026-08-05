using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_CheckAbility : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n9;

	public GTextField n3;

	public GImage n5;

	public GImage n8;

	public GList Abilities;

	public GTextField n6;

	public GGroup n7;

	public GImage n10;

	public const string URL = "ui://b3fc6085stwv1d";

	public static string Name = "UI_btn_CheckAbility";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv1d";
	}

	public static UI_btn_CheckAbility CreateInstance()
	{
		return (UI_btn_CheckAbility)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_CheckAbility");
	}

	public static UI_btn_CheckAbility CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CheckAbility).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://b3fc6085stwv1d".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		Abilities = (GList)((GComponent)this).GetChild("Abilities");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://b3fc6085stwv1d".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		n7 = (GGroup)((GComponent)this).GetChild("n7");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
