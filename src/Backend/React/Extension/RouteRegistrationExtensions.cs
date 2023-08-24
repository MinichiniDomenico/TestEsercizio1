using Backend.Features.Get.Employees;
using Backend.Features.Get.Suppliers;

namespace Backend;

static class RouteRegistrationExtensions
{
    public static void UseApiRoutes(this WebApplication app)
    {
        var apiGroup = app.MapGroup("api");

        apiGroup.MapGet("suppliers/get/list", async ([AsParameters]SupplierListQuery query, IMediator mediator) => await mediator.Send(query)).WithName("GetSuppliersList").WithOpenApi();
        apiGroup.MapGet("employees/get/list", async ([AsParameters]EmployeesListQuery query, IMediator mediator) => await mediator.Send(query)).WithName("GetEmployeesList").WithOpenApi();
        apiGroup.MapGet("customer/get/list", async ([AsParameters] CustomerListQuery query, IMediator mediator) => await mediator.Send(query)).WithName("GetCustomersList").WithOpenApi();
        apiGroup.MapGet("customer/get/xmlList", async ([AsParameters] CustomerListXmlQuery query, IMediator mediator) => await mediator.Send(query)).WithName("GetCustomerListXmlExtract").WithOpenApi();
    }
}
