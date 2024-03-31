using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcGreeterClient;

// See https://aka.ms/new-console-template for more information

// The port number must match the port of the gRPC server.
//using var channel = GrpcChannel.ForAddress("https://localhost:7223");
//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(
//                  new HelloRequest{ Name = "GreeterClient" });
//Console.WriteLine("Greeeting: " + reply.Message);

//reply = await client.SayHelloAgainAsync(
//              new HelloRequest { Name = "GreeterClient Async " });
//Console.WriteLine("Greeeting: " + reply.Message);

var channel = GrpcChannel.ForAddress("https://localhost:7223");
var customerClient = new Customer.CustomerClient(channel);
var clientRequestd = new CustomerLookupModel { UserId = 2 };
var customer = await customerClient.GetCustomerInfoAsync(clientRequestd);
Console.WriteLine($"{customer.FirstName } {customer.LastName}");

Console.WriteLine();
Console.WriteLine("New Customer List");
Console.WriteLine();

using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
{
    while (await call.ResponseStream.MoveNext())
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine($"{currentCustomer.FirstName} { currentCustomer.LastName} { currentCustomer.EmailAddress }");
    }
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();


