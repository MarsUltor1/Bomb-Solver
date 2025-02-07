﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KTNEBombSolver
{
    enum Color
    {
        Red,
        Yellow,
        Blue,
        Black,
        White,
        Green,
        Null
    }

    enum Symbol
    {
        Copyright,
        FilledStar,
        HollowStar,
        SmileyFace,
        DoubleK,
        Omega,
        SquidKnife,
        Pumpkin,
        HookN,
        Six,
        SquigglyN,
        AT,
        AE,
        MeltedThree,
        Euro,
        NWithHat,
        Dragon,
        QuestionMark,
        Paragraph,
        RightC,
        LeftC,
        Pitchfork,
        Cursive,
        Tracks,
        Balloon,
        UpsideDownY,
        BT
    }

    public class Modules
    {


        /// <summary>
        /// Solve "Simple Wires" Module
        /// </summary>
        /// <param name="lastSerial">last digit of serial number</param>
        public void SWires(int lastSerial)
        {

            List<string> wires = new List<string>();
            List<Color> colors = new List<Color>();
            bool quit = false;

            #region Input Wires
            while (!quit)
            {
                // Get all wires
                Console.WriteLine("\nColors: r (red) | y (yellow | b (blue) | bl (black | w (white) ");
                Console.Write("Enter Every Wire Color: ");
                string wireString = Console.ReadLine().ToLower();

                // Add wires to list
                wires.Clear();
                wires.AddRange(wireString.Split(new char[] { ' ' }));

                // Check for correct number of wires
                if (wires.Count < 3 || wires.Count > 6)
                {
                    Console.Write("ERROR: Invalid number of wires, enter between 3 and 6 colors. Enter [C] to continue or [X] To Quit. ");
                    string cont = Console.ReadLine().ToLower();
                    if (cont == "x") quit = true;
                    continue;
                }

                // Change colors to enum
                for (int i = 0; i < wires.Count; i++)
                {
                    switch (wires[i])
                    {
                        // Handle correctly input colors
                        case "r": colors.Add(Color.Red); break;
                        case "y": colors.Add(Color.Yellow); break;
                        case "b": colors.Add(Color.Blue); break;
                        case "bl": colors.Add(Color.Black); break;
                        case "w": colors.Add(Color.White); break;

                        // Send error message for incorrectly input colors
                        default:
                            Console.Write($"ERROR: Invalid wire color, {wires[i]} is not a valid color. Enter [C] to continue or [X] To Quit. ");
                            string cont = Console.ReadLine().ToLower();
                            if (cont == "x") quit = true;
                            continue;
                    }
                }

                break;
            }
            #endregion

            #region Solve Wires
            // Check if module was quit
            if ( !quit )
            {
                switch (wires.Count)
                {
                    case 3: // Solve for 3 wires
                        if (!colors.Contains(Color.Red))
                            Console.WriteLine("Cut Second Wire");
                        else if (colors[colors.Count() - 1] == Color.White)
                            Console.WriteLine("Cut Last Wire");
                        else if (colors.IndexOf(Color.Blue) != colors.LastIndexOf(Color.Blue))
                            Console.WriteLine("Cut Last Blue Wire");
                        else
                            Console.WriteLine("Cut Last Wire");
                        break;

                    case 4: // Solve for 4 wires
                        if (colors.IndexOf(Color.Red) != colors.LastIndexOf(Color.Red) && lastSerial % 2 != 0)
                            Console.WriteLine("Cut Last Wire");
                        else if (colors.Last() == Color.Yellow && !colors.Contains(Color.Red))
                            Console.WriteLine("Cut First Wire");
                        else if (colors.Contains(Color.Blue) && colors.IndexOf(Color.Blue) == colors.LastIndexOf(Color.Blue))
                            Console.WriteLine("Cut First Wire");
                        else if (colors.IndexOf(Color.Yellow) != colors.LastIndexOf(Color.Yellow))
                            Console.WriteLine("Cut Last Wire");
                        else
                            Console.WriteLine("Cut Second Wire");
                        break;

                    case 5: // Solve for 5 wires
                        if (colors[colors.Count() - 1] == Color.Black && lastSerial % 2 != 0)
                            Console.WriteLine("Cut Fourth Wire");
                        else if (colors.Contains(Color.Red) && colors.IndexOf(Color.Red) == colors.LastIndexOf(Color.Red)
                            && colors.IndexOf(Color.Yellow) != colors.LastIndexOf(Color.Yellow))
                            Console.WriteLine("Cut First Wire");
                        else if (!colors.Contains(Color.Black))
                            Console.WriteLine("Cut Second Wire");
                        else
                            Console.WriteLine("Cut First Wire");
                        break;

                    case 6: // Solve for 6 wires
                        if (!colors.Contains(Color.Yellow) && lastSerial % 2 != 0)
                            Console.WriteLine("Cut Third Wire");
                        else if (colors.Contains(Color.Yellow) && colors.IndexOf(Color.Yellow) == colors.LastIndexOf(Color.Yellow)
                            && colors.IndexOf(Color.White) != colors.LastIndexOf(Color.White))
                            Console.WriteLine("Cut Fourth Wire");
                        else if (!colors.Contains(Color.Red))
                            Console.WriteLine("Cut Last Wire");
                        else
                            Console.WriteLine("Cut Fourth Wire");
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// Solve "Button" Module
        /// </summary>
        /// <param name="numBatt">number of batteries</param>
        public void Button(int numBatt)
        {
            Color color = Color.Null;
            string word = "";
            bool quit = false;

            #region Input Button
            while (!quit)
            {
                // Get button color
                Console.WriteLine("\nColors: r (red) | y (yellow | b (blue) | bl (black | w (white) ");
                Console.Write("Enter Button Color: ");
                string buttonColor = Console.ReadLine().ToLower();

                // Get button word
                Console.Write("Enter Button Word: ");
                word = Console.ReadLine().ToLower();

                // Check color and word
                if (buttonColor != "r" && buttonColor != "y" && buttonColor != "b" &&
                        buttonColor != "bl" && buttonColor != "w")
                {
                    Console.Write($"ERROR: Invalid button color, {buttonColor} is not a valid color. Enter [C] to continue or [X] To Quit. ");
                    string cont = Console.ReadLine().ToLower();
                    if (cont == "x") quit = true;
                    continue;
                }

                if (word != "abort" && word != "detonate" && 
                    word != "hold" && word != "press")
                {
                    Console.Write($"ERROR: Invalid word, {word} is not a valid word. Enter [C] to continue or [X] To Quit. ");
                    string cont = Console.ReadLine().ToLower();
                    if (cont == "x") quit = true;
                    continue;
                }

                // Swap color to enum
                switch (buttonColor)
                {
                    case "r": color = Color.Red; break;
                    case "y": color = Color.Yellow; break;
                    case "b": color = Color.Blue; break;
                    case "bl": color = Color.Black; break;
                    case "w": color = Color.White; break;
                }

                break;
            }
            #endregion

            #region Solve Button
            if (!quit)
            {
                if (color == Color.Blue && word == "abort")
                {
                    Console.WriteLine("Hold and Release Based on Color. Blue = 4 | Yellow = 5 | Other = 1");
                    return;
                }
                if (numBatt > 1 && word == "detonate")
                {
                    Console.WriteLine("Press and Release");
                    return;
                } 
                if (color == Color.White)
                {
                    //Check for CAR indicator
                    Console.Write("Is there a lit CAR indicator (Y/N): ");
                    string ans = Console.ReadLine().ToLower();
                    bool carInd = ans == "y";

                    if (carInd)
                    {
                        Console.WriteLine("Hold and Release Based on Color. Blue = 4 | Yellow = 5 | Other = 1");
                        return;
                    } 
                }
                if (numBatt > 2)
                {
                    //Check for FRK indicator
                    Console.Write("Is there a lit FRK indicator (Y/N): ");
                    string ans = Console.ReadLine().ToLower();
                    bool frkInd = ans == "y";

                    if (frkInd)
                    {
                        Console.WriteLine("Press and Release");
                        return;
                    }
                }
                if (color == Color.Yellow)
                {
                    Console.WriteLine("Hold and Release Based on Color. Blue = 4 | Yellow = 5 | Other = 1");
                    return;
                }
                if (color == Color.Red && word == "hold")
                {
                    Console.WriteLine("Press and Release");
                    return;
                }
                Console.WriteLine("Hold and Release Based on Color. Blue = 4 | Yellow = 5 | Other = 1");
            }
            #endregion
        }

        /// <summary>
        /// Solve the "Keypad" Module
        /// </summary>
        public void Keypad()
        {
            // Setup the six sollution lists
            List<Symbol> columb1 = new List<Symbol>() { Symbol.Balloon, Symbol.AT, Symbol.UpsideDownY, Symbol.SquigglyN, Symbol.SquidKnife, Symbol.HookN, Symbol.LeftC };
            List<Symbol> columb2 = new List<Symbol>() { Symbol.Euro, Symbol.Balloon, Symbol.LeftC, Symbol.Cursive, Symbol.HollowStar, Symbol.SquigglyN, Symbol.QuestionMark };
            List<Symbol> columb3 = new List<Symbol>() { Symbol.Copyright, Symbol.Pumpkin, Symbol.Cursive, Symbol.DoubleK, Symbol.MeltedThree, Symbol.UpsideDownY, Symbol.HollowStar };
            List<Symbol> columb4 = new List<Symbol>() { Symbol.Six, Symbol.Paragraph, Symbol.BT, Symbol.SquidKnife, Symbol.DoubleK, Symbol.QuestionMark, Symbol.SmileyFace };
            List<Symbol> columb5 = new List<Symbol>() { Symbol.Pitchfork, Symbol.SmileyFace, Symbol.BT, Symbol.RightC, Symbol.Paragraph, Symbol.Dragon, Symbol.FilledStar };
            List<Symbol> columb6 = new List<Symbol>() { Symbol.Six, Symbol.Euro, Symbol.Tracks, Symbol.AE, Symbol.Pitchfork, Symbol.NWithHat, Symbol.Omega };
            List<List<Symbol>> solutions = new List<List<Symbol>>() { columb1, columb2, columb3, columb4, columb5, columb6 } ;

            
            List<string> symbolsString = new List<string>();
            List<Symbol> userSymbols = new List<Symbol>();
            int solutionCol = int.MinValue;

            while (true)
            {
                #region Let user input their symbols
                Console.WriteLine("\nSymbols: Copyright | FilledStar | HollowStar | SmileyFace | " +
                                "DoubleK | Omega | SquidKnife | Pumpkin | HookN | Six | SquigglyN | " +
                                "AT | AE | MeltedThree | Euro | NWithHat | Dragon | QuestionMark | " +
                                "Paragraph | RightC | LeftC | Pitchfork | Cursive | Tracks | " +
                                "Balloon | UpsideDownY | BT");
                Console.Write("Enter your 4 symbols: ");
                string input = Console.ReadLine().ToLower();

                // Split wires into list
                symbolsString.Clear();
                symbolsString.AddRange(input.Split(' '));

                // Check for correct number of symbols
                if (symbolsString.Count != 4)
                {
                    Console.Write("ERROR: Invalid number of symbols, enter 4 symbols. Enter [C] to continue or [X] To Quit. ");
                    string cont = Console.ReadLine().ToLower();
                    if (cont == "x") return;
                    continue;
                }

                // change list into enums
                userSymbols.Clear();
                foreach (string symbol in symbolsString)
                {
                    switch(symbol)
                    {
                        case "copyright": userSymbols.Add(Symbol.Copyright); break;
                        case "filledstar": userSymbols.Add(Symbol.FilledStar); break;
                        case "hollowstar": userSymbols.Add(Symbol.HollowStar); break;
                        case "smileyface": userSymbols.Add(Symbol.SmileyFace); break;
                        case "doublek": userSymbols.Add(Symbol.DoubleK); break;
                        case "omega": userSymbols.Add(Symbol.Omega); break;
                        case "squidknife": userSymbols.Add(Symbol.SquidKnife); break;
                        case "pumpkin": userSymbols.Add(Symbol.Pumpkin); break;
                        case "hookn": userSymbols.Add(Symbol.HookN); break;
                        case "six": userSymbols.Add(Symbol.Six); break;
                        case "squigglyn": userSymbols.Add(Symbol.SquigglyN); break;
                        case "at": userSymbols.Add(Symbol.AT); break;
                        case "ae": userSymbols.Add(Symbol.AE); break;
                        case "meltedthree": userSymbols.Add(Symbol.MeltedThree); break;
                        case "euro": userSymbols.Add(Symbol.Euro); break;
                        case "nwithhat": userSymbols.Add(Symbol.NWithHat); break;
                        case "dragon": userSymbols.Add(Symbol.Dragon); break;
                        case "questionmark": userSymbols.Add(Symbol.QuestionMark); break;
                        case "paragraph": userSymbols.Add(Symbol.Paragraph); break;
                        case "rightc": userSymbols.Add(Symbol.RightC); break;
                        case "leftc": userSymbols.Add(Symbol.LeftC); break;
                        case "pitchfork": userSymbols.Add(Symbol.Pitchfork); break;
                        case "cursive": userSymbols.Add(Symbol.Cursive); break;
                        case "tracks": userSymbols.Add(Symbol.Tracks); break;
                        case "balloon": userSymbols.Add(Symbol.Balloon); break;
                        case "upsidedowny": userSymbols.Add(Symbol.UpsideDownY); break;
                        case "bt": userSymbols.Add(Symbol.BT); break;

                        default:
                            Console.WriteLine($"ERROR: Invalid symbol, {symbol} is not a valid symbol. Enter [C] to continue or [X] To Quit. ");
                            string cont = Console.ReadLine().ToLower();
                            if (cont == "x") return;
                            continue;
                    }
                }
                #endregion

                // Figure out which list contains all four symbols
                
                for (int i = 0; i < 6; i++)
                {
                    // check if solution columb contains all 4 user symbols
                    if (solutions[i].Contains(userSymbols[0]) && solutions[i].Contains(userSymbols[1]) && solutions[i].Contains(userSymbols[2]) && solutions[i].Contains(userSymbols[3]))
                    {
                        solutionCol = i;
                        break;
                    }
                }

                // check that a solution columb was found
                if (solutionCol == int.MinValue)
                {
                    Console.WriteLine("ERROR: Solution does not exist, please double check your symbols and try again. Enter [C] to continue or [X] To Quit. ");
                    string cont = Console.ReadLine().ToLower();
                    if (cont == "x") return;
                    continue;
                }

                break;
            }

            
            // Figure out the order of the symbols
            List<Symbol> solutionOrder = new List<Symbol>();
            foreach (Symbol sym in solutions[solutionCol])
            {
                if (userSymbols.Contains(sym))
                {
                    solutionOrder.Add(sym);
                }
            }

            // Send order of symbols to solve the module
            Console.WriteLine($"The Solution is: {solutionOrder[0]}, {solutionOrder[1]}, {solutionOrder[2]}, {solutionOrder[3]}");
        }

        /// <summary>
        /// Solve "Simon Says" Module
        /// </summary>
        /// <param name="hasVowel">Does the serial number contain a vowel</param>
        /// <param name="numStrikes">Number of strikes on the bomb</param>
        public void SimonSays(bool hasVowel,int numStrikes)
        {
            #region Set Solution Dictionary
            // Setup possible solution dictionarys
            Dictionary<Color, Color> vowel0Strikes = new Dictionary<Color, Color>() { { Color.Red, Color.Blue }, {Color.Blue, Color.Red }, {Color.Green, Color.Yellow }, { Color.Yellow, Color.Green } };
            Dictionary<Color, Color> vowel1Strikes = new Dictionary<Color, Color>() { { Color.Red, Color.Yellow }, { Color.Blue, Color.Green }, { Color.Green, Color.Blue }, { Color.Yellow, Color.Red } };
            Dictionary<Color, Color> vowel2Strikes = new Dictionary<Color, Color>() { { Color.Red, Color.Green }, { Color.Blue, Color.Red }, { Color.Green, Color.Yellow }, { Color.Yellow, Color.Blue } };
            Dictionary<Color, Color> noVowel0Strikes = new Dictionary<Color, Color>() { { Color.Red, Color.Blue }, { Color.Blue, Color.Yellow }, { Color.Green, Color.Green }, { Color.Yellow, Color.Red } };
            Dictionary<Color, Color> noVowel1Strikes = new Dictionary<Color, Color>() { { Color.Red, Color.Red }, {Color.Blue, Color.Blue }, {Color.Green, Color.Yellow }, { Color.Yellow, Color.Green } };
            Dictionary<Color, Color> noVowel2Strikes = new Dictionary<Color, Color>() { { Color.Red, Color.Yellow }, {Color.Blue, Color.Green }, {Color.Green, Color.Blue }, { Color.Yellow, Color.Red } };
            Dictionary<Color, Color> solutionDict = new Dictionary<Color, Color>();

            // Set correct solution dictionary based on serial number and number of strikes
            if (hasVowel)
            {
                switch (numStrikes)
                {
                    case 0: solutionDict = vowel0Strikes; break;
                    case 1: solutionDict = vowel1Strikes; break;
                    case 2: solutionDict = vowel2Strikes; break;
                }
            }
            else
            {
                switch (numStrikes)
                {
                    case 0: solutionDict = noVowel0Strikes; break;
                    case 1: solutionDict = noVowel1Strikes; break;
                    case 2: solutionDict = noVowel2Strikes; break;
                }
            }
            #endregion

            // Loop until Simon is solved
            bool isSolved = false;
            List<Color> sequence = new List<Color>();
            while (!isSolved)
            {
                // Have user give the next color in sequence
                Console.WriteLine("\nColors: b (blue) | r (red) | y (yellow) | g (green)");
                Console.Write("Enter the last color to be shown. Or if the module is disarmed enter d (done/disarmed): ");
                string input = Console.ReadLine().ToLower().Trim();

                // Add input color to sequence list
                switch (input)
                {
                    case "b": sequence.Add(Color.Blue); break;
                    case "r": sequence.Add(Color.Red); break;
                    case "y": sequence.Add(Color.Yellow); break;
                    case "g": sequence.Add(Color.Green); break;
                    case "d": isSolved = true; continue;

                    default:
                        Console.WriteLine("ERROR: Invalid color input pleas try again");
                        continue;
                }

                // Output solution to current step of simon
                Console.Write("Step Solution: ");
                foreach (Color c in sequence)
                {
                    Console.Write($"{solutionDict[c]}, ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Solve the "Who's on First" Module
        /// </summary>
        public void WhosOnFirst()
        {
            // Trackers
            bool located = false;
            bool decrypted = false;
            int stage = 1;

            while (stage <= 3)
            {
                Console.WriteLine();

                #region Locate Word
                while (!located)
                {
                    // Get Word on Display
                    Console.Write("Word on Display: ");
                    string locate = Console.ReadLine().ToLower();

                    // Figure out Position to Look
                    if (locate == "" || locate == "leed" || locate == "reed" || locate == "they're")
                    {
                        Console.WriteLine("Bottom Left");
                        located = true;
                        decrypted = false;
                    }
                    else if (locate == "cee" || locate == "display" || locate == "hold on" || locate == "lead" || locate == "no" || locate == "says" || locate == "see" || locate == "there" || locate == "you are")
                    {
                        Console.WriteLine("Bottom Right");
                        located = true;
                        decrypted = false;
                    }
                    else if (locate == "led" || locate == "nothing" || locate == "they are" || locate == "yes")
                    {
                        Console.WriteLine("Middle Left");
                        located = true;
                        decrypted = false;
                    }
                    else if (locate == "blank" || locate == "read" || locate == "red" || locate == "their" || locate == "you" || locate == "you're" || locate == "your")
                    {
                        Console.WriteLine("Middle Right");
                        located = true;
                        decrypted = false;
                    }
                    else if (locate == "ur")
                    {
                        Console.WriteLine("Upper Left");
                        located = true;
                        decrypted = false;
                    }
                    else if (locate == "c" || locate == "okay" || locate == "first")
                    {
                        Console.WriteLine("Upper Right");
                        located = true;
                        decrypted = false;
                    }
                    else
                    {
                        Console.Write("ERROR: Invalid Word, Try Again. Enter [C] to continue or [X] To Quit. ");
                        string cont = Console.ReadLine().ToLower();

                        if (cont == "x")
                        {
                            located = true;
                            decrypted = true;
                            stage = 4;
                        }
                    }
                }
                #endregion

                #region Decrypt Word
                while (!decrypted)
                {
                    // Get Word on Button
                    Console.Write("Word: ");
                    string decrypt = Console.ReadLine().ToLower();

                    // Get String of Words
                    switch (decrypt)
                    {
                        case "blank":
                            Console.WriteLine("WAIT, RIGHT, OKAY, MIDDLE, BLANK");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "done":
                            Console.WriteLine("SURE, UH HUH, NEXT, WHAT? YOUR, UR, YOU'RE, HOLD, LIKE, YOU, U, YOU ARE, UH UH, DONE");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "first":
                            Console.WriteLine("LEFT, OKAY, YES, MIDDLE, NO, RIGHT, NOTHING, UHHH, WAIT, READY, BLANK, WHAT, PRESS, FIRST");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "hold":
                            Console.WriteLine("YOU ARE, U, DONE, UH UH, YOU, UR, SURE, WHAT?, YOU'RE, NEXT, HOLD");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "left":
                            Console.WriteLine("RIGHT, LEFT");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "like":
                            Console.WriteLine("YOU'RE, NEXT, U, UR, HOLD, DONE, UH UH, WHAT?, UH HUH, YOU, LIKE");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "middle":
                            Console.WriteLine("BLANK, READY, OKAY, WHAT, NOTHING, PRESS, NO, WAIT, LEFT, MIDDLE");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "next":
                            Console.WriteLine("WHAT?, UH HUH, UH UH, YOUR, HOLD, SURE, NEXT");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "no":
                            Console.WriteLine("BLANK, UHHH, WAIT, FIRST, WHAT, READY, RIGHT, YES, NOTHING, LEFT, PRESS, OKAY, NO");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "nothing":
                            Console.WriteLine("UHHH, RIGHT, OKAY, MIDDLE, YES, BLANK, NO, PRESS, LEFT, WHAT, WAIT, FIRST, NOTHING");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "okay":
                            Console.WriteLine("MIDDLE, NO, FIRST, YES, UHHH, NOTHING, WAIT, OKAY");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "press":
                            Console.WriteLine("RIGHT, MIDDLE, YES, READY, PRESS");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "ready":
                            Console.WriteLine("YES, OKAY, WHAT, MIDDLE, LEFT, PRESS, RIGHT, BLANK, READY");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "right":
                            Console.WriteLine("YES, NOTHING, READY, PRESS, NO, WAIT, WHAT, RIGHT");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "sure":
                            Console.WriteLine("YOU ARE, DONE, LIKE, YOU'RE, YOU, HOLD, UH HUH, UR, SURE");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "u":
                            Console.WriteLine("UH HUH, SURE, NEXT, WHAT?, YOU'RE, UR, UH UH, DONE, U");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "uh huh":
                            Console.WriteLine("UH HUH");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "uh uh":
                            Console.WriteLine("UR, U, YOU ARE, YOU'RE, NEXT, UH UH");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "uhhh":
                            Console.WriteLine("READY, NOTHING, LEFT, WHAT, OKAY, YES, RIGHT, NO, PRESS, BLANK, UHHH");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "ur":
                            Console.WriteLine("DONE, U, UR");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "wait":
                            Console.WriteLine("UHHH, NO, BLANK, OKAY, YES, LEFT, FIRST, PRESS, WHAT, WAIT");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "what":
                            Console.WriteLine("UHHH, WHAT");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "what?":
                            Console.WriteLine("YOU, HOLD, YOU'RE. YOUR, U, DONE, UH UH, LIKE, YOU ARE, UH HUH, UR, NEXT, WHAT?");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "yes":
                            Console.WriteLine("OKAY, RIGHT, UHHH, MIDDLE, FIRST, WHAT, PRESS, READY, NOTHING, YES");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "you":
                            Console.WriteLine("SURE, YOU ARE, YOUR, YOU'RE, NEXT, UH HUH, UR, HOLD, WHAT?, YOU");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "you are":
                            Console.WriteLine("YOUR, NEXT, LIKE, UH HUH, WHAT?, DONE, UH UH, HOLD, YOU, U, YOU'RE, SURE, UR, YOU ARE");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "you're":
                            Console.WriteLine("YOU, YOU'RE");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        case "your":
                            Console.WriteLine("UH UH, YOU ARE, UH HUH, YOUR");
                            decrypted = true;
                            stage += 1;
                            located = false;
                            break;

                        default:
                            Console.Write("ERROR: Invalid Word, Try Again. Enter [C] to continue or [X] To Quit. ");
                            string cont = Console.ReadLine().ToLower();

                            if (cont == "x")
                            {
                                located = true;
                                decrypted = true;
                                stage = 4;
                            }
                            break;
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// Solve the "Memory" module
        /// </summary>
        public void Memory()
        {
            List<int[]> positionLabelPair = new List<int[]>();

            for (int i = 0; i < 5; i++)
            {
                int display;

                // get number on display
                while (true)
                {
                    Console.Write("\nEnter Number on Display: ");
                    
                    // Solution requires and integer between 1-4
                    if (int.TryParse(Console.ReadLine().ToLower().Trim(), out display) && 0 < display && display < 5 )
                    {
                        break;
                    }
                }

                #region Send user solution and get the number they pressed
                // change logic for each of the 5 stages of memory
                switch (i)
                {
                    #region Stage 1
                    case 0:
                        positionLabelPair.Add(new int[2]);
                        if (display == 1 || display == 2)
                        {
                            Console.WriteLine("Press the button in the second position");
                            // store the position of what number was pressed
                            positionLabelPair[i][0] = 2;
                        }
                        else if (display == 3)
                        {
                            Console.WriteLine("Press the button in the third position");
                            // store the position of what number was pressed
                            positionLabelPair[i][0] = 3;
                        }
                        else
                        {
                            Console.WriteLine("Press the button in the fourth position");
                            // store the position of what number was pressed
                            positionLabelPair[i][0] = 4; 
                        }

                        // get number user pressed
                        while (true)
                        {
                            int pressedNum;
                            Console.Write("What number was pressed: ");

                            // Solution requires and integer between 1-4
                            if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedNum) && 0 < pressedNum && pressedNum < 5)
                            {
                                // store the value of what number was pressed
                                positionLabelPair[i][1] = pressedNum; 
                                break;
                            }
                        }

                        break;
                    #endregion

                    #region Stage 2
                    case 1:
                        positionLabelPair.Add(new int[2]);
                        if (display == 1)
                        {
                            Console.WriteLine("Press the button labeled 4");

                            // store the value of what number was pressed
                            positionLabelPair[i][1] = 4; 

                            // get position user pressed
                            while (true)
                            {
                                int pressedPos;
                                Console.Write("What position was 4 in: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedPos) && 0 < pressedPos && pressedPos < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][0] = pressedPos; 
                                    break;
                                }
                            }
                        }
                        else if (display == 3)
                        {
                            Console.WriteLine("Press the button in the first position");

                            // store the position of what number was pressed
                            positionLabelPair[i][0] = 1; 

                            // get number user pressed
                            while (true)
                            {
                                int pressedNum;
                                Console.Write("What number was pressed: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedNum) && 0 < pressedNum && pressedNum < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][1] = pressedNum; 
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Press the button in position {positionLabelPair[0][0]}");

                            // store the position of what number was pressed
                            positionLabelPair[i][0] = positionLabelPair[0][0];

                            // get number user pressed
                            while (true)
                            {
                                int pressedNum;
                                Console.Write("What number was pressed: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedNum) && 0 < pressedNum && pressedNum < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][1] = pressedNum; 
                                    break;
                                }
                            }
                        }

                        break;
                    #endregion

                    #region Stage 3
                    case 2:
                        positionLabelPair.Add(new int[2]);
                        if (display == 1)
                        {
                            Console.WriteLine($"Press the button labeled {positionLabelPair[1][1]}");

                            // store the value of what number was pressed
                            positionLabelPair[i][1] = positionLabelPair[1][1];

                            // get position user pressed
                            while (true)
                            {
                                int pressedPos;
                                Console.Write($"What position was {positionLabelPair[1][1]} in: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedPos) && 0 < pressedPos && pressedPos < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][0] = pressedPos;
                                    break;
                                }
                            }
                        }
                        else if (display == 2)
                        {
                            Console.WriteLine($"Press the button labeled {positionLabelPair[0][1]}");

                            // store the value of what number was pressed
                            positionLabelPair[i][1] = positionLabelPair[0][1];

                            // get position user pressed
                            while (true)
                            {
                                int pressedPos;
                                Console.Write($"What position was {positionLabelPair[0][1]} in: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedPos) && 0 < pressedPos && pressedPos < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][0] = pressedPos;
                                    break;
                                }
                            }
                        }
                        else if (display == 3)
                        {
                            Console.WriteLine("Press the button in the third position");

                            // store the position of what number was pressed
                            positionLabelPair[i][0] = 3;

                            // get number user pressed
                            while (true)
                            {
                                int pressedNum;
                                Console.Write("What number was pressed: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedNum) && 0 < pressedNum && pressedNum < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][1] = pressedNum;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Press the button labeled 4");

                            // store the value of what number was pressed
                            positionLabelPair[i][1] = 4;

                            // get position user pressed
                            while (true)
                            {
                                int pressedPos;
                                Console.Write("What position was 4 in: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedPos) && 0 < pressedPos && pressedPos < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][0] = pressedPos;
                                    break;
                                }
                            }
                        }

                        break;
                    #endregion

                    #region Stage 4
                    case 3:
                        positionLabelPair.Add(new int[2]);
                        if (display == 1)
                        {
                            Console.WriteLine($"Press the button in position {positionLabelPair[0][0]}");

                            // store the position of what number was pressed
                            positionLabelPair[i][0] = positionLabelPair[0][0];

                            // get number user pressed
                            while (true)
                            {
                                int pressedNum;
                                Console.Write("What number was pressed: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedNum) && 0 < pressedNum && pressedNum < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][1] = pressedNum;
                                    break;
                                }
                            }
                        }
                        else if (display == 2)
                        {
                            Console.WriteLine("Press the button in the first position");

                            // store the position of what number was pressed
                            positionLabelPair[i][0] = 1;

                            // get number user pressed
                            while (true)
                            {
                                int pressedNum;
                                Console.Write("What number was pressed: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedNum) && 0 < pressedNum && pressedNum < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][1] = pressedNum;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Press the button in position {positionLabelPair[1][0]}");

                            // store the position of what number was pressed
                            positionLabelPair[i][0] = positionLabelPair[1][0];

                            // get number user pressed
                            while (true)
                            {
                                int pressedNum;
                                Console.Write("What number was pressed: ");

                                // Solution requires and integer between 1-4
                                if (int.TryParse(Console.ReadLine().ToLower().Trim(), out pressedNum) && 0 < pressedNum && pressedNum < 5)
                                {
                                    // store the value of what number was pressed
                                    positionLabelPair[i][1] = pressedNum;
                                    break;
                                }
                            }
                        }

                        break;
                    #endregion

                    #region Stage 5
                    case 4:
                        if (display == 1)
                        {
                            Console.WriteLine($"Press the button labeled {positionLabelPair[0][1]}");
                        }
                        else if (display == 2)
                        {
                            Console.WriteLine($"Press the button labeled {positionLabelPair[1][1]}");
                        }
                        else if (display == 3)
                        {
                            Console.WriteLine($"Press the button labeled {positionLabelPair[3][1]}");
                        }
                        else
                        {
                            Console.WriteLine($"Press the button labeled {positionLabelPair[2][1]}");
                        }

                        break;
                    #endregion
                }
                #endregion
            }
        }

        /// <summary>
        /// Solve the "Morse Code" module
        /// </summary>
        public void MorseCode()
        {
            /*
             * beats (600) bistro (552) bombs (565) boxes (535) break (572) brick (575)
             * shell (505) slick (522) steak (582) sting (592) strobe (545)
             * flick (555)
             * halls (515)
             * leaks (542)
             * trick (532)
             * vector (595)
             */

            string curLetter;
            char lastLetter;

            // narrow down first letter
            while (true)
            {
                Console.Write("Enter the first letter as dots and dashes (ex. -.--): ");
                curLetter = Console.ReadLine().ToLower().Trim();

                switch (curLetter)
                {
                    case "-...": // b needs more narrowing down
                        lastLetter = 'b';
                        break;

                    case "...": // s needs more narrowing down
                        lastLetter = 's';
                        break;

                    case "..-.": // f
                        Console.WriteLine("Solution: 3.555");
                        return;

                    case "....": // h
                        Console.WriteLine("Solution: 3.515");
                        return;

                    case ".-..": // l
                        Console.WriteLine("Solution: 3.542");
                        return;

                    case "-": // t
                        Console.WriteLine("Solution: 3.532");
                        return;

                    case "...-": // v
                        Console.WriteLine("Solution: 3.595");
                        return;

                    default:
                        Console.WriteLine("ERROR: input could not be parsed please try again");
                        continue;
                }

                break;
            }

            /*
             * beats (600) bistro (552) bombs (565) boxes (535) break (572) brick (575)
             * shell (505) slick (522) steak (582) sting (592) strobe (545)
             */

            // narrow down solution using second letter
            while (true)
            {
                Console.Write("Enter the second letter as dots and dashes: ");
                curLetter = Console.ReadLine().ToLower().Trim();

                if (lastLetter == 'b')
                {
                    switch (curLetter)
                    {
                        case ".": // e
                            Console.WriteLine("Solution: 3.600");
                            return;

                        case "..": // i
                            Console.WriteLine("Solution: 3.552");
                            return;

                        case "---": // o needs more information
                            lastLetter = 'o';
                            break;

                        case ".-.": // r needs more information
                            lastLetter = 'r';
                            break;

                        default:
                            Console.WriteLine("ERROR: input could not be parsed please try again");
                            continue;
                    }
                }
                else
                {
                    switch (curLetter)
                    {
                        case "....": // h
                            Console.WriteLine("Solution: 505");
                            return;

                        case ".-..": // l
                            Console.WriteLine("Solution: 522");
                            break;

                        case "-": // t needs more information
                            lastLetter = 't';
                            break;

                        default:
                            Console.WriteLine("ERROR: input could not be parsed please try again");
                            continue;
                    }
                }

                break;
            }

            /*
             * bombs (565) boxes (535) break (572) brick (575)
             * steak (582) sting (592) strobe (545)
             */

            // Solve the puzzle with third letter
            while (true)
            {
                Console.Write("Enter the third letter as dots and dashes: ");
                curLetter = Console.ReadLine().ToLower().Trim();

                if (lastLetter == 'o')
                {
                    switch (curLetter)
                    {
                        case "--": // m
                            Console.WriteLine("Solution: 3.565");
                            return;

                        case "-..-": // x
                            Console.WriteLine("Solution: 3.535");
                            return;

                        default:
                            Console.WriteLine("ERROR: input could not be parsed please try again");
                            continue;
                    }
                }
                else if (lastLetter == 'r')
                {
                    switch (curLetter)
                    {
                        case ".": // m
                            Console.WriteLine("Solution: 3.572");
                            return;

                        case "..": // x
                            Console.WriteLine("Solution: 3.575");
                            return;

                        default:
                            Console.WriteLine("ERROR: input could not be parsed please try again");
                            continue;
                    }
                }
                else
                {
                    switch (curLetter)
                    {
                        case ".": // m
                            Console.WriteLine("Solution: 3.582");
                            return;

                        case "..": // x
                            Console.WriteLine("Solution: 3.592");
                            return;

                        case ".-.":
                            Console.WriteLine("Solution: 3.545");
                            return;

                        default:
                            Console.WriteLine("ERROR: input could not be parsed please try again");
                            continue;
                    }
                }
            }
        }

        /// <summary>
        /// Solve the "Complicated Wires" module
        /// </summary>
        /// <param name="lastSerial">Last digit of the serial number</param>
        /// <param name="parrllelPort">Whether the bomb has a serial port</param>
        /// <param name="numBatteries">Number of batteries on the bomb</param>
        public void ComplicatedWires(int lastSerial,bool parrllelPort,int numBatteries)
        {
            Console.WriteLine("Go through all the instructions one wire at a time, you will be able to repeat for additional wires after finishing all the questions. Enter Q at anypoint to quit or once there are no more wires");

            // run as many times as there are wires
            while (true)
            {
                bool hasRed = false;
                bool hasBlue = false;
                bool hasStar = false;
                bool ledOn = false;

                #region get next wire information
                // Get all four boolean values with one user input
                bool done = false;
                while (!done)
                {
                    Console.Write("\nAnswer the fallowing four questions with (Y/N) seperated by a space.\nDoes the wire have any red? Does the Wire have any blue? Does the wire have a star? does the wire have a lit up LED?\nAnswer: ");
                    string input = Console.ReadLine().ToLower().Trim();

                    // Check for user quiting the module
                    if (input == "q") return;

                    // Split input into the values for all four booleans
                    string[] answers = input.Split(' ');
                    if (answers.Length != 4)
                    {
                        Console.WriteLine("ERROR: Incorrect number of answers, please try again only giving 4 answers");
                        continue;
                    }

                    for (int i = 0; i < 4; i++ )
                    {
                        bool currentBool;

                        switch (answers[i])
                        {
                            case "y":
                                currentBool = true;
                                break;

                            case "n":
                                currentBool = false;
                                break;

                            default:
                                Console.WriteLine("ERROR: Invalid input, please enter either Y or N.");
                                i = int.MaxValue;
                                continue;
                        }

                        switch (i)
                        {
                            case 0: 
                                hasRed = currentBool; 
                                break;

                            case 1: 
                                hasBlue = currentBool; 
                                break;

                            case 2:
                                hasStar = currentBool;
                                break;

                            case 3:
                                ledOn = currentBool;
                                done = true;
                                break;
                        }
                    }
                }
                #endregion

                #region Solve whether wire should be cut
                int toCutCatagory;

                // Find where the wire sits in the four part ven diagram
                if (hasRed && hasBlue && hasStar && ledOn) toCutCatagory = 1;
                else if (hasRed && hasBlue && hasStar && !ledOn) toCutCatagory = 3;
                else if (hasRed && hasBlue && !hasStar && ledOn) toCutCatagory = 2;
                else if (hasRed && !hasBlue && hasStar && ledOn) toCutCatagory = 4;
                else if (hasRed && hasBlue && !hasStar && !ledOn) toCutCatagory = 2;
                else if (hasRed && !hasBlue && hasStar && !ledOn) toCutCatagory = 0;
                else if (hasRed && !hasBlue && !hasStar && ledOn) toCutCatagory = 4;
                else if (hasRed && !hasBlue && !hasStar && !ledOn) toCutCatagory = 2;
                else if (!hasRed && hasBlue && hasStar && ledOn) toCutCatagory = 3;
                else if (!hasRed && hasBlue && hasStar && !ledOn) toCutCatagory = 1;
                else if (!hasRed && hasBlue && !hasStar && ledOn) toCutCatagory = 3;
                else if (!hasRed && !hasBlue && hasStar && ledOn) toCutCatagory = 4;
                else if (!hasRed && hasBlue && !hasStar && !ledOn) toCutCatagory = 2;
                else if (!hasRed && !hasBlue && hasStar && !ledOn) toCutCatagory = 0;
                else if (!hasRed && !hasBlue && !hasStar && ledOn) toCutCatagory = 1;
                else toCutCatagory = 0;

                // Send cut instructions based on ven diagram results
                switch (toCutCatagory)
                {
                    case 0:
                        Console.WriteLine("Cut the Wire");
                        break;

                    case 1:
                        Console.WriteLine("Don't Cut the Wire");
                        break;

                    case 2:
                        if (lastSerial % 2 == 0) Console.WriteLine("Cut the Wire");
                        else Console.WriteLine("Don't Cut the Wire");
                        break;

                    case 3:
                        if (parrllelPort) Console.WriteLine("Cut the Wire");
                        else Console.WriteLine("Don't Cut the Wire");
                        break;

                    case 4:
                        if (numBatteries > 1) Console.WriteLine("Cut the Wire");
                        else Console.WriteLine("Don't Cut the Wire");
                        break;
                }
                #endregion
            }
        }

        public void WireSequences()
        {
            // Trackers for which wire occurence each color is
            int numRed = 0;
            int numBlue = 0;
            int numBlack = 0;

            // Solution lookup tables
            string[] redSolutions = new string[9] { "Cut if connected to C", "Cut if connected to B", "Cut if connected to A", "Cut if connected to A or C", 
                "Cut if connected to B", "Cut if connected to A or C", "Cut", "Cut if connected to A or B", "Cut if connected to B" };
            string[] blueSolutions = new string[9] { "Cut if connected to B", "Cut if connected to A or C", "Cut if connected to B", "Cut if connected to A",
                "Cut if connected to B", "Cut if connected to B or C", "Cut if Connected to C", "Cut if connected to A or C", "Cut if connected to A" };
            string[] blackSolutions = new string[9] { "Cut", "Cut if connected to A or C", "Cut if connected to B", "Cut if connected to A or C",
                "Cut if connected to B", "Cut if connected to B or C", "Cut if connected to A or B", "Cut if connected to C", "Cut if connected to C" };

            // Run through solver for each of the 4 panels
            List<Color> wires = new List<Color>();
            for (int i = 0; i < 4; i++)
            {
                wires.Clear();

                // Get input from user
                while (true)
                {
                    Console.WriteLine("\nColors: r (Red) | b (Blue) | bl (Black)");
                    Console.Write("Enter all the wire colors in order seperated by a space (ex. r r bl): ");
                    string input = Console.ReadLine().ToLower().Trim();

                    string[] inputList = input.Split(' ');
                    bool allValidColors = true;

                    // parse user input into color enums
                    foreach (string s in inputList)
                    {
                        switch (s)
                        {
                            case "r":
                                wires.Add(Color.Red);
                                break;

                            case "b":
                                wires.Add(Color.Blue);
                                break;

                            case "bl":
                                wires.Add(Color.Black);
                                break;

                            default:
                                Console.WriteLine("Error: Invalid input please try again.");
                                allValidColors = false;
                                break;
                        }
                    }

                    if (allValidColors) break;
                }

                // Output current steps solution
                foreach (Color wire in wires)
                {
                    switch (wire) 
                    { 
                        case Color.Red:
                            Console.WriteLine(redSolutions[numRed]);
                            numRed++;
                            break;

                        case Color.Blue:
                            Console.WriteLine(blueSolutions[numBlue]);
                            numBlue++;
                            break;

                        case Color.Black:
                            Console.WriteLine(blackSolutions[numBlack]);
                            numBlack++;
                            break;
                    }
                }
            }
        }
    }
}