using System.Collections.Generic;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;

namespace UI.GvGWorldMap3;

public class GvG3FlagshipFunctionBase
{
	private string _functionType;

	private string _desc;

	public string Desc
	{
		get
		{
			if (string.IsNullOrEmpty(_desc))
			{
				_desc = "GvG3FlagshipFunctionsDesc".ToConfiguration<Dictionary<string, string>>()[_functionType].ToLanguage();
			}
			return _desc;
		}
	}

	public void Init(FlagshipFuncStatus funcStatus, GButton button, string functionType)
	{
		_functionType = functionType;
		((GComponent)button).GetController("Status").SetSelectedIndex((int)funcStatus);
	}

	public void Update(FlagshipFuncStatus funcStatus, GButton button)
	{
		((GComponent)button).GetController("Status").SetSelectedIndex((int)funcStatus);
	}
}
