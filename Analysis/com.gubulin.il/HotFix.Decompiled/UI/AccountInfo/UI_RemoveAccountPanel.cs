using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.AccountInfo;

public class UI_RemoveAccountPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_RemoveAccountDialog Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://b9yxt7u0p2md53";

	public static string Name = "UI_RemoveAccountPanel";

	private int removeCountDownValue = 10;

	private Coroutine RemoveCountDown { get; set; }

	public static string GetURL()
	{
		return "ui://b9yxt7u0p2md53";
	}

	public static UI_RemoveAccountPanel CreateInstance()
	{
		return (UI_RemoveAccountPanel)(object)UIPackage.CreateObject("AccountInfo", "RemoveAccountPanel");
	}

	public static UI_RemoveAccountPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RemoveAccountPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0p2md53", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_RemoveAccountDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}

	public void BeforeDestroy()
	{
		if (RemoveCountDown != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(RemoveCountDown);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
	}

	public void OnShow()
	{
		RemoveCountDown = FGUIManager.Instance.OpenIEnumerator(RemoveAccountEnumerator());
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		((GObject)Dialog.cancel).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.goToRemove).data = "账号注销按钮";
		((GObject)Dialog.goToRemove).onClick.Add(new EventCallback1(GoToRemoveAccount));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.cancel).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.goToRemove).onClick.Remove(new EventCallback1(GoToRemoveAccount));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void GoToRemoveAccount(EventContext context)
	{
		UiHelper.CustomerServiceOnlineClickLink(context);
	}

	private IEnumerator RemoveAccountEnumerator()
	{
		while (removeCountDownValue > 0)
		{
			yield return (object)new WaitForSeconds(1f);
			removeCountDownValue--;
			((GObject)Dialog.goToRemove.countdown).text = $"({removeCountDownValue}s)";
		}
		yield return (object)new WaitForSeconds(1f);
		if (!((GObject)this).isDisposed && !((GObject)Dialog).isDisposed)
		{
			((GObject)Dialog.goToRemove).enabled = true;
			Dialog.goToRemove.Type.selectedIndex = 1;
		}
	}
}
