using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_FoodStore : GComponent
{
	public GImage n7;

	public UI_FoodStoreBar Food;

	public GTextField n2;

	public GTextField Countdown;

	public GGroup n6;

	public GLoader n8;

	public const string URL = "ui://pobej4q7uadob";

	public static string Name = "UI_com_FoodStore";

	public static string GetURL()
	{
		return "ui://pobej4q7uadob";
	}

	public static UI_com_FoodStore CreateInstance()
	{
		return (UI_com_FoodStore)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_FoodStore");
	}

	public static UI_com_FoodStore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FoodStore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uadob", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Food = (UI_FoodStoreBar)(object)((GComponent)this).GetChild("Food");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://pobej4q7uadob".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}
