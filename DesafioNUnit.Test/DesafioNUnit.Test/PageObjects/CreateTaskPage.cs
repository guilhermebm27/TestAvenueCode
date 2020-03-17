using DesafioNUnit.Test.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace DesafioNUnit.Test.PageObjects
{
    public class CreateTaskPage
    {
        private readonly IWebDriver _webDriver;

        public CreateTaskPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Obsolete]
        public void ClicarMyTask()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var clicarMyTask = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my_task")));
            clicarMyTask.Click();
        }

        [Obsolete]
        public void PreencherCampo(Table table)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var preencherCampo = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("new_task")));
            preencherCampo.SendKeys(table.Rows[0][0].ToString());
        }

        [Obsolete]
        public void ClicarInserirTarefa()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var insertTask = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='input-group-addon glyphicon glyphicon-plus']")));
            insertTask.Click();
        }

        [Obsolete]
        public void ClicarRemoverTarefa()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var removerTask = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='btn btn-xs btn-danger']")));
            Helpers.Esperar(2);
            removerTask.Click();
        }
        [Obsolete]
        public void ValidaLimiteMinimoDeCaracter()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var preencherCampo = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("new_task")));
            string texto = preencherCampo.GetAttribute("value");

            try
            {
                Assert.IsFalse(texto.Length <= 3);
            }
            catch (Exception)
            {
                throw new StaleElementReferenceException("Campo deve ser preenchido com pelo menos três caracteres para que o usuário possa inseri-la e o caso de teste não será executado");
            }

        }
            [Obsolete]
        public void ValidaLimiteMaximoDeCaracter()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var preencherCampo = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("new_task")));
            string texto = preencherCampo.GetAttribute("value");

            try
            {
                Assert.IsFalse(texto.Length >= 250);
            }
            catch (Exception)
            {
                throw new StaleElementReferenceException("Campo deve ter mais de 250 caracteres para que o usuário possa inseri-la e o caso de teste não será executado");
            }

        }

    }
}
