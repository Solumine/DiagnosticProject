using System.Text.Json;

namespace Project;

public class DiagnosticHandler
{
    private readonly string filePath;
    private List<Diagnostic>? diagnostics;
    private readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

    public DiagnosticHandler(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
        }

        this.filePath = filePath;
    }

     public void Create(Diagnostic diagnostic)
    {
        diagnostics ??= new List<Diagnostic>();
        diagnostics.Add(diagnostic);
    }

    public async Task Read()
    {
        if (File.Exists(filePath))
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous))
            {                
                if (new FileInfo(filePath).Length == 0)
                    await File.WriteAllTextAsync(filePath, "[]");
                else
                    diagnostics = await JsonSerializer.DeserializeAsync<List<Diagnostic>>(fs, options) ?? new List<Diagnostic>();
            }
        }
        else
            using(File.Create(filePath)){};
    }

    public async Task Update()
    {
        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Write, 4096, FileOptions.Asynchronous))
        {
            await JsonSerializer.SerializeAsync(fs, diagnostics, options);
        }
    }
}