using System.Buffers;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static ExerciseClass; //I added this class
using static System.Console;
using static System.Convert;

static void RunExerciseOne()
{
    string firstName = "Joakim";
    string lastName = "Nylund";

    WriteLine($"Hello {firstName} {lastName}! I'm glad to inform you that you are the test subject of my very first assignment!");
    // WriteLine("Hello {0} {1}! I'm glad to inform you that you are the test subject of my very first assignment!", firstName, lastName);
    // WriteLine("Hello " + firstName + " " + lastName + "! I'm glad to inform you that you are the test subject of my very first assignment!", firstName, lastName);
}

static void RunExerciseTwo()
{
    Write("Please enter your first name: ");
    string? firstName = ReadLine();
    Write("Please enter your last name: ");
    string? lastName = ReadLine();

    WriteLine($"\nHello {firstName} {lastName}! Have a nice day!");
}

static void RunExerciseThree()
{
    Write("Enter two consecutive numbers with one(!) space in between: ");
    string[] inputtedNumbers = ReadLine()!.Trim().Split(" ");
    Write(int.Parse(inputtedNumbers[1]) == int.Parse(inputtedNumbers[0]) + 1 ? "They are consecutive " : "They are not consecutive ");
}

static void RunExerciseFour()
{
    //The format characters d (short format) and D (long format) make it more concise.
    WriteLine($"Today's date is {DateTime.Today:d} in a short format, {DateTime.Today:D} in a long format, and {DateTime.Today:yyyy-MMMM-dd} in a mixed format.");

    //example of a different approach
    // WriteLine("Todays date in the short date format is: " + DateTime.Now.ToShortDateString());
    // WriteLine("Today's date in the long date format is: " + DateTime.Now.ToLongDateString());

    WriteLine($"\nTomorrow's date in a short format: {DateTime.Today.AddDays(1):d}");
    WriteLine($"Yesterday's date in a short format: {DateTime.Today.AddDays(-1):d}");

    IFormatProvider esCulture = new System.Globalization.CultureInfo("es-ESP", true); //for fun
    string[] currentMomentDateTimeFormats = DateTime.Now.GetDateTimeFormats(esCulture); //defaults to OS settings if no argument is passed.

    CyanForeGroundColor();
    WriteLine("\nAll alternative Spanish date & time formats: ");
    WriteLine(string.Join("\n", currentMomentDateTimeFormats.Distinct())); //.Distinct() added because of duplicates
    GreenForeGroundColor();
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
    int sumPartB = (int)(firstNumPartB + secondNumPartB);

    //Part c
    int evenNumPartC = 2;
    int oddNumPartC = 3;
    WriteLine("\nPart C. Answer: " + oddNumPartC / (double)evenNumPartC);
}

static void RunExerciseSix()
{
    int x = 40, y = 20, z = 25, m = 15;
    int e0 = (x + y) * z / m; //   //(2*2*3*5)*(5*5)/(3*5) = 1500/15  - There are no denominator-exclusive primes, meaning no casting is necessary for this order (even if arithmetic operators had been right-associative) 
    int e1 = (int)((x + y) * (z / (double)m)); // (2*2*3*5)*((5*5)/(3*5)) = 60*1,666...  - you first need to cast m (or z) to double, and then the whole expression to int.
    int f = x + y * (z / m);
    int g = x + y * z / m; //no parentheses are needed for this one
    int h = (x + y * z) / m;
    WriteLine($"e: {e0} f: {f} g: {g} h: {h}");
}

static void RunExerciseSeven()
{
    Write("Enter any positive integer: ");
    int? integerToBeChecked = int.Parse(ReadLine()!);
    WriteLine(integerToBeChecked % 2 == 0 ? "The integer is even" : "The integer is odd");
}

static void RunExerciseEight()
{
    Random randomNumber = new();
    IList<int> randomIntegerList = new List<int>();
    for (int i = 0; i < 20; i++)
        randomIntegerList.Add(randomNumber.Next());

    IList<int> evenList = new List<int>(randomIntegerList.Where(x => x % 2 == 0));
    IList<int> oddList = new List<int>(randomIntegerList.Except(evenList));
    // IList<int> oddList = new List<int>(randomIntegerList.Where(x => x % 2 != 0));  //also works

    //Same thing can be accomplished using a for-loop (or a foreach loop).
    // for (int i = 0; i<randomIntegerList.Count; i++)
    // {
    //     if (randomIntegerList[i] % 2 == 0) 
    //         evenList.Add(randomIntegerList[i]);
    //     else if (randomIntegerList[i] % 2 == 1) 
    //         oddList.Add(randomIntegerList[i]);
    // }

    Write("List of even elements: " + string.Join(" ", evenList));
    Write("\nList of odd elements:  " + string.Join(" ", oddList));
}

