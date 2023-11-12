// See https://aka.ms/new-console-template for more information

using static System.Console;
using static System.Convert;

static void RunExerciseOne()
{
    string firstName = "Joakim";
    string lastName = "Nylund";
    // WriteLine("Hello {0} {1}! I'm glad to inform you that you are the test subject of my very first assignment!", firstName, lastName);
    WriteLine($"Hello {firstName} {lastName}! I'm glad to inform you that you are the test subject of my very first assignment!");
    ReadKey();
}

static void RunExerciseTwo()
{
    Write("Please enter your first name: ");
    string firstName = ReadLine();
    Write("Please enter your last name: ");
    string lastName = ReadLine();
    WriteLine("Hello {0} {1}! Have a nice day!", firstName, lastName);
    ReadKey();
}

static void RunExerciseThree()
{
    int n = 0;
    int k = 0;

    Write("Enter two consecutive numbers: ");
    try
    {
        n = ToInt32(ReadLine());
        k = ToInt32(ReadLine());
        if (k == n + 1)
            WriteLine("Consecutive");
        else
            WriteLine("Not consecutive");
    }
    catch (FormatException)
    {
        WriteLine("Error. Wrong format inputted.");
    }
    ReadKey();
}
static void RunExerciseFour()
{
    IFormatProvider sweCulture =
    new System.Globalization.CultureInfo("sv-SE", true);

    DateTime today = DateTime.Now;
    string[] todayLongDateFormat = today.GetDateTimeFormats('f'); //if no argument is given, it uses a default set of formats (which seems to be based on OS settings)
    WriteLine("Today's date in the long format is: {0}", todayLongDateFormat);
    WriteLine("\nAlternative (Swedish) date formats for today: ");
    string[] todayDateVariants = today.GetDateTimeFormats(sweCulture); //if no argument is given, it uses a default set of formats

    foreach (string format in todayDateVariants.Distinct()) //.Distinct() added because of duplicates
    {
        WriteLine(format);
    }

    DateTime tomorrow = today.AddDays(1);
    string[] tomorrowString = tomorrow.GetDateTimeFormats('d');
    WriteLine("\nTomorrow's date in short format is: {0}", tomorrowString);
    DateTime yesterday = today.AddDays(-1);
    string[] yesterdayString = yesterday.GetDateTimeFormats('d');
    WriteLine("Yesterday's date in short format is: {0}", yesterdayString);

    ReadKey();
}

static void RunExerciseFive()
{
    //Part a
    int firstNumPartA = 2;
    int secondNumPartA = 3;
    double sumPartA = firstNumPartA + secondNumPartA;

    //Part b
    double firstNumPartB = 2.3;
    double secondNumPartB = 3.2;
    int sumPartB = (int)firstNumPartB + (int)secondNumPartB;

    //Part c
    int evenNumPartC = 2;
    int oddNumPartC = 3;
    WriteLine(oddNumPartC / (double)evenNumPartC);

    ReadKey();
}

static void RunExerciseSix()
{
    int x = 40;
    int y = 20;
    int z = 25;
    int m = 15;

    int e = (int)((x + y) * z / (double)m);
    int f = x + y * (z / m);
    int g = x + y * z / m; //no parentheses needed for this one
    int h = (x + y * z) / m;
    WriteLine($"e: {e} f: {f} g: {g} h: {h}"); //using interpolation
    ReadKey();
}

static void RunExerciseSeven()
{
    Write("Enter any positive integer: ");
    int integerToBeChecked = ToInt32(ReadLine());
    if (integerToBeChecked % 2 == 0)
        WriteLine("The integer is even");
    else
        WriteLine("The integer is odd");

    ReadKey();
}

