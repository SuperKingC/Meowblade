using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.LordOfDreams;

public class UI_GvGHelpPanel : GComponent, IUiController
{
	public GLoader background;

	public GGraph _mask;

	public UI_GvGHelpDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://0i520nzmpx1kocj";

	public static string Name = "UI_GvGHelpPanel";

	private float ScoreMultiplierValue;

	public static string GetURL()
	{
		return "ui://0i520nzmpx1kocj";
	}

	public static UI_GvGHelpPanel CreateInstance()
	{
		return (UI_GvGHelpPanel)(object)UIPackage.CreateObject("LordOfDreams", "GvGHelpPanel");
	}

	public static UI_GvGHelpPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGHelpPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmpx1kocj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		_mask = (GGraph)((GComponent)this).GetChild("_mask");
		Dialog = (UI_GvGHelpDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("ScoreMultiplier", out var value))
		{
			ScoreMultiplierValue = (float)value;
			((GObject)Dialog.ScoreMultiplierText).text = $"X{ScoreMultiplierValue}";
		}
	}

	public void OnShow()
	{
		Popup.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)_mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)_mask).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
