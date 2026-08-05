using System;
using System.Collections.Generic;

namespace ProtoBuf;

public class PType
{
	public delegate object DelegateFunctionCreateInstance(string typeName);

	public delegate Type DelegateFunctionGetRealType(object o);

	private static PType m_Current;

	private Dictionary<string, Type> m_Types = new Dictionary<string, Type>();

	private static DelegateFunctionCreateInstance CreateInstanceFunc;

	private static DelegateFunctionGetRealType GetRealTypeFunc;

	private static PType Current
	{
		get
		{
			if (m_Current == null)
			{
				m_Current = new PType();
			}
			return m_Current;
		}
	}

	private PType()
	{
	}

	private void RegisterTypeInternal(string metaName, Type type)
	{
		m_Types[metaName] = type;
	}

	private Type FindTypeInternal(string metaName)
	{
		Type value = null;
		if (!m_Types.TryGetValue(metaName, out value))
		{
			throw new SystemException($"PropertyMeta : {metaName} is not registered!");
		}
		return value;
	}

	public static void RegisterType(string metaName, Type type)
	{
		Current.RegisterTypeInternal(metaName, type);
	}

	public static void RegisterFunctionCreateInstance(DelegateFunctionCreateInstance func)
	{
		CreateInstanceFunc = func;
	}

	public static void RegisterFunctionGetRealType(DelegateFunctionGetRealType func)
	{
		GetRealTypeFunc = func;
	}

	public static Type FindType(string metaName)
	{
		return Current.FindTypeInternal(metaName);
	}

	public static object CreateInstance(Type type)
	{
		if (Type.GetType(type.FullName) == null && CreateInstanceFunc != null)
		{
			return CreateInstanceFunc(type.FullName);
		}
		return Activator.CreateInstance(type, nonPublic: true);
	}

	public static Type GetPType(object o)
	{
		if (GetRealTypeFunc != null)
		{
			return GetRealTypeFunc(o);
		}
		return o.GetType();
	}
}
