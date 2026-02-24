using Employees.Core.Models;

namespace Employees.Core.Services;

public static class CsvLoader
{
    public static List<WorkLog> Load(string path)
    {
        var lines = File.ReadAllLines(path);
        var list = new List<WorkLog>();

        foreach (var line in lines.Skip(1)) // skip header
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var cols = line.Split(",", StringSplitOptions.TrimEntries);

            var empId = int.Parse(cols[0]);
            var projectId = int.Parse(cols[1]);
            var from = DateParser.Parse(cols[2]);
            var to = DateParser.Parse(cols[3]);

            list.Add(new WorkLog(empId, projectId, from, to));
        }

        return list;
    }
}
