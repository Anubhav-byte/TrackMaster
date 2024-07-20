using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Employees;
using TrackMaster.Domain.Models;
using TrackMaster.Domain.Persistence;
using TrackMaster.Domain.Repository._shared;

namespace TrackMaster.Domain.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployee
    {
        public EmployeeRepository(TrackMasterContext trackMasterContext) : base(trackMasterContext)
        {
        }

        public async Task<bool> AddEmployee(AddEmployeeRequest employee)
        {
            FormattableString addEmpStoredProcedureExecute = $"AddEmp @mgrid={employee.ManagerId},@e_Name={employee.EmployeeName},@email={employee.EmployeeEmail},@isadmin={employee.IsAdmin}";
            var value = await this._dbContext.Database.ExecuteSqlAsync(addEmpStoredProcedureExecute);
            return true;
        }

        public async Task<Models.Employee> GetEmployee(int employeeId)
        {
            try
            {
                Models.Employee employee = _dbContext.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();

                return employee;

            }
            catch (Exception ex)
            {
                return null;
                //throw;
            }
        }

        public async Task<List<Models.Employee>> GetSubordinates(int managerId)
        {
            try
            {
                return new List<Models.Employee>();
            }
            catch (Exception ex)
            {
                return null;
                
            }
        }
    }
}
