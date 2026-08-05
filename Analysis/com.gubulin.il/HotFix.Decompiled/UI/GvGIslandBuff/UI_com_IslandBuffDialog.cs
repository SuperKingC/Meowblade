using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_com_IslandBuffDialog : GComponent
{
	public Controller camp;

	public GImage back;

	public GTextField n1;

	public UI_btn_MyCamp n2;

	public UI_btn_OtherCamp n5;

	public GImage n3;

	public GList otherCampBuffList;

	public UI_com_MyCampBuff myCampBuff;

	public const string URL = "ui://zh7jgfijnewqfh";

	public static string Name = "UI_com_IslandBuffDialog";

	public static string GetURL()
	{
		return "ui://zh7jgfijnewqfh";
	}

	public static UI_com_IslandBuffDialog CreateInstance()
	{
		return (UI_com_IslandBuffDialog)(object)UIPackage.CreateObject("GvGIslandBuff", "com_IslandBuffDialog");
	}

	public static UI_com_IslandBuffDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandBuffDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		camp = ((GComponent)this).GetController("camp");
		back = (GImage)((GComponent)this).GetChild("back");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://zh7jgfijnewqfh".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (UI_btn_MyCamp)(object)((GComponent)this).GetChild("n2");
		n5 = (UI_btn_OtherCamp)(object)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		otherCampBuffList = (GList)((GComponent)this).GetChild("otherCampBuffList");
		myCampBuff = (UI_com_MyCampBuff)(object)((GComponent)this).GetChild("myCampBuff");
	}
}
