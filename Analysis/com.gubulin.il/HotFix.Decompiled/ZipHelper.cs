using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using UnityEngine;

public class ZipHelper
{
	private static List<string> ignoreExts = new List<string>(new string[2] { ".meta", ".manifest" });

	private static List<string> ignoreFiles = new List<string>(new string[1] { ".ds_store" });

	private static void SetCode()
	{
		ZipStrings.CodePage = Encoding.UTF8.CodePage;
	}

	private static bool ZipDirectory(string folderToZip, ZipOutputStream zipStream, string parentFolderName)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		SetCode();
		bool result = true;
		FileStream fileStream = null;
		Crc32 val = new Crc32();
		try
		{
			string[] directories = Directory.GetDirectories(folderToZip, "*", SearchOption.AllDirectories);
			string[] array = (from s in Directory.GetFiles(folderToZip, "*.*", SearchOption.AllDirectories)
				where !ignoreExts.Contains(Path.GetExtension(s).ToLower()) && !ignoreFiles.Contains(Path.GetFileName(s).ToLower())
				select s.Replace('\\', '/')).ToArray();
			parentFolderName = folderToZip.Replace('\\', '/');
			if (!parentFolderName.EndsWith("/"))
			{
				parentFolderName += "/";
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				FileInfo fileInfo = new FileInfo(text);
				fileStream = File.OpenRead(text);
				byte[] array3 = new byte[fileStream.Length];
				fileStream.Read(array3, 0, array3.Length);
				ZipEntry val2 = new ZipEntry(text.Replace(parentFolderName, ""));
				val2.DateTime = fileInfo.LastWriteTime;
				val2.Size = fileStream.Length;
				fileStream.Close();
				val.Reset();
				val.Update(array3);
				val2.Crc = val.Value;
				zipStream.PutNextEntry(val2);
				((Stream)(object)zipStream).Write(array3, 0, array3.Length);
			}
		}
		catch
		{
			result = false;
		}
		finally
		{
			if (fileStream != null)
			{
				fileStream.Close();
				fileStream.Dispose();
			}
			GC.Collect();
			GC.Collect(1);
		}
		return result;
	}

	public static bool ZipDirectory(string folderToZip, string zipedFile, string password)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		if (!Directory.Exists(folderToZip))
		{
			return false;
		}
		ZipOutputStream val = new ZipOutputStream((Stream)File.Create(zipedFile));
		val.SetLevel(9);
		if (!string.IsNullOrEmpty(password))
		{
			((DeflaterOutputStream)val).Password = password;
		}
		string fullPath = Path.GetFullPath(folderToZip);
		string fullPath2 = Path.GetFullPath(fullPath + "/../");
		bool result = ZipDirectory(fullPath, val, fullPath2);
		((DeflaterOutputStream)val).Finish();
		((Stream)(object)val).Close();
		return result;
	}

	public static bool ZipDirectory(string folderToZip, string zipedFile)
	{
		return ZipDirectory(folderToZip, zipedFile, null);
	}

	public static bool ZipFile(string fileToZip, string zipedFile, string password)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		SetCode();
		bool result = true;
		ZipOutputStream val = null;
		FileStream fileStream = null;
		if (!File.Exists(fileToZip))
		{
			return false;
		}
		try
		{
			fileStream = File.OpenRead(fileToZip);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			fileStream = File.Create(zipedFile);
			val = new ZipOutputStream((Stream)fileStream);
			if (!string.IsNullOrEmpty(password))
			{
				((DeflaterOutputStream)val).Password = password;
			}
			ZipEntry val2 = new ZipEntry(Path.GetFileName(fileToZip));
			val.PutNextEntry(val2);
			val.SetLevel(6);
			((Stream)(object)val).Write(array, 0, array.Length);
		}
		catch
		{
			result = false;
		}
		finally
		{
			if (val != null)
			{
				((DeflaterOutputStream)val).Finish();
				((Stream)(object)val).Close();
			}
			if (fileStream != null)
			{
				fileStream.Close();
				fileStream.Dispose();
			}
		}
		GC.Collect();
		GC.Collect(1);
		return result;
	}

	public static bool ZipFile(string fileToZip, string zipedFile)
	{
		return ZipFile(fileToZip, zipedFile, null);
	}

	public static bool Zip(string fileToZip, string zipedFile, string password)
	{
		bool result = false;
		if (Directory.Exists(fileToZip))
		{
			result = ZipDirectory(fileToZip, zipedFile, password);
		}
		else if (File.Exists(fileToZip))
		{
			result = ZipFile(fileToZip, zipedFile, password);
		}
		return result;
	}

	public static bool Zip(string fileToZip, string zipedFile)
	{
		return Zip(fileToZip, zipedFile, null);
	}

	public static bool UnZip(string zipFilePath, string unZipDir, string password)
	{
		try
		{
			SetCode();
			if (zipFilePath == string.Empty)
			{
				throw new Exception("压缩文件不能为空！");
			}
			if (!File.Exists(zipFilePath))
			{
				throw new FileNotFoundException("压缩文件不存在！");
			}
			if (unZipDir == string.Empty)
			{
				unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
			}
			if (!unZipDir.EndsWith("/"))
			{
				unZipDir += "/";
			}
			UnZip(File.OpenRead(zipFilePath), unZipDir, password);
		}
		catch (Exception ex)
		{
			Debug.LogError((object)ex);
			return false;
		}
		return true;
	}

	public static bool UnZip(Stream baseInputStream, string unZipDir, string password)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		try
		{
			SetCode();
			if (!unZipDir.EndsWith("/"))
			{
				unZipDir += "/";
			}
			if (!Directory.Exists(unZipDir))
			{
				Directory.CreateDirectory(unZipDir);
			}
			ZipInputStream val = new ZipInputStream(baseInputStream);
			try
			{
				if (!string.IsNullOrEmpty(password))
				{
					val.Password = password;
				}
				ZipEntry nextEntry;
				while ((nextEntry = val.GetNextEntry()) != null)
				{
					string directoryName = Path.GetDirectoryName(nextEntry.Name);
					string fileName = Path.GetFileName(nextEntry.Name);
					if (!string.IsNullOrEmpty(directoryName))
					{
						Directory.CreateDirectory(unZipDir + directoryName);
					}
					if (directoryName == null || !directoryName.EndsWith("/"))
					{
					}
					if (!(fileName != string.Empty))
					{
						continue;
					}
					using FileStream fileStream = File.Create(unZipDir + nextEntry.Name);
					byte[] array = new byte[2048];
					while (true)
					{
						int num = ((Stream)(object)val).Read(array, 0, array.Length);
						if (num > 0)
						{
							fileStream.Write(array, 0, num);
							continue;
						}
						break;
					}
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Debug.LogError((object)ex);
			return false;
		}
		return true;
	}

	public static bool UnZip(string fileToUnZip, string zipedFolder)
	{
		return UnZip(fileToUnZip, zipedFolder, null);
	}

	public static bool UnZip(Stream baseInputStream, string unZipDir)
	{
		return UnZip(baseInputStream, unZipDir, null);
	}

	public static bool UnZip(byte[] data, string unZipDir)
	{
		MemoryStream memoryStream = new MemoryStream(data);
		memoryStream.Position = 0L;
		bool result = UnZip(memoryStream, unZipDir, null);
		memoryStream.Dispose();
		memoryStream.Close();
		return result;
	}

	public static IEnumerator AsyncUnZip(byte[] data, string unZipDir, Action<float> _action = null)
	{
		if (data == null)
		{
			ILRuntimeDebug.LogError("压缩文件不能为空！");
			yield return false;
			yield break;
		}
		if (unZipDir == string.Empty)
		{
			ILRuntimeDebug.LogError("解压缩目录不能为空！");
			yield return false;
			yield break;
		}
		if (!unZipDir.EndsWith("/"))
		{
			unZipDir += "/";
		}
		SetCode();
		if (!Directory.Exists(unZipDir))
		{
			Directory.CreateDirectory(unZipDir);
		}
		MemoryStream inputStream = new MemoryStream(data)
		{
			Position = 0L
		};
		long total = inputStream.Length;
		float process = 0f;
		ZipInputStream s = new ZipInputStream((Stream)inputStream);
		try
		{
			while (true)
			{
				ZipEntry nextEntry;
				ZipEntry theEntry = (nextEntry = s.GetNextEntry());
				if (nextEntry == null)
				{
					break;
				}
				string directoryName = Path.GetDirectoryName(theEntry.Name);
				string fileName = Path.GetFileName(theEntry.Name);
				if (!string.IsNullOrEmpty(directoryName))
				{
					Directory.CreateDirectory(unZipDir + directoryName);
				}
				if (fileName != string.Empty)
				{
					using FileStream streamWriter = File.Create(unZipDir + theEntry.Name);
					byte[] entrydata = new byte[2048];
					while (true)
					{
						int size = ((Stream)(object)s).Read(entrydata, 0, entrydata.Length);
						if (size > 0)
						{
							streamWriter.Write(entrydata, 0, size);
							continue;
						}
						break;
					}
					process += (float)streamWriter.Length;
				}
				_action?.Invoke(Mathf.Min(1f, process / (float)total));
				yield return null;
			}
		}
		finally
		{
			((IDisposable)s)?.Dispose();
		}
		yield return true;
	}

	public static IEnumerator AsyncUnZip(string zipFilePath, string unZipDir, Action<float> _action = null)
	{
		if (zipFilePath == string.Empty)
		{
			ILRuntimeDebug.LogError("压缩文件不能为空！");
			yield return false;
			yield break;
		}
		if (!File.Exists(zipFilePath))
		{
			ILRuntimeDebug.LogError("压缩文件不存在！");
			yield return false;
			yield break;
		}
		if (unZipDir == string.Empty)
		{
			unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
		}
		if (!unZipDir.EndsWith("/"))
		{
			unZipDir += "/";
		}
		SetCode();
		if (!Directory.Exists(unZipDir))
		{
			Directory.CreateDirectory(unZipDir);
		}
		int total = 0;
		using (FileStream _stream = new FileStream(zipFilePath, FileMode.Open, FileAccess.Read))
		{
			ZipInputStream _s = new ZipInputStream((Stream)_stream);
			try
			{
				while (true)
				{
					ZipEntry nextEntry = _s.GetNextEntry();
					if (nextEntry != null)
					{
						total++;
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)_s)?.Dispose();
			}
		}
		int process = 0;
		FileStream f_stream = new FileStream(zipFilePath, FileMode.Open, FileAccess.Read);
		ZipInputStream s = new ZipInputStream((Stream)f_stream);
		for (int i = 0; i < total; i++)
		{
			ZipEntry theEntry = s.GetNextEntry();
			if (theEntry == null)
			{
				break;
			}
			string directoryName = Path.GetDirectoryName(theEntry.Name);
			string fileName = Path.GetFileName(theEntry.Name);
			if (!string.IsNullOrEmpty(directoryName))
			{
				Directory.CreateDirectory(unZipDir + directoryName);
			}
			if (directoryName != null && !directoryName.EndsWith("/"))
			{
			}
			if (fileName != string.Empty)
			{
				using FileStream streamWriter = File.Create(unZipDir + theEntry.Name);
				byte[] data = new byte[2048];
				while (true)
				{
					int size = ((Stream)(object)s).Read(data, 0, data.Length);
					if (size > 0)
					{
						streamWriter.Write(data, 0, size);
						continue;
					}
					break;
				}
			}
			process++;
			_action?.Invoke((float)process / (float)total);
			yield return null;
		}
		yield return true;
	}
}
