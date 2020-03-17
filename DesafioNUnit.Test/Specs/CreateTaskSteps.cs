using BoDi;
using DesafioNUnit.Test.Base;
using DesafioNUnit.Test.PageObjects;
using DesafioNUnit.Test.Utils;
using System;
using TechTalk.SpecFlow;

namespace DesafioNUnit.Specs
{
    [Binding]
    public class CreateTaskSteps : PageBase
    {
        private readonly LoginPage log;
        private readonly MetodosComuns mc;
        private readonly TestEvidence evidenciaTeste;
        private readonly CreateTaskPage criarTarefa;

        public CreateTaskSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
            log = new LoginPage(Driver);
            mc = new MetodosComuns(Driver);
            evidenciaTeste = new TestEvidence(Driver);
            criarTarefa = new CreateTaskPage(Driver);
        }
        [Given(@"que o usuário esta autenticado no sistema")]
        [Obsolete]
        public void DadoQueOUsuarioEstaAutenticadoNoSistema(Table table)
        {
            log.OpenTaesaWebSite();
            log.ClicarBotaoInicialAutenticao();
            log.DadosParaLogar(table);
            log.ClicarLogin();
        }

        [When(@"acessar a tela inicial")]
        [Obsolete]
        public void QuandoAcessarATelaInicial()
        {
            mc.verificaURL("https://qa-test.avenuecode.com/");
        }

        [When(@"clicar em My Tasks")]
        [Obsolete]
        public void QuandoClicarEmMyTasks()
        {
            criarTarefa.ClicarMyTask();
        }

        [When(@"acessar na tela de My Tasks")]
        [Obsolete]
        public void QuandoAcessarNaTelaDeMyTasks()
        {
            criarTarefa.ClicarMyTask();
        }

        [When(@"informar os dados para inserir nova tarefa")]
        [Obsolete]
        public void QuandoInformarOsDadosParaInserirNovaTarefa(Table table)
        {
            criarTarefa.PreencherCampo(table);
        }

        [When(@"clicar em adicionar tarefa")]
        [Obsolete]
        public void QuandoClicarEmAdicionarTarefa()
        {
            criarTarefa.ClicarInserirTarefa();
        }

        [Then(@"o link ""(.*)"" deve ficar visivel para o usuário")]
        public void EntaoOLinkDeveFicarVisivelParaOUsuario(string assert)
        {
            mc.ExisteTexto(assert);
        }

        [Then(@"usuário é redirecionado para a tela de listagem de tarefas")]
        public void EntaoUsuarioERedirecionadoParaATelaDeListagemDeTarefas()
        {
            mc.verificaURL("https://qa-test.avenuecode.com/tasks");
        }

        [Then(@"é exibido uma mensagem com o nome do usuário conectado Hey ""(.*)"", this is your todo list for today:")]
        public void EntaoEExibidoUmaMensagemComONomeDoUsuarioConectadoHeyThisIsYourTodoListForToday(string assert)
        {
            mc.ExisteTexto("Hey," + assert + "this is your todo list for today:");
        }

        [Then(@"tarefa ""(.*)"" deve ser exibida na listagem")]
        public void EntaoTarefaDeveSerExibidaNaListagem(string assert)
        {
            mc.ExisteTexto(assert);
            evidenciaTeste.Capture("NewTask");
        }
        [Then(@"sistema deverá exibir crítica informando limite mínimo de caracteres")]
        [Obsolete]
        public void EntaoSistemaDeveraExibirCriticaInformandoLimiteMinimoDeCaracteres()
        {
            criarTarefa.ValidaLimiteMinimoDeCaracter();
        }

        [Then(@"sistema deverá exibir critica informando ao usuário limite maximo de caracteres")]
        [Obsolete]
        public void EntaoSistemaDeveraExibirCriticaInformandoAoUsuarioLimiteMaximoDeCaracteres()
        {
            criarTarefa.ValidaLimiteMaximoDeCaracter();
        }
    }
}
