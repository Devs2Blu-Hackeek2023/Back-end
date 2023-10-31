<div align="center"><img  width="300px" src="https://cdn.discordapp.com/attachments/1165114170858012712/1166204580133085235/co2now-logo.png?ex=6549a3a6&is=65372ea6&hm=0182f70d7713c46be0c3085b1cc587813f38ea4cb7f988a1a8fcc311a37e059f&"></div>

<br>

- 🔗 **Link:**
- 🕵️‍♀️ **Suporte:**
- 🌲 **Tema:** Meio Abiente
- 🌾 **Stack:** C# + Flutter
- 💡 **Proposta:** Mapeamento e monitoramento de CO2 emitido por veículos nas principais vias de Blumenau-SC
- 👫 **Integrantes:**
    - <a href="https://github.com/ednadepaula">Edna de Paula<a/>
    - <a href="https://github.com/GabrielDickmannSchneider">Gabriel Schneider<a/>
    - <a href="https://github.com/gameking360">Gabriel Labes</a>
    - <a href="https://github.com/helenaluz">Helena Luz</a>
    - <a href="https://github.com/jhonatasilva1902">Jhonata Silva</a>
    - <a href="https://github.com/LucasDS0608">Lucas Schneider</a>
    - <a href="https://github.com/LucasTheiss1">Lucas Theiss</a>
    - <a href="https://github.com/ViniciusHenriqueGrossert">Vinicius Grossert</a>

## 🎇 Funcionalidades

- 🔎 Mapeamento de emissão de CO2 por veiculo e por via
- 📊 Analise e controle dados de CO2 da cidade
- 📟 Calculo de CO2*

## 📴 Funcionalidades não implementadas

- 🚗 Conexão com a API do Detran
- 🎥 Sistemas de câmeras cobrindo as vias
- 🦾 Intêligencia Artificial para a captura das placas
 <div align="center"><img  width="600px" src="https://cdn.discordapp.com/attachments/1165434873008357447/1168643347183841391/copia.png?ex=655282ee&is=65400dee&hm=f757b7680991cbf60b13ae29750cdd4ed796a17d4cd6e57143b8a88c2196e7ae&"></div>


<br>

## 📑 Índice

