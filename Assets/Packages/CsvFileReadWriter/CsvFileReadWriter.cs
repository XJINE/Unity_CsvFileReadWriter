using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class CsvFileReadWriter
{
    #region Method

    public static (string[] values, bool success) ReadFromAssets(string file)
    {
        return Read(Path.Combine(Application.dataPath, file));
    }

    public static (string[] values, bool success) ReadFromAssets(string dir, string file)
    {
        dir ??= "";
        return Read(Path.Combine(Application.dataPath, dir, file));
    }

    public static (string[] values, bool success) ReadFromStreamingAssets(string file)
    {
        return Read(Path.Combine(Application.streamingAssetsPath, file));
    }

    public static (string[] values, bool success) ReadFromStreamingAssets(string dir, string file)
    {
        dir ??= "";
        return Read(Path.Combine(Application.streamingAssetsPath, dir, file));
    }

    public static (string[] values, bool success) Read(string dir, string file)
    {
        return Read(Path.Combine(dir, file));
    }

    public static (string[] values, bool success) Read(string path, bool forthExtension = true)
    {
        if (forthExtension && !path.EndsWith(".csv"))
        {
            path += ".csv";
        }

        var (text, success) = TextFileReadWriter.Read(path);

        return success ? (text.Split(','), true) : (null, false);
    }

    public static (string text, bool success) WriteToAssets<T>(string file, IEnumerable<T> values)
    {
        return Write(Path.Combine(Application.dataPath, file), values);
    }

    public static (string text, bool success) WriteToAssets<T>(string dir, string file, IEnumerable<T> values)
    {
        dir ??= "";
        return Write(Path.Combine(Application.dataPath, dir, file), values);
    }

    public static (string text, bool success) WriteToStreamingAssets<T>(string file, IEnumerable<T> values)
    {
        return Write(Path.Combine(Application.streamingAssetsPath, file), values);
    }

    public static (string text, bool success) WriteToStreamingAssets<T>(string dir, string file, IEnumerable<T> values)
    {
        dir ??= "";
        return Write(Path.Combine(Application.streamingAssetsPath, dir, file), values);
    }

    public static (string text, bool success) Write<T>(string dir, string file, IEnumerable<T> values)
    {
        return Write(Path.Combine(dir, file), values);
    }

    public static (string text, bool success) Write<T>(string path, IEnumerable<T> values, bool forceExtension = true)
    {
        var text = "";

        foreach (var value in values)
        {
            text += value + ",";
        }

        text = text.TrimEnd(',');

        if (forceExtension && !path.EndsWith(".csv"))
        {
            path += ".csv";
        }

        return TextFileReadWriter.Write(path, text);
    }

    public static string[] RemoveNullOrWhiteSpaces(IEnumerable<string> values)
    {
        if (values == null)
        {
            return null;
        }

        var result = new List<string>(values.Count());

        for (var i = 0; i < values.Count(); i++)
        {
            var value = values.ElementAt(i);

            if (string.IsNullOrWhiteSpace(value))
            {
                continue;
            }

            result.Add(value);
        }

        return result.ToArray();
    }

    #endregion Method
}