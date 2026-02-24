namespace Employees.Core.Models
{
    public record OverlapResult(
    int EmpId1,
    int EmpId2,
    int ProjectId,
    int Days
    );
}
