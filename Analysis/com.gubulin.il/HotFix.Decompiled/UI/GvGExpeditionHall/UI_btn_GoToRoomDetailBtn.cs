using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_GoToRoomDetailBtn : GButton
{
	public GGraph n142;

	public GTextField n140;

	public GImage n141;

	public const string URL = "ui://k19peou7sz5k1v";

	public static string Name = "UI_btn_GoToRoomDetailBtn";

	public static string GetURL()
	{
		return "ui://k19peou7sz5k1v";
	}

	public static UI_btn_GoToRoomDetailBtn CreateInstance()
	{
		return (UI_btn_GoToRoomDetailBtn)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_GoToRoomDetailBtn");
	}

	public static UI_btn_GoToRoomDetailBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GoToRoomDetailBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7sz5k1v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n142 = (GGraph)((GComponent)this).GetChild("n142");
		n140 = (GTextField)((GComponent)this).GetChild("n140");
		string id = "ui://k19peou7sz5k1v".Replace("ui://", "") + "-" + ((GObject)n140).id;
		((GObject)n140).text = LanguagesManager.GetDesc(id);
		n141 = (GImage)((GComponent)this).GetChild("n141");
	}
}
