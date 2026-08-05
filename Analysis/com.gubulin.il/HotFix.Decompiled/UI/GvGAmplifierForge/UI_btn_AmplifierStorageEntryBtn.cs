using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_btn_AmplifierStorageEntryBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n4;

	public const string URL = "ui://fpjheycbhgiki";

	public static string Name = "UI_btn_AmplifierStorageEntryBtn";

	public static string GetURL()
	{
		return "ui://fpjheycbhgiki";
	}

	public static UI_btn_AmplifierStorageEntryBtn CreateInstance()
	{
		return (UI_btn_AmplifierStorageEntryBtn)(object)UIPackage.CreateObject("GvGAmplifierForge", "btn_AmplifierStorageEntryBtn");
	}

	public static UI_btn_AmplifierStorageEntryBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AmplifierStorageEntryBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbhgiki", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://fpjheycbhgiki".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}
