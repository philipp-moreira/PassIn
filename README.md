
# Pass.In

## Resumo
Aplicação com o objetivo de viabilizar a gestão de eventos presenciais.

## Especificação

- ####  Backend
    - #### Requisitos
        - ##### 1 - Funcionais
            - 1.1 Cadastrar evento;
            - 1.2 Cadastrar um participante em um evento;
            - 1.3 Realizar check-in de um participante em um evento;
            - 1.4 Consultar um evento;
            - 1.5 Consultar uma participação;
            - 1.6 Consultar lista de participantes de um evento;
            - ##### - Regras de Negócio
                - O participante deve poder se inscrever em um evento apenas uma vez;
                - O participante deve poder ser inscrever em um evento que possua vaga disponível;

                >>**Nota**: Check-In: Confirmação de presença no evento
        - ##### 2 - Não Funcionais
            - N/C*

- #### Frontend
    *Não é escopo desta solução implementar a solução para frontend.*

    - #### Requisitos
        - ##### 1 - Funcionais
            - ~~1.1 Cadastrar evento;~~
            - ~~1.2 Cadastrar um participante em um evento;~~
            - ~~1.3 Realizar check-in de um participante em um evento;~~
            - ~~1.4 Consultar um evento;~~
            - ~~1.5 Consultar uma participação/visualizar o crachá de inscrição;~~
            - ~~1.6 Consultar lista de participantes de um evento;~~
            - ##### - Regras de Negócio
                - O participante deve poder se inscrever em um evento apenas uma vez;
                - O participante deve poder ser inscrever em um evento que possua vaga disponível;
                >>**Nota**: Check-In: Confirmação de presença no evento
        - ##### 2 - Não Funcionais
            - ~~2.1 O check-in no evento será realizado através de um QRCode;~~

- #### Diagrama(s) 
    - UML
    - DER (Diagrama Entidade Relacionamento)

- #### Stack
    - Banco de Dados
        - ![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)
    - Aplicação/Web API RestFull
        - ![Static Badge](https://img.shields.io/badge/.NET-v8.0-blue?style=flat-square)
        - ![Static Badge](https://img.shields.io/badge/C%23--blue?style=flat-square&logo=csharp&logoColor=green)
        
        - ![Static Badge](https://img.shields.io/badge/openapi-v3.0-green?style=flat-square&logo=swagger&logoColor=%2385EA2D)
