using System;

namespace ProtoBuf.Meta;

public class TypeFormatEventArgs : EventArgs
{
	private Type type;

	private string formattedName;

	private readonly bool typeFixed;

	public Type Type
	{
		get
		{
			return type;
		}
		set
		{
			if (type != value)
			{
				if (typeFixed)
				{
					throw new InvalidOperationException("The type is fixed and cannot be changed");
				}
				type = value;
			}
		}
	}

	public string FormattedName
	{
		get
		{
			return formattedName;
		}
		set
		{
			if (formattedName != value)
			{
				if (!typeFixed)
				{
					throw new InvalidOperationException("The formatted-name is fixed and cannot be changed");
				}
				formattedName = value;
			}
		}
	}

	internal TypeFormatEventArgs(string formattedName)
	{
		if (string.IsNullOrEmpty(formattedName))
		{
			throw new ArgumentNullException("formattedName");
		}
		this.formattedName = formattedName;
	}

	internal TypeFormatEventArgs(Type type)
	{
		this.type = type ?? throw new ArgumentNullException("type");
		typeFixed = true;
	}
}
