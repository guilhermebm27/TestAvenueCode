using System;
using BoDi;
using DesafioNUnit.Test.Base;
using DesafioNUnit.Test.PageObjects;
using DesafioNUnit.Test.Utils;
using TechTalk.SpecFlow;

namespace DesafioNUnit.Specs {
    [Binding]
    public class CreateSubTaskSteps : PageBase {

        private readonly LoginPage log;
        private readonly MetodosComuns mc;
        private readonly TestEvidence evidenciaTeste;
        private readonly CreateTaskPage criarTarefa;
        private readonly CreateSubTaskPage subTarefa;

        public CreateSubTaskSteps (IObjectContainer objectContainer) : base (objectContainer) 
        {
            log = new LoginPage (Driver);
            mc = new MetodosComuns (Driver);
            evidenciaTeste = new TestEvidence (Driver);
            criarTarefa = new CreateTaskPage (Driver);
            subTarefa = new CreateSubTaskPage(Driver);
        }
        [Given(@"que o usuário esteja autenticado no sistema")]
        [Obsolete]
        public void DadoQueOUsuarioEstejaAutenticadoNoSistema(Table table)
        {
            log.OpenTaesaWebSite();
            log.ClicarBotaoInicialAutenticao();
            log.DadosParaLogar(table);
            log.ClicarLogin();
        }
        [When(@"acessar a tela de minhas tarefas")]
        [Obsolete]
        public void QuandoAcessarATelaDeMinhasTarefas()
        {
            log.ValidarPaginaInicial();
            criarTarefa.ClicarMyTask();
            mc.verificaURL("https://qa-test.avenuecode.com/tasks");
        }
        [When(@"estou na tela de subtarefas")]
        [Obsolete]
        public void QuandoEstouNaTelaDeSubtarefas()
        {
            log.ValidarPaginaInicial();
            criarTarefa.ClicarMyTask();
            subTarefa.ClicarEmSubTarefas();
            mc.ExisteTexto("Editing Task");        
        }

        [When(@"preencho o campo descrição com mais de 250 caracteres")]
        [Obsolete]
        public void QuandoPreenchoOCampoDescricaoComMaisDe250Caracteres(Table table)
        {
            subTarefa.PreencherCampoDescrciaoSubtarefas(table);
        }

        [Then(@"sistema não deve permitir escrita com mais de 250 caracteres")]
        [Obsolete]
        public void EntaoSistemaNaoDevePermitirEscritaComMaisDe250Caracteres()
        {
            subTarefa.ValidaLimiteMaximoDeCaracterSubTarefa();
            evidenciaTeste.Capture("limiteDeCaracteres");
        }

        [When(@"preencho o formulário para cadastro de nova subtarefa")]
        [Obsolete]
        public void QuandoPreenchoOFormularioParaCadastroDeNovaSubtarefa(Table table)
        {
            subTarefa.PreencherCamposSubtarefas(table);
        }

        [When(@"clicar em adicionar")]
        [Obsolete]
        public void QuandoClicarEmAdicionar()
        {
            subTarefa.AdicionarSubtarefa();
        }

        [Then(@"sistema deve exibir subtarefa ""(.*)"" na parte inferior da caixa de diálogo modal")]
        public void EntaoSistemaDeveExibirSubtarefaNaParteInferiorDaCaixaDeDialogoModal(string assert)
        {
            mc.ExisteTexto(assert);
            evidenciaTeste.Capture("SubtarefaAdicionadaComSucesso");
        }
 
        [When(@"deixo de informar um dos campos obrigatórios")]
        [Obsolete]
        public void QuandoDeixoDeInformarUmDosCamposObrigatorios(Table table)
        {
            subTarefa.PreencherCamposSubtarefas(table);
        }

        [Then(@"Sistema não deve permitir adicionar subtarefa e com isso não deve exibir na parte inferior descrição ""(.*)""")]
        public void EntaoSistemaNaoDevePermitirAdicionarSubtarefaEComIssoNaoDeveExibirNaParteInferiorDescricao(string assert)
        {
            mc.ExisteTexto(assert);
            evidenciaTeste.Capture("SistemaNaoDeveExibirSubtarefa");
        }

        [Then(@"os campos descrição de vencimento de subtarefa devem ficar visiveis para o usuário")]
        [Obsolete]
        public void EntaoOsCamposDescricaoDeVencimentoDeSubtarefaDevemFicarVisiveisParaOUsuario()
        {
            subTarefa.VerificarExistenciaBotaoGerenciarSubTarefas();
            evidenciaTeste.Capture("CamposExibemNaTelaCorretamente");
        }


        [Then(@"o botão Manage Subtasks é exibido na tela")]
        [Obsolete]
        public void EntaoOBotaoManageSubtasksEExibidoNaTela()
        {
            subTarefa.VerificarExistenciaBotaoGerenciarSubTarefas();
            evidenciaTeste.Capture("ValidarExistenciaBotaoManagerSubTasks");
        }
    }
}