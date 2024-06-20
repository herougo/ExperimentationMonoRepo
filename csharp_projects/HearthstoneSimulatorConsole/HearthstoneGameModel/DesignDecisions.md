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
		new ManaDiscount(new OwnWeaponAttackIntValue()),
		new OwnWeaponAttackIntValueMonitor()
	)
}
```

### b) 