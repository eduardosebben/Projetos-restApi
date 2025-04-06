Api foi criada para poder processar relatorios fora da api do Erp

Algumas regras de empresa padrao devem ser observadas para cada consulta

Até o momento a principal forma para consumir a API é por RestApi

Existe uma complexidade para conseguir descobrir qual a conexão ele deve usar, para isso o sistema usa
um token (quando integra com account) dentro dele deve conter informações como guid da organização e ambiente pretendido
com isso o sistema busca com essas informações a string connection dentro do account

======================
Principais Bibliotecas
======================
Dapper - possível implementar comandos sql diretamente
	- Algumas regras devem ser observadas onde o codigo deve ser implementado 
	- Todas consultas e codigos SQL devem ser implementados na camada de infraestrutura 
	- Pode ser criado quantos repositorios forem necessários, esses repositórios podem conter suas interfaces na camada de Application ou Dominio 
	e sua implementação deve ser realizada na camda de Infraestrutura
	
Entity Framework - possível buscar por entidades mapeadas
	- Algumas regras importantes:
	- Entidades não devem nunca serem retornadas diretamente para a camada de UI, isso evita problemas de acoplamento de codigo e performance
	- O Lazy load esta desligado e assim deve permanecer - então ou se deve usar o comando 
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
Existe alguns contextos de banco de dados o Principal e mais complexo é o que no momento utiliza contexto de http request 
para buscar qual o jwt e quais informacoes de banco deve buscar, isso só quando existir uma integração com o account
se não deve buscar diretamente do appSettings
Hj ele espera que todas as chamadas venham por Http, caso tenha que implementar Kafka esse contexto não deve existir entao deve ser 
implementado dentro desse contexto, por injeção de dependencia(Di) ou outra forma que não deixe o codigo acoplado

=======================
[Proxy Criptografia]
=======================
Foi criado um proxy de criptografia para ConectaMD5
deve ser usadado ele ao invez de chamar diretamente a 
biblioteca, motivos:
	- não tem que referenciar em outras aplicações a lib MD5
	- permite trocar a biblioteca em apenas um ponto


=======================
[Camadas]
=======================
Domain:
	- camada de dominio onde temos entidades, enums e coisas mais gerais sobre a aplicacao

Application:
	- onde fica a regra de negocio, intefaces,Dtos, servicos 


Infraestrutura:
	- Implemntação concreta de repositorios, onde ficam as libs do Dapper e EF
	- Implementação de comunicação externas

UI:
	- Somente entrada e saida de dados sem grandes implementações aqui, somente controller e configurações e startup

