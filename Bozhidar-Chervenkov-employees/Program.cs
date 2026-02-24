using Employees.Core.Services;

Console.WriteLine("Enter CSV file path:");
string? path = Console.ReadLine();

var logs = CsvLoader.Load(path!);
var results = OverlapCalculator.Calculate(logs);
var bestPair = OverlapCalculator.FindBestPair(results);

Console.WriteLine($"Best pair: {bestPair.EmpId1}, {bestPair.EmpId2}, {bestPair.TotalDays} days");
