using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_mailbox_t : GButton
{
	public Controller button;

	public Controller Status;

	public UI_MailBoxContent Content;

	public GImage note;

	public GImage newNote;

	public GGraph SfxBack;

	public Transition breathing;

	public Transition ShowContent;

	public const string URL = "ui://j611zmymr3081n";

	public static string Name = "UI_mailbox_t";

	public static string GetURL()
	{
		return "ui://j611zmymr3081n";
	}

	public static UI_mailbox_t CreateInstance()
	{
		return (UI_mailbox_t)(object)UIPackage.CreateObject("MainCity", "mailbox_t");
	}

	public static UI_mailbox_t CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mailbox_t).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymr3081n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Content = (UI_MailBoxContent)(object)((GComponent)this).GetChild("Content");
		note = (GImage)((GComponent)this).GetChild("note");
		newNote = (GImage)((GComponent)this).GetChild("newNote");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		breathing = ((GComponent)this).GetTransition("breathing");
		ShowContent = ((GComponent)this).GetTransition("ShowContent");
	}
}
