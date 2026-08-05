using System.Collections.Generic;

public class VersionResourceFile
{
	public string Number;

	public bool Big;

	public Dictionary<string, string> Md5;

	public Dictionary<string, int> Size;

	public VersionResourceFile()
	{
		Md5 = new Dictionary<string, string>();
		Size = new Dictionary<string, int>();
	}
}
