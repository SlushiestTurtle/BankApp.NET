using System;

List<int> inputList = new List<int>();
int length = 0;
while (length < 4)
{
    Console.WriteLine("Type your number");
    string number = Console.ReadLine();
    if (number != null)
    {
        int input = Int32.Parse(number);
        inputList.Add(input);
    }
    length = inputList.Count; 
}
int b = 0, d = 0, c = 0, l = 0;
foreach (int i in inputList)
{
    if (b == 0)
    {
        b = i;
    }
    else if (d == 0)
    {
        d = i;
    }
    else if (c == 0)
    {
        c = i;
    }
    else if (l == 0)
    {
        l = i;
    }
}

Console.WriteLine(String.Format("b: {0}, d: {1}, c: {2}, l: {3}", b.ToString(), d.ToString(), c.ToString(), l.ToString()));
while (true)
{
    int totalLegs = b + d + c;

    if (l < totalLegs)
    {
        throw new Exception("Impossible!");
    }
    else if (l > totalLegs)
    {
        continue;
    }

    while (true)
    {
        int countB = 0;
        int countD = 0;
        int countC = 0;

        if (l > b || l > d || l > c)
        {
            l -= b;
            countB += 1;
        }
        else if (l > d)
        {
            l -= d;
        }
        else if (l > c)
        {
            l -= c;
        }
    }
}

