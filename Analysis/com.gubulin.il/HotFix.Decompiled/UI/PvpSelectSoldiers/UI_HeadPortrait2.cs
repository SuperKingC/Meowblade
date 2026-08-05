using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_HeadPortrait2 : GComponent
{
	public Controller Type;

	public GGraph Mask;

	public GLoader PlayerIcon;

	public const string URL = "ui://82mo10n5exsyjdqt";

	public static string Name = "UI_HeadPortrait2";

	public static string GetURL()
	{
		return "ui://82mo10n5exsyjdqt";
	}

	public static UI_HeadPortrait2 CreateInstance()
	{
		return (UI_HeadPortrait2)(object)UIPackage.CreateObject("PvpSelectSoldiers", "HeadPortrait2");
	}

	public static UI_HeadPortrait2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HeadPortrait2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5exsyjdqt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PlayerIcon = (GLoader)((GComponent)this).GetChild("PlayerIcon");
	}
}
