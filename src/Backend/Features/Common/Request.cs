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
     #region Employ

    public class EmployeesListQuery : IRequest<List<EmployeesListQueryResponse>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    #endregion 