static void RunExerciseNine()
{
    Write("Insert a unitless radius value: ");
    double radius = double.Parse(ReadLine()!);

    double circleArea = Math.PI * radius * radius; //formula pi*radius^2
    double sphereSurfaceArea = 4 * Math.PI * radius * radius; //formula (4*pi*radius^

    WriteLine($"\nThe area of a circle with radius of {radius} is : {circleArea}");
    WriteLine($"The surface area of a sphere with a radius of {radius} is : {sphereSurfaceArea}");
}

static void RunExerciseTen()
{
    //I wanted to do this exercise with a single input of all the numbers and without having to convert the entire array to a value type

    Write("Enter 10 numbers of your choosing with one(!) space in between (1 2 3...) : ");
    string[] inputStringNumbers = ReadLine()!.Trim().Split(" ");  //only accepts commas as decimal markers. Determined by OS settings?

    if (!inputStringNumbers.Where(stringNumber => stringNumber[0] == '-' && stringNumber[1] != 0).Any()) //minus followed by a space will produce an IndexOutOfRangeException
        WriteLine("No negative numbers entered.");
    else
        WriteLine($"The negative numbers are: " + string.Join(" ", inputStringNumbers.Where(x => double.Parse(x) < 0)));
    // double.Parse(x) was much more concise than setting the multiple conditions on strings and their characters that are otherwise needed to plug all failure cases. 
}

static void RunExerciseEleven()
{
    //Typical body temperature is: 36.5–37.5 °C. 

    Write("Enter your body temperature in °C: ");
    float bodyTemp = ToSingle(ReadLine());  // single-precision float numbers are more than precise enough for this use-case.

    if (bodyTemp >= 36.5 && bodyTemp <= 37.5)
        WriteLine("You don't have a fever");
    else if (bodyTemp > 37.5 && bodyTemp < 42)
        WriteLine("You have a fever.");
    else if (bodyTemp < 36.5 && bodyTemp > 28.0)
        WriteLine("You have hypothermia.");
    else
        WriteLine("Something is wrong.");
}

static void RunExerciseTwelve()
{
    Write("Enter the current year: ");
    int inputYear = int.Parse(ReadLine()!);
    WriteLine(inputYear == DateTime.Now.Year ? "Correct" : "Incorrect");
}

static void RunExerciseThirteen()
{
    Write("Insert an arithmetic operator: ");
    ConsoleKeyInfo inputOperator = ReadKey();

    Write("\nInsert operand number 1: ");
    double operandNum1 = ToDouble(ReadLine());

    Write("Insert operand number 2: ");
    double operandNum2 = ToDouble(ReadLine());

    switch (inputOperator.KeyChar)
    {
        case '+':
            WriteLine($"\n{operandNum1} + {operandNum2} = {operandNum1 + operandNum2}");
            break;
        case '-':
            WriteLine($"\n{operandNum1} - {operandNum2} = {operandNum1 - operandNum2}");
            break;
        case '*':
            WriteLine($"\n{operandNum1} * {operandNum2} = {operandNum1 * operandNum2}");
            break;
        case '/':
            WriteLine($"\n{operandNum1} / {operandNum2} = {operandNum1 / operandNum2}");
            break;
    }
}

static void RunExerciseFourteen()
{
    Write("Enter your grade (A-D): ");
    ConsoleKeyInfo grade = ReadKey();

    switch (grade.Key)
    {
        case ConsoleKey.A:
            WriteLine("\nGreat job!");
            break;
        case ConsoleKey.B:
            WriteLine("\nWell done.");
            break;
        case ConsoleKey.C:
            WriteLine("\nYou passed");
            break;
        case ConsoleKey.D:
            WriteLine("\nYou passed");
            break;
    }
}

