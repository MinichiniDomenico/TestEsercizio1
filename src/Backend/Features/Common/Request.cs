#region Customer
    public class CustomerListXmlQuery : IRequest<string>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
    public class CustomerListQuery : IRequest<List<CustomerListQueryResponse>>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
    #endregion