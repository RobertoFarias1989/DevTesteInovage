# DevTesteInovage
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/RobertoFarias1989/DevTesteInovage/blob/master/LICENSE) 



## 💻 Sobre o projeto

Projeto desenvolvido visando atender ao teste técnico proposto pela empresa [Inovage - SAP Gold Partner](https://inovage.com.br/).

Para executar o projeto ,localmente, será necessário instalar o SQL Server e informar sua string de conexão no appsettings.json.

![image](https://github.com/RobertoFarias1989/DevTesteInovage/assets/118789432/c33b6929-91db-49b4-9da9-7e4517d2eae2)

- Produtos:
![image](https://github.com/RobertoFarias1989/DevTesteInovage/assets/118789432/5cdb70bc-9a0d-42f3-b880-be87a6ef6057)

- Pedidos:
![image](https://github.com/RobertoFarias1989/DevTesteInovage/assets/118789432/3ce60bba-50c3-491e-8f7c-cdbd9604c1ba)

Somente será possível alterar o status do Pedido para à caminho se ele estiver com o status criado.<br/>
Somente será possível alterar o status do Pedido para entregue se ele estiver à caminho.<br/>
Somente será possível alterar o status do Pedido para cancelado se ele não tiver sido entregue.<br/>

- PedidoItens:
![image](https://github.com/RobertoFarias1989/DevTesteInovage/assets/118789432/51c97e05-954d-46dd-8f99-61ac0f14f613)

Somente será possível adicionar um PedidoItem se: o Produto não estiver inativado e o Pedido não tiver sido cancelado.

---

## 🛠 Tecnologias Utilizadas

- Arquitetura limpa

- Entity Framework Core

- Padrão Repository

- AutoMapper

- Validação de APIs com FluentValidation
 
- NET 6

## Autor

- Roberto Farias

[![Linkedin Badge](https://img.shields.io/badge/-Roberto_Farias-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://https://www.linkedin.com/in/robertofarias1989/)](https://www.linkedin.com/in/robertofarias1989/)
[![Gmail Badge](https://img.shields.io/badge/-robertosf1989@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:math.henry04@hotmail.com)](mailto:robertosf1989@gmail.com)

---
