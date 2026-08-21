# 📦 Dependencies


_[![Spectre.Console NuGet Version](https://img.shields.io/nuget/v/spectre.console.svg?style=flat&label=NuGet%3A%20Spectre.Console)](https://www.nuget.org/packages/spectre.console)_


## 🌟 Highlights

- Engine Agnostic
- A code-driven behavior tree
- (Almost) Stateless Nodes
- Behavior selection & execution are decoupled

## ℹ️ Overview

>If you don't know anything about behavior tree, I recommand you to watch this [video](https://www.youtube.com/watch?v=6VBCXvfNlCM&t=149s)

**Stateless Behavior Tree** is a framework build to create easy and maintenable behavior tree for video games.

### Features

Composites node implemented :
- Sequence
- Selector

Leaves node :
- Action
- Condition

## 🚀 Usage


```cs
BlackBoard memory = new Blackboard();
BlackBoard worldContext = new Blackboard();


BT simpleCombatTree = new BT.Builder()
                 .Sequence("Combat Tree (Sequence)")
                    .Condition(new AttackCondition())
                    .Action(new DoAttack())
                .End()
            .Build();

IAIDecision? decision = simpleCombatTree.Tick(worldContext, memory).decision;
sendDecision?.Invoke(decision);

```


## ⬇️ Installation & Run Demo

```bash
git clone https://github.com/Noomolas01/Stateless-BehaviorTree.git && dotnet build Stateless-BehaviorTree\BehaviorTree.Demo\BehaviorTree.Demo.csproj && dotnet run --project Stateless-BehaviorTree\BehaviorTree.Demo\BehaviorTree.Demo.csproj

```


### ✍️ About Me

Hello, I'm Muhammad, I study game development and I'm really interested in symbolic AI in video games.
Don't hesitate to message me !