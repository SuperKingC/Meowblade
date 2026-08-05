using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_IslandComeAgainPanel : GComponent
{
	public GImage n26;

	public UI_EnterGVG EnterGVGBtn;

	public GGraph n27;

	public GTextField Time;

	public const string URL = "ui://kozswd8hp1ftf2n";

	public static string Name = "UI_IslandComeAgainPanel";

	public static string GetURL()
	{
		return "ui://kozswd8hp1ftf2n";
	}

	public static UI_IslandComeAgainPanel CreateInstance()
	{
		return (UI_IslandComeAgainPanel)(object)UIPackage.CreateObject("SpecialActivity", "IslandComeAgainPanel");
	}

	public static UI_IslandComeAgainPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandComeAgainPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hp1ftf2n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n26 = (GImage)((GComponent)this).GetChild("n26");
		EnterGVGBtn = (UI_EnterGVG)(object)((GComponent)this).GetChild("EnterGVGBtn");
		n27 = (GGraph)((GComponent)this).GetChild("n27");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id = "ui://kozswd8hp1ftf2n".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id);
	}
}
