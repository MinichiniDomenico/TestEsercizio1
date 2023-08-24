namespace Backend.Features.Get.Suppliers;

internal class SupplierListQueryHandler : IRequestHandler<SupplierListQuery, List<SupplierListQueryResponse>>
{
    private readonly BackendContext context;

    public SupplierListQueryHandler(BackendContext context)
    {
        this.context = context;
    }

    public async Task<List<SupplierListQueryResponse>> Handle(SupplierListQuery request, CancellationToken cancellationToken)
    {
        var query = context.Suppliers.AsQueryable();
        if (!string.IsNullOrEmpty(request.Name))
            query = query.Where(q => q.Name.ToLower().Contains(request.Name.ToLower()));

        var data = await query.OrderBy(q => q.Name).ToListAsync(cancellationToken);
        var result = new List<SupplierListQueryResponse>();

        foreach (var item in data)
            result.Add(new SupplierListQueryResponse
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                Email = item.Email,
                Phone = item.Phone,
            });

        return result;
    }
}