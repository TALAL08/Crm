using Crm.Models;
using Crm.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public EmployeeController()
        {
            _Context = new ApplicationDbContext();
        }

        // GET: Employee
        public ActionResult New()
        {



            var ViewModel = new NewEmployeeViewModel
            {
                Designations = _Context.Designations.ToList(),
                Stores = _Context.Stores.ToList()



            };


            return View("EmployeeForm",ViewModel);
        }

        public ActionResult Edit(int Id)
        {
            var Employee = _Context.Employees
                .Include(e => e.EducationalPersonalDetails)
                .Include(e => e.AccountDetails)
                .Include(e => e.Designation)
                .Single(e => e.Id == Id);
            
            var ViewModel = new NewEmployeeViewModel
            {
                Employee = Employee,
                Designations = _Context.Designations.ToList(),
                Stores = _Context.Stores.ToList()
            };

            return View("EmployeeForm", ViewModel);
        }

        public ActionResult Save(Employee employee)
        {
            var Employee = _Context.Employees
                .Include(e => e.AccountDetails)
                .Include(e => e.EducationalPersonalDetails)
                .SingleOrDefault(e => e.Id == employee.Id);


            if (Employee != null)
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

            else
            {

                var AccountDetail = new EmployeeAccountDetails
                {
                    BankName = employee.AccountDetails.BankName,
                    AccountNo = employee.AccountDetails.AccountNo,
                    IFSC = employee.AccountDetails.IFSC

                };
                _Context.EmployeeAccountDetails.Add(AccountDetail);


                var Detail = new EmployeeDetails
                {
                    GuardianName = employee.EducationalPersonalDetails.GuardianName,
                    GuardianRealation = employee.EducationalPersonalDetails.GuardianRealation,
                    GuardianContactNo = employee.EducationalPersonalDetails.GuardianContactNo,
                    IdCardNo = employee.EducationalPersonalDetails.IdCardNo,
                    Qalificaiton = employee.EducationalPersonalDetails.Qalificaiton,
                    WorkExperience = employee.EducationalPersonalDetails.WorkExperience,
                    WorkFeild = employee.EducationalPersonalDetails.WorkFeild
                };

                _Context.EmployeeDetails.Add(Detail);

                var NewEmployee = new Employee
                {
                    Name = employee.Name,
                    StoreId = employee.StoreId,
                    Address = employee.Address,
                    ContactNo = employee.ContactNo,
                    DesignationId = employee.DesignationId,



                };
                _Context.Employees.Add(NewEmployee);

            }
                _Context.SaveChanges();


           return RedirectToAction("Index", "Home");
           

        }

        public ActionResult ListOfEmployees()
        {   
            
            return View();
        }


    }
}