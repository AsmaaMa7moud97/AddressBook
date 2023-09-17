using AddressBook.Entity;
using AddressBook.Infrastructure.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application.Commands
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteDepartmentCommandHandler(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _context.Departments.Where(x => x.Id == request.Id).FirstOrDefault();
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}