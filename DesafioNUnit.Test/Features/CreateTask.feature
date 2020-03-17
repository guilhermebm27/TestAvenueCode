#language: pt-br
Funcionalidade: CreateTask
	Como usuário do ToDo App
	Eu deveria ser capaz de criar uma tarefa
	Para que eu possa gerenciar minhas tarefas

Contexto:
	Dado que o usuário esta autenticado no sistema
		| Email                   | password      |
		| guilhermebm27@gmail.com | Bm19283746@13 |

Cenário: 1) Validar existencia do link Minhas tarefas na barra de navegação
	Quando acessar a tela inicial
	Então o link "My Tasks" deve ficar visivel para o usuário

Cenário: 2) Validar direcionamento de link Minhas tarefas
	Quando acessar a tela inicial
	E clicar em My Tasks
	Então usuário é redirecionado para a tela de listagem de tarefas

Cenário: 3) Validar mensagem na parte superior informando usuario conectado
	Quando acessar na tela de My Tasks
	Então é exibido uma mensagem com o nome do usuário conectado Hey "Guilherme", this is your todo list for today:

Cenário: 4) Adicionar nova tarefa
	Quando acessar na tela de My Tasks
	E informar os dados para inserir nova tarefa
		| inserir nova tarefa      |
		| abertura de oscilografia |
	E clicar em adicionar tarefa
	Então tarefa "abertura de oscilografia" deve ser exibida na listagem

Cenário: 5) Validar limite mínimo de caracteres para adicionar nova tarefa
	Quando acessar na tela de My Tasks
	E informar os dados para inserir nova tarefa
		| inserir nova tarefa |
		| abc                 |
	Então sistema deverá exibir crítica informando limite mínimo de caracteres

Cenário: 6) Validar limite maximo de caracter para adicionar tarefa
	Quando acessar na tela de My Tasks
	E informar os dados para inserir nova tarefa
		| inserir nova tarefa                                                                                                                                                                                                                                                                                                                                                                                                                             |
		| A tecnologia é para muitos algo desconhecido, sabem apenas o elementar, nem mesmo o básico. Contudo, vivem. Contudo, existem. Contudo, se relacionam. É justamente neste ponto que quero chegar. Não sou contra a tecnologia, muito antes pelo contrário, ela faz parte da minha vida e do meu trabalho. Entretanto, a tecnologia pode e deve ser utilizada para o crescimento das pessoas e não as pessoas crescerem dependendo da tecnologia. |
	Então sistema deverá exibir critica informando ao usuário limite maximo de caracteres