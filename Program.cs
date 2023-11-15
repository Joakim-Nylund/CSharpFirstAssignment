using System.Buffers;
using static System.Console;
using static System.Convert;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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
    string? firstName = ReadLine();
    Write("Please enter your last name: ");
    string? lastName = ReadLine();
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
        if (k == n + 1 || k == n - 1)
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
    IFormatProvider sweCulture = new System.Globalization.CultureInfo("sv-SE", true);

    DateTime now = DateTime.Now;

    //alt 1
    WriteLine("Todays date in the short date format is: " + now.ToString("d")); //the format character d and D handle the formatting in a concise manner.
    WriteLine("Today's date in the long date format is: " + now.ToString("D"));

    //alt 2
    // WriteLine("Todays date in the short date format is: " + now.ToShortDateString());
    // WriteLine("Today's date in the long date format is: " + now.ToLongDateString());

    WriteLine("Todays date in a mixed format is: " + now.ToString("yyyy-MMMM-dd"));

    // DateTime today = DateTime.Today; //not really necessary for the purposes of this exercise

    string[] todayTimeAndDatevariants = now.GetDateTimeFormats(sweCulture); //if no argument is given, it uses a default set of formats (which seems to be based on OS settings)
    WriteLine("\nAll alternative (Swedish) date and time formats for today/now: ");
    foreach (string format in todayTimeAndDatevariants.Distinct()) WriteLine(format); //.Distinct() added because of duplicates

    //alt 1
    WriteLine($"\nTomorrow's date in short format is: {now.AddDays(1):d}");
    WriteLine($"Yesterday's date in short format is: {now.AddDays(-1):d}");
    // WriteLine($"\nTomorrow's date in short format is: {now.AddDays(1).ToString("d")}");
    // WriteLine($"Yesterday's date in short format is: {now.AddDays(-1).ToString("d")}");

    //alt2 
    // DateTime tomorrow = now.AddDays(1);
    // string[] tomorrowString = tomorrow.GetDateTimeFormats('d');
    // WriteLine($"\nTomorrow's date in short format is: {tomorrowString}");
    // DateTime yesterday = now.AddDays(-1);
    // string[] yesterdayString = yesterday.GetDateTimeFormats('d');
    // WriteLine($"Yesterday's date in short format is: {yesterdayString}");

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
    IList<int> randomIntegerList = new List<int>();
    for (int i = 0; i < 20; i++)
        randomIntegerList.Add(randomNumber.Next());

    IList<int> evenList = new List<int>(randomIntegerList.Where(x => x % 2 == 0));
    IList<int> oddList = new List<int>(randomIntegerList.Except(evenList));
    // IList<int> oddList = new List<int>(randomIntegerList.Where(x => x % 2 != 0));

    //An alternative would be:
    // for (int i = 0; i<randomIntegerList.Count; i++)
    // {
    //     if (randomIntegerList[i] % 2 == 0) 
    //         evenList.Add(randomIntegerList[i]);
    //     if (randomIntegerList[i] % 2 == 1) 
    //         oddList.Add(randomIntegerList[i]);
    // }

    // A lazier (and more computationally expensive) alternative would be: 
    // foreach (int i in randomIntegerList)
    //     if (i % 2 == 0) evenList.Add(i);
    // foreach (int i in randomIntegerList)
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

    double sphereVolume = 4 * Math.PI * radius * radius; //formula (4*pi*radius^
    WriteLine("The surface area of a sphere with the given radius is: {0} units", sphereVolume);

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

        // if (inputYear == currentYear)
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
    Random randomNumber = new();
    int secretNumber = randomNumber.Next(10); //sets the range from 0 to 9
    string? answer = "yes";
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
    for (int i = topLayerOfStars; i > 0; i--) //should iterate to the number of stars in the top layer
    {
        for (int j = 0; j < topLayerOfStars - i; j++) //should start at 0 and increase to number (topLayerOfStars - i) 
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

int RunExerciseTwentyOne(int fibNum, int fibStart = 0)
{
    /*Exercise 21 (Optional) 

    Write a program to print the Fibonacci series */
    //first call on its own method recursively until fibNum == 0 and then go back up to calculate the values consecutively.
    //How to set a condition for this?

    if (fibNum < 1)
    {
        return fibNum;
    }
    else

        return RunExerciseTwentyOne(fibNum - 1) + RunExerciseTwentyOne(fibNum - 2);
}

static void RunExerciseTwentyTwo()
{
    Write("Insert the height of the triangle: ");
    double height = ToDouble(ReadLine());
    Write("Insert the width of the triangle: ");
    double width = ToDouble(ReadLine());
    WriteLine($"Area of the triangle is: {height * width / 2}");

    ReadKey();
}

static void RunExerciseTwentyThree()
{
    //this exercise is about overloading methods. They must be defined in a separate class as they cannot be declared in the main function (or the functional equivalent).

    double d1 = 1.75, d2 = 2.64, d3 = 3.91, d4 = 4.13;

    WriteLine(ExerciseMethods.AddNumbers(d1, d2));
    WriteLine(ExerciseMethods.AddNumbers(d1, d2, d3));
    WriteLine(ExerciseMethods.AddNumbers(d1, d2, d3, d4));

    ReadKey();
}

static void RunExerciseTwentyFour()
{
    int[] ex1 = { 1, 2, 3, 4, 5 }; //expected output: 5
    int[] ex2 = { 1, 530202, -903, 3, -1, 86 }; //expected output: 530202
    int[] ex3 = { 1, 23 * 23, -5303, 353, -1, 86 }; // expected output: 23*23  (529)

    WriteLine(ExerciseMethods.GreatestNumber(ex1));
    WriteLine(ExerciseMethods.GreatestNumber(ex2));
    WriteLine(ExerciseMethods.GreatestNumber(ex3));
}

static void RunExerciseTwentyFive()
{
    Write("Insert number A: ");
    double a = ToDouble(ReadLine());
    Write("Insert number B: ");
    double b = ToDouble(ReadLine());
    WriteLine("Swapping....");
    ExerciseMethods.SwapExercise25(a, b);
    WriteLine($"Value A is still {a} outside the function and value B is still {b} outside the fuction.");

    ReadKey();
}

static void RunExerciseTwentySix()
{
    Write("Insert number A: ");
    double a = ToDouble(ReadLine());
    Write("Insert number B: ");
    double b = ToDouble(ReadLine());
    WriteLine("Swapping....");

    ExerciseMethods.SwapExercise26(ref a, ref b);
    WriteLine($"Value A is now also {a} outside the function and value B is now also {b} outside the fuction.");

    // double A = a, B = b;
    // ExerciseMethods.SwapExercise26(a, b, out A, out B); //using out

    ReadKey();
}

static void RunExerciseTwentySeven()
{

    Write("Insert a string: ");
    string? inputString = ReadLine();
    char[] inputCharArray = inputString.ToCharArray();

    // alt 1
    int palindromeCount = 0;
    for (int i = 0; i < inputCharArray.Length / 2; i++)
    {
        if (inputCharArray[i] == inputCharArray[^(i + 1)]) palindromeCount++;
    }
    if (palindromeCount == (inputCharArray.Length / 2)) WriteLine("The string is a palindrome!");
    else WriteLine("The string is *not* a palindrome!");

    //alt 2
    //this requires a proxy string
    //use split instead and assign to a string[] and compare them when reversed?

    // [0..^0]
    // char[] firstPart = inputCharArray[..];
    // char[] secondPart = inputCharArray[inputCharArray.Length / 2];
    // WriteLine(secondPart);
    // secondPart = (string)secondPart.Reverse();
    // WriteLine(firstPart);
    // WriteLine(secondPart);

    // string[] splitString = inputString.Split(inputString.Length / 2);

    // if (inputString.Substring(inputString.Length / 2) == inputString.Substring(0, inputString.Length / 2).Reverse())
    //GetEnumerable() or just use Convert.ToCharArray().

    // if (firstPart == secondPart) WriteLine("The string is a palindrome!");
    // else WriteLine("The string is *not* a palindrome!");

    ReadKey();
}

static void RunExerciseTwentyEight()

{
    WriteLine("Enter 12 positive integer numbers: ");

    uint[] inputIntegers = new uint[12];
    for (uint u = 0; u < inputIntegers.Length; u++)
    {
        inputIntegers[u] = ToUInt32(ReadLine());
    }
    Write("You entered: ");
    WriteLine(string.Join(" ", inputIntegers));

    var evenNumbers = inputIntegers.Where(x => x % 2 == 0).ToArray();
    var oddNumbers = inputIntegers.Where(x => x % 2 == 1).ToArray();

    Write("Even numbers: ");
    WriteLine(string.Join(" ", evenNumbers));
    Write("Odd numbers: ");
    WriteLine(string.Join(" ", oddNumbers));

    ReadKey();
}

static void RunExerciseTwentyNine()
{
    int[] randomArray = new int[20];
    int[] evenFirstOddSecond = new int[20];
    Random randomNumber = new();

    for (int i = 0; i < randomArray.Length; i++)
        randomArray[i] = randomNumber.Next(100); //for the sake of output readability, the maxValue is set to 100

    Write("Created array: ");
    WriteLine(string.Join(" ", randomArray));

    //alt 1 - using the FindAll method of the static Array class and then concatenating the results
    int[] evenNumbers = Array.FindAll(randomArray, x => x % 2 == 0); //returns all even numbers
    int[] oddNumbers = Array.FindAll(randomArray, x => x % 2 == 1); //returns all odd numbers

    evenFirstOddSecond = evenNumbers.Concat(oddNumbers).ToArray(); //Conversion could be expensive....
    //or
    // evenNumbers.CopyTo(evenFirstOddSecond, 0);
    // oddNumbers.CopyTo(evenFirstOddSecond, evenNumbers.Length);

    //alt 2
    // int elementCounter = 0;
    // foreach (int i in randomArray.Where(x => x % 2 == 0))
    // {
    //     evenFirstOddSecond[elementCounter++] = i;
    // }
    // foreach (int i in randomArray.Where(x => x % 2 == 1))
    // {
    //     evenFirstOddSecond[elementCounter++] = i;
    // }

    Write("Even first, odd second: ");
    WriteLine(string.Join(" ", evenFirstOddSecond));
    ReadKey();
}

static void RunExerciseThirty()
{
    // Create an array. Set the size of an array as a random number between 5 and 15. Sort this array without using sort method.
    Random randomNumber = new();

    int[] arrayFiveFifteen = new int[randomNumber.Next(5, 15)];
    for (int i = 0; i < arrayFiveFifteen.Length; i++)
        arrayFiveFifteen[i] = randomNumber.Next(100); //for the sake of output readability, the maxValue is set to 100

    int swapHolder;

    Write("Generated array: ");
    WriteLine(string.Join(" ", arrayFiveFifteen));

    //Bubble-sort. Time complexity: O(n^2)). Space complexity: O(1).  - I know bubble-sort is bad, but it's the only one I know.
    for (int j = 0; j < Math.Pow(arrayFiveFifteen.Length, 2); j++)
    {
        for (int i = 0; i < arrayFiveFifteen.Length - 1; i++)
        {
            if (arrayFiveFifteen[i] > arrayFiveFifteen[i + 1])
            {
                swapHolder = arrayFiveFifteen[i];
                arrayFiveFifteen[i] = arrayFiveFifteen[i + 1];
                arrayFiveFifteen[i + 1] = swapHolder;
            }
        }
    }
    //Quicker sorting method algorithm - add later?

    Write("Sorted array:    ");
    WriteLine(string.Join(" ", arrayFiveFifteen));

    ReadKey();
}

static void RunExerciseThirtyOne()
{
    // Create an array.Set the size of an array as a random number smaller than 16. Fill in the array with random numbers(positive, smaller than 100, not repeated).
    // Create another array of the same size and ask the user if he / she wants to fill in the array with either square or cube result of the values from previous array.

    Random randomNumber = new();
    int[] randomArray = new int[randomNumber.Next(16)]; //use distinct

    int numberToAdd;
    for (int i = 0; i < randomArray.Length; i++)
    {
        numberToAdd = randomNumber.Next(100);
        if (numberToAdd != Array.Find(randomArray, x => x == numberToAdd)) //only adds it if it doesn't already exist in the array
            randomArray[i] = numberToAdd;
        else i--; //if it does exist, we need to iterate on the same index again and generate a new random number for it.
    }

    Write("Generated array: ");
    Write(string.Join(" ", randomArray));

    Write("\nDo you want to square or cube these values? Type 2 to square or 3 to cube: ");
    int power = ToInt32(ReadLine());
    int[] derivedArray = new int[randomArray.Length];

    for (int i = 0; i < randomArray.Length; i++)
        derivedArray[i] = (int)Math.Pow(randomArray[i], power);

    Write("New array generated: ");
    Write(string.Join(" ", derivedArray));

    ReadKey();
}

static void RunExerciseThirtyTwo()
{
    Write("Insert a string with comma-separated number: ");
    string[] numberSnippet = ReadLine().Split(',');
    int[] numbers = new int[numberSnippet.Length];
    for (int i = 0; i < numberSnippet.Length; i++)
        numbers[i] = int.Parse(numberSnippet[i]);

    WriteLine("Lowest value is: " + numbers.Min());
    WriteLine("Highest value is: " + numbers.Max());
    WriteLine("Average value is: " + numbers.Average());
    ReadKey();
}

static void RunExerciseThirtyThree()
{
    //A) Change string “The quick fox Jumped Over the DOG” to the string “The brown fox jumped over the lazy dog” using required string manipulation functions.
    string questionA = "The quick fox Jumped Over the DOG";

    //Quick and efficient solution.
    WriteLine("Question A: Original text: " + questionA);
    questionA = questionA.Replace("quick fox Jumped Over the DOG", "brown fox jumped over the lazy dog");
    WriteLine("Question A: Altered text: " + questionA);

    // Longer solution showing other ways to accomplish the same task.
    // WriteLine("Question A: Original text: " + questionA);
    // questionA = questionA.Replace("quick", "brown").Replace("J", "j").Replace("Over", "over").Substring(0, questionA.IndexOf('D')) + "lazy " + questionA.Substring(questionA.IndexOf("D"), questionA.IndexOf("G") - questionA.IndexOf("D") + 1).ToLower();
    // WriteLine("Question A: Altered text: " + questionA);

    //B) - Enter any two words from console and check whether they are same words or not
    Write("\nEnter the first word: ");
    string? questionB1 = ReadLine();
    Write("Enter the second word: ");
    string? questionB2 = ReadLine();

    if (questionB1.Equals(questionB2, StringComparison.InvariantCultureIgnoreCase))
        WriteLine("They are the same word!");
    else
        WriteLine("They are *not* the same word");


    //C) - Input word Donkey and display it as the word Monkey on the console.
    string questionC = "Donkey";
    WriteLine("\nQuestion C: Original text: " + questionC);
    questionC = questionC.Replace("D", "M");
    WriteLine("Question C: Altered text: " + questionC);

    // D) Replace ‘I’ with ‘We’ and ‘am’ with ‘are’ in given text below.
    string questionD = "I am going to visit Kolmården zoo tomorrow. I am a big fan of the dolphin show. I may watch all dolphin shows during the day. I would like to take a gondola safari as well. I wish to visit Bamse and his team there.";

    WriteLine("\nQuestion D: Original text: " + questionD);
    questionD = questionD.Replace("a big fan", "big fans").Replace("I", "We").Replace("am", "are");
    WriteLine("Question D: Altered text: " + questionD);

    //E) Actual string is "She is the popular singer." and the expected string is "She is the most popular singer."
    string questionE = "She is the popular singer.";
    WriteLine("\nQuestion E: Original text: " + questionE);
    questionE = questionE.Replace("the", "the most");
    WriteLine("Question E: Altered text: " + questionE);

    //F) Actual string is "A friend is the asset of your life." and the expected string is "A true friend is the greatest asset of your life"
    string questionF = "A friend is the asset of your life.";
    WriteLine("\nQuestion F: Original text: " + questionF);
    questionF = questionF.Remove(questionF.IndexOf('.'), 1).Replace("A", "A true").Replace("the", "the greatest");
    WriteLine("Question F: Altered text: " + questionF);

    //G) Actual string is "My name is Nalini Phopase." Expected string: "Nalini Phopase"
    string questionG = "My name is Nalini Phopase.";
    WriteLine("\nQuestion G: Original text: " + questionG);
    // questionG = questionG.Remove(questionG.IndexOf('.'), 1).Substring(questionG.IndexOf('N'));
    questionG = questionG.Remove(questionG.IndexOf('.'), 1)[questionG.IndexOf('N')..];
    WriteLine("Question G: Altered text: " + questionG);

    //H) Actual string is "Arrays are very common in programming, they look something like: [1,2,3,4,5]" Expected string: "[1,4,5,6,7,8]"*/
    string questionH = "Arrays are very common in programming, they look something like: [1,2,3,4,5]";
    WriteLine("\nQuestion H: Original text: " + questionH);
    questionH = questionH.Substring(questionH.IndexOf('['));
    WriteLine("Question H: Altered text: " + questionH);

    ReadKey();
}

static void RunExerciseThirtyFour()
{
    Write("Enter your date of birth (format: yyyy-mm-dd): ");
    string? dateOfBirthString = ReadLine();
    int age = ExerciseMethods.CalculateAge(dateOfBirthString);
    WriteLine($"You are {age} years old");

    //add .Weekday and say "you were born on a {dateOfBirth.Weekday} and are x years old". ?

    ReadKey();
}

static void RunExerciseThirtyFive()
{
    Write("Enter your name:");
    string name = ReadLine();
    Write("\n Greetings ");
    ReadKey();

    // ExerciseMethods.CalculateAge(dateOfBirthString);

    

}

static void RunExerciseThirtySix()
{
    for (int j = 1; j <= 10; j++)
    {
        for (int k = 1; k <= 10; k++)
        {
            Write("+---");
            if (k == 10)
                Write("+");
        }
        WriteLine();

        for (int i = 1; i <= 10; i++)
        {
            Write("|");

            if (j * i == 100)
                Write(j * i);
            else if (j * i >= 10)
                Write(" " + j * i);
            else if (j * i < 10)
                Write("  " + j * i);

            if (i == 10)
                Write("|");
        }
        WriteLine();

        if (j == 10)
        {
            for (int k = 0; k < 10; k++)
                Write("+---");
            Write("+");
        }
    }
    ReadKey();
}

bool keepAlive = true;
while (keepAlive)
{
    try
    {
        Write("Enter assignment number (or -1 to exit): ");
        var assignmentChoice = int.Parse(ReadLine() ?? ""); //?? is the null-coalescing operator, if the statement to its left equals null, the value to its right will be used
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
            case 21:

                Write("How many digits of the fibonacci sequence do you want to compute?: ");
                int fibonacciDigits = ToInt32(ReadLine());
                WriteLine(RunExerciseTwentyOne(fibonacciDigits));

                ReadKey();
                break;
            case 22:
                RunExerciseTwentyTwo();
                break;
            case 23:
                RunExerciseTwentyThree();
                break;
            case 24:
                RunExerciseTwentyFour();
                ReadKey();
                break;
            case 25:
                RunExerciseTwentyFive();
                break;
            case 26:
                RunExerciseTwentySix();
                break;
            case 27:
                RunExerciseTwentySeven();
                break;
            case 28:
                RunExerciseTwentyEight();
                break;
            case 29:
                RunExerciseTwentyNine();
                break;
            case 30:
                RunExerciseThirty();
                break;
            case 31:
                RunExerciseThirtyOne();
                break;
            case 32:
                RunExerciseThirtyTwo();
                break;
            case 33:
                RunExerciseThirtyThree();
                break;
            case 34:
                RunExerciseThirtyFour();
                break;
            case 35:
                RunExerciseThirtyFive();
                break;
            case 36:
                RunExerciseThirtySix();
                break;

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

public static class ExerciseMethods
{
    public static double AddNumbers(double one, double two)
    {
        return one + two;
    }
    public static double AddNumbers(double one, double two, double three)
    {
        return one + two + three;
    }
    public static double AddNumbers(double one, double two, double three, double four)
    {
        return one + two + three + four;
    }

    public static int GreatestNumber(int[] array)
    {
        //Alternative 1
        return array.Max();

        //Alternative 2
        // Array.Sort(array);
        // return array[array.Length - 1];

        //Alternative 3
        // int highestNumber = int.MinValue;
        // foreach (int i in array)
        // {
        //     if (i > highestNumber) highestNumber = i;
        // }
        // return highestNumber;

    }

    public static void SwapExercise25(double a, double b)
    {
        double temp = b;
        b = a;
        a = temp;

        WriteLine($"Value A is now {a} inside the function and value B is now {b} inside the fuction.");
    }

    public static void SwapExercise26(ref double a, ref double b)
    {
        double temp = b;
        b = a;
        a = temp;
        WriteLine($"Value A is now {a} inside the function and value B is now {b} inside the fuction.");
    }

    // public static void SwapExercise26(double a, double b, out double A, out double B) //using out instead
    // {
    //     double temp = b;
    //     b = a;
    //     a = temp;
    //     A = a;
    //     B = b;
    //     WriteLine($"Value A is now {a} inside the function and value B is now {b} inside the fuction.");
    // }

    public static int CalculateAge(string dateOfBirthString)
    {
        //add ability to enter in any format
        // string[] dateTimeVariantsToday = now.GetDateTimeFormats();

        DateTime dateOfBirth = ToDateTime(dateOfBirthString);
        DateTime now = DateTime.Now;

        int age;
        if (dateOfBirth.Month < now.Month || (dateOfBirth.Month == now.Month && dateOfBirth.Day <= now.Day)) //either a previous month, or a previous day/the same day the same month
            age = now.Year - dateOfBirth.Year;
        else
            age = now.Year - dateOfBirth.Year - 1;

        return age;
    }

}