﻿using CustomerApp.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
namespace CustomerApp
{
    public class APIGateway
    {
        private string url = "https://localhost:7260/api/Customer";

        private HttpClient httpClient = new HttpClient();

        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();

            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {

                    var data = JsonConvert.DeserializeObject<List<Customer>>(result);

                    if (data != null)
                        customers = data;
                }
                else
                {
                    throw new Exception("Error Occurred at the API Endpoint, Error Info. " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }

            return customers;
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(customer);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<Customer>(result);

                    if (data != null)
                        customer = data;
                }
                else
                {
                    throw new Exception("Error Occurred at the API Endpoint, Error Info. " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }

            return customer;
        }
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();

            url = url + "/" + id;

            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<Customer>(result);

                    if (data != null)
                    {
                        customer = data;
                    }
                    else
                    {
                        throw new Exception("Error Occurred at the API Endpoint, Error Info. " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }

            return customer;
        }
        public void UpdateCustomer(Customer customer)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            url = url + "/" + customer.id;

            string json = JsonConvert.SerializeObject(customer);

            try
            {
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    throw new Exception("Error Occurred at the API Endpoint, Error Info. " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }

            return;
        }
        public void DeleteCustomer(int id)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            url = url + "/" + id;

            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    throw new Exception("Error Occurred at the API Endpoint, Error Info. " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred at the API Endpoint, Error Info. " + ex.Message);
            }
            finally { }

            return;
        }
    }
}
