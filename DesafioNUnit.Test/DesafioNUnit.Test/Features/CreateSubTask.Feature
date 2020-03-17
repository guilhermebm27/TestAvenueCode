#language: pt-br
Funcionalidade: CreateSubTask
    Como usuário do ToDo App
    Eu deveria ser capaz de criar uma subtarefa
    Para que eu possa dividir minhas tarefas em pedaços menores

Contexto:
	Dado que o usuário esteja autenticado no sistema
		| Email                   | password      |
		| guilhermebm27@gmail.com | Bm19283746@13 |

Cenário: 1) Validar existencia do botão Manage Subtasks na tela de tarefas
	Quando acessar a tela de minhas tarefas
	Então o botão Manage Subtasks é exibido na tela

Cenário: 2) Inserir valor com mais de 250 caracteres no campo descricao
	Quando estou na tela de subtarefas
	E preencho o campo descrição com mais de 250 caracteres
		| inserir descrição                                                                                                                                                                                                                                              |
		| Testes de GUI automatizados  Esse tipo de teste automatizado é a forma mais difícil de automação porque envolve o teste de uma interface do usuário do aplicativo.  É difícil porque as interfaces gráficas são altamente sujeitas a mudanças. Mas esse tipo d |
	Então sistema não deve permitir escrita com mais de 250 caracteres

Cenário: 3) Preencher campos e clicar em adicionar substarefas
	Quando estou na tela de subtarefas
	E preencho o formulário para cadastro de nova subtarefa
		| SubTask Description:                  | Due Date:  |
		| subtarefa de consulta de oscilografia | 20/10/2019 |
	E clicar em adicionar
	Então sistema deve exibir subtarefa "subtarefa de consulta de oscilografia" na parte inferior da caixa de diálogo modal

Cenário: 4) Deixar de preencher campos obrigatórios
	Quando estou na tela de subtarefas
	E deixo de informar um dos campos obrigatórios
		| SubTask Description:  | Due Date: |
		| subtarefa de consulta |           |
	E clicar em adicionar
	Então Sistema não deve permitir adicionar subtarefa e com isso não deve exibir na parte inferior descrição "subtarefa de consulta"

Cenário: 5) Validar existencia dos campos decricação e vencimento de susbtarefa
	Quando estou na tela de subtarefas
	Então os campos descrição de vencimento de subtarefa devem ficar visiveis para o usuário

