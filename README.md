# Unity_CsvFileReadWriter

``CsvFileReadWriter`` provides simple functions to read/write csv file.

## Importing

You can use Package Manager or import it directly.

```
https://github.com/XJINE/Unity_CsvFileReadWriter.git?path=Assets/Packages/CsvFileReadWriter
```

### Dependencies

This project use following resources.

- https://github.com/XJINE/Unity_TextFileReadWriter

## How to Use

Following functions are included.

```csharp
(string[] values, bool success) ReadFromAssets(string file)
(string[] values, bool success) ReadFromAssets(string dir, string file)

(string[] values, bool success) ReadFromStreamingAssets(string file)
(string[] values, bool success) ReadFromStreamingAssets(string dir, string file)

(string[] values, bool success) Read(string dir, string file)
(string[] values, bool success) Read(string path, bool forthExtension = true)

(string text, bool success) WriteToAssets<T>(string file, IEnumerable<T> values)
(string text, bool success) WriteToAssets<T>(string dir, string file, IEnumerable<T> values)

(string text, bool success) WriteToStreamingAssets<T>(string file, IEnumerable<T> values)
(string text, bool success) WriteToStreamingAssets<T>(string dir, string file, IEnumerable<T> values)

(string text, bool success) Write<T>(string dir, string file, IEnumerable<T> values)
(string text, bool success) Write<T>(string path, IEnumerable<T> values, bool forceExtension = true)
```
