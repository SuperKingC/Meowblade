using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.Souvenir;

public class UI_main_Souvenir : GComponent, IUiController
{
	public GGraph back;

	public UI_com_Content Popup;

	public const string URL = "ui://8kibkcqi8zhy0";

	public static string Name = "UI_main_Souvenir";

	private const string _ITEM_ID = "ItemId";

	private string _itemId;

	private Souvenir _souvenir;

	public static string GetURL()
	{
		return "ui://8kibkcqi8zhy0";
	}

	public static UI_main_Souvenir CreateInstance()
	{
		return (UI_main_Souvenir)(object)UIPackage.CreateObject("Souvenir", "main_Souvenir");
	}

	public static UI_main_Souvenir CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_Souvenir).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8kibkcqi8zhy0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Popup = (UI_com_Content)(object)((GComponent)this).GetChild("Popup");
	}

	public static void OpenPanel(string itemId)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object> { { "ItemId", itemId } });
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
		_itemId = (parameters.TryGetValue("ItemId", out var value) ? value.ToString() : null);
		if (!string.IsNullOrEmpty(_itemId))
		{
			_souvenir = SouvenirHelper.GetSouvenirCache(_itemId);
		}
		DisplayItemDesc();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		Popup.Content.itemRenderer = new ListItemRenderer(LineTextRenderer);
		((GObject)back).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void DisplayItemDesc()
	{
		if (_souvenir != null)
		{
			RenderContent();
		}
	}

	private void RenderContent()
	{
		FGUIManager.Instance.SetItemIconAndFrame(Popup.Icon, _itemId);
		((GObject)Popup.ItemStock).text = GameManagers.Instance.StockController.GetStock(_itemId).ToString();
		((GObject)Popup.ItemName).text = Item.Name(GameManagers.Instance, _itemId);
		Popup.Content.numItems = _souvenir.LineTexts.Count;
	}

	private void LineTextRenderer(int index, GObject obj)
	{
		UI_com_LineText lineTextUi = obj as UI_com_LineText;
		if (lineTextUi == null)
		{
			throw new Exception("UI_main_Souvenir.LineTextRenderer obj is not UI_com_LineText");
		}
		lineTextUi.State.SetSelectedIndex(0);
		ISouvenirLineText lineText = _souvenir.LineTexts[index];
		lineText.RenderSouvenirLineText(DisplayText);
		void DisplayText(string processedText)
		{
			if (!((GObject)lineTextUi).isDisposed)
			{
				((GObject)lineTextUi.Desc).text = processedText;
				lineTextUi.State.SetSelectedIndex((!string.IsNullOrEmpty(processedText)) ? 1 : 0);
			}
		}
	}
}
