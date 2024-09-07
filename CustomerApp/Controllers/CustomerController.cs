using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly APIGateway apiGateway;
        public CustomerController(APIGateway ApiGateway)
        {
            this.apiGateway = ApiGateway;
        }
        public IActionResult Index()
        {
            List<Customer> customers = apiGateway.ListCustomers();

            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Customer customer = new Customer();

            return View(customer);
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            apiGateway.CreateCustomer(customer);

            return RedirectToAction("index");
        }
        public IActionResult Details(int Id)
        {
            Customer customer = apiGateway.GetCustomer(Id);

            return View(customer);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Customer customer = apiGateway.GetCustomer(Id);

            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            apiGateway.UpdateCustomer(customer);

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer customer = apiGateway.GetCustomer(id);

            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            apiGateway.DeleteCustomer(customer.id);

            return RedirectToAction("index");
        }
    }
}
