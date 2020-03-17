using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioNUnit.Test.Utils
{
    public static class Helpers
    {
        public static bool ValidarMensagemSucesso(IWebDriver driver, string css, string mensagemSucesso)
        {
            bool ok = false;
            bool mensagemApareceu;
            bool aMensagemNaoAparecer;

            do
            {
                var by = By.CssSelector(css);
                mensagemApareceu = driver.TryFindElement(by, out IWebElement balaoMensagem);
                aMensagemNaoAparecer = !mensagemApareceu;

                if (mensagemApareceu)
                {
                    ok = balaoMensagem.Text.Contains(mensagemSucesso);
                }

            } while (aMensagemNaoAparecer);

            return ok;
        }
    }
}
