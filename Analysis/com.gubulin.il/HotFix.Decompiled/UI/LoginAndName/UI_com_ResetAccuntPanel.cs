using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_com_ResetAccuntPanel : GComponent
{
	public GImage n3;

	public GGraph n4;

	public GButton resetBtn;

	public GImage n5;

	public GTextField n22;

	public GImage n6;

	public GTextField n7;

	public GRichTextField cancel;

	public GImage n13;

	public GTextField n17;

	public GLoader rewardIcon;

	public GTextField rewardCount;

	public GGroup n16;

	public GTextField n23;

	public GTextField n24;

	public const string URL = "ui://yb3s7uv7m2wg5u";

	public static string Name = "UI_com_ResetAccuntPanel";

	public static string GetURL()
	{
		return "ui://yb3s7uv7m2wg5u";
	}

	public static UI_com_ResetAccuntPanel CreateInstance()
	{
		return (UI_com_ResetAccuntPanel)(object)UIPackage.CreateObject("LoginAndName", "com_ResetAccuntPanel");
	}

	public static UI_com_ResetAccuntPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ResetAccuntPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7m2wg5u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		resetBtn = (GButton)((GComponent)this).GetChild("resetBtn");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id = "ui://yb3s7uv7m2wg5u".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://yb3s7uv7m2wg5u".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		cancel = (GRichTextField)((GComponent)this).GetChild("cancel");
		string id3 = "ui://yb3s7uv7m2wg5u".Replace("ui://", "") + "-" + ((GObject)cancel).id;
		((GObject)cancel).text = LanguagesManager.GetDesc(id3);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id4 = "ui://yb3s7uv7m2wg5u".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id4);
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardCount = (GTextField)((GComponent)this).GetChild("rewardCount");
		string id5 = "ui://yb3s7uv7m2wg5u".Replace("ui://", "") + "-" + ((GObject)rewardCount).id;
		((GObject)rewardCount).text = LanguagesManager.GetDesc(id5);
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id6 = "ui://yb3s7uv7m2wg5u".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id6);
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id7 = "ui://yb3s7uv7m2wg5u".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id7);
	}
}
