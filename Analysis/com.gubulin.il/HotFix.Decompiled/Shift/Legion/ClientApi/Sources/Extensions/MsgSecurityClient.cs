namespace Shift.Legion.ClientApi.Sources.Extensions;

public static class MsgSecurityClient
{
	public static string SIndex = string.Empty;

	private static byte ObfuscatingKey = 37;

	private static byte ObfuscatingKey_2 = 55;

	public static void Do(MsgSecurityAction action, ref byte[] data)
	{
		switch (action)
		{
		case MsgSecurityAction.Encryption:
			Obfuscating(ref data);
			break;
		case MsgSecurityAction.Decryption:
			De_Obfuscating(ref data);
			break;
		}
	}

	private static void Obfuscating(ref byte[] data)
	{
		long num = data.Length;
		for (int i = 0; i < 10; i += 2)
		{
			if (i + 1 < num)
			{
				byte b = data[i];
				byte b2 = data[i + 1];
				if (b < num && b >= 10 && b2 < num && b2 >= 10)
				{
					byte b3 = data[b];
					data[b] = data[b2];
					data[b2] = b3;
				}
			}
		}
		for (int j = 0; j < data.Length; j++)
		{
			data[j] ^= ObfuscatingKey;
		}
	}

	private static void De_Obfuscating(ref byte[] data)
	{
		long num = data.Length;
		for (int i = 0; i < data.Length; i++)
		{
			data[i] ^= ObfuscatingKey;
		}
		for (int num2 = 8; num2 >= 0; num2 -= 2)
		{
			if (num2 + 1 < num)
			{
				byte b = data[num2];
				byte b2 = data[num2 + 1];
				if (b < num && b >= 10 && b2 < num && b2 >= 10)
				{
					byte b3 = data[b];
					data[b] = data[b2];
					data[b2] = b3;
				}
			}
		}
	}

	public static void DoForOAIDCert(MsgSecurityAction action, ref byte[] data)
	{
		switch (action)
		{
		case MsgSecurityAction.Encryption:
			Obfuscating_2(ref data);
			break;
		case MsgSecurityAction.Decryption:
			De_Obfuscating_2(ref data);
			break;
		}
	}

	private static void Obfuscating_2(ref byte[] data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] ^= ObfuscatingKey_2;
		}
	}

	private static void De_Obfuscating_2(ref byte[] data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] ^= ObfuscatingKey_2;
		}
	}
}
