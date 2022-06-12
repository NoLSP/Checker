using Jint;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TaskChecker.Models;

namespace TaskChecker.Helpers
{
    public class CMDTestsEngine : TestsEngine
    {
        public async override Task<bool> RunTest(string studentSolutionFilePath, Test teacherTest)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = studentSolutionFilePath,
                        Arguments = teacherTest.InputValue,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                        WorkingDirectory = Directory.GetCurrentDirectory()
                    }
                };

                process.Start();

                var result = process.StandardOutput.ReadToEnd();
                result = result.Trim();

                return result == teacherTest.ExpectedResult;
            }
            catch (Exception Ex)
            {
                //Тут можно будет выводить ошибку
                return false;
            }
        }
    }
}
