using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_com_PvPEntranceDialog : GComponent
{
	public GImage n0;

	public UI_exitBtn Close;

	public GImage n4;

	public GTextField n2;

	public GTextField n3;

	public GImage n10;

	public GImage n7;

	public GImage n6;

	public GImage n8;

	public GImage n9;

	public Transition t1;

	public const string URL = "ui://47lbpgx9pbvcj5ltfs";

	public static string Name = "UI_com_PvPEntranceDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9pbvcj5ltfs";
	}

	public static UI_com_PvPEntranceDialog CreateInstance()
	{
		return (UI_com_PvPEntranceDialog)(object)UIPackage.CreateObject("Tips", "com_PvPEntranceDialog");
	}

	public static UI_com_PvPEntranceDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PvPEntranceDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9pbvcj5ltfs", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Close = (UI_exitBtn)(object)((GComponent)this).GetChild("Close");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://47lbpgx9pbvcj5ltfs".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://47lbpgx9pbvcj5ltfs".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
