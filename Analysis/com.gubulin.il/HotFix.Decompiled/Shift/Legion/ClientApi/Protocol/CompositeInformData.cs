using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class CompositeInformData
{
	[ProtoMember(4)]
	public string _jsonCompositeResult;

	private Dictionary<string, int> _compositeResult;

	[ProtoMember(1)]
	public string PiecesId { get; set; }

	[ProtoMember(2)]
	public int CompositeCnt { get; set; }

	public Dictionary<string, int> CompositeResult
	{
		get
		{
			if (_compositeResult == null && !string.IsNullOrEmpty(_jsonCompositeResult))
			{
				_compositeResult = JsonHelper.ToObject<Dictionary<string, int>>(_jsonCompositeResult);
			}
			return _compositeResult;
		}
		set
		{
			_compositeResult = value;
			_jsonCompositeResult = JsonHelper.ToJson(value);
		}
	}

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Models.ModelsBonus")]
	public List<ModelsBonus> BonusList { get; set; }

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<ModelsBonus>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
