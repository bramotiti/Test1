using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Test1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await autheticate();
        }
        static async Task autheticate()
        {
            HttpClient client = new HttpClient();
            var request = new {
                Url = "https://testonline.botswanapost.co.bw/api/api/v1/ApiUsers/authenticate",
                Body=new
                {
                    username= "Boago",
                    password= "Lion4Reason"
                }
            };

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Console.WriteLine(value);
        }
        static async Task register()
        {
            HttpClient client = new HttpClient()    ;
            var request = new
            {
                Url = "https://testonline.botswanapost.co.bw/api/api/v1/ApiUsers/register",
                user = new User
                {
                    username = "Boago",
                    password = "Lion4Reason",
                    role="user"
                }
            };

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.user));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Console.WriteLine(value);
            Console.WriteLine(response.EnsureSuccessStatusCode());
        }

        static async Task getCustomerAddress()
        {
            HttpClient httpClient = new HttpClient();
            var Url = "https://testonline.botswanapost.co.bw/api/api/v1/customeraddresses";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEwMDUiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2MDUwOTg0NTksImV4cCI6MTYwNTcwMzI1OSwiaWF0IjoxNjA1MDk4NDU5fQ.TWasgQVWsgXsht5ABbGFp826QE76IQiIyZZ8gpjznVM");
            var response=await httpClient.GetAsync(Url);
            Console.WriteLine(response.StatusCode);
        }

    }

}