- [Configurações](#-configurações)
- [Back-End](#-back-end)
  - [UML](#-uml)
  - [Fluxo](#-fluxo-back-end)
  - [Bibliotecas](#-bibliotecas-back-end)
  - [Endpoints](#-endpoints)
    - [Emissao](#emissao)
    - [Login](#login)
    - [Proprietario](#proprietário)
    - [Rua](#rua)
    - [Trafego](#trafego)
    - [Usuário](#usuário)
    - [Veiculo](#veiculo)
- [Front-End](#-front-end)
  - [Fluxo](#-fluxo-front-end)
  - [Telas](#-telas)
  - [Bibliotecas](#-bibliotecas-front-end)
- [DevOps](#-devops)
  - [Fluxo](#-fluxo-devops)
  - [Ferramentas](#-ferramentas)
- [Referências](#-referências)

<br>

## ⚙ Configurações

Para configurar o ambiente e as ferramentas necessárias para o projeto, siga as instruções abaixo:

### Configuração da AWS

Certifique-se de configurar suas credenciais da AWS e definir as variáveis de ambiente apropriadas ou usar o AWS CLI.

### Configuração do Terraform

Antes de prosseguir, inicialize e aplique as configurações do Terraform. Além disso, você pode definir outras configurações específicas do projeto.

### Configuração do Ansible

Certifique-se de definir os hosts e inventários corretos para o Ansible. Você pode executar os playbooks Ansible após a configuração.

### Configuração do GitHub Actions

Utilize o GitHub Actions para automatizar a implantação e gerenciamento da infraestrutura na AWS. Você encontrará fluxos de trabalho no GitHub Actions para DevOps, Frontend e outros.

## Uso

Aqui estão exemplos de como usar as ferramentas no projeto:

### Terraform

Use o Terraform para criar, atualizar e destruir recursos na AWS. Um exemplo de configuração do backend S3 está disponível em [backend.tf](http://backend.tf).

Um exemplo de criação de instância, grupo de segurança e chave SSH pode ser encontrado em [main.tf](main.tf).

### Ansible

O Ansible é usado para configurar recursos na AWS. Um exemplo de playbook Ansible está disponível em [playbook.yml](playbook.yml).

### GitHub Actions

O GitHub Actions é usado para automatizar processos. Existem dois fluxos de trabalho:

- [deploy-c#.yml](deploy-c#.yml): Um fluxo de trabalho para construir e implantar uma aplicação C#.
- [siriustech_vm.yml](siriustech_vm.yml): Um fluxo de trabalho para provisionar a infraestrutura AWS usando Terraform.

## Instância EC2

Após a configuração, você terá uma instância EC2 em execução com serviços Docker. A seguir, estão os arquivos de configuração para os serviços:

### Clone do Git dockerfiles

Você pode clonar o repositório Git do Dockerfiles para obter configurações de contêineres adicionais.

### Pasta co2now

- [docker-compose.yml](docker-compose.yml): Um arquivo de configuração do Docker Compose para o serviço "co2now".

- [appsettings.json](appsettings.json): Um arquivo de configuração do aplicativo com informações de conexão e configurações JWT.

### Pasta ngixloadbalancer

- [docker-compose.yml](docker-compose.yml): Um arquivo de configuração do Docker Compose para um serviço nginx/load balancer.

- [nginx.conf](nginx.conf): Um arquivo de configuração do Nginx para balanceamento de carga e redirecionamento de tráfego.

<br> 

## 🔌 Back-End

**🔗 Link:** <a href="https://api.co2now.devs2blu.dev.br/swagger/index.html">https://api.co2now.devs2blu.dev.br</a>

**👯‍♂️ Integrantes:**  Edna de Paula, Gabriel Labes, Helena Luz, Rob Caputo e Vinicius Grossert

**🔧 Tecnologias:**  <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"> 
   <img src="https://img.shields.io/badge/entity-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"> 

<br>

### 🖼 UML 
<div align="center"><img  width="500px" src="https://cdn.discordapp.com/attachments/1165434873008357447/1168392905195536384/Classe_UML_1.png"></div>


### 📗 Bibliotecas Back-End

- BCrypt.Net-Next
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.IdentityModel.Tokens
- Newtonsoft.Json
- Swashbuckle.AspNetCore
- System.IdentityModel.Tokens.Jwt
- ViaCep

### 🎢 Fluxo Back-End

<div align="center"><img  width="500px" src="https://cdn.discordapp.com/attachments/1165102190025785454/1168588464854421504/Diagrama_em_branco_2.png?ex=65524fd1&is=653fdad1&hm=ecb067f5fe35d31b8281d5816c37079b2e4624a3ed4febf5c29802f8acb814fd&"></div>

### 📍 Endpoints 

#### Emissao

- ```POST - Emissao/ia``` Cria uma nova emissão simulando uma Inteligência Artificial, com rua e veiculos aleatorios.
- ```POST - Emissao``` Fornece os dados iniciais para gerar a emissão de um determinado veículo em uma rua específica.
- ```GET - Emissao``` Retorna a lista de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no banco de dados.
- ```DELETE - Emissao/{Id}``` Deleta uma emissão de CO2 identificada pelo Id informado no parâmetro.
- ```GET - Emissao/{Id}``` Retorna a emissão de CO2 identificada pelo Id informado no parâmetro.
- ```PUT - Emissao/{Id}``` Altera os dados de emissão de CO2 identificada pelo Id informado no parâmetro.
- ```GET - Emissao/total``` Retorna o somatório de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no banco de dados.
- ```GET - Emissao/total/ano/{ano}``` Retorna o somatório de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no ano informado no parêmetro.
- ```GET - Emissao/total/mes/{mes}/ano/{ano}``` Retorna o somatório de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no mês e ano informado no parêmetro.
- ```GET - Emissao/total/dia/{dia}/mes/{mes}/ano/{ano}``` Retorna o somatório de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no dia, mês e ano informado no parêmetro.
- ```GET - Emissao/ultimo/ano``` Retorna o somatório de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no ano atual.
- ```GET - Emissao/ultimo/mes``` Retorna o somatório de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no mês atual.
- ```GET - Emissao/ultimo/dia``` Retorna o somatório de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no dia atual.

#### Login
- ```POST - Login``` Realiza da validação de usuário e senha por meio de autenticação usando tokens JWT e claims, identificando o role correspondente de acesso.

#### Proprietário
- ```GET - Proprietario``` Retorna todos os proprietários de veículos resgistrados no banco de dados.
- ```GET - Proprietario/Id``` Retorna o proprietário de veículo resgistrado no banco de dados, identificado pelo Id informado no parêmetro.
- ```POST - Proprietario``` Cria um novo proprietário de veículo.
- ```DELETE - Proprietario/Id``` Deleta o propritário identificado pelo Id informado no parâmetro.

#### Rua
- ```POST - Rua``` Cria uma nova rua.
- ```GET - Rua``` Retorna todas as ruas resgistradas no banco de dados.
- ```GET - Rua/{Id}``` Retorna a rua resgistrada no banco de dados, identificada pelo Id informado no parâmetro.
- ```GET - Rua/cep/{CEP}``` Retorna a rua resgistrada no banco de dados, identificada pelo CEP informado no parâmetro.
- ```GET - Rua/{Id}/emissao/Total``` Retorna o total de emissão de CO2 na rua identificada pelo Id informado no parâmetro.
- ```GET - Rua/{Id}/emissao/Ano/{ano}``` Retorna o total de emissão de CO2 durante o ano informado no parâmetro, na rua identificada pelo Id informado no parêmetro.
- ```GET - Rua/{Id}/emissao/ano/{ano}/mes/{mes}``` Retorna o total de emissão de CO2 durante o mês e ano informado no parâmetro, na rua identificada pelo Id informado no parâmetro.
- ```GET - Rua/{Id}/emissao/ano/{ano}/mes/{mes}/dia/{dia}``` Retorna o total de emissão de CO2 de um dia, mês e ano informado no parâmetro, na rua identificada pelo Id informado no parâmetro.
- ```GET - Rua/{Id}/emissao/ultimo/dia``` Retorna o somatório de todas as emissões de CO2 de todos os veículos na rua identificada pelo Id informado no parêmetro, no dia atual.
- ```GET - Rua/{Id}/emissao/media``` Retorna a media de todas as emissões de CO2 de todos os veículos na rua identificada pelo Id informado no parêmetro.
- ```GET - Rua/emissao/regiao/{regiao}``` Retorna o somatório de todas as emissões de CO2 de todos os veículos da região informada no parâmetro.
- ```GET - Rua/emissao/bairro/{bairro}``` Retorna o somatório de todas as emissões de CO2 de todos os veículos do bairro informado no parâmetro.
- ```GET - Rua/{Id}/emissao/ultimos/30dias``` Retorna o somatório de todas as emissões de CO2 de todos os veículos na rua identificada pelo Id informado no parâmetro, nos ultimos 30 dias.
- ```GET - Rua/MaisPoluentes``` Retorna uma lista de ruas em ordem decrescente pelo total de emissão de CO2.
- ```GET - Rua/MaisPoluentes/5anos``` Retorna uma lista de ruas em ordem decrescente pelo total de emissão de CO2 dos últimos 5 anos.
- ```GET - Rua/MaisPoluentes/5meses``` Retorna uma lista de ruas em ordem decrescente pelo total de emissão de CO2 dos últimos 5 meses.
- ```PUT - Rua/{Id}``` Altera os dados da rua identificada pelo Id informado no parâmetro.

#### Trafego
- ```POST - Trafego``` Simula o trafego de veículos e o registro deles na posição inicial e final da rua com intervalo de tempo randomizado entre um carro e outro. Tanto as ruas como os veículos são geradas de maneira aleatória.

#### Usuário
- ```POST - Usuario``` Cria um usuario e senha de acesso a aplicação.
- ```POST - Usuario/Id``` altera a senha de acesso da aplicação.

#### Veiculo
- ```POST - Veiculo``` Cria um novo veiculo.
- ```GET - Veiculo``` Retorna uma lista com todos os veículos registrados no banco de dados.
- ```GET - Veiculo/{Id}``` Retorna o veiculo resgistrado no banco de dados, identificado pelo Id informado no parâmetro.
- ```GET - Veiculo/Proprietario/{id}``` Retorna a lista de veiculos resgistrado no banco de dados pertencentes ao proprietário identificado pelo Id informado no parâmetro.
- ```GET - Veiculo/{Id}/Emissao/dia/{dia}/mes/{mes}/ano/{ano}``` Retorna o total de emissão de CO2 de um dia, mês e ano informado no parâmetro, pelo veiculo identificado pelo Id informado no parâmetro.
- ```GET - Veiculo/emissao/categoria/{categoria}``` Retorna o total de emissão de CO2 de categoria de veiculo informada no parâmetro.
- ```GET - Veiculo/emissao/veiculo/{Id}/6meses``` Retorna o total de emissão de CO2 dos últimos 6 meses gerada pelo veículo identificado pelo Id informado no parâmetro.
- ```GET - Veiculo/Placa/{placa}``` Retorna o veiculo resgistrado no banco de dados, identificado pela Placa informada no parâmetro.
- ```PUT - Veiculo/{Id}``` Altera os dados do veículo identificado pelo Id infirmado no parâmetro.
- ```DELETE - Veiculo/{Id}``` Deleta o veiculo identificado pelo Id informado no parâmetro.

<br>

## 💻 Front-End

**🔗 Link:** <a href="https://co2now.devs2blu.dev.br/#/home">https://co2now.devs2blu.dev.br</a>

**👯‍♂️ Integrantes:**  Gabriel Schneider e Lucas Schneider.

**🔧 Tecnologias:**   <img src="https://img.shields.io/badge/Flutter-239120?style=for-the-badge&logo=flutter&logoColor=white&color=blue">
  <img src="https://img.shields.io/badge/Dart-512BD4?style=for-the-badge&logo=dart&logoColor=white&color=blue"> 
  <img src="https://img.shields.io/badge/Figma-512BD4?style=for-the-badge&logo=figma&logoColor=white&color=purple"> 

<br>

### 🎢 Fluxo Front-End

<div align="center"><img  width="1000px" src="https://cdn.discordapp.com/attachments/1165114170858012712/1168586086046519297/Diagrama_em_branco_1.png?ex=65524d9a&is=653fd89a&hm=f95809ee29d72f6c20ef5412dfa9ca7ed5f2e54a40abbff26557f6d34e9938e0&"></div>

### 🖍 Prototipação

<div align="center"><img  width="200px" src="https://cdn.discordapp.com/attachments/1165114170858012712/1168578889220628670/Mobile.png?ex=655246e6&is=653fd1e6&hm=d602d1c7fc5026df11dd85ba6522f1ef0cab00c2e70e661ad9dfe7ffdc069e08&"></div>

<div align="center"><a href="https://www.figma.com/proto/uTGEgnSGR9kWeFf303tEWv/Mobile?type=design&node-id=261-6465&t=RZAjlYAfBFz0Bgzr-1&scaling=scale-down&page-id=7%3A3&starting-point-node-id=322%3A6515&mode=design">Ver no figma</a></div>
<br>

<div align="center"><img  width="800px" src="https://cdn.discordapp.com/attachments/1165434873008357447/1168691829223473152/Screenshot_2023-10-30_202244.png?ex=6552b015&is=65403b15&hm=50df283dbe8d3940820e7f0daa6ab7a2524983107280bd1762bb5f4f435b3c15&"></div>

<div align="center"><a href="https://www.figma.com/file/os1JcLsUkGJfe9orrKnOfp/Web-user?type=design&node-id=27%3A6743&mode=design&t=4KqZo93m6bpWTKcc-1">Ver no figma</a></div>

### 📗 Bibliotecas Front-End

- FL_charts
- SideBarX
- Http

<br>

## ☁ DevOps

**👯‍♂️ Integrantes:**  Jhonata Silva e Lucas Theiss.

**🔧 Tecnologias:**   <img src="https://img.shields.io/badge/TerraForm-239120?style=for-the-badge&logo=terraform&logoColor=white&color=purple">
  <img src="https://img.shields.io/badge/Ansible-512BD4?style=for-the-badge&logo=ansible&logoColor=white&color=red"> 
  <img src="https://img.shields.io/badge/GitHub%20Actions-512BD4?style=for-the-badge&logo=github-actions&logoColor=white&color=purple"> 
  <img src="https://img.shields.io/badge/EC2-512BD4?style=for-the-badge&logo=amazon-ec2&logoColor=white&color=orange"> 
  <img src="https://img.shields.io/badge/AWS-512BD4?style=for-the-badge&logo=amazon-aws&logoColor=white&color=orange"> 
  <img src="https://img.shields.io/badge/Docker-512BD4?style=for-the-badge&logo=docker&logoColor=white&color=blue"> 
  <img src="https://img.shields.io/badge/Linux-512BD4?style=for-the-badge&logo=linux&logoColor=white&color=yellow"> 

**📜 Documentaçõa detalhada:** <a href="https://quickest-macrame-144.notion.site/Sirius-Tech-28bc51cc5927497cbea9aa70b6744874">Link no Notion<a/>

<br>

### 🎢 Fluxo DevOps


<div align="center"><img  width="800px" src="https://cdn.discordapp.com/attachments/1165434873008357447/1168941329951248384/image.png?ex=65539872&is=65412372&hm=48bd2ba7c26ffc7fe61afceabfac091282f5ee9cc1b2409fceca50e6297d2fb3&"></div>
<br>
<div align="center"><img  width="1000px" src="https://cdn.discordapp.com/attachments/1165434873008357447/1168941330316132412/image.png?ex=65539873&is=65412373&hm=52aeafd125ea6710b3aa725baf58dda8384af8959bcbe1877af3c3a1608fa4ed&"></div>


<br>

## 🔗 Referências

 -  Calculo de Emissão de CO2
     - <a href="https://www.autolexicon.net/en/articles/cng-compressed-natural-gas/">Fonte 1</a>
     - <a href="https://impactful.ninja/the-carbon-footprint-of-ethanol/">Fonte 2</a>

