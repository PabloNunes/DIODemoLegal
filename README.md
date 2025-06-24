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
4. Execute `dotnet run --project Client` para iniciar o servidor de desenvolvimento
5. Acesse `http://localhost:5192` no navegador