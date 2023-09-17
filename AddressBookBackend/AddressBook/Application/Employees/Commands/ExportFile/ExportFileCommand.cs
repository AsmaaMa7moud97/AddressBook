using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AddressBook.Application
{

    public record ExportFileCommand() : IRequest<FileContentResult>;
}
