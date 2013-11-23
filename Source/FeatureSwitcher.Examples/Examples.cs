using System;
using System.Linq;

namespace FeatureSwitcher.Examples
{
    class Examples
    {
        public static void Show()
        {
            var showExamples = typeof(Program).Assembly.GetTypes()
                                              .Where(x => typeof(IShowExample).IsAssignableFrom(x))
                                              .Where(x => !x.IsAbstract && !x.IsInterface)
                                              .Select(x => (IShowExample)Activator.CreateInstance(x))
                                              .ToArray();

            if (showExamples.Any())
            {
                var exampleSelection = showExamples
                    .Select((x, i) => string.Format("{0} - {1}", i + 1, x.Name))
                    .ToList();

                var showAgain = true;
                do
                {
                    if (Feature<ConsoleColors>.Is().Enabled)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.WriteLine("Available examples:");
                    exampleSelection.ForEach(Console.WriteLine);

                    Console.WriteLine();
                    Console.WriteLine("Which example should I show you? Enter 0 to exit.");
                    Console.Write(" > ");

                    int choise;
                    if (int.TryParse(Console.ReadLine(), out choise))
                    {
                        var exampleIndex = choise - 1;
                        if (exampleIndex == -1)
                            showAgain = false;
                        else if (exampleIndex >= 0 && exampleIndex < showExamples.Length)
                        {
                            showExamples[exampleIndex].Show();
                            Console.ResetColor();
                            if (Feature<PreserveOutputAfterExample>.Is().Disabled)
                                Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There is no example number {0}...", choise);
                            Console.WriteLine("Please try enter the correct number of the example.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("I couldn't understand your wish...");
                        Console.WriteLine("Please try enter the number of the example.");
                        Console.WriteLine();
                    }
                } while (showAgain);
            }
            else
                Console.WriteLine("No example available!");
        }
    }
}