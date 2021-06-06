using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Db.Operations
{
    public class TicketRepository
    {
        public List<TicketModel> GetTickets()
        {
            using (var context = new TicketSystemDBEntities())
            {
                var dbResult = context.Ticket.ToList();
                var tickets = ListTicketToListTicketModel(dbResult);

                return tickets;
            }
        }

        public List<TicketModel> GetTickets(string search)
        {
            using (var context = new TicketSystemDBEntities())
            {
                var dbResult = context.Ticket.Where(tic => tic.Description.Contains(search)).ToList();
                var tickets = ListTicketToListTicketModel(dbResult);
                return tickets;
            }
        }
        public List<TicketGroupByProjectModel> GetTicketsGroupByProject()
        {
            using (var context = new TicketSystemDBEntities())
            {
                var dbResult = context.Database.SqlQuery<TicketGroupByProjectModel>("SELECT[ProjectName], COUNT(*) as 'TicketCount' FROM[dbo].[Ticket] GROUP BY[ProjectName] ORDER BY[ProjectName]").ToList();
                return dbResult;
            }
        }
        private List<TicketModel> ListTicketToListTicketModel(List<Ticket> dbResult)
        {
            var tickets = new List<TicketModel>();

            foreach (var tic in dbResult)
                tickets.Add(new TicketModel
                {
                    TicketId = tic.TicketId,
                    ProjectName = tic.ProjectName,
                    DepartmentId = tic.DepartmentId,
                    EmployeeId = tic.EmployeeId,
                    Description = tic.Description,
                    DateTime = tic.DateTime,
                    Department = new DepartmentModel
                    {
                        DepartmentId = tic.DepartmentId,
                        DepartmentName = GetDepartments().Where(x => x.DepartmentId == tic.DepartmentId).FirstOrDefault().DepartmentName
                    },
                    Employee = new EmployeeModel
                    {
                        EmployeeId = tic.EmployeeId,
                        EmployeeName = GetEmployees().Where(x => x.EmployeeId == tic.EmployeeId).FirstOrDefault().EmployeeName
                    }
                }
                );

            return tickets;
        }

        public List<DepartmentModel> GetDepartments()
        {
            using (var context = new TicketSystemDBEntities())
            {
                var dbResult = context.Department.ToList();
                var departments = new List<DepartmentModel>();

                foreach (var dep in dbResult)
                    departments.Add(new DepartmentModel {
                        DepartmentId = dep.DepartmentId, 
                        DepartmentName = dep.DepartmentName}
                    );

                return departments;
            }
        }

        public List<EmployeeModel> GetEmployees()
        {
            using (var context = new TicketSystemDBEntities())
            {
                var dbResult = context.Employee.ToList();
                var employees = new List<EmployeeModel>();

                foreach (var emp in dbResult)
                    employees.Add(new EmployeeModel
                    {
                        EmployeeId = emp.EmployeeId,
                        EmployeeName = emp.EmployeeName,
                        DepartmentId = emp.DepartmentId
                    }
                    );

                return employees;
            }
        }

        public int AddTicket(TicketModel model)
        {
            using (var context = new TicketSystemDBEntities())
            {
                Ticket newTicket = new Ticket()
                {
                    ProjectName = model.ProjectName,
                    DepartmentId = model.DepartmentId,
                    EmployeeId = model.EmployeeId,
                    Description = model.Description,
                    DateTime = model.DateTime
                };

                context.Ticket.Add(newTicket);
                context.SaveChanges();

                return newTicket.TicketId;
            }
        }
    }
}
