using Jint;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TaskChecker.Models;

namespace TaskChecker.Helpers
{
    public class BashTestsEngine : TestsEngine
    {
        public async override Task<bool> RunTest(string studentSolutionFilePath, Test teacherTest)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:44330")
                };

                using var stream = File.OpenRead(studentSolutionFilePath);
                using var request = new HttpRequestMessage(HttpMethod.Post, "/Api/Test");
                using var content = new MultipartFormDataContent
                {
                    { new StreamContent(stream), "file", new FileInfo(studentSolutionFilePath).Name },
                    { new StringContent("api"), "login" },
                    { new StringContent("password"), "password" },
                    { new StringContent(teacherTest.InputValue), "inputValue" },
                    { new StringContent(teacherTest.ExpectedResult), "expectedValue" },
                };

                request.Content = content;

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContent responseContent = response.Content;
                    var jsonString = await responseContent.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RequestResult>(jsonString);

                    if (result.Success && result.TestResult)
                    {
                        return true;
                    }
                }

                return false;

            }
            catch (Exception Ex)
            {
                //Тут можно будет выводить ошибку
                return false;
            }
        }
    }
}
