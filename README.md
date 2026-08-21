# 📦 Dependencies


_[![Spectre.Console NuGet Version](https://img.shields.io/nuget/v/spectre.console.svg?style=flat&label=NuGet%3A%20Spectre.Console)](https://www.nuget.org/packages/spectre.console)_


## 🌟 Highlights

- Engine Agnostic
- Code-Driven Behavior Tree
- Stateless Nodes
- Clear separation between choosing a behavior and applying it

## ℹ️ Overview

Stateless





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


## ⬇️ Installation



```bash
git clone
```

And be sure to specify any other minimum requirements like Python versions or operating systems.

*You may be inclined to add development instructions here, don't.*


## 💭 Feedback and Contributing

Add a link to the Discussions tab in your repo and invite users to open issues for bugs/feature requests.

This is also a great place to invite others to contribute in any ways that make sense for your project. Point people to your DEVELOPMENT and/or CONTRIBUTING guides if you have them.
### ✍️ Author

Muhammad H. Fayette Mikano