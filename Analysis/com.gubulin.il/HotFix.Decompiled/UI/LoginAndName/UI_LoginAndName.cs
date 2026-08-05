using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.LoginAndName;

public class UI_LoginAndName : GComponent, IUiController
{
	public GLoader background;

	public UI_exit exitButton;

	public UI_nameWindow nameWindow;

	public UI_name startGameButton;

	public GGroup nameGroup;

	public GRichTextField slogan;

	public UI_loginWindow loginWindow;

	public UI_Login loginButton;

	public GGroup loginGroup;

	public GTextField popUp;

	public UI_nameWindow nameWindow_2;

	public const string URL = "ui://yb3s7uv7ryu8c";

	public static string Name = "UI_LoginAndName";

	private List<string> nameList = new List<string>();

	private bool nameIsRepeat;

	private bool isError;

	public static string GetURL()
	{
		return "ui://yb3s7uv7ryu8c";
	}

	public static UI_LoginAndName CreateInstance()
	{
		return (UI_LoginAndName)(object)UIPackage.CreateObject("LoginAndName", "LoginAndName");
	}

	public static UI_LoginAndName CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LoginAndName).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ryu8c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		exitButton = (UI_exit)(object)((GComponent)this).GetChild("exitButton");
		nameWindow = (UI_nameWindow)(object)((GComponent)this).GetChild("nameWindow");
		startGameButton = (UI_name)(object)((GComponent)this).GetChild("startGameButton");
		nameGroup = (GGroup)((GComponent)this).GetChild("nameGroup");
		slogan = (GRichTextField)((GComponent)this).GetChild("slogan");
		string id = "ui://yb3s7uv7ryu8c".Replace("ui://", "") + "-" + ((GObject)slogan).id;
		((GObject)slogan).text = LanguagesManager.GetDesc(id);
		loginWindow = (UI_loginWindow)(object)((GComponent)this).GetChild("loginWindow");
		loginButton = (UI_Login)(object)((GComponent)this).GetChild("loginButton");
		loginGroup = (GGroup)((GComponent)this).GetChild("loginGroup");
		popUp = (GTextField)((GComponent)this).GetChild("popUp");
		nameWindow_2 = (UI_nameWindow)(object)((GComponent)this).GetChild("nameWindow");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		nameList.Add("123456");
		((GObject)loginGroup).visible = true;
		((GObject)nameGroup).visible = false;
		LoginInit();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		((GObject)exitButton).onClick.Add(new EventCallback0(ExitEvent));
		((GObject)loginButton).onClick.Add(new EventCallback0(LoginEvent));
		((GObject)startGameButton).onClick.Add(new EventCallback0(StartGameEvent));
		((GObject)nameWindow.inputName).onFocusIn.Add(new EventCallback0(InputNameFocusInEvent));
		((GObject)nameWindow.inputName).onFocusOut.Add(new EventCallback0(InputNameFocusOutEvent));
		nameWindow.inputName.onChanged.Add(new EventCallback0(InputNameChangeEvent));
		((GObject)loginWindow.inputUsername).onFocusIn.Add(new EventCallback0(InputUsenameFocusIn));
		((GObject)loginWindow.inputPassword).onFocusIn.Add(new EventCallback0(InputPasswordFocusIn));
		loginWindow.inputUsername.onChanged.Add(new EventCallback0(InputUsrnameChangeEvent));
		loginWindow.inputPassword.onChanged.Add(new EventCallback0(InputPasswordChangeEvent));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		((GObject)exitButton).onClick.Remove(new EventCallback0(ExitEvent));
		((GObject)loginButton).onClick.Remove(new EventCallback0(LoginEvent));
		((GObject)startGameButton).onClick.Remove(new EventCallback0(StartGameEvent));
		((GObject)nameWindow.inputName).onFocusIn.Remove(new EventCallback0(InputNameFocusInEvent));
		((GObject)nameWindow.inputName).onFocusOut.Remove(new EventCallback0(InputNameFocusOutEvent));
		nameWindow.inputName.onChanged.Remove(new EventCallback0(InputNameChangeEvent));
		((GObject)loginWindow.inputUsername).onFocusIn.Remove(new EventCallback0(InputUsenameFocusIn));
		((GObject)loginWindow.inputPassword).onFocusIn.Remove(new EventCallback0(InputPasswordFocusIn));
		loginWindow.inputUsername.onChanged.Remove(new EventCallback0(InputUsrnameChangeEvent));
		loginWindow.inputPassword.onChanged.Remove(new EventCallback0(InputPasswordChangeEvent));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	private void ExitEvent()
	{
		if (((GObject)loginGroup).visible)
		{
			End();
		}
		if (((GObject)nameGroup).visible)
		{
			((GObject)nameGroup).visible = false;
			LoginInit();
			((GObject)loginGroup).visible = true;
		}
	}

	private void StartGameEvent()
	{
		if (((GObject)nameWindow.inputName).text != "")
		{
			if (!JudgeNameWindowContent())
			{
				return;
			}
			if (!((GObject)nameWindow.tipNo).visible && !((GObject)nameWindow.tipYes).visible)
			{
				if (((GObject)nameWindow.inputName).text != nameList[0])
				{
					nameIsRepeat = false;
				}
				else
				{
					nameIsRepeat = true;
				}
			}
			if (!nameIsRepeat)
			{
				End();
			}
			else
			{
				((GObject)popUp).text = "该名字已被使用，请换一个试试。";
			}
		}
		else
		{
			((GObject)popUp).text = "请先起名";
		}
	}

	private void LoginEvent()
	{
		if (((GObject)loginWindow.inputUsername).text == "")
		{
			((GObject)popUp).text = "用户名不能为空";
			isError = true;
		}
		else if (((GObject)loginWindow.inputPassword).text == "")
		{
			((GObject)popUp).text = "请输入您的密码";
		}
		else if (JudgeLoginWindow())
		{
			bool flag = false;
			bool flag2 = true;
			((GObject)loginGroup).visible = false;
			NameInit();
			((GObject)nameGroup).visible = true;
		}
		else
		{
			isError = true;
			((GObject)popUp).text = "您输入的用户名或密码不正确，请再次尝试。";
		}
	}

	private void InputNameChangeEvent()
	{
		((GObject)popUp).text = "";
		if (((GObject)nameWindow.inputName).text != "" && !JudgeNameWindowContent())
		{
			((GObject)popUp).text = "用户名只能包含汉字、数字、字母";
		}
		LimitLength(nameWindow.inputName, 18);
	}

	private void InputUsrnameChangeEvent()
	{
		LimitLength(loginWindow.inputUsername, 30);
	}

	private void InputPasswordChangeEvent()
	{
		LimitLength(loginWindow.inputPassword, 30);
	}

	private void InputNameFocusInEvent()
	{
		if (((GObject)nameWindow.inputName).text != "" && ((GObject)nameWindow.tipNo).visible)
		{
			((GObject)nameWindow.tipNo).visible = false;
		}
		else if (((GObject)nameWindow.inputName).text != "" && ((GObject)nameWindow.tipYes).visible)
		{
			((GObject)nameWindow.tipYes).visible = false;
		}
		((GObject)popUp).text = "";
	}

	private void InputNameFocusOutEvent()
	{
		if (!(((GObject)nameWindow.inputName).text != ""))
		{
			return;
		}
		if (JudgeNameWindowContent())
		{
			if (((GObject)nameWindow.inputName).text != nameList[0])
			{
				nameIsRepeat = false;
				((GObject)nameWindow.tipYes).visible = true;
			}
			else
			{
				nameIsRepeat = true;
				((GObject)nameWindow.tipNo).visible = true;
			}
		}
		else
		{
			((GObject)popUp).text = "用户名只能包含汉字、数字、字母";
		}
	}

	private void InputUsenameFocusIn()
	{
		((GObject)popUp).text = "";
		if (isError)
		{
			((GObject)loginWindow.inputPassword).text = "";
			isError = false;
		}
	}

	private void InputPasswordFocusIn()
	{
		((GObject)popUp).text = "";
		if (isError)
		{
			((GObject)loginWindow.inputPassword).text = "";
			isError = false;
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void LoginInit()
	{
		((GObject)popUp).text = "";
		((GObject)loginWindow.inputUsername).text = "";
		((GObject)loginWindow.inputPassword).text = "";
	}

	private void NameInit()
	{
		((GObject)popUp).text = "";
		((GObject)nameWindow.inputName).text = "";
		((GObject)nameWindow.tipYes).visible = false;
		((GObject)nameWindow.tipNo).visible = false;
	}

	private void LimitLength(GTextInput input, int length)
	{
		if (JudgeTextLength(input, length))
		{
			input.maxLength = 0;
		}
		else if (JudgeChar(((GObject)input).text))
		{
			input.maxLength = ((GObject)input).text.Length;
			((GObject)input).text = ((GObject)input).text.Substring(0, ((GObject)input).text.Length - 1);
		}
		else
		{
			((GObject)input).text = ((GObject)input).text.Substring(0, ((GObject)input).text.Length - 1);
			input.maxLength = ((GObject)input).text.Length;
		}
	}

	private bool JudgeNameWindowContent()
	{
		string pattern = "^[\\u4e00-\\u9fa5A-Za-z0-9]+$";
		return Regex.IsMatch(((GObject)nameWindow.inputName).text, pattern);
	}

	private bool JudgeTextLength(GTextInput input, int length)
	{
		string pattern = "[^\\x00-\\xff]";
		if (Regex.Replace(((GObject)input).text, pattern, "aa").Length <= length)
		{
			return true;
		}
		return false;
	}

	private bool JudgeLoginWindow()
	{
		bool result = false;
		string pattern = "^[\\x20 -\\x7E]+$";
		if (Regex.IsMatch(((GObject)loginWindow.inputUsername).text, pattern) && Regex.IsMatch(((GObject)loginWindow.inputPassword).text, pattern))
		{
			result = true;
		}
		return result;
	}

	private bool JudgeChar(string input)
	{
		string pattern = "[^\\x00-\\xff]";
		char[] value = new char[1] { input[input.Length - 1] };
		string input2 = new string(value);
		return Regex.IsMatch(input2, pattern);
	}
}
