using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Services;

namespace UI.RollingMarquee;

public class UI_RollingMarqueePanel : GComponent, IUiController
{
	public UI_RollingNoticeBack Notice;

	public const string URL = "ui://ccmc9e4k8u4a2";

	public static string Name = "UI_RollingMarqueePanel";

	private static NewsTicker myTicker;

	private const string NoticeBack = "back";

	public static string GetURL()
	{
		return "ui://ccmc9e4k8u4a2";
	}

	public static UI_RollingMarqueePanel CreateInstance()
	{
		return (UI_RollingMarqueePanel)(object)UIPackage.CreateObject("RollingMarquee", "RollingMarqueePanel");
	}

	public static UI_RollingMarqueePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RollingMarqueePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ccmc9e4k8u4a2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Notice = (UI_RollingNoticeBack)(object)((GComponent)this).GetChild("Notice");
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
		((GObject)this).sortingOrder = 119;
	}

	public void OnShow()
	{
		NoticeInit();
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<NewsTicker>("NEWS_TICKER_PULLED", UpdateTicker);
		SharedMessenger.AddListener<MarqueeContent>("NEWS_MARQUEE_CONTENT_PULLED", UpdateMarqueeContent);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<NewsTicker>("NEWS_TICKER_PULLED", UpdateTicker);
		SharedMessenger.RemoveListener<MarqueeContent>("NEWS_MARQUEE_CONTENT_PULLED", UpdateMarqueeContent);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void NoticeInit()
	{
		if (myTicker != null)
		{
			if (myTicker.Repeat == 0)
			{
				((GObject)Notice).visible = false;
				return;
			}
			((GObject)Notice).visible = true;
			HideLastTickerItem();
			CreatNoticeItem();
		}
		else
		{
			((GObject)Notice).visible = false;
		}
	}

	public void CreatNoticeItem()
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		if (myTicker.Repeat <= 0 && myTicker.Repeat >= 0)
		{
			return;
		}
		if (myTicker.Repeat > 0)
		{
			myTicker.Repeat--;
		}
		UI_RollingNoticeCom tickerItem = UI_RollingNoticeCom.CreateInstance_ILRuntime();
		((GComponent)Notice.RollingNotice).AddChild((GObject)(object)tickerItem);
		((GComponent)tickerItem).GetChild("notice").text = myTicker.Content;
		((GObject)tickerItem).x = ((GObject)Notice.RollingNotice).width - 14f;
		float num = ((GObject)tickerItem).width + ((GObject)Notice.RollingNotice).width;
		int num2 = 80;
		float num3 = num / (float)num2;
		((GObject)tickerItem).data = false;
		((GComponent)tickerItem).GetChild("notice").alpha = 1f;
		((GObject)tickerItem).TweenMoveX(0f - num, num3).SetEase((EaseType)0).OnUpdate((GTweenCallback)delegate
		{
			if (((GObject)tickerItem).data != null)
			{
				float num4 = 0f - (((GObject)tickerItem).width - ((GObject)Notice.RollingNotice).width);
				if (((GObject)tickerItem).x < num4 && !(bool)((GObject)tickerItem).data)
				{
					((GObject)tickerItem).data = true;
					CreatNoticeItem();
				}
			}
		})
			.OnComplete((GTweenCallback)delegate
			{
				if (myTicker.Repeat == 0)
				{
					((GObject)Notice).visible = false;
				}
				((GComponent)Notice.RollingNotice).RemoveChild((GObject)(object)tickerItem, true);
			});
	}

	private void HideLastTickerItem()
	{
		for (int num = ((GComponent)Notice.RollingNotice).numChildren - 1; num >= 0; num--)
		{
			if (!(((GComponent)Notice.RollingNotice).GetChildAt(num).name == "back"))
			{
				((GComponent)Notice.RollingNotice).RemoveChild(((GComponent)Notice.RollingNotice).GetChildAt(num), true);
			}
		}
	}

	private void UpdateTicker(NewsTicker ticker)
	{
		if (ticker.Type == NewsTickerType.Marquee && ticker.Repeat > 0)
		{
			return;
		}
		ticker.Type = NewsTickerType.Normal;
		if (myTicker != null)
		{
			if (ticker.Id != myTicker.Id)
			{
				myTicker = ticker;
				NoticeInit();
			}
		}
		else
		{
			myTicker = ticker;
			NoticeInit();
		}
	}

	private void UpdateMarqueeContent(MarqueeContent content)
	{
		if (content == null || content.Timestamp + 86400 < (int)GameController.Instance.GetServerTime() || GameLocalDataManager.IsMarqueePlayed(content.Id))
		{
			return;
		}
		if (myTicker != null)
		{
			if (myTicker.Type != NewsTickerType.Normal)
			{
				myTicker = new NewsTicker
				{
					Id = content.Id,
					Content = content.Content,
					Repeat = content.Repeat,
					Type = NewsTickerType.Marquee
				};
				NoticeInit();
			}
			else if (content.Id != myTicker.Id)
			{
				myTicker = new NewsTicker
				{
					Id = content.Id,
					Content = content.Content,
					Repeat = content.Repeat,
					Type = NewsTickerType.Normal
				};
				NoticeInit();
			}
		}
		else
		{
			myTicker = new NewsTicker
			{
				Id = content.Id,
				Content = content.Content,
				Repeat = content.Repeat,
				Type = NewsTickerType.Marquee
			};
			NoticeInit();
		}
		GameLocalDataManager.SetMarqueePlayed(content.Id);
	}
}