static void RunExerciseFifteen()
{
    int inputNum = 0;
    do
    {
        Write("Enter any positive integer smaller than 100: ");
        inputNum = int.Parse(ReadLine()!);
    } while (inputNum > 100 || inputNum < 1);

    //I know that writing several statements on the same row is a no-no, but maybe there are exceptions?
    CyanForeGroundColor(); WriteLine("\nUsing for-loops"); GreenForeGroundColor();
    Write("Ascending order: ");
    for (int i = 1; i <= inputNum; i++)
        Write(i + " ");

    Write("\nDescending order: ");
    for (int i = inputNum; i > 0; i--)
        Write(i + " ");

    CyanForeGroundColor(); WriteLine("\n\nUsing while-loops"); GreenForeGroundColor();
    Write("Ascending order: ");
    int loopCounterExercise15 = 1;
    while (loopCounterExercise15 <= inputNum)
        Write(loopCounterExercise15++ + " ");

    Write("\nDescending order: ");
    loopCounterExercise15 = inputNum;
    while (loopCounterExercise15 >= 1)
        Write(loopCounterExercise15-- + " ");

    CyanForeGroundColor(); WriteLine("\n\nUsing do-while-loops"); GreenForeGroundColor();
    loopCounterExercise15 = 1;
    Write("Ascending order: ");
    do { Write(loopCounterExercise15++ + " "); }
    while (loopCounterExercise15 <= inputNum);

    Write("\nDescending order: ");
    do { Write(--loopCounterExercise15 + " "); }
    while (loopCounterExercise15 > 1);
}

static void RunExerciseSixteen()
{
    Write("Enter a date: ");
    DateTime inputDate = ToDateTime(ReadLine());

    if (inputDate.Year < DateTime.Now.Year)
        WriteLine("Past year");
    else if (inputDate.Year > DateTime.Now.Year)
        WriteLine("Future year");
    else
        WriteLine("Present year");

    //alternatively one could use nested ternary conditional operators 
    // WriteLine(inputDate.Year < DateTime.Now.Year ? "Past year" : inputDate.Year > DateTime.Now.Year ? "Future year" : "Present year");
}

static void RunExerciseSeventeen()
{
    // leap years are perfectly divisible by four, but not divisible by 100 unless also divisible by 400

    WriteLine("\nLeap years (1990-Now) with for-loop & user-made conditionals: ");
    for (int i = 1990; i <= DateTime.Now.Year; i += 4)
    {
        if (i % 100 != 0 || i % 400 == 0)
            Write(i + " ");
    }

    WriteLine("\n\nLeap years (1990-Now) with a for-loop & IsLeapYear: ");
    for (int i = 1990; i <= DateTime.Now.Year; i += 4)
    {
        if (DateTime.IsLeapYear(i))
            Write(i + " ");
    }

    IEnumerable<int> leapYears0 = Enumerable.Range(1990, DateTime.Now.Year - 1990 + 1).Where(x => x % 4 == 0 && x % 100 != 0 || x % 400 == 0); //+1 to include the current year
    WriteLine("\n\nLeap years (1990-Now) with an enumerator, LINQ, & user-made conditionals: \n" + string.Join(" ", leapYears0));

    IEnumerable<int> leapYears2 = Enumerable.Range(1990, DateTime.Now.Year - 1990 + 1).Where(x => DateTime.IsLeapYear(x));
    WriteLine("\nLeap years (1990-Now) with an enumerator, LINQ, & IsLeapYear: \n" + string.Join(" ", leapYears2));
}

static void RunExerciseEighteen()
{
    Random randomNumber = new();
    int guessedNumber = -1, secretNumber = randomNumber.Next(10); //sets the range from 0 to 9
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
            Write("\nDo you want to stop guessing? (Yes/No) ");
            answer = ReadLine();
        }

    } while (secretNumber != guessedNumber && answer!.ToLower() != "yes");
}

static void RunExerciseNineteen()
{
    //Print reverse pyramid. # of stars in the top layer = # of layers

    //* * * * *  0 initial whitespaces,  5 stars  
    // * * * *   1 initial whitespace,   4 stars
    //  * * *    2 initial whitespaces,  3 stars
    //   * *     .......
    //    *      4 initial whitespaces,  1 stars

    Write("Time for creating a pyramid!\nHow many layers do you want it to have? ");
    int pyramidLayers = ToInt32(ReadLine());
    for (int i = pyramidLayers; i > 0; i--)
    {
        for (int j = 0; j < pyramidLayers - i; j++) //initial whitespaces
            Write(" ");
        for (int k = i; k > 0; k--) //star generator
            Write("* ");
        WriteLine();    //switches layer
    }
}

