using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Bubble02 : GComponent
{
	public GImage n11;

	public GTextField n12;

	public GTextField n13;

	public const string URL = "ui://k2sprg26laau6k";

	public static string Name = "UI_mc_Bubble02";

	public static string GetURL()
	{
		return "ui://k2sprg26laau6k";
	}

	public static UI_mc_Bubble02 CreateInstance()
	{
		return (UI_mc_Bubble02)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Bubble02");
	}

	public static UI_mc_Bubble02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Bubble02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau6k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id = "ui://k2sprg26laau6k".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id2 = "ui://k2sprg26laau6k".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id2);
	}
}
