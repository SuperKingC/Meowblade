using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_CantRemoveTip : GComponent
{
	public Controller Type;

	public GImage n165;

	public GTextField n167;

	public GTextField n171;

	public GTextField n170;

	public GTextField n172;

	public const string URL = "ui://7ymaonxtc69m51";

	public static string Name = "UI_CantRemoveTip";

	public static string GetURL()
	{
		return "ui://7ymaonxtc69m51";
	}

	public static UI_CantRemoveTip CreateInstance()
	{
		return (UI_CantRemoveTip)(object)UIPackage.CreateObject("GvGShipOverview", "CantRemoveTip");
	}

	public static UI_CantRemoveTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CantRemoveTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtc69m51", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n165 = (GImage)((GComponent)this).GetChild("n165");
		n167 = (GTextField)((GComponent)this).GetChild("n167");
		string id = "ui://7ymaonxtc69m51".Replace("ui://", "") + "-" + ((GObject)n167).id;
		((GObject)n167).text = LanguagesManager.GetDesc(id);
		n171 = (GTextField)((GComponent)this).GetChild("n171");
		string id2 = "ui://7ymaonxtc69m51".Replace("ui://", "") + "-" + ((GObject)n171).id;
		((GObject)n171).text = LanguagesManager.GetDesc(id2);
		n170 = (GTextField)((GComponent)this).GetChild("n170");
		string id3 = "ui://7ymaonxtc69m51".Replace("ui://", "") + "-" + ((GObject)n170).id;
		((GObject)n170).text = LanguagesManager.GetDesc(id3);
		n172 = (GTextField)((GComponent)this).GetChild("n172");
		string id4 = "ui://7ymaonxtc69m51".Replace("ui://", "") + "-" + ((GObject)n172).id;
		((GObject)n172).text = LanguagesManager.GetDesc(id4);
	}
}
