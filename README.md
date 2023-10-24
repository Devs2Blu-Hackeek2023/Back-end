<h1 style="align:center">CO2 Now - Prototipo</h1>

# Ideia
Atualmente, o problema da emissão de gás carbônico está crescendo constantemente. Muitos municípios já se veem na necessidade de implementar medidas restritivas, como uma espécie de 'remédio' para esse problema. Por exemplo, Londres adotou um sistema de cobrança para veículos não autorizados que circulam em áreas de baixas emissões (ULEZ). Essas ações são inspiradas não apenas por Londres, mas também pelo programa Brasil Carbono Zero em 2026. Sabendo disso, nós pensamos em prevenir isso, com uma sistema que simula o mapeamento da emissão de CO2 por veículos nas principais vias de Blumenau.

# Informações Importantes
- **Stack:** C# + Flutter
- **Tema:** Meio Ambiente(3)
- **Público Alvo:** Poder Público
- **Nome Equipe:** SiriusTech

# Funcionalidades

**Requisitos Funcionais**

- Cálculo de emissão de CO2:
    
    Aplicação irá calcular a emissão de CO2 de um veículo que passar por determinada rua, a partir de um ponto inicial e um ponto final. Através da captura da imagens da placa e a distância percorrida.
    
- Visualização de dados:
    
    Será possível visualizar os dados de emissão de CO2 dos veículos de acordo com a permissão por usuário.
    
    1. View *pública* (sem necessidade de login): mostrar dados do total de emissões por ano e por região, horário de maior emissão e modelo de carro que que mais emite CO2, podendo visualizar os dados de acordo com o CEP digitado. 
    2. View *proprietário* (login por proprietário de veículo): mostrar os dados total e por veículo de cada proprietário.
    3. View *admin* (login do Detran): Além das demais views, permitir fazer update nos dados dos veículos.
- Geração de gráficos:
    
    O sistema deve gerar gráficos que mostram a taxa de emissão de CO2 por região (CEP) e por veículo, permitindo uma análise visual dos dados.
    
- Pesquisa de emissão por região:
    
    O sistema deve permitir a possibilidade de pesquisar a emissão de CO2 por CEP digitado

**Requisitos não funcionais**

- Segurança:
    1. Deve haver autenticação de acesso e a permissão diferentes para cada usuário na visualização dos dados.
    2. Apenas o usuário admin deve poder alterar dados dos veículos.
    3. Os dados dos veiculos serão carregados diretamente via API do Detran (simulação).
    
- Usabilidade:
    1. O sistema deve ter versão mobile e web, sendo responsivo em ambos casos.
    2. O sistema deve ter acesso claro e intuitivo com poucas informações em tela, permitindo fácil entendimento ao público em geral.
    
- Compatibilidade com Navegadores:
    
    O sistema deve ser compatível com os principais navegadores da web, incluindo, mas não se limitando a, Google Chrome, Mozilla Firefox, Microsoft Edge, Safari e outros navegadores populares. Os recursos e funcionalidades do sistema devem funcionar consistentemente em todos esses navegadores
    
- Compatibilidade com plataformas mobile:
    
    O sistema deve ser acessível a partir de dispositivos Android, além de ser projetado de forma a permitir a evolução futura para suportar dispositivos IOS.

  # Integrantes

- Edna de Paula
- Gabriel Labes
- Gabriel Scheneider
- Helena Luz
- Jonatha Silva
- Lucas Schneider
- Lucas Theiss
- Rob Caputo
- Vinicius

<a href="https://quickest-macrame-144.notion.site/CO2Now-75dc991ff3a0458c9ef34ab87bd2fbc5">Site para melhor vizualizção</a>






