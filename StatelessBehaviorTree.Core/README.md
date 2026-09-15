
# Stateless Behavior Tree


## 🌟 Highlights

- Engine agnostic
- Code driven
- Nodes are designed to be stateless
- Behavior selection & execution are meant to be decoupled
- A single tree can be shared with multiple agents



## ℹ️ Overview

>If you don't know anything about behavior tree, I recommend you to watch this [video](https://www.youtube.com/watch?v=6VBCXvfNlCM&t=149s), then read this [article](https://www.gamedeveloper.com/programming/behavior-trees-for-ai-how-they-work) and then watch [this](https://www.youtube.com/watch?v=Qq_xX1JCreI).

**Stateless Behavior Tree** is an engine agnostic framework built to help you create complex behavior.  
Inspired by the functional paradigm, every node is ***stateless*** making single trees easily shareable with multiple AI.


### Features

- Easy tree creation with fluid builder pattern
- Selector & Sequence nodes
- Action & Condition nodes
- Custom node creation is available

## 🚀 Usage

### How it works in a nutshell

   1. A behavior tree consumes datas through a blackboard.
   2. It produces a decision depending on the datas.
   3. The decision is then sent to the corresponding component.
   4. Component executes the decision and reports how it went in the blackboard.
   5. Go back to step 1.

### Example

```cs
// Basic architecture

// Shared data among nodes
BlackBoard memory = new Blackboard();
// Shared data among entities
BlackBoard worldContext = new Blackboard();


BT simpleCombatTree = new BT.Builder()
                 .Sequence("Combat Tree (Sequence)")
                    .Condition(new AttackCondition())
                    .Action(new DoAttack())
                .End()
            .Build();

IAIDecision? decision = simpleCombatTree.Tick(worldContext, memory).decision;

if (decision != null)
    decisionEmitter?.Invoke(decision);

```

## 📦 Dependencies
| Package | Used in | Purpose |
|---|---|---|
| [![Spectre.Console NuGet Version](https://img.shields.io/nuget/v/spectre.console.svg?style=flat&label=NuGet%3A%20Spectre.Console)](https://www.nuget.org/packages/spectre.console) | `BehaviorTree.Demo` only | Pretty console rendering for the demo/tree visualization |

## ⬇️ Installation & Run Demo

```bash
git clone https://github.com/Noomolas01/Stateless-BehaviorTree.git && dotnet build Stateless-BehaviorTree\BehaviorTree.Demo\BehaviorTree.Demo.csproj && dotnet run --project Stateless-BehaviorTree\BehaviorTree.Demo\BehaviorTree.Demo.csproj

```


### ✍️ About Me

Hello, World !  
I'm Muhammad, I study game development and I'm really interested in symbolic AI in video games.
Don't hesitate to message me !  

