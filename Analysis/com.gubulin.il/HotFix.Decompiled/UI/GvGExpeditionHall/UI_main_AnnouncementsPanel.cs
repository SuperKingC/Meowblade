using System;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.Announcement;

namespace UI.GvGExpeditionHall;

public class UI_main_AnnouncementsPanel : GComponent
{
	public GGraph mask;

	public GImage back;

	public UI_com_Announcements Announcements;

	public GTextField title;

	public GGroup n5;

	public UI_btn_CloseAnnouncements exit;

	public const string URL = "ui://k19peou7h9n16p7w";

	public static string Name = "UI_main_AnnouncementsPanel";

	private const bool _ENABLE = true;

	private GvGAnnouncement _announcement;

	private bool _rendered;

	private const string _GVG3_ANNOUNCEMENT = "GvG3Announcement";

	public static string GetURL()
	{
		return "ui://k19peou7h9n16p7w";
	}

	public static UI_main_AnnouncementsPanel CreateInstance()
	{
		return (UI_main_AnnouncementsPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "main_AnnouncementsPanel");
	}

	public static UI_main_AnnouncementsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_AnnouncementsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7h9n16p7w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		back = (GImage)((GComponent)this).GetChild("back");
		Announcements = (UI_com_Announcements)(object)((GComponent)this).GetChild("Announcements");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://k19peou7h9n16p7w".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n5 = (GGroup)((GComponent)this).GetChild("n5");
		exit = (UI_btn_CloseAnnouncements)(object)((GComponent)this).GetChild("exit");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		((GObject)exit).onClick.Set(new EventCallback0(Close));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)exit).onClick.Clear();
	}

	private void Close()
	{
		((GObject)this).visible = false;
	}

	public void Init(GvGAnnouncement announcement, Action<bool> setAnnouncementsBtnVisible = null)
	{
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		_announcement = announcement;
		setAnnouncementsBtnVisible?.Invoke(obj: true);
		TryPopUpNewAnnouncement();
	}

	private void TryPopUpNewAnnouncement()
	{
		if (_announcement != null)
		{
			int num = GameLocalDataManager.GetInt("GvG3Announcement");
			if (num < _announcement.Id)
			{
				GameLocalDataManager.SetInt("GvG3Announcement", _announcement.Id);
				Render();
			}
		}
	}

	public void Render()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		if (_announcement != null)
		{
			if (_rendered)
			{
				((GObject)this).visible = true;
				return;
			}
			((GObject)Announcements.tip).text = _announcement.Content;
			HtmlParseOptions htmlParseOptions = Announcements.tip.richTextField.htmlParseOptions;
			htmlParseOptions.linkUnderline = true;
			htmlParseOptions.ignoreWhiteSpace = true;
			((DisplayObject)Announcements.tip.richTextField).onClickLink.Set(new EventCallback1(UiHelper.FguiTextClickLink));
			_rendered = true;
			((GObject)this).visible = true;
		}
	}
}
