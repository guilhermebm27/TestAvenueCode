using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace DesafioNUnit.Test.PageObjects {
    public class CreateSubTaskPage
    {
        private readonly IWebDriver _webDriver;

        public CreateSubTaskPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Obsolete]
        public void VerificarExistenciaBotaoGerenciarSubTarefas()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(180));
                var subtarefas = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='btn btn-xs btn-primary ng-binding']")));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }

        }

        [Obsolete]
        public void ClicarEmSubTarefas()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(180));
            var subtarefas = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='btn btn-xs btn-primary ng-binding']")));
            subtarefas.Click();
        }

        [Obsolete]
        public void PreencherCampoDescrciaoSubtarefas(Table table)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

            var descricao = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("new_sub_task")));
            descricao.SendKeys(table.Rows[0][0].ToString());
        }

        [Obsolete]
        public void PreencherCamposSubtarefas(Table table)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

            var descricao = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("new_sub_task")));
            descricao.SendKeys(table.Rows[0][0].ToString());

            var vencimentoData = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("dueDate")));
            vencimentoData.Clear();
            vencimentoData.SendKeys(table.Rows[0][1].ToString());
        }

        [Obsolete]
        public void AdicionarSubtarefa()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

            var adicionarSubTarefa = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("add-subtask")));
            adicionarSubTarefa.Click();
        }

        [Obsolete]
        public void ValidaLimiteMaximoDeCaracterSubTarefa()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var preencherCampo = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("new_sub_task")));
            string texto = preencherCampo.GetAttribute("value");

            try
            {
                Assert.IsFalse(texto.Length >= 250);
            }
            catch (Exception)
            {
                throw new StaleElementReferenceException("Campo não pode ter mais de 250 caracteres para que o usuário possa inserir subtarefa, caso de teste não será executado");
            }

        }

        [Obsolete]
        public void VerificarExistenciaDosCamposDescricaoEVencimentoDeData()
        {
            
            try
            {
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
                var descricao = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("new_sub_task")));
                var vencimentoData = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("dueDate")));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
    
        }
    }
}