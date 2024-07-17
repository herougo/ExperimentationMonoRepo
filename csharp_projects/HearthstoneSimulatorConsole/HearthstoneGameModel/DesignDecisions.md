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