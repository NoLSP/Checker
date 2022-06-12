using TaskChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Helpers
{
    public abstract class TestsEngine
    {
        public static TestsEngine ObtainEngine(ProgrammingLanguage programmingLanguage)
        {
            return ObtainEngine(programmingLanguage.Name);
        }

        public static TestsEngine ObtainEngine(string programmingLanguage)
        {
            switch (programmingLanguage)
            {
                case "JavaScript":
                    return new JavaScriptTestsEngine();
                case "cmd":
                    return new CMDTestsEngine();
                case "bash":
                    return new BashTestsEngine();
                default: 
                    return null;
            }
        }

        public abstract Task<bool> RunTest(string studentSolutionFilePath, Test teacherTest);
    }
}
