using AddressBook.Entity;
using AddressBook.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application.Commands
{
    public class CreateNewEmployeeCommandHandler : IRequestHandler<CreateNewEmployeeCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateNewEmployeeCommandHandler(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(CreateNewEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee Employee = new Employee();
            Employee.FullName = request.FullName;
            Employee.Email = request.Email;
            Employee.MobileNumber = request.MobileNumber;
            Employee.Address = request.Address;
            Employee.Age = request.Age;
            Employee.DateOfBirth = request.DateOfBirth;
            Employee.DepartmentId = request.DepartmentId;
            Employee.JobTitleId = request.JobTitleId;
            Employee.LogoImageName = request.LogoImageName;
            Employee.LogoImageStorageFileName = request.LogoImageStorageFileName;
            Employee.UserId = request.UserId;
            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();
            return Employee.Id;
        }
    }
}