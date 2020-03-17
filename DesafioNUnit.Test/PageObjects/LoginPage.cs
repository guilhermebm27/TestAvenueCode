using DesafioNUnit.Test.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace DesafioNUnit.Test.PageObjects
{

    public class LoginPage
    {
        private readonly IWebDriver _webDriver;
        private readonly string Host = "https://qa-test.avenuecode.com/";
        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement AutenticacaoEmail;

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement AutenticacaoPassword;

        [FindsBy(How = How.CssSelector, Using = "[class='btn btn-primary']")]
        public IWebElement enterBtn;

        public void OpenTaesaWebSite()
        {
            _webDriver.LoadPage(TimeSpan.FromSeconds(20), url: Host);
            _webDriver.Manage().Window.Maximize();
        }
        public void VerificarDirecionamentoTelaDeAutenticacao()
        {
            Assert.AreEqual(Host + "users/sign_in", _webDriver.Url);
        }

        [Obsolete]
        public void ClicarBotaoInicialAutenticao()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var enterBtnInicialAutenticacao = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='btn btn-lg btn-primary']")));
            enterBtnInicialAutenticacao.Click();
        }

        [Obsolete]
        public void DadosParaLogar(Table table)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var AutenticacaoEmail = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user_email")));
            AutenticacaoEmail.SendKeys(table.Rows[0][0].ToString());

            var AutenticacaoPassword = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user_password")));
            AutenticacaoPassword.SendKeys(table.Rows[0][1].ToString());
        }

        [Obsolete]
        public void ClicarLogin()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var enterBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='btn btn-primary']")));

            enterBtn.Click();
        }
        public void ValidarPaginaInicial()
        {
            Assert.AreEqual(Host, _webDriver.Url);
        }
     
    }
}
