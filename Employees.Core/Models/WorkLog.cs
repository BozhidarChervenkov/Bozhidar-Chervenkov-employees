namespace Employees.Core.Models
{
    public record WorkLog(
    int EmpId,
    int ProjectId,
    DateTime DateFrom,
    DateTime DateTo
    );
}