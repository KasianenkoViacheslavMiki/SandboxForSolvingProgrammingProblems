using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxForSolvingProgrammingProblems.Infrastructure.Content
{

    static class SupportedProgrammingLanguages
    {
        //Хардкод на те які мови підтримуються
        public static ObservableCollection<Language> SupportedLanguages()
        {
            return new ObservableCollection<Language>
            (
                new Language[]
                {
                    new Language { NameLanguage = "C", LangArgument = "C" },
                    new Language { NameLanguage = "C++14", LangArgument = "CPP14" },
                    new Language { NameLanguage = "C++17", LangArgument = "CPP17" },
                    new Language { NameLanguage = "Clojure", LangArgument = "CLOJURE" },
                    new Language { NameLanguage = "C#", LangArgument = "CSHARP" },
                    new Language { NameLanguage = "Go", LangArgument = "GO" },
                    new Language { NameLanguage = "Haskell", LangArgument = "HASKELL" },
                    new Language { NameLanguage = "Java 8", LangArgument = "JAVA8" },
                    new Language { NameLanguage = "Java 14", LangArgument = "JAVA14" },
                    new Language { NameLanguage = "JavaScript(Nodejs)", LangArgument = "JAVASCRIPT_NODE" },
                    new Language { NameLanguage = "Kotlin", LangArgument = "KOTLIN" },
                    new Language { NameLanguage = "Objective C", LangArgument = "OBJECTIVEC" },
                    new Language { NameLanguage = "Pascal", LangArgument = "PASCAL" },
                    new Language { NameLanguage = "Perl", LangArgument = "PERL" },
                    new Language { NameLanguage = "PHP", LangArgument = "PHP" },
                    new Language { NameLanguage = "Python 2", LangArgument = "PYTHON" },
                    new Language { NameLanguage = "Python 3", LangArgument = "PYTHON3" },
                    new Language { NameLanguage = "Python 3.8", LangArgument = "PYTHON3_8" },
                    new Language { NameLanguage = "R", LangArgument = "R" },
                    new Language { NameLanguage = "Ruby", LangArgument = "RUBY" },
                    new Language { NameLanguage = "Rust", LangArgument = "RUST" },
                    new Language { NameLanguage = "Scala", LangArgument = "SCALA" },
                    new Language { NameLanguage = "Swift", LangArgument = "SWIFT" },
                    new Language { NameLanguage = "TypeScript", LangArgument = "TYPESCRIPT" }
                }
            );
        }
    }
}
