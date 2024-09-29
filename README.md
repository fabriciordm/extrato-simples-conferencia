<b><p align="center">
Sistema de Visualização de Extratos Bancários
</p></b> 



![image](https://github.com/user-attachments/assets/a314c7e3-fd09-4c1e-9886-8aea995291a6)

![image](https://github.com/user-attachments/assets/ecdf4727-4f40-4852-8bc6-6b30db7aa687)



Este projeto é um sistema de visualização de extratos bancários desenvolvido utilizando ASP.NET Core MVC com .NET 8. O objetivo é permitir que correntistas visualizem seus extratos diretamente através de um aplicativo, com a opção de aplicar filtros e exportar os dados em formato PDF.

<b><p align="center">
Funcionalidades Principais
</p></b>


<b><p align="left">
Filtro de Datas
</p></b>
O usuário pode visualizar transações dos últimos 5, 10, 15 ou 20 dias.

<b><p align="left">
Visualização de Extrato
</p></b>
O extrato é apresentado com as seguintes colunas:
Data (formato: dd/MM)
Tipo da Transação
Valor Monetário

<b><p align="left">
Exportação para PDF
</p></b>
O usuário pode gerar um arquivo PDF com os dados do extrato para fins de impressão ou compartilhamento.

<b><p align="left">
Arquitetura e Padrões Utilizados
</p></b>

O projeto segue o padrão Model-View-Controller (MVC), garantindo uma separação clara entre lógica de negócio, interface do usuário e acesso a dados. Além disso, são aplicados os principais princípios de design de software, como SOLID, para manter a qualidade e a manutenibilidade do código.

<b><p align="center">
Endpoints
</p></b>

O projeto disponibiliza uma série de endpoints RESTful para que o aplicativo bancário possa consumir os dados do extrato e interagir com as funcionalidades do sistema. Esses endpoints são responsáveis por carregar os dados necessários para a interface do usuário e processar entradas e filtros.

![image](https://github.com/user-attachments/assets/41d45867-2ebc-4c70-a04f-6b90a3fc6cbc)

![image](https://github.com/user-attachments/assets/6b1cd8e8-e907-4cc1-a3d2-406190a59bf1)


<b><p align="center">
Tecnologias Utilizadas e abordagens utilizadas
</p></b>
<b><p align="center">
.NET 8 - Entity Framework Core - MVC - Geração de PDF (PdfSharp) - DDD - 
Design Patterns
</p></b>


