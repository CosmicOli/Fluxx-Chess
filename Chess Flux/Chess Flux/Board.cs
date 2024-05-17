using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Flux_Chess
{
    internal class Board
    {
        UI ui = new UI();

        protected record RulesAndGoalsCards
        {
            public List<GoalCard> goalCards { get; set; }

            public DrawCard drawCard { get; set; } 

            public PlayCard playCard { get; set; } 

            public MoveCard moveCard { get; set; }

            public HandLimitCard handLimitCard { get; set; }

            public GoalLimitCard goalLimitCard { get; set; }
        }

        RulesAndGoalsCards rulesAndGoalsCards;

        int currentTurn = 0;
        Player whitePlayer = new Player(Rules.handLimit.Value);
        Player blackPlayer = new Player(Rules.handLimit.Value);

        Deck drawDeck = new Deck(new List<Card>());
        Deck discardDeck = new Deck(new List<Card>());

        public Board(Deck drawDeck, GoalCard goalCard, DrawCard drawCard, PlayCard playCard, MoveCard moveCard, HandLimitCard handLimitCard, GoalLimitCard goalLimitCard)
        {
            this.drawDeck = drawDeck;
            List<GoalCard> newList = new List<GoalCard> { goalCard };
            rulesAndGoalsCards = new RulesAndGoalsCards { goalCards = newList, drawCard = drawCard, playCard = playCard, moveCard = moveCard, handLimitCard = handLimitCard, goalLimitCard = goalLimitCard };
        }

        public void UpdateRules()
        {
            Rules.drawAmount = rulesAndGoalsCards.drawCard.DrawAmount;
            Rules.playAmount = rulesAndGoalsCards.playCard.PlayAmount;
            Rules.moveAmount = rulesAndGoalsCards.moveCard.MoveAmount;
            Rules.handLimit = rulesAndGoalsCards.handLimitCard.HandLimit;
            Rules.goalLimit = rulesAndGoalsCards.goalLimitCard.GoalLimit;
        }

        public RuleCard[] GetCurrentBoard(out List<GoalCard> goals)
        {
            // They are not returned using the locally defined struct as that doesn't need to exist outside this scope.
            // It exists within this class as it makes the code a lot neater, but it makes the code less neat to exist outside of this class.
            RuleCard[] ruleCards = { rulesAndGoalsCards.drawCard, rulesAndGoalsCards.playCard, rulesAndGoalsCards.moveCard, rulesAndGoalsCards.handLimitCard, rulesAndGoalsCards.goalLimitCard };

            goals = new List<GoalCard>();
            foreach (GoalCard goalCard in rulesAndGoalsCards.goalCards)
            {
                goals.Add(goalCard);
            }
            return ruleCards;
        }

        public void UseCard(Card card, Player playingPlayer, Player nonPlayingPlayer, Object additionalInput)
        {
            Type t = card.GetType();
            if (t.IsSubclassOf(typeof(RuleCard)))
            {
                switch (t.Name)
                {
                    case nameof(DrawCard):
                        rulesAndGoalsCards.drawCard = (DrawCard)card;
                        UpdateRules();
                        break;

                    case nameof(PlayCard):
                        rulesAndGoalsCards.playCard = (PlayCard)card;
                        UpdateRules();
                        break;

                    case nameof(MoveCard):
                        rulesAndGoalsCards.moveCard = (MoveCard)card;
                        UpdateRules();
                        break;

                    case nameof(HandLimitCard):
                        rulesAndGoalsCards.handLimitCard = (HandLimitCard)card;
                        UpdateRules();
                        break;

                    case nameof(GoalLimitCard):
                        rulesAndGoalsCards.goalLimitCard = (GoalLimitCard)card;
                        UpdateRules();
                        ChangeGoals();
                        break;
                }
            }
            else if (t.Equals(typeof(ActionCard)))
            {
                /* There are 2 paradigms I could do here:
                 *      Store cards as their names and info in a text file, then run code based on their names in a card code file.
                 *      Store cards as their names and info and code in a text file, then compile and run that code at runtime when importing the cards.
                 *      
                 * Personally I prefer option 2, as it keeps all card data in one place and then the program simply imports the card data, instead of hard coding the cards into the code.
                 * It is however slower due to compiling and running at runtime, as well as arguably bad practice especially in a compiled language.
                 * Speed isnt a problem though in this program due to its infrequent running of code, and furthermore I think it'd be fun to try this method regardless.
                 * 
                 * There is a major problem, .NET core doesn't support Microsoft.CodeDom as it uses Roslyn in favour of it, and Roslyn doesn't have good documentation.
                 */

                // Action<Player, Player, int> stealCard = (playingPlayer, nonPlayingPlayer, cardNumber) => CardFunctions.StealCard(ref playingPlayer, ref nonPlayingPlayer, cardNumber);

                ActionCard.methodParameters methodParameters = new ActionCard.methodParameters { playingPlayer = playingPlayer, nonPlayingPlayer = nonPlayingPlayer, discardDeck = discardDeck, drawDeck = drawDeck };
                ((ActionCard)card).Code(methodParameters);

            }
            else if (t.Equals(typeof(GoalCard)))
            {
                rulesAndGoalsCards.goalCards.Add((GoalCard)card);
                ChangeGoals();
            }

            void ChangeGoals()
            {
                if (Rules.goalLimit.HasValue)
                {
                    while (rulesAndGoalsCards.goalCards.Count > Rules.goalLimit)
                    {
                        ui.Output("Please pick a goal card to remove.");
                        int cardNumberToRemove = Convert.ToInt32(ui.GetInput());
                        GoalCard discardedGoal = rulesAndGoalsCards.goalCards[cardNumberToRemove];
                        discardDeck.Push(discardedGoal);
                        rulesAndGoalsCards.goalCards.RemoveAt(cardNumberToRemove);
                    }
                }
            }
        }

        public void TakeTurn()
        {
            void Turn(ref Player playingPlayer, ref Player nonPlayingPlayer)
            {
                playingPlayer.DrawWithRules(ref drawDeck);

                ui.Output($"You have {Rules.moveAmount} moves.");
                
                for (int plays = 0; plays < Rules.playAmount; plays++)
                {
                    int cardNumber = Convert.ToInt16(ui.GetInput());
                    UseCard(playingPlayer.Discard(cardNumber), playingPlayer, nonPlayingPlayer, 3);
                }

                if (Rules.handLimit.HasValue)
                {
                    while (playingPlayer.Hand.Count > Rules.handLimit)
                    {
                        ui.Output("Please pick a card in your hand to remove.");
                        int cardNumberToRemove = Convert.ToInt32(ui.GetInput());
                        Card discardedCard = playingPlayer.Hand[cardNumberToRemove];
                        discardDeck.Push(discardedCard);
                        playingPlayer.Hand.PopAt(cardNumberToRemove);
                    }
                }
            }

            currentTurn++;

            if (currentTurn % 2 == 1)
            {
                Turn(ref whitePlayer, ref blackPlayer);
            }
            if (currentTurn % 2 == 0)
            {
                Turn(ref blackPlayer, ref blackPlayer);
            }
        }
    }
}
