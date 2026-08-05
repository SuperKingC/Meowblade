using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_OperationSP : GButton
{
	public Controller button;

	public Controller Type;

	public Controller State;

	public Controller ColorTotal;

	public Controller ShowRemainCount;

	public Controller ColorCurrent;

	public GImage back;

	public GLoader n10;

	public GLoader n11;

	public GImage n13;

	public GImage n12;

	public GTextField n14;

	public GGroup n15;

	public GImage n19;

	public GImage n20;

	public GTextField remainCount;

	public GTextField remainCountTotal;

	public GTextField mark;

	public GGroup SuppressRebellion;

	public const string URL = "ui://4eq8fgd2b87g5x";

	public static string Name = "UI_btn_OperationSP";

	public static string GetURL()
	{
		return "ui://4eq8fgd2b87g5x";
	}

	public static UI_btn_OperationSP CreateInstance()
	{
		return (UI_btn_OperationSP)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_OperationSP");
	}

	public static UI_btn_OperationSP CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OperationSP).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2b87g5x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		ColorTotal = ((GComponent)this).GetController("ColorTotal");
		ShowRemainCount = ((GComponent)this).GetController("ShowRemainCount");
		ColorCurrent = ((GComponent)this).GetController("ColorCurrent");
		back = (GImage)((GComponent)this).GetChild("back");
		n10 = (GLoader)((GComponent)this).GetChild("n10");
		n11 = (GLoader)((GComponent)this).GetChild("n11");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://4eq8fgd2b87g5x".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		n15 = (GGroup)((GComponent)this).GetChild("n15");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		remainCount = (GTextField)((GComponent)this).GetChild("remainCount");
		remainCountTotal = (GTextField)((GComponent)this).GetChild("remainCountTotal");
		mark = (GTextField)((GComponent)this).GetChild("mark");
		SuppressRebellion = (GGroup)((GComponent)this).GetChild("SuppressRebellion");
	}
}
