using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_com_FirstShipIntroDialog : GComponent
{
	public Controller HasEnterIZ;

	public GImage tipBack;

	public GImage n57;

	public GGraph SpineLoader;

	public GImage n48;

	public GTextField ShipName;

	public UI_com_ChangeNameBtn ChangeNameBtn;

	public GGroup NameTitleGroup;

	public UI_com_DestroyShipBtn DestroyShipBtn;

	public GTextField n56;

	public GTextField n58;

	public GTextField n59;

	public GTextField n60;

	public GGroup n61;

	public const string URL = "ui://pwrbvhpvazac6p";

	public static string Name = "UI_com_FirstShipIntroDialog";

	public static string GetURL()
	{
		return "ui://pwrbvhpvazac6p";
	}

	public static UI_com_FirstShipIntroDialog CreateInstance()
	{
		return (UI_com_FirstShipIntroDialog)(object)UIPackage.CreateObject("GvGShipPopup", "com_FirstShipIntroDialog");
	}

	public static UI_com_FirstShipIntroDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FirstShipIntroDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvazac6p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasEnterIZ = ((GComponent)this).GetController("HasEnterIZ");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		ChangeNameBtn = (UI_com_ChangeNameBtn)(object)((GComponent)this).GetChild("ChangeNameBtn");
		NameTitleGroup = (GGroup)((GComponent)this).GetChild("NameTitleGroup");
		DestroyShipBtn = (UI_com_DestroyShipBtn)(object)((GComponent)this).GetChild("DestroyShipBtn");
		n56 = (GTextField)((GComponent)this).GetChild("n56");
		string id = "ui://pwrbvhpvazac6p".Replace("ui://", "") + "-" + ((GObject)n56).id;
		((GObject)n56).text = LanguagesManager.GetDesc(id);
		n58 = (GTextField)((GComponent)this).GetChild("n58");
		string id2 = "ui://pwrbvhpvazac6p".Replace("ui://", "") + "-" + ((GObject)n58).id;
		((GObject)n58).text = LanguagesManager.GetDesc(id2);
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id3 = "ui://pwrbvhpvazac6p".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id3);
		n60 = (GTextField)((GComponent)this).GetChild("n60");
		string id4 = "ui://pwrbvhpvazac6p".Replace("ui://", "") + "-" + ((GObject)n60).id;
		((GObject)n60).text = LanguagesManager.GetDesc(id4);
		n61 = (GGroup)((GComponent)this).GetChild("n61");
	}
}