static void RunExerciseEight()
{
    Random randomNumber = new Random();
    int[] number = new int[20];
    for (int i = 0; i < 20; i++)
    {
        number[i] = randomNumber.Next();
    }
    List<int> evenList = new(number.Where(x => x % 2 == 0));
    List<int> oddList = new(number.Where(x => x % 2 != 0));

    //An alternative would be: 
    // foreach (int i in number)
    //     if (i % 2 == 0) evenList.Add(i);
    // foreach (int i in number)
    //     if (i % 2 != 0) oddList.Add(i);

    WriteLine("List of even elements: ");
    WriteLine(string.Join(" ", evenList));
    WriteLine("List of odd elements: ");
    WriteLine(string.Join(" ", oddList));

    ReadKey();
}

static void RunExerciseNine()
{
    Write("Insert a radius value: ");
    WriteLine();
    double radius = ToInt32(ReadLine());
    double circleArea = Math.PI * radius * radius; //formula pi*radius^2
    WriteLine("The area of a circle with the given radius is: {0} units", circleArea);

    double sphereVolume = (4 / 3) * Math.PI * radius * radius * radius; //formula (4/3)pi*radius^3 - I know the brackets are unnecessary
    WriteLine("The volume of a sphere with the given radius is: {0} units", sphereVolume);

    ReadKey();
}

static void RunExerciseTen()
{
    WriteLine("Enter 10 numbers of your choosing.");

    double[] tenRandomNumbers = new double[10];
    for (int i = 0; i < 10; i++)
    {
        Write("Number {0}: ", i + 1);
        tenRandomNumbers[i] = ToDouble(ReadLine());
    }
    if (tenRandomNumbers.Where(x => x < 0).Count() <= 0)
        WriteLine("No negative numbers entered.");

    else
    {
        Write("The negative numbers are: ");
        foreach (double number in tenRandomNumbers.Where(x => x < 0))
            Write(number + " ");
        WriteLine();
    }

    ReadKey();
}

static void RunExerciseEleven()
{
    // Typical body temperature is: 36.5–37.5 °C.
    // For the purposes of this exercise, I define fever as having a temperature above 37.5 degrees celcius.
    Write("Enter your body temperature in °C: ");
    float bodyTemp = ToSingle(ReadLine());

    if (bodyTemp > 37.5)
        WriteLine("You have a fever.");
    else WriteLine("You don't have a fever");

    ReadKey();
}

static void RunExerciseTwelve()
{
    DateTime now = DateTime.Now;
    int currentYear = now.Year;
    int inputYear;
    try
    {
        Write("Enter the current year:");
        inputYear = ToInt32(ReadLine());

        if (inputYear == currentYear)
            WriteLine("Correct");
        else
            WriteLine("Incorrect");

    }

    catch (FormatException) //Some additional validation, because why not.
    {
        WriteLine("Error. Wrong format inputted.");
    }

    ReadKey();
}

static void RunExerciseThirteen()
{
    Write("Insert an arithmetic operator: ");
    ConsoleKeyInfo inputOperator = ReadKey();
    WriteLine("You input: {0}", inputOperator.KeyChar);

    WriteLine();
    Write("Insert operand number 1: ");
    double operandNum1 = ToDouble(ReadLine());

    Write("Insert operand number 2: ");
    double operandNum2 = ToDouble(ReadLine());

    switch (inputOperator.KeyChar)
    {
        case '+':
            WriteLine("{0} + {1} = {2}", operandNum1, operandNum2, operandNum1 + operandNum2);
            break;
        case '-':
            WriteLine("{0} - {1} = {2}", operandNum1, operandNum2, operandNum1 - operandNum2);
            break;
        case '*':
            WriteLine("{0} * {1} = {2}", operandNum1, operandNum2, operandNum1 * operandNum2);
            break;
        case '/':
            WriteLine("{0} / {1} = {2}", operandNum1, operandNum2, operandNum1 / operandNum2);
            break;

    }

    ReadKey();
}