static void RunExerciseTwenty()
{
    // Write a program that keeps asking the user to enter numbers, until he enters -1. Then displays a sum and average of all numbers entered before -1

    int sum = 0, inputNumber = 0, elementCounter = 0;
    do
    {
        Write("Input a number or input -1 to print the sum of inputted numbers: ");

        sum += inputNumber;
        inputNumber = ToInt32(ReadLine());
        elementCounter++;
    } while (inputNumber != -1);

    WriteLine("\nThe sum is {0}", sum);
    WriteLine("The average is {0}", (double)sum / (elementCounter - 1));
}

static void RunExerciseTwentyOne()
{
    Write("How many digits of the fibonacci sequence do you want to compute?: ");
    int fibonacciDigits = ToInt32(ReadLine());
    for (int i = 0; i < fibonacciDigits; i++)
        Write(CalculateFibonacci(i) + " ");
}

static void RunExerciseTwentyTwo()
{
    Write("Insert the height of the triangle: ");
    double height = ToDouble(ReadLine());
    Write("Insert the width of the triangle: ");
    double width = ToDouble(ReadLine());
    WriteLine($"\nArea of the triangle is: {height * width / 2}");
}

static void RunExerciseTwentyThree()
{
    //this exercise is about overloading methods. They must be defined in a separate class as they cannot be declared in the main function (or the functional equivalent).
    decimal d1 = 1.75m, d2 = 2.64m, d3 = 3.91m, d4 = -4.13m; //rounding errors appear if I use double

    AddNumbers(d1, d2);
    AddNumbers(d1, d2, d3);
    AddNumbers(d1, d2, d3, d4);
}

static void RunExerciseTwentyFour()
{
    int[] exArray1 = { 1, 2, 3, 4, 5 }; //expected output: 5
    int[] exArray2 = { 1, 530202, -903, 3, -1 }; //expected output: 530202
    int[] exArray3 = { 1, 23 * 23, -5303, 353, -1 }; // expected output: 23*23  (529)

    WriteLine(GreatestNumber(exArray1));
    WriteLine(GreatestNumber(exArray2));
    WriteLine(GreatestNumber(exArray3));
}

static void RunExerciseTwentyFive()
{
    Write("Insert number A: ");
    double a = ToDouble(ReadLine());
    Write("Insert number B: ");
    double b = ToDouble(ReadLine());
    WriteLine("Swapping....");

    SwapExercise25(a, b);
    WriteLine($"Number A is still {a} outside the function and number B is still {b} outside the fuction.");
}

static void RunExerciseTwentySix()
{
    Write("Insert number A: ");
    double a = ToDouble(ReadLine());
    Write("Insert number B: ");
    double b = ToDouble(ReadLine());
    WriteLine("Swapping....");

    SwapExercise26(ref a, ref b);
    WriteLine($"Number A is now also {a} outside the function and number B is now also {b} outside the fuction.");
}

static void RunExerciseTwentySeven()
{
    Write("Insert a string: ");
    string? inputString = ReadLine();

    int palindromeCount = 0;
    for (int i = 0; i < inputString!.Length / 2; i++)
        if (inputString[i] == inputString[^(i + 1)]) palindromeCount++;
    Write(palindromeCount == (inputString.Length / 2) ? "The string is a palindrome!" : "The string is *not* a palindrome!");
}

static void RunExerciseTwentyEight()
{
    Write("Enter 12 positive integer numbers with one(!) space in between: ");
    string[] inputIntegersString = ReadLine()!.Trim().Split(" ");
    Write("You entered: " + string.Join(" ", inputIntegersString));

    int[] inputIntegerArray = new int[inputIntegersString.Length];
    for (int i = 0; i < inputIntegersString.Length; i++)
        inputIntegerArray[i] = int.Parse(inputIntegersString[i]);

    int[] evenIntegerArray = inputIntegerArray.Where(x => x % 2 == 0).ToArray();
    int[] oddIntegerArray = inputIntegerArray.Where(x => x % 2 == 1).ToArray();

    WriteLine("\n\nEven numbers: ");
    foreach (int num in evenIntegerArray) Write(num + " ");
    WriteLine("\nOdd numbers: ");
    foreach (int num in oddIntegerArray) Write(num + " ");

    //Concise way to print all even and odd numbers directly. 
    // WriteLine("\nEven numbers: " + string.Join(" ", inputIntegersString.ToArray().Where(x => int.Parse(x) % 2 == 0)));
    // WriteLine("Odd numbers: " + string.Join(" ", inputIntegersString.ToArray().Where(x => int.Parse(x) % 2 == 1)));
}

