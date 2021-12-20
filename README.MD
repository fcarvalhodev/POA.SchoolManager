# POA Gerenciamento Escolar

> Projeto gerenciador de escolas de Porto Alegre.

- WebApi: https://poaschool.azurewebsites.net/swagger/index.html
- WebApp: https://poaschool.web.app/

### Ajustes e melhorias

O projeto ainda está em desenvolvimento e as próximas atualizações serão voltadas nas seguintes tarefas:

- [x] Criar um back-end que consuma os dados da url http://datapoa.com.br/dataset/sie/resource/5579bc8e-1e47-47ef-a06e-9f08da28dec8
- [x] Criar testes para o back-end
- [x] Criar API com os endpoints disponibilziados via swagger
- [x] Criar uma página web em Angular para receber os dados.
- [x] Criar tratativa em caso a URL esteja offline (dados estáticos disponibilizados).
- [x] Integrar API e Página web.
- [x] Disponibilizar filtro na grid para as escolas.
- [x] Linkar mapa ao endereço das escolas.
- [ ] Usar serviço de rota para escolas próximas.
- [ ] Ordenar por distância escolas mais próximas.
- [ ] Disponibilizar ambos sites em uma URL.

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:
<!---Estes são apenas requisitos de exemplo. Adicionar, duplicar ou remover conforme necessário--->
* Você instalou a `versão 3.1 .Net Core SDK`
* Você instalou a `versão mais recente .Net CLI`
* Você instalou a `versão 16.13 LTS Node JS`
* Você instalou a `versão 13.1+ do Angular CLI`
* Você tem uma máquina `Windows/Linux`. Indique qual sistema operacional é compatível / não compatível.

## 🚀 Instalando <POA.SchoolManager>

Para instalar o <POA.SchoolManager>, siga estas etapas:

Linux e macOS (back-end):
Use os comandos abaixo na pasta <src> do projeto.
```
dotnet restore
dotnet build
dotnet test
dotnet run
dotnet run -p .\POA.SchoolManagerApplication\POA.SchoolManagerApplication.csproj
```
Após executar os comandos check pela porta que está aberta, e inclua /swagger na URL para acessar a página com os endpoints.

>Obs: Caso execute direto do Visual Studio, não é necessário incluir o /swagger na URL.

## 🚀 Instalando <POA.SchoolManager> Angular APP

Para instalar o <POA.SchoolManager> Angular APP, siga estas etapas:

Linux e macOS (back-end):
Use os comandos abaixo na pasta wwwroot/application/poa-webapp.

```
npm install
ng serve
```

Se você estiver rodando local, troque as URL's no arquivo app.component.ts
  
```
let url = "https://poaschool.azurewebsites.net/api/v1/Schools"
//let url = "https://localhost:44350/api/v1/Schools";
```
  
  


