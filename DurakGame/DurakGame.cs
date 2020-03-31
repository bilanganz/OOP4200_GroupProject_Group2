﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Card_Lib;
using CardBox;

namespace DurakGame
{
    public partial class frmDurakGame : Form
    {
        private int currentCard;
        private Deck playDeck;
        //change 1
        private Player HumanPlayer = new Player("Player One");
        private Player ComputerPlayer = new Player("Computer");
        private Cards discardedCards;
        static int deckSize = 52;
        private CardBox.CardBox dragCard;

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private const int POP = 25;

        /// <summary>
        /// The regular size of a CardBox control
        /// </summary>
        static private Size regularSize = new Size(250, 100);

        private Deck myDeck = new Deck(deckSize);



        //initialize components of the form
        public frmDurakGame()
        {
            InitializeComponent();

        }

        private void DealHands()
        {            
            for (int c = 0; c < 6; c++)
            {
                HumanPlayer.PlayHand.Add(playDeck.GetCard(currentCard++));
                CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(currentCard));
                flowHumanHand.Controls.Add(aCardBox);
            }

            for (int c = 0; c < 6; c++)
            {
                ComputerPlayer.PlayHand.Add(playDeck.GetCard(currentCard++));
                CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(currentCard));
                flowComputerHand.Controls.Add(aCardBox);
            }
            //RealignCards(flowHumanHand);
        }

        //resets game
        public void ResetGame(object source, EventArgs args)
        {

        }

        //on form load reset game
        private void frmDurakGame_Load(object sender, EventArgs e)
        {
            pbDeck.Image = (new Card()).GetCardImage();
            currentCard = 0;
            playDeck = new Deck(deckSize);
            //playDeck.LastCardDrawn += ResetGame;
            playDeck.Shuffle(deckSize);
            discardedCards = new Cards();
            txtDeckCardsRemaining.Text = playDeck.CardsRemaining.ToString();
            DealHands();
            //ResetGame();
            this.BackgroundImage = Properties.Resources.bg1;
        }

        //starts a new game
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            //ResetGame();

            DisplayAllCardLists();


            //AttackDefendPhase();

        }


        public void AttackDefendPhase()
        {
            //int userInput = 1;
            //Attacking/defendingPhase   
            //myPlayerOne.AttackingPhase(myRiver, userInput);

            //myPlayerTwo.DefendingPhase(myRiver);

            DisplayAllCardLists();

        }



        //on card click will raise event in card image control class
        //clicked card will go through player attack/defend phase method
        private void Card_Click(object sender, EventArgs e)
        {

        }


        //will display all card lists on the windows form
        public void DisplayAllCardLists()
        {

        }

        //displays discard cards
        public void DisplayDiscardCards()
        {

        }

        //displays trump card
        public void DisplayTrumpCards()
        {

        }

        //displays player one cards
        public void DisplayPlayerOneCards()
        {

        }

        //displays player two cards
        public void DisplayPlayerTwoCards()
        {

        }

        //displays river cards
        public void DisplayRiverCards()
        {

        }

        //button pickup clicked ends human turn and picks up cards
        private void btnPickUp_Click(object sender, EventArgs e)
        {

        }

        //cease attack button ends human turn and computer starts attacking
        private void btnCeaseAttack_Click(object sender, EventArgs e)
        {


        }
        private void flpDeck_Paint(object sender, PaintEventArgs e)
        {

        }

        private void new20Deck_Click(object sender, EventArgs e)
        {
            deckSize = 20;
            // myDeck = new GameDeck(deckSize);
            //ResetGame();
        }

        private void new36Deck_Click(object sender, EventArgs e)
        {
            deckSize = 36;
            // myDeck = new GameDeck(deckSize);
            //ResetGame();
        }

        private void new52Deck_Click(object sender, EventArgs e)
        {
            deckSize = 52;
            // myDeck = new GameDeck(deckSize);
            //ResetGame();
        }

        private void lblTrumpCard_Click(object sender, EventArgs e)
        {

        }

        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;

                    // Determine width of all the cards/controls 
                    int allCardWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardWidth) / 2;
                }
                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;

                }
            }
        }

    }
}
