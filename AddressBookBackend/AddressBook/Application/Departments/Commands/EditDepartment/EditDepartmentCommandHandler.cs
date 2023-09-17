using AddressBook.Entity;
using AddressBook.Infrastructure.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application.Commands
{
    public class EditDepartmentCommandHandler : IRequestHandler<EditDepartmentCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public EditDepartmentCommandHandler(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _context.Departments.Where(x => x.Id == request.Id).FirstOrDefault();
            department.NameAr = request.NameAr;
            department.NameEn = request.NameEn;
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department.Id;
        }
    }
}