# Enquete Estudantil - DIO Demo Legal

[Azure Static Web Apps](https://docs.microsoft.com/azure/static-web-apps/overview) permite criar facilmente aplicativos [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) em minutos. Use este repositório com o [guia de início rápido do Blazor](https://docs.microsoft.com/azure/static-web-apps/getting-started?tabs=blazor) para construir e personalizar um novo site estático.

## 🗳️ Funcionalidade de Enquete

Este aplicativo inclui uma enquete interativa onde os estudantes podem votar no seu tema favorito entre:

- **IA Agêntica** - Sistemas de inteligência artificial que agem de forma autônoma
- **Implantação de LLMs Simples** - Deploy e implementação de modelos de linguagem em produção  
- **Protocolo MCP (Model Context Protocol)** - Protocolo para comunicação e contexto entre modelos

### Características da Enquete

- ✅ **Interface em Português Brasileiro**: Toda a interface está localizada em PT-BR
- 🔒 **Um voto por usuário**: Cada usuário pode votar apenas uma vez (controlado via localStorage)
- 📊 **Resultados em tempo real**: Os resultados são atualizados imediatamente após cada voto
- 💾 **Persistência local**: Os dados da enquete são armazenados no localStorage do navegador
- 📱 **Design responsivo**: Interface adaptada para dispositivos móveis e desktop

### Como Usar

1. **Executar o aplicativo**: 
   ```bash
   dotnet run --project Client
   ```

2. **Acessar a enquete**: Abra o navegador em `http://localhost:5192`

3. **Votar**: 
   - Clique em uma das três opções disponíveis
   - Seu voto será registrado instantaneamente
   - Você verá os resultados atualizados logo em seguida

4. **Visualizar resultados**:
   - Os resultados são exibidos em formato de gráfico de barras
   - Mostra a porcentagem e número total de votos para cada opção
   - Destaca qual opção você votou (se já tiver votado)

### Tecnologias Utilizadas

- **Blazor WebAssembly** (.NET 6): Framework para aplicações web client-side
- **Bootstrap 5**: Framework CSS para estilização responsiva
- **LocalStorage**: Persistência de dados no navegador
- **JSON Serialization**: Armazenamento estruturado dos dados da enquete

### Estrutura do Projeto

```
Client/
├── Components/
│   ├── StudentPoll.razor          # Componente principal da enquete
│   └── StudentPoll.razor.css      # Estilos específicos da enquete
├── Models/
│   ├── PollOption.cs              # Modelo para opções da enquete
│   └── PollData.cs                # Modelo para dados da enquete
├── Services/
│   └── PollService.cs             # Lógica de negócio da enquete
└── Pages/
    └── Index.razor                # Página principal com a enquete
```

### Desenvolvimento

Para desenvolver novas funcionalidades:

1. Clone o repositório
2. Execute `dotnet restore` para restaurar dependências
3. Execute `dotnet build` para compilar
4. Execute `dotnet test` para executar os testes
5. Execute `dotnet run --project Client` para iniciar o servidor de desenvolvimento
6. Acesse `http://localhost:5192` no navegador

### Testes

Este projeto inclui testes automatizados utilizando xUnit para garantir a qualidade do código:

- **Testes de Unidade**: Cobertura dos serviços principais (PollService) e modelos de dados
- **Framework**: xUnit com Moq para mocking
- **Execução Local**: `dotnet test`
- **CI/CD**: Testes executados automaticamente em cada push/PR

#### Estrutura de Testes

```
BlazorBasic.Tests/
├── Services/
│   └── PollServiceTests.cs        # Testes do serviço de enquetes
└── Models/
    ├── PollOptionTests.cs         # Testes do modelo PollOption
    └── PollDataTests.cs           # Testes do modelo PollData
```

#### Executando Testes

```bash
# Executar todos os testes
dotnet test

# Executar testes com relatório detalhado
dotnet test --verbosity normal

# Executar testes com cobertura de código
dotnet test --collect:"XPlat Code Coverage"
```

### CI/CD Pipeline

O projeto utiliza GitHub Actions para automação de CI/CD:

1. **Testes Automatizados**: Executados em cada push e pull request
2. **Build e Deploy**: Deploy automático para Azure Static Web Apps após sucesso dos testes
3. **Relatórios de Teste**: Resultados visíveis diretamente no GitHub

#### Pipeline de CI/CD

- **Etapa 1**: Checkout do código
- **Etapa 2**: Setup do .NET 8
- **Etapa 3**: Restauração de dependências (`dotnet restore`)
- **Etapa 4**: Build do projeto (`dotnet build`)
- **Etapa 5**: Execução dos testes (`dotnet test`)
- **Etapa 6**: Deploy para Azure (somente se testes passarem)

Os testes devem passar obrigatoriamente para que o deploy seja realizado.