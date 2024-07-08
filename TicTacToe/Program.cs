using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] spaces = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            char user1 = ' ';
            char user2= ' ';
            char computer= ' ';
            string option;
            int opt;
            bool running = true;
            do
            {
                Console.Write("Choose from the options: \n");
                Console.Write("1. Player1 vs Player2\n");
                Console.Write("2. Player1 vs PC\n");
                Console.Write("Option :");
                opt= int.Parse(Console.ReadLine());
            } while (opt != 1 && opt != 2);

            if (opt == 1)
            {
                do
                {
                    Console.Write("Player1 choose to play with X or O: ");
                    option = Convert.ToString(Console.ReadLine());
                }while (!(option == "X" || option == "x"|| option == "O" || option == "o"));

                if (option == "X" || option == "x")
                {
                    user1 = 'X';
                    user2 = 'O';
                }
                else if (option == "O" || option == "o")
                {
                    user1 = 'O';
                    user2 = 'X';
                }

                lines(ref spaces);

                while (running)
                {
                    user1Move(spaces, user1);
                    lines(ref spaces);
                    if (checkWinnerP1vP2(spaces, user1, user2))
                    {
                        running = false;
                        break;
                    }
                    else if (checkTie(spaces))
                    {
                        running = false;
                        break;
                    }
                    user2Move(spaces, user2);
                    lines(ref spaces);
                    if (checkWinnerP1vP2(spaces, user1, user2))
                    {
                        running = false;
                        break;
                    }
                    else if (checkTie(spaces))
                    {
                        running = false;
                        break;
                    }
                }
            }
            else if (opt == 2)
            {

                do
                {
                    Console.Write("Player1 choose to play with X or O: ");
                    option = Convert.ToString(Console.ReadLine());
                } while (!(option == "X" || option == "x" || option == "O" || option == "o"));
                if (option == "X" || option == "x")
                {
                    user1 = 'X';
                    computer = 'O';
                }
                else if (option == "O" || option == "o")
                {
                    user1 = 'O';
                    computer = 'X';
                }

                lines(ref spaces);

                while (running)
                {
                    user1Move(spaces, user1);
                    lines(ref spaces);
                    if (checkWinnerPC(spaces, user1, computer))
                    {
                        running = false;
                        break;
                    }
                    else if (checkTie(spaces))
                    {
                        running = false;
                        break;
                    }
                    computerMove(spaces, computer);
                    lines(ref spaces);
                    if (checkWinnerPC(spaces, user1, computer))
                    {
                        running = false;
                        break;
                    }
                    else if (checkTie(spaces))
                    {
                        running = false;
                        break;
                    }
                }
            }

            Console.ReadLine();
        }
        static void lines(ref char[] spaces)
        {
            Console.Write("     |     |     \n");
            Console.Write("  {0}  |  {1}  |  {2}   \n",spaces[0],spaces[1],spaces[2]);
            Console.Write("_____|_____|_____\n");
            Console.Write("     |     |     \n");
            Console.Write("  {0}  |  {1}  |  {2}   \n", spaces[3], spaces[4], spaces[5]);
            Console.Write("_____|_____|_____\n");
            Console.Write("     |     |     \n");
            Console.Write("  {0}  |  {1}  |  {2}   \n", spaces[6], spaces[7], spaces[8]); ;
            Console.Write("     |     |     \n");
            Console.WriteLine();
        }
        static void user1Move(char[] spaces, char user1)
        {
            int num;
            bool nton = false;
            do
            {
                do
                {
                    Console.Write("Enter a spot to place a maker (1-9)");
                    num = int.Parse(Console.ReadLine());
                    num--;
                } while (num < 0 || num > 8);

                if (spaces[num] == ' ')
                {
                    spaces[num] = user1;
                    nton = true;
                }
            } while (nton == false);
            }
        static void user2Move(char[] spaces,  char user2)
        {
            int num;
            bool nton = false;
            do
            {
                do
                {
                    Console.Write("Enter a spot to place a maker (1-9)");
                    num = int.Parse(Console.ReadLine());
                    num--;

                } while (num < 0 || num > 8);
                if (spaces[num] == ' ')
                {
                    spaces[num] = user2;
                    nton = true;

                }
            } while (nton == false);

        }
        static void computerMove(char[] spaces, char computer)
        {
            int num;
            Random random = new Random();
            
            while (true)
            {
                num = random.Next(1, 9);

                if (spaces[num] == ' ')
                {
                    spaces[num] = computer;
                    break;
                }
            }
        }
       static bool checkWinnerPC(char[] spaces, char user1, char computer)
        {
            if ((spaces[0] != ' ') && (spaces[0] == spaces[1] && spaces[1] == spaces[2]))
            {
                Console.Write((spaces[0] == user1) ? "You won! :-D" : "You lost :-("); 
            }
            else if ((spaces[3] != ' ') && (spaces[3] == spaces[4] && spaces[4] == spaces[5]))
            {
                Console.Write((spaces[3] == user1) ? "You won! :-D" : "You lost :-(");
            }
            else if ((spaces[6] != ' ') && (spaces[6] == spaces[7] && spaces[7] == spaces[8]))
            {
                Console.Write((spaces[6] == user1) ? "You won! :-D" : "You lost :-(");
            }
            else if ((spaces[0] != ' ') && (spaces[0] == spaces[3] && spaces[3] == spaces[6]))
            {
                Console.Write((spaces[0] == user1) ? "You won! :-D" : "You lost :-(");
            }
            else if ((spaces[1] != ' ') && (spaces[1] == spaces[4] && spaces[4] == spaces[7]))
            {
                Console.Write((spaces[1] == user1) ? "You won! :-D" : "You lost :-(");
            }
            else if ((spaces[2] != ' ') && (spaces[2] == spaces[5] && spaces[5] == spaces[8]))
            {
                Console.Write((spaces[2] == user1) ? "You won! :-D" : "You lost :-(");
            }
            else if ((spaces[0] != ' ') && (spaces[0] == spaces[4] && spaces[4] == spaces[8]))
            {
                Console.Write((spaces[0] == user1) ? "You won! :-D" : "You lost :-(");
            }
            else if ((spaces[2] != ' ') && (spaces[2] == spaces[4] && spaces[4] == spaces[6]))
            {
                Console.Write((spaces[2] == user1) ? "You won! :-D" : "You lost :-(");
            }
            else
            
            {
                return false;
            }

            return true;
        }
       static bool checkWinnerP1vP2(char[] spaces, char user1, char user2)
        {
            if ((spaces[0] != ' ') && (spaces[0] == spaces[1] && spaces[1] == spaces[2]))
            {
                Console.Write((spaces[0] == user1) ? "You won! :-D" :"Player 2 won"); 
            }
            else if ((spaces[3] != ' ') && (spaces[3] == spaces[4] && spaces[4] == spaces[5]))
            {
                Console.Write((spaces[3] == user1) ? "You won! :-D" : "Player 2 won");
            }
            else if ((spaces[6] != ' ') && (spaces[6] == spaces[7] && spaces[7] == spaces[8]))
            {
                Console.Write((spaces[6] == user1) ? "You won! :-D" : "Player 2 won");
            }
            else if ((spaces[0] != ' ') && (spaces[0] == spaces[3] && spaces[3] == spaces[6]))
            {
                    Console.Write((spaces[0] == user1) ? "You won! :-D" : "Player 2 won");
            }
            else if ((spaces[1] != ' ') && (spaces[1] == spaces[4] && spaces[4] == spaces[7]))
            {
                Console.Write((spaces[1] == user1) ? "You won! :-D" : "Player 2 won");
            }
            else if ((spaces[2] != ' ') && (spaces[2] == spaces[5] && spaces[5] == spaces[8]))
            {
                Console.Write((spaces[2] == user1) ? "You won! :-D" : "Player 2 won");
            }
            else if ((spaces[0] != ' ') && (spaces[0] == spaces[4] && spaces[4] == spaces[8]))
            {
                Console.Write((spaces[0] == user1) ? "You won! :-D" : "Player 2 won");
            }
            else if ((spaces[2] != ' ') && (spaces[2] == spaces[4] && spaces[4] == spaces[6]))
            {
                Console.Write((spaces[2] == user1) ? "You won! :-D" : "Player 2 won");
            }
            else
            {
                return false;
            }

            return true;
        }
        static bool checkTie(char[] spaces)
        {
            for (int i = 0; i < 9; i++)
            {
                if (spaces[i] == ' ')
                {
                    return false;
                }
            }
            Console.Write("It's a tie :-|");
            return true;
        }
    }
}
