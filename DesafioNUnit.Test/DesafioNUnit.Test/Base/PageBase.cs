using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioNUnit.Test.Base
{
    public class PageBase : IDisposable
    {
        protected IWebDriver Driver { get; }

        // Configuração e injeção de dependência do WebDriver
        public PageBase(IObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs(new ChromeDriver(), typeof(IWebDriver));
            Driver = objectContainer.Resolve<IWebDriver>();
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
