using System.Xml.Serialization;
internal class CustomerListQueryHandler : IRequestHandler<CustomerListQuery, List<CustomerListQueryResponse>>
    {
        private readonly BackendContext context;

        public CustomerListQueryHandler(BackendContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Restituisce l'elenco dei customer
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Email"></param>
        /// <returns>Lista di oggetti customer inclusi codice e descrizione categoria</returns>
        public async Task<List<CustomerListQueryResponse>> Handle(CustomerListQuery request, CancellationToken cancellationToken)
        {
            var query = context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Nome))
                query = query.Where(q => q.Name.ToLower().Contains(request.Nome.ToLower()));
            if (!string.IsNullOrWhiteSpace(request.Email))
                query = query.Where(q => q.Email.ToLower().Contains(request.Email.ToLower()));

            query = query.Include(i => i.CustomerCategory);


            var data = await query.ToListAsync(cancellationToken);
            List<CustomerListQueryResponse> result = new();

            foreach (var item in data)
                result.Add(new CustomerListQueryResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Email = item.Email,
                    Phone = item.Phone,
                    Iban = item.Iban,
                    Code = item.CustomerCategory?.Code ?? "",
                    Description = item.CustomerCategory?.Description ?? "",
                });

            return result;
        }
    }
    
     internal class CustomerListXmlExtractQueryHandler : IRequestHandler<CustomerListXmlQuery, string>
    {
        private readonly BackendContext context;

        public CustomerListXmlExtractQueryHandler(BackendContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Restituisce una stringa in formato xml contenente l'elenco dei customer.
        /// La funzione è puramente dimostrativa, può risultare ridindande in quanto può essere sfruttata solo la precedente e poi gestire nella pagina web la serializzazione ed 
        /// il download con javascript oppure utilizzando il componente di blazor.
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Email"></param>
        /// <returns>Una stringa in formato xml contenente la lista di oggetti customer inclusi codice e descrizione categoria</returns>
        public async Task<string> Handle(CustomerListXmlQuery request, CancellationToken cancellationToken)
        {
            var query = context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Nome))
                query = query.Where(q => q.Name.ToLower().Contains(request.Nome.ToLower()));
            if (!string.IsNullOrWhiteSpace(request.Email))
                query = query.Where(q => q.Email.ToLower().Contains(request.Email.ToLower()));

            query = query.Include(i => i.CustomerCategory);

            var data = await query.ToListAsync(cancellationToken);
            List<CustomerListQueryResponse> customersList = new();

            foreach (var item in data)
                customersList.Add(new CustomerListQueryResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Email = item.Email,
                    Phone = item.Phone,
                    Iban = item.Iban,
                    Code = item.CustomerCategory?.Code ?? "",
                    Description = item.CustomerCategory?.Description ?? "",
                });

            var serializer = new XmlSerializer(customersList.GetType());

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, customersList);
                return writer.ToString();
            }
        }
    }    