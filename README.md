# Gerador de JSON 

Aplicação que permite criar **objetos personalizados**, adicionando **atributos, objetos aninhados e listas**, **gerando um JSON válido** a partir dessas estruturas.  
O programa também realiza **validações automáticas** e as exibe após o JSON ser gerado.

## Funcionalidades
- Aplicação Windows (Console)
- Criação dinâmica de **objetos personalizados** via código.  
- Adição de **atributos** (chave → valor) a cada objeto.  
- Inclusão de **outros objetos dentro de objetos**, permitindo hierarquias complexas.  
- Criação de **listas de objetos**.  
- Geração automática de um **JSON estruturado**.  
- **Validação do JSON** (nomes e consistência de objetos em listas).

## Exemplos de Geração

- JSON válido gerado pelo programa:

![Captura de tela](exemplo_json_valido.png)

- JSON inválido gerado pelo programa:
  
![Captura de tela](exemplo_json_invalido.png)

- Validação exibida pelo console:
  
![Captura de tela](saida_console_validacao.png)

## Tecnologias
  - C#
  - Console
  
## Rodando localmente

- Clone o projeto

```bash
  https://github.com/Je0225/Gerador-de-JSON.git
```

- Abra o projeto no seu ambiente de desenvolvimento.
- Altere a classe **Program** do programa e crie seus objetos.
- Compile e execute o programa.