static void RunExerciseFourteen()
{
    Write("Enter your grade: ");
    char grade = ToChar(ReadLine());

    switch (grade)
    {
        case 'A':
            WriteLine("Great job!");
            break;
        case 'B':
            WriteLine("Well done.");
            break;
        case 'C':
            WriteLine("Not bad.");
            break;
        case 'D':
            WriteLine("You passed!");
            break;
    }

    ReadKey();
}

static void RunExerciseFifteen()
{
    Write("Enter a number smaller than 100: ");
    int inputNum = ToInt32(ReadLine());

    WriteLine("Using for-loops.");
    Write("Ascending order: ");
    for (int i = 1; i <= inputNum; i++)
    {
        Write(i + " ");
    }
    WriteLine();

    Write("Descending order: ");
    for (int i = inputNum; i > 0; i--)
    {
        Write(i + " ");
    }
    WriteLine();

    WriteLine("Using while-loops.");

    int whileCounter = 1;
    Write("Ascending order: ");
    while (whileCounter <= inputNum) Write(whileCounter++ + " ");
    WriteLine();

    Write("Descending order: ");
    whileCounter = inputNum;
    while (whileCounter >= 1) Write(whileCounter-- + " ");
    WriteLine();

    WriteLine("Using do-while-loops.");
    int doWhileCounter = 1;
    Write("Ascending order: ");
    do
    {
        Write(doWhileCounter++ + " ");
    } while (doWhileCounter <= inputNum);
    WriteLine();
    Write("Descending order: ");
    do
    {
        Write(--doWhileCounter + " ");
    } while (doWhileCounter > 1);
    WriteLine();

    ReadKey();
}

static void RunExerciseSixteen()
{
    Write("Enter a date: ");
    DateTime inputDate = ToDateTime(ReadLine());
    int inputYear = inputDate.Year;

    DateTime currentDate = DateTime.Now;
    int currentYear = currentDate.Year;

    if (inputYear < currentYear)
        WriteLine("Past year");
    else if (inputYear > currentYear)
        WriteLine("Future year");
    else
        WriteLine("Present year");

    ReadKey();
}

static void RunExerciseSeventeen()
{
    // leap years are perfectly divisible by four, but not divisible by 100 unless also divisible by 400
    DateTime currentDate = DateTime.Now;
    int currentYear = currentDate.Year;
    int startYear = 1900;
    Write("Leap years from 1990 until now: ");
    while (startYear < currentYear)
    {
        if (startYear % 4 == 0 && startYear % 100 != 0 || startYear % 400 == 0)
        {
            Write(startYear + " ");
        }
        startYear++;
    }
    WriteLine();

    ReadKey();
}

static void RunExerciseEighteen()
{
    int guessedNumber;
    // Random randomNumber = new Random();
    Random randomNumber = new();
    int secretNumber = randomNumber.Next(10); //sets the range from 0 to 9
    string answer = "yes";
    do
    {
        Write("Guess a number from 0 to 9: ");
        guessedNumber = ToInt32(ReadLine());
        if (secretNumber == guessedNumber)
            WriteLine("You guessed right!");
        else
        {
            WriteLine("You guessed wrong!");
            Write("Type yes to continue guessing: ");
            answer = ReadLine();
        }

    } while (secretNumber != guessedNumber && answer == "yes");

    ReadKey();
}

static void RunExerciseNineteen()
{
    //Print reverse pyramid. Top layer starts at 5 stars

    // * * * * *  zero initial whitespaces, four whitespaces, five stars  
    //  * * * *   one initial whitespace, four whitespaces, four stars
    //   * * *    two initial whitespaces, four whitespaces, 3 stars
    //    * *     .......
    //     *

    // char star = '*';

    int topLayerOfStars = 5;
    int whiteSpaces = 4;

    for (int i = topLayerOfStars; i > 0; i--) //should iterate to the number of stars in the top layer
    {
        for (int j = 0; j < topLayerOfStars - i; j++) //should start at 0 and increase to number of whitespaces
        {
            Write(" ");
        }

        for (int k = i; k > 0; k--) //should start at number of stars in the top layer 
        {
            Write('*');
            Write(" ");
        }
        WriteLine();
    }

    ReadKey();
}

