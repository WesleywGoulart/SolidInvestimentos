# 💼 Simulador de Investimentos com SOLID — C# .NET 8

Este projeto tem como objetivo ilustrar de forma **prática e didática** a aplicação dos princípios **SOLID** em um sistema simples de simulação de investimentos financeiros, utilizando **C# com .NET 8**.

---

## 📚 Sobre o Projeto

A aplicação permite simular o retorno de um investimento, com base em:

- Tipo de investimento (CDB ou Poupança)
- Valor investido
- Período em meses

### 🧾 Exemplos de uso:
O usuário informa:
- Tipo de investimento: `CDB` ou `Poupança`
- Valor: ex: `1000.00`
- Tempo: ex: `12 meses`

O sistema calcula o retorno estimado com base em uma taxa fixa por tipo e exibe o resultado.

---

## 🛠️ Como Executar

> Pré-requisitos: [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

1. Clone o repositório:

```bash
git clone https://github.com/WesleywGoulart/SolidInvestimentos.git
cd SolidInvestimentos
```

2. Execute o projeto:

```bash
dotnet run --project SolidInvestimentos
```

---

## 🧠 Aplicação dos Princípios SOLID

O projeto foi arquitetado com foco em aplicar **cada princípio SOLID de forma explícita**. Abaixo, explicamos cada um com os arquivos e responsabilidades envolvidos:

---

### 🔸 S — **Single Responsibility Principle (SRP)**

> Uma classe deve ter apenas uma razão para mudar.

| Classe | Responsabilidade Única |
|--------|------------------------|
| `Investment.cs` | Representa os dados de um investimento |
| `CdbInvestment.cs` | Calcula o retorno de um CDB |
| `PoupancaInvestment.cs` | Calcula o retorno da Poupança |
| `ConsoleLogger.cs` | Realiza o log das mensagens no console |
| `InvestmentSimulator.cs` | Orquestra a simulação com estratégia e log |

Cada classe tem uma responsabilidade clara e isolada, o que facilita manutenção, testes e evolução.

---

### 🔸 O — **Open/Closed Principle (OCP)**

> Classes devem estar abertas para extensão, mas fechadas para modificação.

Exemplos no projeto:

- `IInvestmentStrategy` permite criar novos tipos de investimentos (ex: TesouroDiretoInvestment) **sem modificar** o código existente.
- `ConsoleLogger` pode ser substituído por `FileLogger` sem alterar `InvestmentSimulator`.

Você pode estender o sistema criando novas classes que implementem interfaces existentes.

---

### 🔸 L — **Liskov Substitution Principle (LSP)**

> Objetos de uma classe derivada devem poder substituir objetos de sua classe base sem afetar o comportamento.

As classes:

- `CdbInvestment`
- `PoupancaInvestment`

Implementam `IInvestmentStrategy`, e podem ser utilizadas em qualquer lugar onde essa interface é esperada, sem alterar o funcionamento.

Exemplo:

```csharp
IInvestmentStrategy strategy = new CdbInvestment();
```

---

### 🔸 I — **Interface Segregation Principle (ISP)**

> Uma interface nunca deve forçar o cliente a depender de métodos que ele não utiliza.

O projeto define **interfaces específicas e coesas**:

| Interface | Responsabilidade |
|-----------|------------------|
| `IInvestmentStrategy` | Cálculo completo de retorno |
| `IInvestmentCalculator` | Interface alternativa, apenas para cálculo |
| `ILogger` | Logar mensagens da aplicação |

As classes implementam apenas o que precisam, evitando acoplamento desnecessário.

---

### 🔸 D — **Dependency Inversion Principle (DIP)**

> Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações.

- `InvestmentSimulator` depende das interfaces `IInvestmentStrategy` e `ILogger`, e **não** das implementações `CdbInvestment` ou `ConsoleLogger`.
- `RunSimulation` também depende apenas de `ILogger`.

Assim, é possível trocar qualquer implementação sem afetar as classes consumidoras.

Exemplo:

```csharp
ILogger logger = new ConsoleLogger();
IInvestmentStrategy strategy = new CdbInvestment();
InvestmentSimulator simulator = new InvestmentSimulator(strategy, logger);
```

## 📂 Estrutura de Pastas

```
SolidInvestimentos/
├── Core/
│   ├── Entities/              → Modelos de domínio (Investment)
│   ├── Interfaces/            → Abstrações (ILogger, IInvestmentStrategy)
│   └── Services/              → Lógicas de negócio (simulador e estratégias)
│
├── Application/
│   └── UseCases/              → Orquestração do fluxo de uso (RunSimulation)
│
├── Infrastructure/
│   └── Logging/               → Implementações concretas de infraestrutura
│
├── Utils/                     → Fábrica de estratégias (InvestmentFactory)
├── Program.cs                 → Entrada da aplicação
```

---

## 📈 Exemplo de Execução

```plaintext
=== Simulador de Investimentos ===

Escolha o tipo de investimento:
1 - CDB
2 - Poupança

Opção: 1
Digite o valor a ser investido (ex: 1000.50): 1500
Digite o número de meses (ex: 12): 10

🔄 Simulando investimento...

[LOG] Simulação de investimento para 'cdb':
[LOG] Valor investido: R$ 1500,00
[LOG] Período: 10 meses
[LOG] Retorno estimado: R$ 1665,00

✅ Simulação finalizada. Pressione qualquer tecla para sair.
```

## 👨‍💻 Autor

**Wesley Willian Cecilio Goulart**  
Desenvolvedor com foco em C# .NET, APIs REST e engenharia de software segura e performática.

[🔗 LinkedIn](https://www.linkedin.com/in/wesleywillian)  
[💻 GitHub](https://github.com/WesleywGoulart)
