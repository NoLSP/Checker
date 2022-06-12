using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace TaskChecker.Models
{
    public partial class ProgrammingLanguage
    {
        public static ProgrammingLanguage Find(DataContext dataContext, string name)
        {
            return dataContext.Set<ProgrammingLanguage>()
                .FirstOrDefault(x => x.Name == name);
        }

        public static ProgrammingLanguage Obtain(DataContext dataContext, string name, string title, string fileExtensions)
        {
            var language = Find(dataContext, name);

            if (language == null)
            {
                language = new ProgrammingLanguage()
                {
                    Name = name,
                    Title = title,
                    FileExtensions = fileExtensions
                };

                dataContext.ProgrammingLanguages.Add(language);
                dataContext.SaveChanges();
            }

            return language;
        }

        public static ProgrammingLanguage JavaScript(DataContext dataContext)
        {
            var state = Find(dataContext, "JavaScript");

            if (state == null)
                state = Obtain(dataContext, "JavaScript", "JavaScript", ".js");

            return state;
        }

        public static ProgrammingLanguage CMD(DataContext dataContext)
        {
            var state = Find(dataContext, "cmd");

            if (state == null)
                state = Obtain(dataContext, "cmd", "CMD", ".cmd");

            return state;
        }

        public static void Install(DataContext dataContext)
        {
            JavaScript(dataContext);
            CMD(dataContext);
        }
    }
}