static void RunExerciseTwentyNine()
{
    int[] randomArray = new int[20];
    int[] evenFirstOddSecond = new int[20];
    Random randomNumber = new();

    for (int i = 0; i < randomArray.Length; i++)
        randomArray[i] = randomNumber.Next(10, 100); // 10<= randomArray[i] < 100 : for the sake of output readability and easy comparison

    WriteLine("Created array:          " + string.Join(" ", randomArray));

    //alt 1 - using the FindAll method of the static Array class and then concatenating the results
    int[] evenNumbers = Array.FindAll(randomArray, x => x % 2 == 0); //returns all even numbers
    int[] oddNumbers = Array.FindAll(randomArray, x => x % 2 == 1); //returns all odd numbers
    evenFirstOddSecond = evenNumbers.Concat(oddNumbers).ToArray(); //Conversion could be expensive....

    //alt 2
    // evenNumbers.CopyTo(evenFirstOddSecond, 0);
    // oddNumbers.CopyTo(evenFirstOddSecond, evenNumbers.Length);

    //alt 3
    // int elementCounter = 0;
    // foreach (int i in randomArray.Where(x => x % 2 == 0))
    //     evenFirstOddSecond[elementCounter++] = i;
    // foreach (int i in randomArray.Where(x => x % 2 == 1))
    //     evenFirstOddSecond[elementCounter++] = i;

    WriteLine("Even first, odd second: " + string.Join(" ", evenFirstOddSecond));
}

static void RunExerciseThirty()
{
    // Create an array. Set the size of an array as a random number between 5 and 15. Sort this array without using sort method.
    Random randomNumber = new();

    int[] arrayFiveFifteen = new int[randomNumber.Next(6, 15)]; //6 because minValue is included, maxValue is not.
    for (int i = 0; i < arrayFiveFifteen.Length; i++)
        arrayFiveFifteen[i] = randomNumber.Next(100); //for the sake of output readability, the maxValue is set to 100

    WriteLine("Generated array: " + string.Join(" ", arrayFiveFifteen));


    //Improvised primitive bubble-sort(of). Time complexity: O(n^2)). Space complexity: O(1). I know bubble-sort is bad, but it's the only one I know.
    int[] sortedArray = BubbleSort(arrayFiveFifteen);

    WriteLine("Sorted array:    " + string.Join(" ", sortedArray));
}

static void RunExerciseThirtyOne()
{
    //I interpreted the requirement "not repeated" as pertaining to the array as a whole. I therefore check for duplicates.
    Random randomNumber = new();
    int[] randomArray = new int[randomNumber.Next(1, 16)];

    int numberToAdd;
    for (int i = 0; i < randomArray.Length; i++)
    {
        numberToAdd = randomNumber.Next(100);
        if (numberToAdd != Array.Find(randomArray, x => x == numberToAdd)) //duplicate check
            randomArray[i] = numberToAdd;
        else i--; //if a duplicate does exist, we need to repeat the process for this element.
    }

    Write("Generated array: " + string.Join(" ", randomArray));
    Write("\nDo you want to square or cube these values? Type (square/cube): "); //I wanted to try solving for a string input instead of just numbers.
    string exponentString = ReadLine()!.ToLower();
    int power = 0;
    do
    {
        if (exponentString == "square")
            power = 2;
        else if (exponentString == "cube")
            power = 3;
        else
        {
            Write("\nWrong input, try again (square/cube): ");
            exponentString = ReadLine()!.ToLower();
        }
    } while (power != 2 && power != 3); //Previously attempted condition (power != 2 || power != 3)  seemed to cause a fall through for power ==2 and power == 3.

    //alternative solution using a simple for-loop
    // int[] derivedArray = new int[randomArray.Length];
    // for (int i = 0; i < randomArray.Length; i++)
    //     derivedArray[i] = (int)Math.Pow(randomArray[i], power);

    //alternative solution using CopyTo and ForEach
    // int[] derivedArray = new int[randomArray.Length];
    // randomArray.CopyTo(derivedArray, 0);
    // Array.ForEach(derivedArray, x => x = (int)Math.Pow(x, power));

    int[] derivedArray = randomArray.Select(x => (int)Math.Pow(x, power)).ToArray();    //my favorite solution
    Write($"{exponentString.Replace(exponentString[0], char.ToUpper(exponentString[0])) + "d"} array: " + string.Join(" ", derivedArray));
}

