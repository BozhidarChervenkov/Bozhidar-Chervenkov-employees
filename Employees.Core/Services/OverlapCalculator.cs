using Employees.Core.Models;

namespace Employees.Core.Services;

public static class OverlapCalculator
{
    public static List<OverlapResult> Calculate(List<WorkLog> logs)
    {
        var results = new List<OverlapResult>();

        var grouped = logs.GroupBy(x => x.ProjectId);

        foreach (var project in grouped)
        {
            var entries = project.ToList();

            for (int i = 0; i < entries.Count; i++)
            {
                for (int j = i + 1; j < entries.Count; j++)
                {
                    var a = entries[i];
                    var b = entries[j];

                    var start = a.DateFrom > b.DateFrom ? a.DateFrom : b.DateFrom;
                    var end = a.DateTo < b.DateTo ? a.DateTo : b.DateTo;

                    if (start <= end)
                    {
                        int days = (end - start).Days + 1;

                        results.Add(new OverlapResult(
                            Math.Min(a.EmpId, b.EmpId),
                            Math.Max(a.EmpId, b.EmpId),
                            project.Key,
                            days
                        ));
                    }
                }
            }
        }

        return results;
    }

    public static EmployeePairSummary FindBestPair(List<OverlapResult> results)
    {
        return results
            .GroupBy(r => (r.EmpId1, r.EmpId2))
            .Select(g => new EmployeePairSummary(
                g.Key.EmpId1,
                g.Key.EmpId2,
                g.Sum(x => x.Days)
            ))
            .OrderByDescending(x => x.TotalDays)
            .FirstOrDefault()!;
    }
}
