using AddressBook.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application
{
    public class ExportFileHandler : IRequestHandler<ExportFileCommand, FileContentResult>
    {
        private readonly IMediator _mediator;
       
        public ExportFileHandler(IMediator mediator
           )
        {
            _mediator = mediator;
          
        }
        public async Task<FileContentResult> Handle(ExportFileCommand request, CancellationToken cancellationToken)
        {
            byte[] result=null;
            var txtName = "Employees";
           
            var res= await _mediator.Send(new GetSearchEmployeesQuery());
            var employees = res.ToList();
             result = DownLoadExcelSheet(employees);
               var fileContentResult = new FileContentResult(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {

                    FileDownloadName = $"{txtName}.xlsx"
                };
                return fileContentResult;
           
            }
           
        private byte[] DownLoadExcelSheet(List<EmployeeModel> input)
        {
            using (var pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
                ws.Cells[1, 1].Value = "Employee No";
                ws.Cells[1, 2].Value = "FullName";
                ws.Cells[1, 3].Value = "Email";
                ws.Cells[1, 4].Value ="Mobile Number";
                ws.Cells[1, 5].Value = "Birth Date";
                ws.Cells[1, 6].Value = "Address";
                ws.Cells[1, 7].Value = "Age";
                ws.Cells[1, 8].Value = "Job Name";
                ws.Cells[1, 9].Value = "Department Name";
                ws.Cells["A2"].LoadFromCollection(input, false, OfficeOpenXml.Table.TableStyles.Light1);

                var start = ws.Dimension.Start;
                var end = ws.Dimension.End;
                using (ExcelRange rng = ws.Cells["A1:I1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                    rng.Style.Font.Color.SetColor(Color.White);
                }

                using (ExcelRange rng = ws.Cells[$"A1:I{end.Row}"])
                {
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                ws.Cells[$"E2:E{end.Row}"].Style.Numberformat.Format = "dd/MM/yyyy";
                ws.Cells.AutoFitColumns();
                return pck.GetAsByteArray();

            }
        }
       
        }
}
