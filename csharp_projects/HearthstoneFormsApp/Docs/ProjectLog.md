

September 24, 2023 - Sunday

- 2h - 1:45pm - 3:40pm: C# project setup and basic layout figure out
- 25min - 3:40pm - 4:05pm: plan future features
- 3.3h - 4:30pm - 7:50pm: ControlManager class work
- 3.3h - 10:10pm - 1:30pm: software design brainstorming

September 25, 2023 - Monday

- 2.83 - 10:40am - 1:30pm: MVC simple app

(some unlogged work)

October 10, 2023 - Tuesday

- 3.5h - 3:20pm - 6:50pm: Adapting to event handler style
- 1h - 11:20pm? - 12:20am: Adapting to event handler style (done)

** My interpretation
Model: manages the game state
View:
- receives events from the model and updates the view
- receives click events and sends them to the controller


To Do

- [x] C# project setup
- [x] basic layout figure out
- [x] create class to manage the game panel view
- [ ] create basic game with 1 minion type
  - [x] boilerplate MVC
  - [ ] challenges
    - [ ] handling click-based action getting
  - [ ] boilerplate Model
    - [ ] HearthstoneGame
    - [ ] BoardManager
    - [ ] Battleboard
    - [ ] EffectManager
    - [ ] Deck
    - [ ] HSMetadata
    - [ ] CardSlot
    - [ ] Pile
    - [ ] CardMover
    - [ ] DecisionMaker
    - [ ] PlayerActionAttemper
  - [ ] View (WebForms and "view model")
    - [ ] both hands
    - [ ] weapon
    - [ ] battleboard
    - [ ] hero health/attack
    - [ ] deck
  - [ ] Controller
- [ ] end turn
- [ ] play minion
- [ ] weapons
- [ ] minion attack action
- [ ] concede
- [ ] minion death
- [ ] Unit Test Suite
  - [ ] 1st test
  - [ ] snapshot implementation
  - [ ] per card
  - [ ] minion death
  - [ ] 