static void RunExerciseTwenty()
{
    // Write a program that keeps asking the user to enter numbers, until he enters -1. Then displays a sum and average of all numbers entered before -1

    int sum = 0;
    int inputNumber = 0;
    int elementCounter = 0;
    do
    {
        Write("Input a number or input -1 to print the sum: ");

        sum += inputNumber;
        inputNumber = ToInt32(ReadLine());
        elementCounter++;
    } while (inputNumber != -1);

    // double average = sum / (double)elementCounter;
    WriteLine();
    WriteLine("The sum is {0}", sum);
    WriteLine("The average is {0}", sum / (double)elementCounter - 1);

    ReadKey();
}

static void RunExerciseTwentyOne(int fibNum)
{
    /*Exercise 21 (Optional) 
    Write a program to print the Fibonacci series */

    //recursion! The method will call itself by adding the value of the current method and the value of the method with currentNumber-1 until currentNumber == 0

    // += ExerciseTwentyOne(fibNum - 2) + ExerciseTwentyOne(fibNum - 1);


    //change return void to return int?
    // Write(fibNum + " ");
    // if (fibNum - 2 == 0)
    //console output WriteLine(string.Join(" ", evenList)); is this needed?
    // int[] array = { 1, 2, 3, 4, 5 };

    // return;

    // ReadKey();
}

// ReadKey();
bool keepAlive = true;
while (keepAlive)
{
    try
    {
        Write("Enter assignment number (or -1 to exit): ");
        var assignmentChoice = int.Parse(ReadLine() ?? "");
        ForegroundColor = ConsoleColor.Green;
        switch (assignmentChoice)
        {
            case 1:
                RunExerciseOne();
                break;
            case 2:
                RunExerciseTwo();
                break;
            case 3:
                RunExerciseThree();
                break;
            case 4:
                RunExerciseFour();
                break;
            case 5:
                RunExerciseFive();
                break;
            case 6:
                RunExerciseSix();
                break;
            case 7:
                RunExerciseSeven();
                break;
            case 8:
                RunExerciseEight();
                break;
            case 9:
                RunExerciseNine();
                break;
            case 10:
                RunExerciseTen();
                break;
            case 11:
                RunExerciseEleven();
                break;
            case 12:
                RunExerciseTwelve();
                break;
            case 13:
                RunExerciseThirteen();
                break;
            case 14:
                RunExerciseFourteen();
                break;
            case 15:
                RunExerciseFifteen();
                break;
            case 16:
                RunExerciseSixteen();
                break;
            case 17:
                RunExerciseSeventeen();
                break;
            case 18:
                RunExerciseEighteen();
                break;
            case 19:
                RunExerciseNineteen();
                break;
            case 20:
                RunExerciseTwenty();
                break;
            // case 22:
            //     RunExerciseTwentyTwo();
            //     break;
            // case 22:
            //     RunExerciseTwentyThree();
            //     break;
            // case 23:
            //     RunExerciseTwenty();
            //     break;
            // case 24:
            //     RunExerciseTwenty();
            //     break;
            // case 25:
            //     RunExerciseTwenty();
            //     break;
            // case 26:
            //     RunExerciseTwenty();
            //     break;
            // case 27:
            //     RunExerciseTwenty();
            //     break;
            // case 28:
            //     RunExerciseTwenty();
            //     break;
            // case 29:
            //     RunExerciseTwenty();
            //     break;

            case -1:
                keepAlive = false;
                break;
            default:
                ForegroundColor = ConsoleColor.Red;
                WriteLine("That is not a valid assignment number!");
                break;
        }
        ResetColor();
        WriteLine("Hit any key to continue..");
        ReadKey();
        Clear();
    }
    catch (Exception e)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(e.Message);
        ResetColor();
    }
}

