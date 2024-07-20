namespace TrackMaster.Domain.Employees
{
    public interface IEmployee
    {
        public Task<bool> AddEmployee(AddEmployeeRequest employee);
        public Task<Models.Employee> GetEmployee(int employeeId);

        public Task<List<Models.Employee>> GetSubordinates(int managerId);
    }
}
