<div align="center">

# 🦣 ExtinctionVerse: O Museu dos Gigantes Perdidos

**MVP de Museu Virtual em Realidade Virtual (VR) para o desafio ExpoVerse — Hackweb**

[![Unity](https://img.shields.io/badge/Unity-6000.3.8f1-black?logo=unity&logoColor=white)](https://unity.com/)
[![Meta XR SDK](https://img.shields.io/badge/Meta%20XR%20SDK-201.0.0-0064e0?logo=meta&logoColor=white)](https://developer.oculus.com/)
[![Platform](https://img.shields.io/badge/Platform-Meta%20Quest%20(Android)-green?logo=android&logoColor=white)](https://www.meta.com/quest/)
[![URP](https://img.shields.io/badge/Render%20Pipeline-URP%2017.3.0-blueviolet)](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@17.3/manual/index.html)
[![License](https://img.shields.io/badge/License-MIT-brightgreen)](LICENSE)

</div>

---

## 📖 Sobre o Projeto

O **ExtinctionVerse: O Museu dos Gigantes Perdidos** é um museu virtual interativo em **Realidade Virtual (VR)**, desenvolvido na engine **Unity 6** e projetado para dispositivos standalone **Meta Quest**. O projeto foi criado como solução para o desafio **ExpoVerse no Hackweb**.

### 🎯 O Problema que Resolve

Sites e apresentações tradicionais sobre animais extintos são limitados: textos, fotos bidimensionais e vídeos não conseguem transmitir a escala real, a presença física e a grandiosidade das criaturas que habitaram a Terra. O **ExtinctionVerse** usa o Metaverso para resolver esse problema, proporcionando algo **impossível no mundo real**: caminhar lado a lado e interagir com animais extintos em escala 1:1.

### ✨ A Experiência Criada

Ao entrar no museu virtual, o usuário é transportado para uma **galeria digital minimalista e atmosférica** com 5 estações lineares. Cada estação apresenta um **modelo 3D** de um animal histórico posicionado sobre um pedestal iluminado. Ao se aproximar de cada estação, um **Totem Interativo** permite que o usuário ative um painel flutuante de informações no espaço 3D — trazendo curiosidades científicas, contexto histórico e dados sobre a extinção de cada espécie.

---

## 🦴 As 5 Estações do Museu

| # | Animal | Período / Época | Tema Central |
|---|--------|----------------|--------------|
| 1 | 🦈 **Megalodon** *(Otodus megalodon)* | Mioceno–Plioceno (~3,6 Ma) | O maior predador marinho de todos os tempos e a supremacia dos oceanos primitivos |
| 2 | 🦏 **Black Rhinoceros** *(Diceros bicornis)* | Século XX (quase extinto) | Impacto devastador da caça predatória e do tráfico de animais selvagens |
| 3 | 🦣 **Mammoth** *(Mammuthus primigenius)* | Pleistoceno (~10.000 a.C.) | Mudanças climáticas da Era do Gelo e caça primitiva como causas da extinção |
| 4 | 🦅 **Archaeopteryx** *(Archaeopteryx lithographica)* | Jurássico (~150 Ma) | O elo perdido: a transição evolutiva entre dinossauros e aves modernas |
| 5 | 🐆 **Smilodon** *(Smilodon fatalis)* | Pleistoceno (~10.000 a.C.) | O predador alfa da megafauna e a evolução extrema dos felinos |

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Versão | Função |
|------------|--------|--------|
| **Unity** | 6000.3.8f1 (Unity 6) | Engine principal de desenvolvimento |
| **Meta XR SDK** | 201.0.0 | SDK para interação VR no Meta Quest |
| **OpenXR** | 1.16.1 | Camada de abstração multiplataforma para XR |
| **Universal Render Pipeline (URP)** | 17.3.0 | Pipeline de renderização otimizado para VR |
| **Unity Input System** | 1.18.0 | Sistema de entrada para controles do Quest |
| **TextMesh Pro** | — | Renderização de texto de alta qualidade nos totens |
| **C#** | — | Linguagem de programação dos scripts de interatividade |
| **Android (Meta Quest OS)** | — | Plataforma alvo de deploy |

---

## 🏗️ Arquitetura e Scripts

O projeto é intencionalmente simples e limpo para garantir performance em hardware standalone:

### [`FollowHeadset.cs`](Assets/Scripts/FollowHeadset.cs)
Responsável pelo **sistema de locomoção híbrido** do personagem:
- Sincroniza o `CharacterController` com a posição física do headset no espaço real (tracking room-scale)
- Implementa **locomoção artificial** via analógico esquerdo do controle, com direção relativa ao olhar do usuário

### [`TotemTrigger.cs`](Assets/Scripts/TotemTrigger.cs) *(CanvasTrigger)*
Responsável pela **mecânica central de interatividade** das estações:
- Detecta quando o player entra na zona de proximidade de um totem via `OnTriggerEnter`
- Ativa dinamicamente o `Canvas 3D` (World Space UI) com informações do animal
- Oculta o canvas automaticamente ao sair da área (`OnTriggerExit`), garantindo UI limpa

```
Assets/
├── Scripts/
│   ├── FollowHeadset.cs      # Sistema de locomoção (físico + analógico)
│   └── TotemTrigger.cs       # Mecânica de ativação dos painéis informativos
├── Models/
│   ├── mammoth/              # Modelo 3D do Mamute
│   ├── sabre/                # Modelo 3D do Tigre Dente-de-Sabre
│   ├── archaeopteryx/        # Modelo 3D do Archaeopteryx
│   ├── black-rhinoceros/     # Modelo 3D de referência
│   └── megalodon/            # Modelo 3D de referência
├── Scenes/
│   └── SampleScene.unity     # Cena principal do museu
├── Materials/                # Materiais e texturas URP
├── Animation/                # Animações dos modelos
└── Settings/                 # Configurações URP e XR
```

---

## 🚀 Instruções de Execução

### Pré-requisitos

- **Unity Hub** instalado ([download](https://unity.com/download))
- **Unity 6000.3.8f1** instalado com os seguintes módulos:
  - `Android Build Support`
  - `Android SDK & NDK Tools`
  - `OpenJDK`
- **Meta Quest Developer Hub** (opcional, para deploy via USB)
- **Meta Quest 2, 3 ou Pro** com modo desenvolvedor ativado, **OU**
- **Meta XR Simulator** (incluído no SDK, para testar no PC)

---

### ▶️ Opção 1 — Executar no Meta XR Simulator (PC, sem óculos)

> ✅ Método mais rápido para avaliar e testar a experiência diretamente no editor Unity.

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/KaioGabriel-the/Extinction-Verse.git
   cd extinction_verse
   ```

2. **Abra o projeto no Unity Hub:**
   - Clique em `Add project from disk` e selecione a pasta `extinction_verse`
   - Confirme a versão **Unity 6000.3.8f1**

3. **Abra a cena principal:**
   - No painel `Project`, navegue até `Assets/Scenes/`
   - Dê duplo clique em `SampleScene.unity`

4. **Ative o Meta XR Simulator:**
   - Vá em `Meta > Simulator > Enable`

5. **Pressione Play** (▶) no editor.
   - Use o simulador para navegar pelo museu com teclado e mouse

---

### 📱 Opção 2 — Build e Deploy no Meta Quest (APK)

> ✅ Método para a experiência VR completa e imersiva.

1. Siga os passos 1–3 da Opção 1 para clonar e abrir o projeto.

2. **Configure o Build Settings:**
   - Vá em `File > Build Settings`
   - Selecione a plataforma **Android**
   - Clique em `Switch Platform`

3. **Conecte seu Meta Quest** ao PC via cabo USB e certifique-se que o **modo desenvolvedor** está ativo.

4. **Build & Run:**
   - Em `Build Settings`, clique em `Build And Run`
   - Aguarde a compilação e o APK será instalado automaticamente no óculos

5. No Quest, vá em **"Biblioteca de aplicativos > Desconhecido"** para encontrar e abrir o ExtinctionVerse.

---

### 🎮 Controles (Meta Quest)

| Ação | Controle |
|------|----------|
| Mover pelo museu | Analógico Esquerdo |
| Ativar totem informativo | Aproximar-se do pedestal da estação |
| Fechar painel | Afastar-se da estação |
| Visualizar animais | Olhar ao redor (rotação de cabeça) |

---

## 🎥 Demonstração e Evidências de Funcionamento

> **📌 Substitua os placeholders abaixo com seus links reais antes de submeter.**

### 🎬 Vídeo Demo
[![Assista ao Demo](https://img.shields.io/badge/▶%20Assistir%20Demo-YouTube-red?logo=youtube)](https://youtu.be/RSV1bJYtarE)

> Demonstração completa navegando pelas 5 estações do museu, ativando os totens e visualizando os painéis informativos.

## 🔄 Fluxo de Navegação (Demonstração para a Banca)

Para avaliar a experiência completa, siga este fluxo:

```
1. 🚪 Entrada no museu — observe o ambiente da galeria
       ↓
2. 🦈 Estação 1 — Aproxime-se do Megalodon
   → Painel ativa automaticamente com informações sobre o gigante dos mares
   → Afaste-se para fechar o painel
       ↓
3. 🦏 Estação 2 — Black Rhinoceros
   → Visualize o modelo 3D em escala real
   → Leia sobre o impacto da caça predatória humana
       ↓
4. 🦣 Estação 3 — Mammoth
   → Observe a escala real do animal no espaço 3D
   → Ative o totem para curiosidades sobre a Era do Gelo
       ↓
5. 🦅 Estação 4 — Archaeopteryx
   → Leia sobre o elo perdido entre dinossauros e aves
       ↓
6. 🐆 Estação 5 — Smilodon
   → Conheça o predador alfa da megafauna pré-histórica
```

---

## 🌱 Valor Educacional e Proposta de Impacto

O **ExtinctionVerse** demonstra como ambientes imersivos em 3D podem **revolucionar o ensino** de:

- 🧬 **Biologia Evolutiva** — visualização de adaptações físicas em escala real
- 📜 **História Natural** — contextualização temporal das extinções
- 🌍 **Consciência Ambiental** — conexão emocional com espécies perdidas para incentivar conservação
- 🦕 **Paleontologia** — experiência "impossível no mundo real" de conviver com megafauna extinta

---

## 📋 Detalhes Técnicos Adicionais

| Item | Detalhe |
|------|---------|
| **Engine** | Unity 6000.3.8f1 |
| **Plataforma Alvo** | Android (Meta Quest 2 / 3 / Pro) |
| **API Gráfica** | OpenGL ES 3.0 / Vulkan |
| **Render Pipeline** | Universal Render Pipeline (URP) 17.3 |
| **XR Plugin** | Meta XR SDK 201.0.0 + OpenXR 1.16.1 |
| **UI do Museu** | World Space Canvas (Canvas 3D no espaço) |
| **Cenas** | 1 cena principal (`SampleScene`) |
| **Scripts C#** | 2 scripts core (`FollowHeadset`, `CanvasTrigger`) |

---

## 🔗 Links do Projeto

| Recurso | Link |
|---------|------|
| 📦 Repositório | [github.com/KaioGabriel-the/extinction_verse](https://github.com/KaioGabriel-the/Extinction-Verse.git) |
| 🎬 Vídeo Demo | [YouTube](https://youtu.be/RSV1bJYtarE) |
| 🎤 Vídeo Pitch | [YouTube](https://youtu.be/SEU_LINK_PITCH) |
| 📋 Template do Desafio | [ExpoVerse — Hackweb](https://SEU_LINK_TEMPLATE) |

---

## 👨‍💻 Equipe

| Nome | Papel | GitHub |
|------|-------|--------|
| **Kaio Gabriel** | Desenvolvedor VR / Unity (solo) | [@KaioGabriel-the](https://github.com/KaioGabriel-the) |

---

## 🎨 Créditos dos Modelos 3D

Todos os modelos 3D utilizados no projeto foram obtidos no [Sketchfab](https://sketchfab.com) e estão licenciados sob a licença **Creative Commons Attribution 4.0 International (CC BY 4.0)**.

> A licença CC BY 4.0 permite uso, adaptação e redistribuição para qualquer finalidade, incluindo comercial, desde que os créditos ao(s) autor(es) original(is) sejam mantidos.

### 🐾 Modelos de Animais

| Modelo | Autor | Link | Licença |
|--------|-------|------|---------|
| **MAMMOTH** | seth the yutyrannus | [skfb.ly/oM76B](https://skfb.ly/oM76B) | [CC BY 4.0](http://creativecommons.org/licenses/by/4.0/) |
| **SABRE** *(Smilodon)* | seth the yutyrannus | [skfb.ly/oM76K](https://skfb.ly/oM76K) | [CC BY 4.0](http://creativecommons.org/licenses/by/4.0/) |
| **ARK archaeopteryx** | seth the yutyrannus | [skfb.ly/oRIzs](https://skfb.ly/oRIzs) | [CC BY 4.0](http://creativecommons.org/licenses/by/4.0/) |
| **ARK Survival Evolved: Megalodon** | Sealife Fan 3 | [skfb.ly/p8GUQ](https://skfb.ly/p8GUQ) | [CC BY 4.0](http://creativecommons.org/licenses/by/4.0/) |
| **Black Rhinoceros** | planeta-elefante | [skfb.ly/pzJsT](https://skfb.ly/pzJsT) | [CC BY 4.0](http://creativecommons.org/licenses/by/4.0/) |

### 🏛️ Modelos Decorativos / Ambiente

| Modelo | Autor | Link | Licença |
|--------|-------|------|---------|
| **Ancient stone sculpture** | xideaa | [skfb.ly/6UNOE](https://skfb.ly/6UNOE) | [CC BY 4.0](http://creativecommons.org/licenses/by/4.0/) |
| **Copy of Aztec sun stone, Museo Nacioanal** | Världskulturmuseerna | [skfb.ly/ouU7w](https://skfb.ly/ouU7w) | [CC BY 4.0](http://creativecommons.org/licenses/by/4.0/) |

---

## 📄 Licença

Este projeto está licenciado sob a licença **MIT**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

<div align="center">

**Feito com ❤️ para o Hackweb — ExpoVerse Challenge**

*"A extinção é para sempre. A memória, não."*

</div>
