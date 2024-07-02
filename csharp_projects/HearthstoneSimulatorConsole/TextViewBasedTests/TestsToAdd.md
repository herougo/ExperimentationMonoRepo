# Tests to Add

Game Mechanics

- SetupGameTest.TestConcedeImmediately
  - [x] Players draw 3 and 4 at the start
  - [x] GameOver (player 0 and player 1)
- [ ] Other
  - [ ] fatigue
- [x] Play card
  - [x] left-most
  - [x] middle
  - [x] right-most
  - [x] error: card outside range
  - [x] error: not enough mana
  - [x] error: destination outside range
  - [x] error: not enough space on the battleboard
- [x] Hero Power
  - [x] not enough mana error
  - [x] hero power already used error
  - [x] hero power refresh next turn

Cards
- [x] VentureCoMercenary
- [x] DreadCorsair

Effects

- [ ] Sleep
- [x] Silence
  - [x] opponent stealth
  - [x] your stealth
  - [x] : Dire Wolf Alpha
  - [x] External: adjacent minions of DWA
  - [x] Trigger: Flesheating Ghoul
  - [x] Deathrattle: Leper Gnome
  - [x] Taunt: Shieldbearer
  - [x] Conditional: AmaniBerserker
  - [x] Buff: BloodsailRaider
  - [x] Windfury: Young Dragonhawk
  - [x] Elusive: Faerie Dragon
  - [x] Divine Shield: Argent Squire
  - [x] Sleep
  - [x] Frozen: Frost Elemental
- etc

Attack

- [x] Zero Attack
- [x] Frozen
- [x] Asleep
- [x] Already Attacked
- [x] Already Attacked Twice with Windfury
- [x] Charge
- [x] Disobey Taunt
- [x] Obey Taunt
- [x] Disobey Stealth
- [x] Can't Attack Effect

Battle

- [ ] attacker choice correct (left, middle, right)
- [ ] defender choice correct (left, middle, right)
- ...

[x] 10 Heroes and hero powers

Tricky Effects

[ ] Dread Corsair
[ ] Lightspawn

Missing Cards

- [ ] Secretkeeper
- [ ] Crazed Alchemist
- [ ] Pint-Sized Summoner

### Specific Cases

- [ ] Timelimited effect then switch players (e.g. sleep)
- [ ] change weapon attack outside destruction/equipping



### Unimplemented Features

Game Mechanics

- [ ] Mulligan
- [x] Player 2 starts with the coin
- [x] Players gain and refresh mana with every turn
- [x] Players draw with every turn
- [x] Successful Attack (charge, obeys taunt)
- [x] Unsuccessful Attack (frozen, windfury attacked enough, 0 attack, disobeys taunt, defender has stealth)