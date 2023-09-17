using AddressBook.Entity;
using AddressBook.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application.Commands
{
    public class CreateNewDepartmentCommandHandler : IRequestHandler<CreateNewDepartmentCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateNewDepartmentCommandHandler(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(CreateNewDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department Department = new Department();
            Department.NameAr = request.NameAr;
            Department.NameEn = request.NameEn;
            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();
            return Department.Id;
        }
    }
}