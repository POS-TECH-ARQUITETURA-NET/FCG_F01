Funcionalidade: CadastroUsuario

Cenário: Cadastro de novo usuário com informações inválidas
  Contexto:
 Dado que estou na página do registro
 Quando preencho o formulário de registro com campo nome inválido:
	| campo         | valor                |
	| nome          | ""                   |
	| email         | "joaoalves@gmail.com"|
	| senha         | "jves!#2020"         |
E clicar em "Registrar"
Então devo ver uma mensagem de erro indicando que o nome é obrigatório
