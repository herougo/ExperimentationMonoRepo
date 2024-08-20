# Design Decisions

## 1) Resolving WhileSelfDamaged

### a) Send Calculate Stats Event

Where?

### b) Send Healing Event (Chosen)

Plan add EventArgs

## 2) Resolving Dread Corsair

### a) IntValueMonitor, ContinuousManaDiscount, and sending events in UpdateStats

```C#
_inHandEffects = new List<EMEffect> {
	new ContinuousMonitorEffect(
		new ManaChange(new OwnWeaponAttackIntValue(), -1),
		new OwnWeaponAttackIntValueMonitor()
	)
}
```

### b) 

## 3) Resolving Crazed Alchemist

Battlecry

- record attack and health
- add SetAttack and SetMaxHealth
- set health
  - set health event

What about external and conditional effects?

- Priority System for EM Nodes

What about Health buffs? -> should work

## 4) Resolving Poisonous

### a) Multiple event slots

## 5) Resolving DealDamage and DivineShield

### a) Events triggered right away (no plan) while in DealDamage

like NEffects

## 6) Resolving Lorewalker Cho

### a) Add eventSlots to Execute

## 7) Decided to add an option for TimeLimitedEMEffect to not add time-limited to new effects (for Millhouse Manastorm)

## 8) Handling Secrets

1) HearthstoneGame gets SecretManager[player]
2) Attack action gets attack declaration, check, and attack
3) Spell cards have _whenPlayedEffect = new CreateSecret(
     new WhenAttacked(CardType.Minion, CardType.Hero),
	 new DealDamage(SelectionConstants.AllLivingEnemies, 2)
   )
4) 

### 8.1) Split trigger and effect?

```C#
class Trigger {
  public bool ShouldRun(...) {
    
  }
}
```

### 8.2) Handling Events

1) Send to effect manager first, then secret

### 8.3) What does SecretManager do?

1) Plan to include "secret used"
2) Copy of EffectManager? -> No, it needs to be its own thing.
3) List< Secret >, Secret contains card slot, trigger and effect

## 9) BattlerFilter enum instead of something else

# Unresolved

## 10) SendEventArgs instead of N arguments

```C#
// OneTimeEffect
public abstract EffectManagerNodePlan Execute(
	HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
);
// Selection
public abstract List<CardSlot> GetSelectedCardSlots
    (HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
);
// Continuous and Trigger
public override EffectManagerNodePlan SendEvent(
    string effectEvent, HearthstoneGame game,
    EffectManagerNode emNode, List<CardSlot> eventSlots);
// EffectManager
public virtual void SendEvent(string effectEvent, List<CardSlot> eventSlots)
{
    ...
    emNode.SendEvent(effectEvent, _game, eventSlots);
    ...
}
// HearthstoneGame attack declaration
UIManager.ReceiveUIEvent(new AttackUIEvent(attackerCardSlot, defenderCardSlot));
EffectManager.SendEvent(new EffectEventArgs(
    EffectEvent.AttackDeclared,
    new List<CardSlot>() { attackerCardSlot, defenderCardSlot }
));
```

1 idea
1) EffectEventArgs(effectEvent, game, eventSlots)
2) 