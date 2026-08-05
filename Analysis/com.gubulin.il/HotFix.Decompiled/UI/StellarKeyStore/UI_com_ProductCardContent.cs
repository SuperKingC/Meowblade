using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.StellarKeyStore;

public class UI_com_ProductCardContent : GComponent
{
	public Controller Type;

	public GLoader back;

	public GImage n39;

	public GGraph sfxBack;

	public GLoader ItemIcon;

	public GTextField Title0;

	public GTextField ItemName;

	public GLoader KeyIcon;

	public GTextField Price;

	public GGroup n38;

	public GMovieClip n40;

	public Transition t0;

	public const string URL = "ui://khops95ljjo119";

	public static string Name = "UI_com_ProductCardContent";

	public static string GetURL()
	{
		return "ui://khops95ljjo119";
	}

	public static UI_com_ProductCardContent CreateInstance()
	{
		return (UI_com_ProductCardContent)(object)UIPackage.CreateObject("StellarKeyStore", "com_ProductCardContent");
	}

	public static UI_com_ProductCardContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProductCardContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95ljjo119", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GLoader)((GComponent)this).GetChild("back");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		Title0 = (GTextField)((GComponent)this).GetChild("Title0");
		string id = "ui://khops95ljjo119".Replace("ui://", "") + "-" + ((GObject)Title0).id;
		((GObject)Title0).text = LanguagesManager.GetDesc(id);
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		string id2 = "ui://khops95ljjo119".Replace("ui://", "") + "-" + ((GObject)ItemName).id;
		((GObject)ItemName).text = LanguagesManager.GetDesc(id2);
		KeyIcon = (GLoader)((GComponent)this).GetChild("KeyIcon");
		Price = (GTextField)((GComponent)this).GetChild("Price");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		n40 = (GMovieClip)((GComponent)this).GetChild("n40");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
