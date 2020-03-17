#language: pt-br
Funcionalidade: Login
	Para acessar a tela inicial
	como usuário do ToDo App
	Quero poder fazer login

Contexto:
	Dado que navego para a página inicial do ToDo App
	E clico no botão Sign In
	Então sou direcionado para a tela de login

Cenário: 1) Usuário autenticado com sucesso
	Quando informar os dados para logar
		| Email                   | Password      |
		| guilhermebm27@gmail.com | Bm19283746@13 |
	E clicar no botão Sign In
	Então usuário é direncionado para a tela inicial e a seguinte mensagem será exibida "Signed in successfully."

Cenario: 2) Usuário não autenticado
	Quando o usuário informar os dados incorretos para autenticação
		| Email               | Password      |
		| joao.silva@test.com | Bm19283746@13 |
	E clicar no botão Sign In
	Então a seguinte mensagem será exibida "Invalid email or password."

Cenario: 3) Deixar de preencher campos obrigatorios para autenticação
	Quando o usuário deixar de informar os campos para autenticação
		| Email               | Password |
		| joao.silva@test.com |          |
	E clicar no botão Sign In
	Então a seguinte mensagem será exibida "Invalid email or password."