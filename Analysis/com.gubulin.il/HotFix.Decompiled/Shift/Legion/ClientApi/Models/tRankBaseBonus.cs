using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Shift.Legion.ClientApi.Models;

public class tRankBaseBonus : ICloneable
{
	public int StartIdx { get; set; }

	public int EndIdx { get; set; }

	public Dictionary<string, object> Bonus { get; set; }

	object ICloneable.Clone()
	{
		return MemberwiseClone();
	}

	public tRankBaseBonus DeepClone()
	{
		using Stream stream = new MemoryStream();
		IFormatter formatter = new BinaryFormatter();
		formatter.Serialize(stream, this);
		stream.Seek(0L, SeekOrigin.Begin);
		return formatter.Deserialize(stream) as tRankBaseBonus;
	}
}
