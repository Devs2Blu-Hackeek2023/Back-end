<h1 align="center">CO2 Now</h1>
<br>

- 🌲 **Tema:** Meio Abiente
- 🌾 **Stack:** C# + Flutter
- 💡 **Ideia:** Mapeamento e monitoramento de CO2 emitido por veículos nas principais vias de Blumenau-SC
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
- 📊 Analise e controle da dos de CO2 da cidade
- 📟 Calculo de CO2*

<br>

## 📑 Índice

- [Back-End](#back-end)
  - [Integrantes](#integrantes)
  - [Tecnologias](#tecnologias)
  - [UML](#uml)
  - [Bibliotecas](#bibliotecas)
  - [Endpoints](#endpoints)
    - [Emissao](#emissao)
    - [Login](#login)
    - [Proprietario](#proprietario)
    - [Rua](#rua)
    - [Trafego](#trafego)
    - [Usuário](#usuário)
    - [Veiculo](#veiculo)
- [Front-End](#front-end)
  - [Fluxo](#fluxo)
  - [Telas](#telas)
  - [Bibliotecas](#bibliotecas)
- [DevOps](#devops)
  - [Fluxo](#fluxo)
  - [Ferramentas](#ferramentas)

<br>

## 🔌 Back-End
 
**👯‍♂️ Integrantes:**  Edna de Paula, Gabriel Labes, Helena Luz, Rob Caputo e Vinicius Grossert

**🔧 Tecnologias:**  <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"> 
   <img src="https://img.shields.io/badge/entity-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"> 

<br>

### 🖼 UML 
<div align="center"><img  width="500px" src="https://cdn.discordapp.com/attachments/1165434873008357447/1168392905195536384/Classe_UML_1.png"></div>


### 📗 Bibliotecas 

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

### 📍 Endpoints 

#### Emissao

- ```POST - Emissao/ia``` Cria uma nova emissão simulando uma Inteligência Artificial, com rua e veiculos aleatorios.
- ```POST - Emissao``` Fornece os dados iniciais para gerar a emissão de um determinado veículo em uma rua específica.
- ```GET - Emissao``` Retorna a lista de todas as emissões de CO2 de todos os veículos em todas as ruas registrados no banco de dados.
- ```DELETE - Emissao{Id}``` Deleta uma emissão de CO2 identificada pelo Id informado no parâmetro.
- ```GET - Emissao{Id}``` Retorna a emissão de CO2 identificada pelo Id informado no parâmetro.
- ```PUT - Emissao{Id}``` Altera os dados de emissão de CO2 identificada pelo Id informado no parâmetro.
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
- ```GET - Rua/Id``` Retorna a rua resgistrada no banco de dados, identificada pelo Id informado no parâmetro.
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

### 🎢 Fluxo 

### 🖼 Telas 

### 📗 Bibliotecas 

<br>

## ☁ DevOps

### 🎢 Fluxo 

### 🎛 Ferramentas

