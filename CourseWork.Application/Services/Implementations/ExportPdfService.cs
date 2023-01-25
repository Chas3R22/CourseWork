using CourseWork.Application.Services.Interfaces;
using CourseWork.Domain.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Implementations
{
    public class ExportPdfService : IExportPdfService
    {
        private readonly IConverter _converter;
        private readonly ICountryService _countryService;
        private readonly IIndustryService _industryService;
        private readonly IOrganizationService _organizationService;

        public ExportPdfService(IConverter converter, ICountryService countryService, IIndustryService industryService, IOrganizationService organizationService)
        {
            _converter = converter;
            _countryService = countryService;
            _industryService = industryService;
            _organizationService = organizationService;
        }

        public void CreatePdf()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 15, Bottom = 20 },
                DocumentTitle = "PDF Data",
                Out = "Data.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8" },
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);
        }

        private string GetHTMLString()
        {
            return

        $@"<html>
            <head>
                <style>
                    .header {{
                        text-align: center;
                        color: orange;
                        padding-bottom: 25px;
                    }}

                    table {{
                        width: 75%;
                        margin: 0 auto;
                    }}

                    td, th {{
                        border: 1px solid black;
                        padding: 20px;
                        font-size: 25px;
                        text-align: center;
                    }}

                    table th {{
                        background-color: orange;
                        color: gray;
                    }}
                </style>
            </head>
            <body>
                <div class='header'>
                    <h1>PDF Document</h1>
                </div>
                <table>
                    <thead>
                        <th>Data Title</th>
                            <th>Count</th>
                    </thead>
                    <tr>
                        <td>{nameof(Country)}</td>
                        <td>{_countryService.GetCount()}</td>
                    </tr>
                    <tr>
                        <td>{nameof(Industry)}</td>
                        <td>{_industryService.GetCount()}</td>
                    </tr>
                    <tr>
                        <td>{nameof(Organization)}</td>
                        <td>{_organizationService.GetCount()}</td>
                    </tr>
                </table>
            </body>
        </html>";
        }
    }
}
