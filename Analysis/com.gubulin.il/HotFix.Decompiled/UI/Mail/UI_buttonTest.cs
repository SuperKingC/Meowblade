using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_buttonTest : GButton
{
	public Controller button;

	public Controller Status;

	public Controller Type;

	public GLoader icon;

	public GRichTextField title1;

	public GRichTextField time1;

	public GRichTextField validity1;

	public GRichTextField title2;

	public GRichTextField time2;

	public GRichTextField validity2;

	public GImage back1;

	public GImage n18;

	public GGraph icon2Back;

	public GLoader icon2;

	public GRichTextField title;

	public GRichTextField time;

	public GRichTextField validity;

	public GImage redNote;

	public GImage newNote;

	public const string URL = "ui://edr57v33oipi0";

	public static string Name = "UI_buttonTest";

	public static string GetURL()
	{
		return "ui://edr57v33oipi0";
	}

	public static UI_buttonTest CreateInstance()
	{
		return (UI_buttonTest)(object)UIPackage.CreateObject("Mail", "buttonTest");
	}

	public static UI_buttonTest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_buttonTest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipi0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title1 = (GRichTextField)((GComponent)this).GetChild("title1");
		time1 = (GRichTextField)((GComponent)this).GetChild("time1");
		validity1 = (GRichTextField)((GComponent)this).GetChild("validity1");
		title2 = (GRichTextField)((GComponent)this).GetChild("title2");
		time2 = (GRichTextField)((GComponent)this).GetChild("time2");
		validity2 = (GRichTextField)((GComponent)this).GetChild("validity2");
		back1 = (GImage)((GComponent)this).GetChild("back1");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		icon2Back = (GGraph)((GComponent)this).GetChild("icon2Back");
		icon2 = (GLoader)((GComponent)this).GetChild("icon2");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		time = (GRichTextField)((GComponent)this).GetChild("time");
		validity = (GRichTextField)((GComponent)this).GetChild("validity");
		redNote = (GImage)((GComponent)this).GetChild("redNote");
		newNote = (GImage)((GComponent)this).GetChild("newNote");
	}
}
