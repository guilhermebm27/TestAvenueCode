using BoDi;
using DesafioNUnit.Test.Base;
using DesafioNUnit.Test.PageObjects;
using DesafioNUnit.Test.Utils;
using System;
using TechTalk.SpecFlow;

namespace DesafioNUnit.Test.Specs
{
    [Binding]
    public class LoginSteps : PageBase
    {
        private readonly LoginPage log;
        private readonly MetodosComuns mc;
        private readonly TestEvidence evidenciaTeste;

        public LoginSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
            log = new LoginPage(Driver);
            mc = new MetodosComuns(Driver);
            evidenciaTeste = new TestEvidence(Driver);
        }

        [Given(@"que navego para a página inicial do ToDo App")]
        public void DadoQueNavegoParaAPaginaInicialDoToDoApp()
        {
            log.OpenTaesaWebSite();
        }

        [Given(@"clico no botão Sign In")]
        [Obsolete]
        public void DadoClicoNoBotaoSignIn()
        {
            log.ClicarBotaoInicialAutenticao();
        }


        [When(@"informar os dados para logar")]
        [Obsolete]
        public void QuandoInformarOsDadosParaLogar(Table table)
        {
            log.DadosParaLogar(table);
        }

        [When(@"clicar no botão Sign In")]
        [Obsolete]
        public void QuandoClicarNoBotaoSignIn()
        {
            log.ClicarLogin();
        }

        [When(@"o usuário informar os dados incorretos para autenticação")]
        [Obsolete]
        public void QuandoOUsuarioInformarOsDadosIncorretosParaAutenticacao(Table table)
        {
            log.DadosParaLogar(table);
        }

        [When(@"o usuário deixar de informar os campos para autenticação")]
        [Obsolete]
        public void QuandoOUsuarioDeixarDeInformarOsCamposParaAutenticacao(Table table)
        {
            log.DadosParaLogar(table);
        }

        [Then(@"sou direcionado para a tela de login")]
        public void EntaoSouDirecionadoParaATelaDeLogin()
        {
            log.VerificarDirecionamentoTelaDeAutenticacao();
        }

        [Then(@"usuário é direncionado para a tela inicial e a seguinte mensagem será exibida ""(.*)""")]
        public void EntaoUsuarioEDirencionadoParaATelaInicialEASeguinteMensagemSeraExibida(string assert)
        {
            mc.Valida("[class='alert alert-info']", assert);
            log.ValidarPaginaInicial();
            evidenciaTeste.Capture("AutenticacaoComSucesso");
        }

        [Then(@"a seguinte mensagem será exibida ""(.*)""")]
        public void EntaoASeguinteMensagemSeraExibida(string assert)
        {
            mc.Valida("[class='alert alert-warning']", assert);
            evidenciaTeste.Capture("ErroDeAutenticacao");
        }
    }
}
