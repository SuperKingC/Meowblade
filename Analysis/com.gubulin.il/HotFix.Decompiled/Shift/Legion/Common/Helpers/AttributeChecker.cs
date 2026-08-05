using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Helpers;

public static class AttributeChecker
{
	private static readonly Type BoolType = typeof(bool);

	private static readonly Type IntType = typeof(int);

	private static readonly Type LongType = typeof(long);

	private static readonly Type FloatType = typeof(float);

	private static readonly Type DoubleType = typeof(double);

	private static readonly Type StringType = typeof(string);

	public static bool Check(AttrCheckConf conf, object data)
	{
		if (conf == null)
		{
			return true;
		}
		bool result = true;
		switch (conf.name)
		{
		case "and":
			if (conf.sub == null)
			{
				return true;
			}
			foreach (AttrCheckConf item in conf.sub)
			{
				if (!Check(item, data))
				{
					return false;
				}
			}
			result = true;
			break;
		case "or":
			if (conf.sub == null)
			{
				return true;
			}
			foreach (AttrCheckConf item2 in conf.sub)
			{
				if (Check(item2, data))
				{
					return true;
				}
			}
			result = false;
			break;
		case "has":
		{
			PropertyInfo property2 = data.GetType().GetProperty(conf.name);
			IEnumerable<string> source = (IEnumerable<string>)property2.GetValue(data);
			result = source.Contains(conf.val);
			break;
		}
		default:
		{
			Type type = data.GetType();
			PropertyInfo property = type.GetProperty(conf.name);
			object obj = ((property == null) ? type.GetField(conf.name).GetValue(data) : property.GetValue(data));
			switch (conf.op)
			{
			case "<":
			{
				Type type6 = obj.GetType();
				if (type6 == IntType)
				{
					result = (int)obj < int.Parse(conf.val);
				}
				else if (type6 == FloatType)
				{
					result = (float)obj < NumericParser.Float(conf.val);
				}
				else if (type6 == LongType)
				{
					result = (long)obj < long.Parse(conf.val);
				}
				else if (type6 == DoubleType)
				{
					result = (double)obj < NumericParser.Double(conf.val);
				}
				break;
			}
			case "<=":
			{
				Type type5 = obj.GetType();
				if (type5 == IntType)
				{
					result = (int)obj <= int.Parse(conf.val);
				}
				else if (type5 == FloatType)
				{
					result = (float)obj <= NumericParser.Float(conf.val);
				}
				else if (type5 == LongType)
				{
					result = (long)obj <= long.Parse(conf.val);
				}
				else if (type5 == DoubleType)
				{
					result = (double)obj <= NumericParser.Double(conf.val);
				}
				break;
			}
			case ">":
			{
				Type type4 = obj.GetType();
				if (type4 == IntType)
				{
					result = (int)obj > int.Parse(conf.val);
				}
				else if (type4 == FloatType)
				{
					result = (float)obj > NumericParser.Float(conf.val);
				}
				else if (type4 == LongType)
				{
					result = (long)obj > long.Parse(conf.val);
				}
				else if (type4 == DoubleType)
				{
					result = (double)obj > NumericParser.Double(conf.val);
				}
				break;
			}
			case ">=":
			{
				Type type3 = obj.GetType();
				if (type3 == IntType)
				{
					result = (int)obj >= int.Parse(conf.val);
				}
				else if (type3 == FloatType)
				{
					result = (float)obj >= NumericParser.Float(conf.val);
				}
				else if (type3 == LongType)
				{
					result = (long)obj >= long.Parse(conf.val);
				}
				else if (type3 == DoubleType)
				{
					result = (double)obj >= NumericParser.Double(conf.val);
				}
				break;
			}
			case "=":
			{
				Type type2 = obj.GetType();
				if (type2 == StringType)
				{
					result = conf.val == (string)obj;
				}
				else if (type2 == IntType)
				{
					result = (int)obj == int.Parse(conf.val);
				}
				else if (type2 == FloatType)
				{
					result = (float)obj == NumericParser.Float(conf.val);
				}
				else if (type2 == BoolType)
				{
					result = int.Parse(conf.val) == (((bool)obj) ? 1 : 0);
				}
				else if (type2 == LongType)
				{
					result = (long)obj == long.Parse(conf.val);
				}
				else if (type2 == DoubleType)
				{
					result = (double)obj == NumericParser.Double(conf.val);
				}
				break;
			}
			}
			break;
		}
		}
		return result;
	}
}
