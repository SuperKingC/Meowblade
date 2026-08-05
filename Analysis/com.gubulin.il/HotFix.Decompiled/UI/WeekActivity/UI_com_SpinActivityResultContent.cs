using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_SpinActivityResultContent : GComponent
{
	public Controller ResultType;

	public Controller PageType;

	public GLoader n31;

	public GImage n32;

	public GImage n35;

	public UI_com_spinResultIcon resultIcon;

	public GGroup n36;

	public GGroup n50;

	public GLoader n47;

	public GImage n48;

	public GImage n49;

	public GList resultList;

	public GTextField n26;

	public GTextField n51;

	public GTextField n52;

	public GTextField n53;

	public GTextField n28;

	public GLoader ticketIcon;

	public GTextField ticketGetCount;

	public GGroup n33;

	public GButton confirmBtn;

	public const string URL = "ui://jl0c82y5fmsk1";

	public static string Name = "UI_com_SpinActivityResultContent";

	public static string GetURL()
	{
		return "ui://jl0c82y5fmsk1";
	}

	public static UI_com_SpinActivityResultContent CreateInstance()
	{
		return (UI_com_SpinActivityResultContent)(object)UIPackage.CreateObject("WeekActivity", "com_SpinActivityResultContent");
	}

	public static UI_com_SpinActivityResultContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpinActivityResultContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5fmsk1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ResultType = ((GComponent)this).GetController("ResultType");
		PageType = ((GComponent)this).GetController("PageType");
		n31 = (GLoader)((GComponent)this).GetChild("n31");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		resultIcon = (UI_com_spinResultIcon)(object)((GComponent)this).GetChild("resultIcon");
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		n50 = (GGroup)((GComponent)this).GetChild("n50");
		n47 = (GLoader)((GComponent)this).GetChild("n47");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		resultList = (GList)((GComponent)this).GetChild("resultList");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id = "ui://jl0c82y5fmsk1".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id);
		n51 = (GTextField)((GComponent)this).GetChild("n51");
		string id2 = "ui://jl0c82y5fmsk1".Replace("ui://", "") + "-" + ((GObject)n51).id;
		((GObject)n51).text = LanguagesManager.GetDesc(id2);
		n52 = (GTextField)((GComponent)this).GetChild("n52");
		string id3 = "ui://jl0c82y5fmsk1".Replace("ui://", "") + "-" + ((GObject)n52).id;
		((GObject)n52).text = LanguagesManager.GetDesc(id3);
		n53 = (GTextField)((GComponent)this).GetChild("n53");
		string id4 = "ui://jl0c82y5fmsk1".Replace("ui://", "") + "-" + ((GObject)n53).id;
		((GObject)n53).text = LanguagesManager.GetDesc(id4);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id5 = "ui://jl0c82y5fmsk1".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id5);
		ticketIcon = (GLoader)((GComponent)this).GetChild("ticketIcon");
		ticketGetCount = (GTextField)((GComponent)this).GetChild("ticketGetCount");
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		confirmBtn = (GButton)((GComponent)this).GetChild("confirmBtn");
	}
}
