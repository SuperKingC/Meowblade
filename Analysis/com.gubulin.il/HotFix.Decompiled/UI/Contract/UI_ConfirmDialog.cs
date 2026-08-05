using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ConfirmDialog : GComponent
{
	public GImage back;

	public GGraph SpineBack;

	public GImage n30;

	public GImage n31;

	public GTextField Content;

	public GGroup n33;

	public GButton receiveBtn;

	public UI_TakeItemContent Item;

	public const string URL = "ui://avplaivdxbr9t5h";

	public static string Name = "UI_ConfirmDialog";

	public static string GetURL()
	{
		return "ui://avplaivdxbr9t5h";
	}

	public static UI_ConfirmDialog CreateInstance()
	{
		return (UI_ConfirmDialog)(object)UIPackage.CreateObject("Contract", "ConfirmDialog");
	}

	public static UI_ConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdxbr9t5h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		Content = (GTextField)((GComponent)this).GetChild("Content");
		string id = "ui://avplaivdxbr9t5h".Replace("ui://", "") + "-" + ((GObject)Content).id;
		((GObject)Content).text = LanguagesManager.GetDesc(id);
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		receiveBtn = (GButton)((GComponent)this).GetChild("receiveBtn");
		Item = (UI_TakeItemContent)(object)((GComponent)this).GetChild("Item");
	}
}
