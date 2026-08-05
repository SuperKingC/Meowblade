using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_StrongholdGain : GButton
{
	public GLoader FrameLoader;

	public GLoader IconLoader;

	public GTextField description;

	public GTextField Amount;

	public GButton itemBtn;

	public GButton ExclamationMarkBtn;

	public const string URL = "ui://twlbabicuv96t";

	public static string Name = "UI_StrongholdGain";

	public static string GetURL()
	{
		return "ui://twlbabicuv96t";
	}

	public static UI_StrongholdGain CreateInstance()
	{
		return (UI_StrongholdGain)(object)UIPackage.CreateObject("Battle", "StrongholdGain");
	}

	public static UI_StrongholdGain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StrongholdGain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicuv96t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		description = (GTextField)((GComponent)this).GetChild("description");
		string id = "ui://twlbabicuv96t".Replace("ui://", "") + "-" + ((GObject)description).id;
		((GObject)description).text = LanguagesManager.GetDesc(id);
		Amount = (GTextField)((GComponent)this).GetChild("Amount");
		string id2 = "ui://twlbabicuv96t".Replace("ui://", "") + "-" + ((GObject)Amount).id;
		((GObject)Amount).text = LanguagesManager.GetDesc(id2);
		itemBtn = (GButton)((GComponent)this).GetChild("itemBtn");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
	}
}