static void RunExerciseThirtyTwo()
{
    Write("Insert a string of comma-separated numbers: ");

    //alt 1
    string[] numberSnippets = ReadLine()!.Split(',');
    int[] numbers = numberSnippets.Select(x => int.Parse(x)).ToArray();


    //alt 2
    // string[] numberSnippets = ReadLine()!.Split(',');
    // int[] numbers = new int[numberSnippets.Length];
    // for (int i = 0; i < numberSnippets.Length; i++)
    //     numbers[i] = int.Parse(numberSnippets[i]);


    //alternative 3 : using ToCharArray(), then StringBuilder, then string and lastly int[] - seems clumsy
    // char[] numberChars = ReadLine()!.ToCharArray();

    // StringBuilder numberBuilder = new();
    // for (int i = 0; i < numberChars.Length; i++)
    //     numberBuilder.Append(numberChars[i]);

    // string builtString = numberBuilder.ToString();
    // int[] numbers = new int[builtString.Where(x => x == ',').Count() + 1]; //cardinality of numbers is always that of #commas + 1

    // for (int i = 0; i < numbers.Where(x => x != ',').Count(); ++i)
    // {
    //     if (builtString.Contains(','))
    //     {
    //         numbers[i] = int.Parse(builtString[..builtString.IndexOf(',')]);
    //         builtString = builtString.Substring(builtString.IndexOf(',') + 1, builtString.Length - builtString.IndexOf(',') - 1);
    //     }
    //     else
    //         numbers[i] = int.Parse(builtString.Substring(0, builtString.Length));
    // }


    //alt 4 - building strings with StringBuilder until ',' appears. Add the to string the int array using int.Parse.
    // char[] numberChars = ReadLine()!.ToCharArray();
    // StringBuilder numberBuilder = new();
    // int[] numbers = new int[numberChars.Where(x => x == ',').Count() + 1];

    // int nonCommaCounter = 0;
    // for (int i = 0; i < numberChars.Length; i++)
    // {
    //     if (numberChars[i] != ',')
    //     {
    //         numberBuilder.Append(numberChars[i]);
    //         if (i == numberChars.Length - 1)        //last number won't be followed by a comma
    //             numbers[nonCommaCounter] = int.Parse(numberBuilder.ToString());
    //     }
    //     else
    //     {
    //         numbers[nonCommaCounter++] = int.Parse(numberBuilder.ToString());
    //         numberBuilder.Clear();
    //     }
    // }


    // WriteLine("Inputted numbers are: " + string.Join(" ", numbers));  //useful for checking inputs.
    WriteLine("Lowest value is: " + numbers.Min());
    WriteLine("Highest value is: " + numbers.Max());
    WriteLine("Average value is: " + numbers.Average());
}

