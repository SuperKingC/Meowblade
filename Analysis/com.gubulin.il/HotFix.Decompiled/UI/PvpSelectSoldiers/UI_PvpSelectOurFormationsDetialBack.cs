using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PvpSelectOurFormationsDetialBack : GComponent
{
	public GImage n14;

	public GImage n13;

	public GTextField n15;

	public const string URL = "ui://82mo10n5uk8wbc";

	public static string Name = "UI_PvpSelectOurFormationsDetialBack";

	public static string GetURL()
	{
		return "ui://82mo10n5uk8wbc";
	}

	public static UI_PvpSelectOurFormationsDetialBack CreateInstance()
	{
		return (UI_PvpSelectOurFormationsDetialBack)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpSelectOurFormationsDetialBack");
	}

	public static UI_PvpSelectOurFormationsDetialBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpSelectOurFormationsDetialBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5uk8wbc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://82mo10n5uk8wbc".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
	}
}
