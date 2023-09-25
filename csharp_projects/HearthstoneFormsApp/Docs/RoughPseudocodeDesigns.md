# Rough Pseudocode Designs

A space where I can write pseudocode and plan the design of the system.

Ideas

- ModelViewControllerFramework class which is a submodule for something to extend it with the kind of UI you want
- WebFormMvcEventReceiver class for taking events broadcast by the view and applying the corresponding changes
- PlayMinionCommandHandler
  - old: CardMover, DecisionMaker, PlayerActionAttempter, AttackAction (validate, execute)
  - new: CardMover, DecisionMaker, AttackCommand (validate(game), execute())

## UI

### Idea 1 - Incomplete

class HearthstoneForm {
	
}

class ControlManager {
	// private sizes and locations

	// public controls
	Panel MainPanel;

}

class 