static void RunExerciseThirtyThree()
{
    //A) Change string “The quick fox Jumped Over the DOG” to the string “The brown fox jumped over the lazy dog” using required string manipulation functions.
    string questionA = "The quick fox Jumped Over the DOG";

    //Quick and efficient solution that "jumps" over the problem.
    WriteLine("Question A: Original text: " + questionA);
    questionA = questionA.Replace("quick fox Jumped Over the DOG", "brown fox jumped over the lazy dog");
    WriteLine("Question A: Altered text: " + questionA);

    // Longer solution showing other ways to accomplish the same task.
    // WriteLine("Question A: Original text: " + questionA);
    // questionA = questionA.Replace("quick", "brown").Replace("J", "j").Replace("Over", "over").Substring(0, questionA.IndexOf('D')) + "lazy " + 
    // questionA.Substring(questionA.IndexOf("D"), questionA.IndexOf("G") - questionA.IndexOf("D") + 1).ToLower();
    // WriteLine("Question A: Altered text: " + questionA);

    //B) - Enter any two words from console and check whether they are same words or not
    Write("\nEnter the first word: ");
    string? questionB1 = ReadLine()!.ToLower();
    Write("Enter the second word: ");
    string? questionB2 = ReadLine()!.ToLower();

    // if (questionB1!.Equals(questionB2, StringComparison.InvariantCultureIgnoreCase))
    if (questionB1 == questionB2)
        WriteLine("They are the same word!");
    else
        WriteLine("They are *not* the same word");

    //C) - Input word Donkey and display it as the word Monkey on the console.
    Write("\nTap enter to see the next part of the exercise ");
    ReadKey();

    string questionC = "Donkey";
    WriteLine("\n\nQuestion C: Original text: " + questionC);
    questionC = questionC.Replace("D", "M");
    WriteLine("Question C: Altered text: " + questionC);

    // D) Replace ‘I’ with ‘We’ and ‘am’ with ‘are’ in given text below.
    Write("\nTap enter to see the next part of the exercise ");
    ReadKey();

    string questionD = "I am going to visit Kolmården zoo tomorrow. I am a big fan of the dolphin show. I may watch all dolphin shows during the day. I would like to take a gondola safari as well. I wish to visit Bamse and his team there.";
    WriteLine("\n\nQuestion D: Original text: " + questionD);
    WriteLine(questionD.Substring(questionD.IndexOf('B')));
    questionD = questionD.Substring(0, questionD.IndexOf('B')).Replace("a big fan", "big fans").Replace("I", "We").Replace("am", "are") + questionD.Substring(questionD.IndexOf('B'));
    WriteLine("Question D: Altered text: " + questionD);

    //E) Actual string is "She is the popular singer." and the expected string is "She is the most popular singer."
    Write("\nTap enter to see the next part of the exercise ");
    ReadKey();

    string questionE = "She is the popular singer.";
    WriteLine("\n\nQuestion E: Original text: " + questionE);
    questionE = questionE.Replace("the", "the most");
    WriteLine("Question E: Altered text: " + questionE);

    //F) Actual string is "A friend is the asset of your life." and the expected string is "A true friend is the greatest asset of your life"
    Write("\nTap enter to see the next part of the exercise ");
    ReadKey();

    string questionF = "A friend is the asset of your life.";
    WriteLine("\n\nQuestion F: Original text: " + questionF);
    questionF = questionF.Remove(questionF.IndexOf('.'), 1).Replace("A", "A true").Replace("the", "the greatest");
    WriteLine("Question F: Altered text: " + questionF);

    //G) Actual string is "My name is Nalini Phopase." Expected string: "Nalini Phopase"
    Write("\nTap enter to see the next part of the exercise ");
    ReadKey();

    string questionG = "My name is Joakim Nylund.";
    WriteLine("\n\nQuestion G: Original text: " + questionG);
    // questionG = questionG.Remove(questionG.IndexOf('.'), 1)[11..]; ;
    questionG = questionG.Remove(questionG.IndexOf('.'), 1)[questionG.IndexOf('J')..]; ;
    WriteLine("Question G: Altered text: " + questionG);

    //H) Actual string is "Arrays are very common in programming, they look something like: [1,2,3,4,5]" Expected string: "[1,4,5,6,7,8]"*/
    Write("\nTap enter to see the next part of the exercise ");
    ReadKey();

    string questionH = "Arrays are very common in programming, they look something like: [1,2,3,4,5]";
    WriteLine("\n\nQuestion H: Original text: " + questionH);
    questionH = questionH[questionH.IndexOf('[')..];
    // questionH = questionH.Substring(questionH.IndexOf('['));
    WriteLine("Question H: Altered text: " + questionH);
}

static void RunExerciseThirtyFour()
{
    Write("Enter your date of birth: ");
    string? dateOfBirthString34 = ReadLine();
    int? age = CalculateAge(dateOfBirthString34!);
    WriteLine($"You are {age} years old");
}

static void RunExerciseThirtyFive()
{
    Write("Enter your full name: ");
    string[] firstAndLastName = ReadLine()!.Split(" ");
    Write($"Greetings {firstAndLastName[0]} {firstAndLastName[1]}, when were you born? ");
    string? birthDate = ReadLine();

    Customer newCustomer = new(birthDate!, firstAndLastName[0] + " " + firstAndLastName[1]);
    BarCounter newCustomerTab = new(newCustomer);
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

            //all 3 conditional statements above in this for-loop can be replaced by the row below.
            // Write($"{j * i,3}"); //this apparently fills up a maximum of 3 spaces as a "buffer", reduced by the number of places filled by the output.
            if (i == 10)
                Write("|");
        }
        WriteLine();

        if (j == 10)
        {
            for (int k = 0; k < 10; k++)
                Write("+---");
            Write("+\n");
        }
    }
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
                RunExerciseTwentyOne();
                break;
            case 22:
                RunExerciseTwentyTwo();
                break;
            case 23:
                RunExerciseTwentyThree();
                break;
            case 24:
                RunExerciseTwentyFour();
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
        Write("\nHit any key to continue..");
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

