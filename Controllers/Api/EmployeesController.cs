using Crm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crm.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private readonly ApplicationDbContext _Context;
        public EmployeesController()
        {
            _Context = new ApplicationDbContext();
        }

        // GET /Api/Employee

        public IHttpActionResult GetEmployees()
        {
            var Employees = _Context.Employees.Include(e => e.Store).Include(e => e.Designation).ToList();


            return Ok(Employees);
        }

        public IHttpActionResult GetEmployee(int Id)
        {
            var Employees = _Context.Employees.Include(e => e.Store).Include(e => e.Designation).Single(e => e.Id == Id);

            if (Employees == null)
                return BadRequest();
            
            return Ok(Employees);
        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (employee == null)
                return NotFound();

            _Context.Employees.Add(employee);

            return Created(Request.RequestUri + "/" + employee.Id, employee );
        }

        [HttpPut]
        public void UpdateEmployee(Employee employee)
        {
            var Employee = _Context.Employees.Include(e => e.Store).Include(e => e.Designation).Single(e => e.Id == employee.Id);

            if (Employee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            else
            {

                Employee.Name = employee.Name;
                Employee.StoreId = employee.StoreId;
                Employee.Address = employee.Address;
                Employee.ContactNo = employee.ContactNo;
                Employee.DesignationId = employee.DesignationId;
               

                Employee.EducationalPersonalDetails.GuardianName = employee.EducationalPersonalDetails.GuardianName;
                Employee.EducationalPersonalDetails.GuardianRealation = employee.EducationalPersonalDetails.GuardianRealation;
                Employee.EducationalPersonalDetails.GuardianContactNo = employee.EducationalPersonalDetails.GuardianContactNo;
                Employee.EducationalPersonalDetails.IdCardNo = employee.EducationalPersonalDetails.IdCardNo;
                Employee.EducationalPersonalDetails.Qalificaiton = employee.EducationalPersonalDetails.Qalificaiton;
                Employee.EducationalPersonalDetails.WorkExperience = employee.EducationalPersonalDetails.WorkExperience;
                Employee.EducationalPersonalDetails.WorkFeild = employee.EducationalPersonalDetails.WorkFeild;


                Employee.AccountDetails.BankName = employee.AccountDetails.BankName;
                Employee.AccountDetails.AccountNo = employee.AccountDetails.AccountNo;
                Employee.AccountDetails.IFSC = employee.AccountDetails.IFSC;

            }
            
        }

        [HttpDelete]
        public void DeleteEmployee(int Id)
        {
            var EmployeeInDb = _Context.Employees.Include(e => e.Store).Include(e => e.Designation).Single(e => e.Id == Id);

            var employeeDetails = _Context.EmployeeDetails.Single(e => e.Id == EmployeeInDb.EmployeeDetailsId);

            var employeeAccDetails = _Context.EmployeeAccountDetails.Single(e => e.Id == EmployeeInDb.EmployeeAccountDetailsId);


            _Context.Employees.Remove(EmployeeInDb);

            _Context.EmployeeDetails.Remove(employeeDetails);

            _Context.EmployeeAccountDetails.Remove(employeeAccDetails);

            

            _Context.SaveChanges();
            
        }



    }
}
