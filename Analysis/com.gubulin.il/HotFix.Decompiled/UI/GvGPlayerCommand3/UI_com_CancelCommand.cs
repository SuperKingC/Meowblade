using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_com_CancelCommand : GComponent
{
	public Controller Type;

	public GImage Background;

	public GTextField n1;

	public GImage n2;

	public UI_com_CommandIcon CurrentCommand;

	public GTextField CommandDetail;

	public GTextField Countdown;

	public GTextField n7;

	public GTextField n8;

	public UI_btn_CancelCommand Cancel;

	public const string URL = "ui://vheg8vabeai32";

	public static string Name = "UI_com_CancelCommand";

	public static string GetURL()
	{
		return "ui://vheg8vabeai32";
	}

	public static UI_com_CancelCommand CreateInstance()
	{
		return (UI_com_CancelCommand)(object)UIPackage.CreateObject("GvGPlayerCommand3", "com_CancelCommand");
	}

	public static UI_com_CancelCommand CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CancelCommand).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://vheg8vabeai32".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		CurrentCommand = (UI_com_CommandIcon)(object)((GComponent)this).GetChild("CurrentCommand");
		CommandDetail = (GTextField)((GComponent)this).GetChild("CommandDetail");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://vheg8vabeai32".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id3 = "ui://vheg8vabeai32".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id3);
		Cancel = (UI_btn_CancelCommand)(object)((GComponent)this).GetChild("Cancel");
	}
}
