using System;
using System.IO;
using System.Text.Json;  // requires .NET Core 3+ or .NET 5+

public class KeyInfo
{
    public string? Key { get; set; }
    public string? IV { get; set; }
}

public static class KeyFileHelper
{
    public static void SaveKey(string path, byte[] key, byte[] iv)
    {
        var info = new KeyInfo
        {
            Key = Convert.ToBase64String(key),
            IV = Convert.ToBase64String(iv)
        };
        var json = JsonSerializer.Serialize(info, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public static (byte[] key, byte[] iv) LoadKey(string path)
    {
        var json = File.ReadAllText(path);
        var info = JsonSerializer.Deserialize<KeyInfo>(json);

	if (info == null || info.Key == null || info.IV == null)
	{
	    throw new InvalidOperationException("Key file is missing data.");
	}

        return (Convert.FromBase64String(info.Key), Convert.FromBase64String(info.IV));
    }
}
