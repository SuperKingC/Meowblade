using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_LeftContent : GComponent
{
	public GLoader backImage;

	public UI_legionScale legionScale;

	public UI_manorScale manorScale;

	public UI_pyx pyx;

	public UI_dungeonScale dungeonScale;

	public UI_treasure treasure;

	public UI_devilGrade devilGrade;

	public const string URL = "ui://zko5n3velkzg2";

	public static string Name = "UI_LeftContent";

	public static string GetURL()
	{
		return "ui://zko5n3velkzg2";
	}

	public static UI_LeftContent CreateInstance()
	{
		return (UI_LeftContent)(object)UIPackage.CreateObject("PrinceOfTheDevils", "LeftContent");
	}

	public static UI_LeftContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LeftContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3velkzg2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		backImage = (GLoader)((GComponent)this).GetChild("backImage");
		legionScale = (UI_legionScale)(object)((GComponent)this).GetChild("legionScale");
		manorScale = (UI_manorScale)(object)((GComponent)this).GetChild("manorScale");
		pyx = (UI_pyx)(object)((GComponent)this).GetChild("pyx");
		dungeonScale = (UI_dungeonScale)(object)((GComponent)this).GetChild("dungeonScale");
		treasure = (UI_treasure)(object)((GComponent)this).GetChild("treasure");
		devilGrade = (UI_devilGrade)(object)((GComponent)this).GetChild("devilGrade");
	}
}
