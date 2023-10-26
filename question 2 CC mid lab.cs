using System;
using System.Collections.Generic;

class Parser
{
    private List<string> tokens;
    private int index;

    public Parser(List<string> input)
    {
        tokens = input;
        index = 0;
    }

    // Start the parsing process
    public void Parse()
    {
        List();
        if (index == tokens.Count)
            Console.WriteLine("Parsing successful!");
        else
            Console.WriteLine("Parsing failed: Unexpected input.");
    }

    private void List()
    {
        Item();
        Rest();
    }

    private void Rest()
    {
        if (index < tokens.Count && tokens[index] == ",")
        {
            index++;
            Item();
            Rest();
        }
        // epsilon (empty) case
    }

    private void Item()
    {
        if (index < tokens.Count && (tokens[index] == "id" || tokens[index] == "num" || tokens[index] == "string"))
        {
            index++;
        }
        else
        {
            Console.WriteLine("Parsing failed: Expected 'id', 'num', or 'string'.");
            Environment.Exit(1);
        }
    }
}

class Program
{
    static void Main()
    {
        List<string> inputTokens = new List<string> { "id", ",", "num", ",", "string" };
        Parser parser = new Parser(inputTokens);
        parser.Parse();
    }
}
