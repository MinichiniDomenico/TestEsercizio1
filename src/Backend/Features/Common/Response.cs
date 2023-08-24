    #region Customer
    public class CustomerListQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Iban { get; set; } = "";
        public string Code { get; set; } = "";
        public string Description { get; set; } = "";
    }
    #endregion
     #region Employ
    public class EmployeesListQueryResponse
    {
        public int Id { get; set; }
        public string Code { get; internal set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public EmployeesListQueryResponseDepartment? Department { get; set; }
    }

    public class EmployeesListQueryResponseDepartment
    {
        public string Code { get; set; } = "";
        public string Description { get; set; } = "";
    }
    #endregion

    #region Suppliers
    public class SupplierListQuery : IRequest<List<SupplierListQueryResponse>>
    {
        public string? Name { get; set; }
    }

    public class SupplierListQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
    }
    #endregion