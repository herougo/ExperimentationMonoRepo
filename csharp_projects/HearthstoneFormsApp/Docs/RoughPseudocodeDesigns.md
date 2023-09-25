# Rough Pseudocode Designs

A space where I can write pseudocode and plan the design of the system.

Unresolved Ideas

- PlayMinionCommandHandler
  - old: CardMover, DecisionMaker, PlayerActionAttempter, AttackAction (validate, execute)
  - new: CardMover, DecisionMaker, AttackCommand (AttackCommandValidator.IsValid(, game), AttackCommandHandler(uses game))
- ViewController???
- Problem
  - finite state machine View behaviour
  - solution: hierarchical MVC framework (i.e. (Model-ViewData-Controller)-Controller-View)?


Resolved Ideas

- ModelViewControllerFramework class which is a submodule for something to extend it with the kind of UI you want
  - make WebFormView an argument for the HSController class (controller should not care what type of view it is)
  - HSController has a ViewData field that's public
  - Also, HSController takes in ViewData as an argument to the constructor
    - GraphicalViewData
- ImageFlyweightManager
- EventManager
  - (interface with notify and post)
  - int AddEventParticipant()
  - void AddSubscription(SenderID, ListenerID)
  - controller outlines the subscriptions
  - problem: If we want to use EventManager, adding view data adds complexity in terms of receiving events (i.e. model <-> view data <-> view instead of model -> view -> model). If an event comes from view data, how do we know where to send it?
    - resolution idea: give view data 2 event participants (one for notify and the other for receiving input)
      - model -> view data notifier -> view -> view data input receiver -> model
      - problem: what if one UI wants drag and drop?
    - resolution
      - model -> view data -> view -(using ControlInputReceptionManager and ViewEventTranslater)-> model
- View components
  - access to ViewData
  - ControlManager
  - ControlInputReceptionManager(ControlManager controlManager)
- Controller components (some)
  - ViewEventTranslater: translates an event from to something from "ViewModel"

Rejected Ideas

- Specialized MvcEventManager
  - 2 methods: Notify, ReceiveInput
    - Model:
      - ReceiveInput => ...
      - Notify => EventManager.NotifyFromModel(event);
    - ViewData
      - ReceiveInput => ...; EventManager.ReceiveInputFromViewData(event); // 
      - Notify => ...; EventManager.NotifyFromViewData(event);
    - View
      - ReceiveInput => EventManager.ReceiveInputFromView()
      - Notify => N/A

## UI

### Idea 1 - Incomplete

class HearthstoneForm {
	
}

class ControlManager {
	// private sizes and locations

	// public controls
	Panel MainPanel;

}
