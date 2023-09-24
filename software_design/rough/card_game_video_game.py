'''
V1 - Original HearthstoneSimulator

Cons
- UIManager integrated with the code
'''
def main():
    my_deck = Deck(['C002'] * 30, cls=HSClass.PRIEST.value)
    opp_deck = Deck(['C002'] * 30, cls=HSClass.PRIEST.value)
    player0_text, player1_text = split_text_by_player(player_text)
    decision_maker0 = PlayerDecisionMaker(TextActionGetter(player0_text))
    decision_maker1 = PlayerDecisionMaker(TextActionGetter(player1_text))
    game = HearthstoneGame(my_deck, opp_deck, decision_maker0, decision_maker1)
    game.setup(shuffle_decks=False)
    for player in game.players:
        player.health = 5
    game.play()

class HearthstoneGame:
    def __init__(self, ...):
        ...
        self.ui_manager = UIManager()
        ...

    def play(self):
        for i in range(1000):
            self.loop_actions_until_end_turn()
    def loop_actions_until_end_turn(self):
        end_turn = False
        while not end_turn:
            turn = self.game_metadata.turn

            action = self.decision_makers[turn].get_action()
            if action:
                action_type, args = action
                if action_type == Actions.END_TURN.value:
                    end_turn = True
                    continue
                elif action_type == Actions.ATTACK.value:
                    attacker_card_slot, defender_card_slot = args
                    self.attack(attacker_card_slot, defender_card_slot)
                ...

        self.ui_manager.log_game_state()

'''
V2 - New Proposed Design

CardGame
- CardMechanics
  - CardTypes, Effects, Conditions, Selections
- CardImplementations
  - 
Model classes
- CardGameState
  - Pile
  - CardSlot
  - EffectManager
  - Deck, HSMetadata
  - BoardManager: hands, decks, players, weapons, battleboard
  - Battleboard
  - HearthstoneGame
- CardGameStateChange
  - CardMover
  - DecisionMaker
  - PlayerActionAttempter
    - AttackAction: validate, execute
Controller
- 
View
- 

'''