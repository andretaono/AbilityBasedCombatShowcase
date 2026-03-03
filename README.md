# Ability-Based Combat System
A modular, reusable **ability-based combat system** designed for real-time, turn-based, or AI-driven games. The focus of this repository is **architecture and system design**, not a full game implementation. The core system is deterministic, testable, and independent of any specific engine.

This repository only includes the source code - no project files are provided.

---

## Architectural Overview
This repository is intentionally divided into two domains:
- `Andre.AbilityBasedCombat` is the reusable system.
- `Andre.Demo` demonstrates usage.

---

### 1. System Domain (`Andre.AbilityBasedCombat`)
The reusable core system.
- Defines abstractions for abilities, triggers, targeting, conditions, modifiers, and effects
- Executes abilities deterministically
- Orchestrates entity updates
- Enforces architectural boundaries
- Uses MVC structure
- Fully unit-tested

The system is:
- Engine-agnostic
- Stateless where possible
- Deterministic
- Scheduling-independent
- Composition-driven

### 2. Demo / Project Domain (`Andre.Demo`)
An example implementation showing how to use the system.
- Concrete targeting rules
- Concrete effects
- Concrete conditions
- Concrete modifiers
- Example triggers
- Minimal Unity integration

The demo exists **only to provide context**. It is not intended as production gameplay code.
> The system is the product.  
> The demo is an example of how to consume it.

---

## Core Design Principles
### Separate “When” from “What”
- **Triggers** decide *when* an ability executes.
- **Abilities** define *what* happens.

This allows the same ability to be reused by:
- Player input
- AI decision systems
- Cooldowns
- Reactive events

---

### Stateless Abilities
`Ability` is a pure data container:
- Base power
- Targeting rule
- Conditions
- Modifiers
- Effects

It contains no execution logic and no trigger logic. This makes abilities:
- Reusable
- Shareable
- Easy to reason about

---

### Deterministic Execution Pipeline
The execution order is intentionally fixed:

**Trigger → Targeting → Conditions → Modifiers → Effects**

This pipeline is implemented in `AbilityExecutor`.

Execution is:
- Isolated
- Scheduling-agnostic
- Fully deterministic
- Testable without engine context

---

### Clear System Boundaries
The system enforces a strict separation between stable services and dynamic combat context.

#### Services (Infrastructure)
Long-lived capabilities, e.g.:
- Position service
- Health service
- Entity service

These are injected dependencies.

#### Context (Execution State)
Per-execution dynamic data:
- Source entity
- Target entity
- Current calculated value

Context is:
- Minimal
- Explicit
- Short-lived

No services are stored inside execution context.

---

### Composition over Inheritance
Abilities are composed of:
- `ITargetingRule`
- `ICondition`
- `IEffectModifier`
- `IEffect`

Each concern is isolated and replaceable. No deep inheritance hierarchies are used.

---

## Why This Repository Exists
This project demonstrates:
- Clean system boundaries
- Intentional abstraction
- Deterministic execution design
- Practical use of composition
- Separation of scheduling from behavior
- Thoughtful interface usage (not over-engineered)

It is intended to showcase architectural reasoning rather than a full game implementation.