public class ExerciseClass
{
    public static void AddNumbers(decimal one, decimal two)
    {
        WriteLine(one + two);
    }
    public static void AddNumbers(decimal one, decimal two, decimal three)
    {
        WriteLine(one + two + three);
    }
    public static void AddNumbers(decimal one, decimal two, decimal three, decimal four)
    {
        WriteLine(one + two + three + four);
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
        //     if (i > highestNumber) highestNumber = i;
        // return highestNumber;
    }
    public static void SwapExercise25(double a, double b)
    {
        double temp = b;
        b = a;
        a = temp;
        WriteLine($"\nNumber A is now {a} inside the function and number B is now {b} inside the fuction.");
    }
    public static void SwapExercise26(ref double a, ref double b)
    {
        double temp = b;
        b = a;
        a = temp;
        WriteLine($"\nNumber A is now {a} inside the function and number B is now {b} inside the fuction.");
    }
    public static int CalculateAge(string dateOfBirthString)
    {
        DateTime dateOfBirth = ToDateTime(dateOfBirthString);
        DateTime now = DateTime.Now;

        int age;
        if (dateOfBirth.Month < now.Month || (dateOfBirth.Month == now.Month && dateOfBirth.Day <= now.Day)) //either a previous month, or (a previous day)/(the same day) the same month
            age = now.Year - dateOfBirth.Year;
        else
            age = now.Year - dateOfBirth.Year - 1;

        return age;
    }
    public static void CyanForeGroundColor()
    {
        if (ForegroundColor != ConsoleColor.Cyan)
            ForegroundColor = ConsoleColor.Cyan;
    }
    public static void GreenForeGroundColor()
    {
        if (ForegroundColor != ConsoleColor.Green)
            ForegroundColor = ConsoleColor.Green;
    }
    public static int CalculateFibonacci(int fibNum)
    {
        if (fibNum < 2)
            return fibNum; ;
        return CalculateFibonacci(fibNum - 1) + CalculateFibonacci(fibNum - 2);
    }
    public static int[] BubbleSort(int[] inputArray)
    {
        int swapHolder;
        for (int j = 0; j < Math.Pow(inputArray.Length, 2); j++)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i] > inputArray[i + 1])
                {
                    swapHolder = inputArray[i];
                    inputArray[i] = inputArray[i + 1];
                    inputArray[i + 1] = swapHolder;
                }
            }
        }
        return inputArray;
    }
}

public static class LocalJurisdiction
{
    public static readonly int legalDrinkingAge = 18;
}
public class BarCounter
{
    static string[] allBeverages = { "beer", "coke" };
    static string[] adultBeverages = { "beer" }; //turn these into lists? make dictionaries? key = name of the drink, value = isOfDrinkingAge bool  ++++++++++++++++
    static string[] childBeverages = allBeverages.Except(adultBeverages).ToArray();
    string? CustomerAnswer { get; set; }

    public BarCounter(Customer customer)
    {
        if (customer.Age >= LocalJurisdiction.legalDrinkingAge)
            GetOrder(allBeverages);
        else
            GetOrder(childBeverages);
    }
    public void GetOrder(string[] beverages)
    {
        for (int i = 0; i < beverages.Length; i++)
        {
            Write("Do you want to order a " + beverages[i] + ": ");
            CustomerAnswer = ReadLine()!;

            if (CustomerAnswer.ToLower() == "yes")
            {
                ServeOrder(beverages[i]);
                break;
            }
        }
    }
    private static void ServeOrder(string beverage)
    {
        WriteLine("Serving " + beverage + "!");
    }
}
public class Customer //inheritance from ExerciseClass is not needed to use the CalculateAge method because of "using static ExerciseClass;"
{
    public string Name { get; set; }
    public readonly int Age;
    public Customer(string birthDateString, string name = "anonymous customer")
    {
        Name = name;
        Age = CalculateAge(birthDateString);
    }
}