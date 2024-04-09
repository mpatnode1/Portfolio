using System;
using System.Security.Cryptography.X509Certificates;

namespace AdventureGame
{

    public class Game
    {
        public static void Main(string[] args)
        {
        
            var decisions = new Decisions();

            //style 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "Magic Burger Palace";
            ASCIIArt.Title();

            //opening text
            var OpeningText = new DialogueText("./TextScripts/OpeningText_1.txt");
            OpeningText.Run();

            //establishes player's name playerName 
            Console.WriteLine("Anyways, what should we put on your nametag? Type your name in and hit enter.");
            decisions.PlayerName = Console.ReadLine();
            Console.WriteLine($"Great, {decisions.PlayerName}! We'll get you started on registering. You'll want to treat each customer with excellent customer service, even if you meet a few weird characters. It's not complicated, you'll get the hang of it.");

          
        
            //asks player do you want to know history - opens dialogue later
            var HistoryText = new DialogueText("./TextScripts/HistoryText_2.txt");
            HistoryText.Run();
            Console.WriteLine("Before you get started, did you wanna hear some of the history of the establishment, or get right into it? Remember, type a number and hit enter to respond.");
            //dialogue options for historytext 1 yes 2 no 
            var HistoryTextChoice = new TextChunks("./TextScripts/TextChunks/HistoryTextChoice_3.txt");
            HistoryTextChoice.Run();
    

            // console response to players choice for whether they hear history
            while(true)
            {
            decisions.HistoryDecision = Console.ReadKey(true).KeyChar;
            if (decisions.HistoryDecision == '1')
                {
                    Console.WriteLine("This place actually used to be a bank, yeah it’s crazy right, you can’t even tell anymore. I mean that’s cause we bulldozed right through it and replaced it with AMAZING sterile white and red walls. Really takes a modern feel to the idea of fast casual dining. We actually just opened a couple months back, before this it was a sub shop called “The UnBread.” You don’t wanna know why they got shut down..");
                    decisions.ScoreAdjustment(25);
                    Console.ReadLine();
                    break;
                }
                else if (decisions.HistoryDecision == '2')
                {
                    Console.WriteLine("Don't think to hard about what you're 'getting paid in.'");
                    Console.ReadLine();
                    break;
                }
                else
                {

                    Console.WriteLine("Nice try buddy. Pick again.");
                }
            }


            Console.WriteLine("ANYWAYS... Let's get you started. Here's your first customer now.");
            Console.ReadLine();


            //Gertrude Intro
            var GertrudeEnterText = new TextChunks("./TextScripts/TextChunks/GertrudeEnter_4.txt");
            GertrudeEnterText.Run();
            Console.ReadLine();
            ASCIIArt.ZombieFull();
            
            var LadyFingerText = new DialogueText("./TextScripts/LadyFingerCon_5.txt");
            LadyFingerText.Run();

            // if player earlier chose to hear history they can response to gert with context

            if (decisions.HistoryDecision == '1')
            {
                ASCIIArt.ZombieHand();
                var Sorry1Choice = new DialogueText("./TextScripts/Sorry1Dialogue_6.txt");
                Sorry1Choice.Run();
                decisions.ScoreAdjustment(25);
             
            }
            else
            {
                Console.WriteLine("An odd request, not only would you not recommend grilling a sponge cake, you don’t serve it either way.");
                Console.ReadLine();
                var NoSorryDialogue = new DialogueText("./TextScripts/NoSorry2Dialogue_7.txt");
                NoSorryDialogue.Run();
            }
            
            Console.ReadLine();
            Console.WriteLine("There is no hot fudge sundae. This store has never sold a hot fudge sundae. You decide it’s best not to argue further.");
            IceCream HotFudgeSundae = new IceCream();
            HotFudgeSundae.ItemName = "Suspicious Hot Fudge Sundae";
            HotFudgeSundae.MenuDisplay();

            HotFudgeSundae.MenuItemName();

            // player rings up gerty and receives extra dime choice
            var RingupText = new DialogueText("./TextScripts/RingUp_8.txt");
            RingupText.Run();
            // choices
            var DimeDialogueChoices = new TextChunks("./TextScripts/TextChunks/DimeDialogue_9.txt");
            DimeDialogueChoices.Run();

            bool IncompleteDime = true;
            bool IncompleteEnd = true;
            while(IncompleteDime)
            {
                var DimeResponse = Console.ReadKey(true).KeyChar;
                switch(DimeResponse) 
                {
                    case '1': //ACCEPTS DIME
                    case '2': //CONFRONTS CUSTOMER
                    if (DimeResponse == '2'){
                        Console.WriteLine("Gerty is staring open-mouthed at her phone like a tablet baby. You can't break through the trance of her friend's grandkids' facebook photos.");
                    }
                    Console.WriteLine("Including the rogue dime, what is the customer's change? Type in a decimal value:");

                    double x = 0;
                    while(true)
                    {
                        string input = Console.ReadLine();
                        try{
                            x = double.Parse(input);
                            if (x == 4.64){//ending 1 - player gets best ending 
                                Console.WriteLine("She grabs the change and the cup, walking off without saying a word. Despite the lackluster customer engagement, you’d say this was a success.");
                                decisions.ScoreAdjustment(50);
                                var Ending1End = new DialogueText("./TextScripts/Endings/Ending1.txt");
                                Ending1End.Run();

                                Util.EndingSequence(1, decisions);
                            }
                            else if (x <= 49.99)
                            {//ending 3 player is sent home
                                Console.WriteLine("She grabs the change and the cup, walking off without saying a word. Despite the lackluster customer engagement, you’d say this was a success. Neither you nor her comment that you’ve given her the incorrect change.");
                                decisions.ScoreAdjustment(25);    

                                var Ending3End = new DialogueText("./TextScripts/Endings/Ending3.txt");
                                Ending3End.Run();

                                Util.EndingSequence(3, decisions);
                            }
                            else if (x >= 50){ //ending 4 - player is fired for short drawer
                                Console.WriteLine("She grabs the change and the cup, walking off without saying a word. Despite the lackluster customer engagement, you’d say this was a success. Neither you nor her comment that you’ve given her the incorrect change.");
                                decisions.ScoreAdjustment(25); 

                                var Ending4End = new DialogueText("./TextScripts/Endings/Ending4.txt");
                                Ending4End.Run();

                                Util.EndingSequence(4, decisions);
                            }
                        } catch {
                            Console.WriteLine("Huh? No, a number. Try again.");
                            continue;
                        }
                        break;
                    }

                    IncompleteDime = false;
                    break;

                    case '3':
                    Console.WriteLine("Gerty looks up at you, confused.");

                    var DimeDecision3Text = new TextChunks("./TextScripts/TextChunks/DimeDecision3_11.txt");
                    DimeDecision3Text.Run();
                    while (IncompleteEnd)
                    {
                        var BadEndChoice = Console.ReadKey(true).KeyChar;
                        switch(BadEndChoice)
                        {
                            case '1':
                                var Ending2Beginning = new DialogueText("./TextScripts/Endings/Ending2_Seg1.txt");
                                Ending2Beginning.Run();
                                decisions.ScoreAdjustment(50);

                                var Ending2End = new DialogueText("./TextScripts/Endings/Ending2_Seg2.txt");
                                Ending2End.Run();

                                Util.EndingSequence(2, decisions);
                                IncompleteEnd = false;
                            break;
                            case '2':
                                Console.WriteLine("“You’re lucky my ears fell off years ago, young creature.” She says and takes back the dime.");
                                decisions.ScoreAdjustment(25);                               
                                Console.ReadLine();
                                Console.WriteLine("You hand her the change and her cup.");
                                decisions.ScoreAdjustment(25);
                                Console.ReadLine();
                                Util.EndingSequence(1, decisions);
                                IncompleteEnd = false;
                            break;

                            default:
                            {
                                Console.WriteLine("Nice try buddy. Pick again.");
                            }
                            break;
                        } 
                    }
                    break;
                }
            }
        } 
    }
}

//ASCII ART LINKS:
//FULLBODY: https://textart.sh/topic/anatomy
//ZOMBIE HAND: https://textart.sh/topic/blood
//TITLE GENERATOR: https://patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20 Font: Patorjk-HeX



        
