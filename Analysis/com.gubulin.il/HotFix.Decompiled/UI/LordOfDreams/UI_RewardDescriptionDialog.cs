using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_RewardDescriptionDialog : GComponent
{
	public GImage n4;

	public GTextField n2;

	public GTextField n3;

	public GTextField n5;

	public const string URL = "ui://0i520nzmcoc4oe2";

	public static string Name = "UI_RewardDescriptionDialog";

	public static string GetURL()
	{
		return "ui://0i520nzmcoc4oe2";
	}

	public static UI_RewardDescriptionDialog CreateInstance()
	{
		return (UI_RewardDescriptionDialog)(object)UIPackage.CreateObject("LordOfDreams", "RewardDescriptionDialog");
	}

	public static UI_RewardDescriptionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RewardDescriptionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmcoc4oe2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://0i520nzmcoc4oe2".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://0i520nzmcoc4oe2".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id3 = "ui://0i520nzmcoc4oe2".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id3);
	}
}
