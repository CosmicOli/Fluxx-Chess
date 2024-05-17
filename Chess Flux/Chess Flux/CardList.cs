using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Flux_Chess.ActionCard;


namespace Flux_Chess
{
    internal class CardList
    {
        static public Card[] cardList = new Card[] {
            new ActionCard("Use What You Take", "Take a card at random from another player's hand, and play it.", new Action<methodParameters>((methodParameters) => CardFunctions.StealCard(ref methodParameters))), 
            
            /*new ActionCard("Today's Special!", "Set your hand aside and draw 3 cards. If today is your birthday, play all 3 cards. If today is a holiday or special anniversary, play 2 of the cards. If it's just another day, play only 1 card. Discard the remainder.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Trash a New Rule", "Select one of the New Rule cards in play and place it in the discard pile.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Discard & Draw", "Discard your entire hand, then draw as many cards as you discarded. Do not cound this card when determining how many replacement cards to draw.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Everybody Gets 1", "Set your hand aside. Count the number of players in the game (including yourself). Draw enough cards to give 1 card to each player, then do so. You decide who gets what.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Everybody Gets 1", "Set your hand aside. Count the number of players in the game (including yourself). Draw enough cards to give 1 card to each player, then do so. You decide who gets what.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Zap A Card", "Choose any card in play anywhere on the table (except for the Basic Rules and any Meta Rules) and add it to your hand.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("It's Trash Day", "All players may choose to discard whatever cards they wish, from their hands or from the table in front of them. Start a new discard pile with this card, and shuffle the old discard pile into the draw pile.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Taxation!", "Each player must choose 1 card from their hand and give it to you.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Let's Simplify", "Discard your choice of up to half (rounded up) of the New Rule cards currently in play.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Trade Hands", "Trade your hand for the hand of one of your opponents.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Draw 2 and Use 'em", "Set your hand aside. Draw 2 cards, play them in the order you choose, then pick up your hand and continue with your turn. This card, and all cards played because of it, are counted as a single play.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Empty the Trash", "Start a new discard pile with this card and shuffle the rest of the discard pile back into the draw pile.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("No Limits", "Discard all Hand Limit rules currrently in play.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Let's Do That Again!", "Search through the discard pile. Take any Action or New Rule card you wish, and immediately play it. Anyone may look through the discard pile at any time, but the order of what's in the pile should never be changed.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Take Another Turn", "Take another turn as soon as you finish this one.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Time Vortex", "Gather up the cards from everyone's hands, shuffle them up (without looking) and deal them out evenly, starting with yourself.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Pandora's Box", "Draw a card. If it's a New Rule, put the card into play, if not, discard it. Keep doing this until you have played 3 New Rule cards.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Rules Reset", "Reset to the Basic Rules. Discard all New Rule cards, and leave only the Basic Rules (and any Meta Rule cards) in play. Don't discard the current Goal.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Draw 3 play 2 of them", "Set your hand aside. Draw 3 cards and play 2 of them. Discard the last card, then pick up your hand and continue with your turn. This card, and all cards played because of it, are counted as a single play.", new Action<methodParameters>((methodParameters) => ref methodParameters)), 
            
            new ActionCard("Jackpot!", "Draw 3 extra cards!", new Action<methodParameters>((methodParameters) => ref methodParameters))*/
        };
    }
}
