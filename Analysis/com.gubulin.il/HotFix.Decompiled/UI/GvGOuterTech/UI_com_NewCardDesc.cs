using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_NewCardDesc : GComponent
{
	public Controller Rarity;

	public GImage n35;

	public GImage n36;

	public GImage n42;

	public GImage n43;

	public GImage n40;

	public GImage n41;

	public GImage n39;

	public GImage n45;

	public GImage n44;

	public GRichTextField Desc;

	public GTextField MaxEffect;

	public GTextField n46;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://th385mttk19mo2l";

	public static string Name = "UI_com_NewCardDesc";

	public static string GetURL()
	{
		return "ui://th385mttk19mo2l";
	}

	public static UI_com_NewCardDesc CreateInstance()
	{
		return (UI_com_NewCardDesc)(object)UIPackage.CreateObject("GvGOuterTech", "com_NewCardDesc");
	}

	public static UI_com_NewCardDesc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NewCardDesc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttk19mo2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		Desc = (GRichTextField)((GComponent)this).GetChild("Desc");
		MaxEffect = (GTextField)((GComponent)this).GetChild("MaxEffect");
		n46 = (GTextField)((GComponent)this).GetChild("n46");
		string id = "ui://th385mttk19mo2l".Replace("ui://", "") + "-" + ((GObject)n46).id;
		((GObject)n46).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
