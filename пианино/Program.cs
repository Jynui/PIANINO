using System;

public static class Program
{
    private static int[] allNotes = new int[] {
        261, 293, 329, 349, 392, 440, 493, 
        523, 587, 659, 698, 783, 880, 987, 
        1046, 1175, 1319, 1397, 1568, 1760, 1976 
        
    };

    private static int[] octaveOffsets = new int[] { 0, 7, 14 }; 
    private static int currentOctaveIndex = 0;
    private static int[] octaves = new int[] { 4, 5, 6 }; 

    private static void Play(int noteIndex)
    {
        if (noteIndex >= 0 && noteIndex < 7)
        {
            int noteWithOctave = allNotes[noteIndex + octaveOffsets[currentOctaveIndex]];
            Console.WriteLine($"Играем ноту {noteIndex + 1} октавы {octaves[currentOctaveIndex]} с частотой {noteWithOctave} Гц");
            Console.Beep(noteWithOctave, 300); 
        }
        else
        {
            Console.WriteLine("Неверный индекс ноты");
        }
    }

    private static void ChangeOctave(int newOctaveIndex)
    {
        if (newOctaveIndex >= 0 && newOctaveIndex < octaves.Length)
        {
            currentOctaveIndex = newOctaveIndex;
            Console.WriteLine($"Переключились на октаву {octaves[currentOctaveIndex]}");
        }
        else
        {
            Console.WriteLine("Неверный индекс октавы");
        }
    }

    public static void Main()
    {
        Console.WriteLine("Пианино готово. Используйте цифровые клавиши для воспроизведения нот.");
        Console.WriteLine("Нажмите F1, F2, F3 для изменения октавы.");
        Console.WriteLine("Нажмите Esc для выхода.");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    
                    break;
                }
                else if (key == ConsoleKey.F1)
                {
                    ChangeOctave(0); 
                }
                else if (key == ConsoleKey.F2)
                {
                    ChangeOctave(1); 
                }
                else if (key == ConsoleKey.F3)
                {
                    ChangeOctave(2); 
                }
                else if (key >= ConsoleKey.D1 && key <= ConsoleKey.D7)
                {
                    int noteIndex = (int)key - (int)ConsoleKey.D1;
                    Play(noteIndex);
                }
            }
        }
    }
}