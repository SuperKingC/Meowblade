using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_UnlockStoneNum : GComponent
{
	public Controller Status;

	public GImage icon;

	public GImage n5;

	public GImage n2;

	public GImage n3;

	public GImage n4;

	public GTextField num;

	public const string URL = "ui://lrhs6zw7vaxb453";

	public static string Name = "UI_UnlockStoneNum";

	public static string GetURL()
	{
		return "ui://lrhs6zw7vaxb453";
	}

	public static UI_UnlockStoneNum CreateInstance()
	{
		return (UI_UnlockStoneNum)(object)UIPackage.CreateObject("Legion", "UnlockStoneNum");
	}

	public static UI_UnlockStoneNum CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockStoneNum).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7vaxb453", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		icon = (GImage)((GComponent)this).GetChild("icon");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://lrhs6zw7vaxb453".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
	}
}
