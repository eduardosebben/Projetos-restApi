Api foi criada para poder processar relatorios fora da api do Erp

Algumas regras de empresa padrao devem ser observadas para cada consulta

At� o momento a principal forma para consumir a API � por RestApi

Existe uma complexidade para conseguir descobrir qual a conex�o ele deve usar, para isso o sistema usa
um token (quando integra com account) dentro dele deve conter informa��es como guid da organiza��o e ambiente pretendido
com isso o sistema busca com essas informa��es a string connection dentro do account

======================
Principais Bibliotecas
======================
Dapper - poss�vel implementar comandos sql diretamente
	- Algumas regras devem ser observadas onde o codigo deve ser implementado 
	- Todas consultas e codigos SQL devem ser implementados na camada de infraestrutura 
	- Pode ser criado quantos repositorios forem necess�rios, esses reposit�rios podem conter suas interfaces na camada de Application ou Dominio 
	e sua implementa��o deve ser realizada na camda de Infraestrutura
	
Entity Framework - poss�vel buscar por entidades mapeadas
	- Algumas regras importantes:
	- Entidades n�o devem nunca serem retornadas diretamente para a camada de UI, isso evita problemas de acoplamento de codigo e performance
	- O Lazy load esta desligado e assim deve permanecer - ent�o ou se deve usar o comando 
	Include() ou se deve criar um objeto com Select()(existem outros comandos) 
	antes de realizar a consulta . ToListAsync()
	- Depois de realizar a consulta ou durante a consulta os dados devem ser transformados em uma DTO para apresentar para UI, essas DTOs podem ser implementadas
	na camada de Application ou Dominio


=======================
[Async]
=======================
Deve ser usado async Task<> para quase todas consultas isso permite que o sistema utilize outras threads 

=======================
[DbContext]
=======================
Existe alguns contextos de banco de dados o Principal e mais complexo � o que no momento utiliza contexto de http request 
para buscar qual o jwt e quais informacoes de banco deve buscar, isso s� quando existir uma integra��o com o account
se n�o deve buscar diretamente do appSettings
Hj ele espera que todas as chamadas venham por Http, caso tenha que implementar Kafka esse contexto n�o deve existir entao deve ser 
implementado dentro desse contexto, por inje��o de dependencia(Di) ou outra forma que n�o deixe o codigo acoplado

=======================
[Proxy Criptografia]
=======================
Foi criado um proxy de criptografia para ConectaMD5
deve ser usadado ele ao invez de chamar diretamente a 
biblioteca, motivos:
	- n�o tem que referenciar em outras aplica��es a lib MD5
	- permite trocar a biblioteca em apenas um ponto


=======================
[Camadas]
=======================
Domain:
	- camada de dominio onde temos entidades, enums e coisas mais gerais sobre a aplicacao

Application:
	- onde fica a regra de negocio, intefaces,Dtos, servicos 


Infraestrutura:
	- Implemnta��o concreta de repositorios, onde ficam as libs do Dapper e EF
	- Implementa��o de comunica��o externas

UI:
	- Somente entrada e saida de dados sem grandes implementa��es aqui, somente controller e configura��es e startup

