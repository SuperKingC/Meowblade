using System;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;

namespace UI.GvG3Medal;

public class UI_com_MedalRecords : GComponent
{
	public GGraph back;

	public UI_com_MedalDialog PopUp;

	public const string URL = "ui://g5hi1peolq582";

	public static string Name = "UI_com_MedalRecords";

	private string _medalId;

	private EventCallback1 _change;

	public static string GetURL()
	{
		return "ui://g5hi1peolq582";
	}

	public static UI_com_MedalRecords CreateInstance()
	{
		return (UI_com_MedalRecords)(object)UIPackage.CreateObject("GvG3Medal", "com_MedalRecords");
	}

	public static UI_com_MedalRecords CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MedalRecords).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peolq582", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		PopUp = (UI_com_MedalDialog)(object)((GComponent)this).GetChild("PopUp");
	}

	public void Init(EventCallback0 close, EventCallback1 change)
	{
		((GObject)back).onClick.Set(close);
		_change = change;
	}

	public void Show(GvGMedalRecord medalRecord)
	{
		_medalId = medalRecord.MedalId;
		PopUp.ActivatedMedal.OnRender(medalRecord, _change);
		((GObject)PopUp.MedalName0).text = medalRecord.Config.Name;
		((GObject)PopUp.MedalLevel).text = medalRecord.Level.ToString();
		((GObject)PopUp.Rank).text = medalRecord.Rank.ToString();
		((GObject)PopUp.MedalDesc).text = medalRecord.Config.PostScript;
		RenderRecords(medalRecord);
	}

	public void Update(GvGMedalRecord medalRecord)
	{
		if (!(medalRecord.MedalId != _medalId))
		{
			PopUp.ActivatedMedal.Update(medalRecord);
		}
	}

	private void RenderRecords(GvGMedalRecord medalRecord)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		PopUp.Records.itemRenderer = new ListItemRenderer(Render);
		PopUp.Records.numItems = medalRecord.Records.Count;
		void Render(int index, GObject obj)
		{
			if (!(obj is UI_com_MedalRecord uI_com_MedalRecord))
			{
				throw new Exception("UI_com_MedalRecords.RenderRecords recordUi is not UI_com_MedalRecord");
			}
			MedalRecord medalRecord2 = medalRecord.Records[index];
			((GObject)uI_com_MedalRecord.Date).text = medalRecord2.Date.LocalDateTime.ToString("yyyy/MM/dd");
			((GObject)uI_com_MedalRecord.IzId).text = medalRecord2.ShowName;
			((GObject)uI_com_MedalRecord.MedalName).text = medalRecord.Config.Name;
			if (index == 0)
			{
				uI_com_MedalRecord.IsFirst.SetSelectedIndex(1);
			}
			else
			{
				uI_com_MedalRecord.IsFirst.SetSelectedIndex(0);
				((GObject)uI_com_MedalRecord.MedalLevel).text = "GvG3MedalRecord".ToLanguage($"{index + 1}");
			}
		}
	}
}
