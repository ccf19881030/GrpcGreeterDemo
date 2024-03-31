using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services
{
    public class CustomerService : Customer.CustomerBase
    { 
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            var customerId = request.UserId;
            var customerModel = new CustomerModel();
            if (customerId == 1)
            {
                customerModel.FirstName = "Steve";
                customerModel.LastName = "Jobs";
            } else if (customerId == 2)
            {
                customerModel.FirstName = "Bill";
                customerModel.LastName = "Gates";
            } else if (customerId == 3)
            {
                customerModel.FirstName = "Ami";
                customerModel.LastName = "Smith";
            }
            return Task.FromResult(customerModel);
        }

        public override async Task GetNewCustomers(
            NewCustomerRequest request,
            IServerStreamWriter<CustomerModel> responseStream,
            ServerCallContext context)
        {
            //return base.GetNewCustomers(request, responseStream, context);
            // 下面使用列表模拟实际数据，实际生产环境中一般采用数据库存储数据
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "Tim",
                    LastName = "Corey",
                    EmailAddress = "tim@iamtimcorey.com",
                    Age = 41,
                    IsAlive = true
                },
                new CustomerModel
                {
                    FirstName = "Sue",
                    LastName = "Storm",
                    EmailAddress = "sue@stormy.net",
                    Age = 28,
                    IsAlive = false
                },
                new CustomerModel
                {
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bilbo@middleearth.net",
                    Age = 117,
                    IsAlive = false
                }
            };

            foreach (var customerItem in customers)
            {
                // await Task.Delay(1000); // 延时1秒
                await responseStream.WriteAsync(customerItem);
            } 
        }
    }
}
