using System;
using System.Collections.Generic;

namespace BalancedBrackets
{
    class Program
    {
		public class Stack
		{
			public int top = -1;
			public char[] items = new char[100];

			public void push(char x)
			{
				if (top == 99)
				{
					Console.WriteLine("Stack full");
				}
				else
				{
					items[++top] = x;
				}
			}

			char pop()
			{
				if (top == -1)
				{
					Console.WriteLine("Underflow error");
					return '\0';
				}
				else
				{
					char element = items[top];
					top--;
					return element;
				}
			}

			Boolean isEmpty()
			{
				return (top == -1) ? true : false;
			}
		}

		static Boolean isMatchingPair(char character1, char character2)
		{
			if (character1 == '(' && character2 == ')')
				return true;
			else if (character1 == '{' && character2 == '}')
				return true;
			else if (character1 == '[' && character2 == ']')
				return true;
			else
				return false;
		}

		static Boolean isBalanced(char[] exp)
		{
			/* Declare an empty character stack */
			Stack<char> st = new Stack<char>();

			/* Traverse the given expression to 
				check matching parenthesis */
			for (int i = 0; i < exp.Length; i++)
			{

				/*If the exp[i] is a starting 
					parenthesis then push it*/
				if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
					st.Push(exp[i]);

				/* If exp[i] is an ending parenthesis 
					then pop from stack and check if the 
					popped parenthesis is a matching pair*/
				if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
				{

					/* If we see an ending parenthesis without 
						a pair then return false*/
					if (st.Count == 0)
					{
						return false;
					}

					/* Pop the top element from stack, if 
						it is not a pair parenthesis of character 
						then there is a mismatch. This happens for 
						expressions like {(}) */
					else if (!isMatchingPair(st.Pop(), exp[i]))
					{
						return false;
					}
				}

			}

			/* If there is something left in expression 
				then there is a starting parenthesis without 
				a closing parenthesis */

			if (st.Count == 0)
				return true; /*balanced*/
			else
			{ /*not balanced*/
				return false;
			}
		}

		public static void Main(String[] args)
		{
			//char[] exp = { '{', '(', ')', '}', '[', ']' };
			string exp = "{{()}[]}";

			if (isBalanced(exp.ToCharArray()))
				Console.WriteLine("Balanced ");
			else
				Console.WriteLine("Not Balanced ");
		}
	}
}