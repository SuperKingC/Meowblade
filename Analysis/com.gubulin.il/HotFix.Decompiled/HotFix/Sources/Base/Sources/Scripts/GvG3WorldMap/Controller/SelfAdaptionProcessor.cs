using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public class SelfAdaptionProcessor
{
	private readonly List<SelfAdaption> _selfAdaptionList = new List<SelfAdaption>();

	public SelfAdaptionProcessor(List<SelfAdaption> selfAdaptionList)
	{
		_selfAdaptionList.AddRange(selfAdaptionList);
	}

	public void ProcessAllSelfAdaption(ComponentAlignType type = ComponentAlignType.None, float scale = 1f)
	{
		bool flag = type != ComponentAlignType.None;
		foreach (SelfAdaption selfAdaption in _selfAdaptionList)
		{
			if (!(type != selfAdaption.AlignType && flag))
			{
				selfAdaption.Scale = scale;
				ProcessSelfAdaptionHelper.ProcessSelfAdaption(selfAdaption);
			}
		}
	}
}
