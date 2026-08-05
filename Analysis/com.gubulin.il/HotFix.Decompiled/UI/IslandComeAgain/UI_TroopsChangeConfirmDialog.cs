using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_TroopsChangeConfirmDialog : GComponent
{
	public GImage back;

	public GTextField n14;

	public UI_TroopsChangeSketchMap OldGroupInfo;

	public UI_TroopsChangeSketchMap CurrentGroupInfo;

	public GButton Close;

	public UI_ConfirmTroopsChange Confirm;

	public GImage n13;

	public GTextField n15;

	public const string URL = "ui://k2sprg26fuww8u";

	public static string Name = "UI_TroopsChangeConfirmDialog";

	public static string GetURL()
	{
		return "ui://k2sprg26fuww8u";
	}

	public static UI_TroopsChangeConfirmDialog CreateInstance()
	{
		return (UI_TroopsChangeConfirmDialog)(object)UIPackage.CreateObject("IslandComeAgain", "TroopsChangeConfirmDialog");
	}

	public static UI_TroopsChangeConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TroopsChangeConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26fuww8u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://k2sprg26fuww8u".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		OldGroupInfo = (UI_TroopsChangeSketchMap)(object)((GComponent)this).GetChild("OldGroupInfo");
		CurrentGroupInfo = (UI_TroopsChangeSketchMap)(object)((GComponent)this).GetChild("CurrentGroupInfo");
		Close = (GButton)((GComponent)this).GetChild("Close");
		Confirm = (UI_ConfirmTroopsChange)(object)((GComponent)this).GetChild("Confirm");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id2 = "ui://k2sprg26fuww8u".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id2);
	}
}
