using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_AccelerateTip : GComponent
{
	public Controller AccStatus;

	public Controller c2;

	public GImage n138;

	public GTextField n141;

	public GTextField n147;

	public GLoader n142;

	public GTextField Qty;

	public GImage n139;

	public GTextField n140;

	public GTextField n145;

	public GTextField n146;

	public GImage n148;

	public const string URL = "ui://th385mttqyfwo8q";

	public static string Name = "UI_com_AccelerateTip";

	public static string GetURL()
	{
		return "ui://th385mttqyfwo8q";
	}

	public static UI_com_AccelerateTip CreateInstance()
	{
		return (UI_com_AccelerateTip)(object)UIPackage.CreateObject("GvGOuterTech", "com_AccelerateTip");
	}

	public static UI_com_AccelerateTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AccelerateTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttqyfwo8q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AccStatus = ((GComponent)this).GetController("AccStatus");
		c2 = ((GComponent)this).GetController("c2");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n141 = (GTextField)((GComponent)this).GetChild("n141");
		string id = "ui://th385mttqyfwo8q".Replace("ui://", "") + "-" + ((GObject)n141).id;
		((GObject)n141).text = LanguagesManager.GetDesc(id);
		n147 = (GTextField)((GComponent)this).GetChild("n147");
		string id2 = "ui://th385mttqyfwo8q".Replace("ui://", "") + "-" + ((GObject)n147).id;
		((GObject)n147).text = LanguagesManager.GetDesc(id2);
		n142 = (GLoader)((GComponent)this).GetChild("n142");
		Qty = (GTextField)((GComponent)this).GetChild("Qty");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		n140 = (GTextField)((GComponent)this).GetChild("n140");
		string id3 = "ui://th385mttqyfwo8q".Replace("ui://", "") + "-" + ((GObject)n140).id;
		((GObject)n140).text = LanguagesManager.GetDesc(id3);
		n145 = (GTextField)((GComponent)this).GetChild("n145");
		string id4 = "ui://th385mttqyfwo8q".Replace("ui://", "") + "-" + ((GObject)n145).id;
		((GObject)n145).text = LanguagesManager.GetDesc(id4);
		n146 = (GTextField)((GComponent)this).GetChild("n146");
		string id5 = "ui://th385mttqyfwo8q".Replace("ui://", "") + "-" + ((GObject)n146).id;
		((GObject)n146).text = LanguagesManager.GetDesc(id5);
		n148 = (GImage)((GComponent)this).GetChild("n148");
	}
}
