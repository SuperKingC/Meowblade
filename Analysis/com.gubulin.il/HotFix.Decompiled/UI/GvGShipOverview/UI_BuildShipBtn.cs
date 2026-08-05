using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_BuildShipBtn : GButton
{
	public Controller Type;

	public GImage NoContentBack;

	public GImage n139;

	public GImage n140;

	public GImage n147;

	public GImage n141;

	public GTextField n144;

	public GImage n142;

	public GTextField n143;

	public GGroup n145;

	public GGroup n146;

	public GImage n153;

	public GImage n152;

	public GImage n149;

	public GTextField n157;

	public GImage n154;

	public GTextField n155;

	public GGroup n156;

	public GGroup n151;

	public const string URL = "ui://7ymaonxtb2oh2m";

	public static string Name = "UI_BuildShipBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxtb2oh2m";
	}

	public static UI_BuildShipBtn CreateInstance()
	{
		return (UI_BuildShipBtn)(object)UIPackage.CreateObject("GvGShipOverview", "BuildShipBtn");
	}

	public static UI_BuildShipBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuildShipBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtb2oh2m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		NoContentBack = (GImage)((GComponent)this).GetChild("NoContentBack");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n147 = (GImage)((GComponent)this).GetChild("n147");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n144 = (GTextField)((GComponent)this).GetChild("n144");
		string id = "ui://7ymaonxtb2oh2m".Replace("ui://", "") + "-" + ((GObject)n144).id;
		((GObject)n144).text = LanguagesManager.GetDesc(id);
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n143 = (GTextField)((GComponent)this).GetChild("n143");
		string id2 = "ui://7ymaonxtb2oh2m".Replace("ui://", "") + "-" + ((GObject)n143).id;
		((GObject)n143).text = LanguagesManager.GetDesc(id2);
		n145 = (GGroup)((GComponent)this).GetChild("n145");
		n146 = (GGroup)((GComponent)this).GetChild("n146");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n149 = (GImage)((GComponent)this).GetChild("n149");
		n157 = (GTextField)((GComponent)this).GetChild("n157");
		string id3 = "ui://7ymaonxtb2oh2m".Replace("ui://", "") + "-" + ((GObject)n157).id;
		((GObject)n157).text = LanguagesManager.GetDesc(id3);
		n154 = (GImage)((GComponent)this).GetChild("n154");
		n155 = (GTextField)((GComponent)this).GetChild("n155");
		string id4 = "ui://7ymaonxtb2oh2m".Replace("ui://", "") + "-" + ((GObject)n155).id;
		((GObject)n155).text = LanguagesManager.GetDesc(id4);
		n156 = (GGroup)((GComponent)this).GetChild("n156");
		n151 = (GGroup)((GComponent)this).GetChild("n151");
	}
}
