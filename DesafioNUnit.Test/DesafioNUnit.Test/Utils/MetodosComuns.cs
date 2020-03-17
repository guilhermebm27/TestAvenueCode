using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace DesafioNUnit.Test.Utils
{
    class MetodosComuns
    {
        private IWebDriver driver;
        public MetodosComuns(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool Valida(string css, string assert)
        {
            bool mensagemNotificacao = Helpers.ValidarMensagemSucesso(driver,css, mensagemSucesso: assert);
            return mensagemNotificacao;

        }
        public void VerificarSeTarefaFoiRemovidaCorretamente(string assert)
        {
            if (!driver.PageSource.Contains(assert))
            {

            }
            else
            {
                Sair();
                throw new StaleElementReferenceException("Tarefa não deveria exibir na tela");
            }
        }
        public bool ExisteTexto(string assert)
        {
            bool achouNome = driver.PageSource.Contains(assert);
            return achouNome;
        }
        public void verificarTitulo(string titulo)
        {
            Assert.AreEqual(driver.Title, titulo);
        }
        public void verificaURL(string url)
        {
            driver.LoadPage(TimeSpan.FromSeconds(15), url);

            if (!driver.Url.Equals(url))
            {
                Sair();
                throw new StaleElementReferenceException("Essa não é página inicial e o caso de teste não será executado");
            }
        }
        public void Sair()
        {
            driver.Quit();
        }

    }
}
