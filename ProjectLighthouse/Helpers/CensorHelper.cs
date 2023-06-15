using System;
using System.Collections.Generic;
using System.Text;
using LBPUnion.ProjectLighthouse.Configuration;
using LBPUnion.ProjectLighthouse.Logging;
using LBPUnion.ProjectLighthouse.Types.Logging;

namespace LBPUnion.ProjectLighthouse.Helpers;

public static class CensorHelper
{
    private static readonly char[] randomCharacters =
    {
        '!', '@', '#', '$', '&', '%', '-', '_',
    };

    private static readonly string[] randomFurry =
    {
        "UwU", "OwO", "uwu", "owo", "o3o", ">.>", "*pounces on you*", "*boops*", "*baps*", ":P", "x3", "O_O", "xD", ":3", ";3", "^w^",
    };

    public static string FilterMessage(string message)
    {
        StringBuilder stringBuilder = new(message);
        if (CensorConfiguration.Instance.UserInputFilterMode == FilterMode.None) return message;

        int profaneCount = 0;

        foreach (string profanity in CensorConfiguration.Instance.FilteredWordList)
        {
            int lastFoundProfanity = 0;
            int profaneIndex;
            List<int> censorIndices = new List<int>();
            
            do
            {
                profaneIndex = message.IndexOf(profanity, lastFoundProfanity, StringComparison.OrdinalIgnoreCase);

                if (profaneIndex == -1) continue;

                censorIndices.Add(profaneIndex);
                
                lastFoundProfanity = profaneIndex + profanity.Length;
            }
            while (profaneIndex != -1);

            for (int i = censorIndices.Count - 1; i >= 0; i--)
            {
                Censor(censorIndices[i], profanity.Length, stringBuilder);
                profaneCount += 1;
            }
        }

        if (profaneCount > 0 && message.Length <= 94 && ServerConfiguration.Instance.LogChatFiltering) // 94 = lbp char limit
            Logger.Info($"Censored {profaneCount} profane words from message \"{message}\"", LogArea.Filter);

        return stringBuilder.ToString();
    }

    private static void Censor(int profanityIndex, int profanityLength, StringBuilder message)
    {
        switch (CensorConfiguration.Instance.UserInputFilterMode)
        {
            case FilterMode.Random:
                char prevRandomChar = '\0';
                for (int i = profanityIndex; i < profanityIndex + profanityLength; i++)
                {
                    if (char.IsWhiteSpace(message[i])) continue;
                    
                    char randomChar = randomCharacters[CryptoHelper.GenerateRandomInt32(0, randomCharacters.Length)];
                    if (randomChar == prevRandomChar)
                        randomChar = randomCharacters[CryptoHelper.GenerateRandomInt32(0, randomCharacters.Length)];

                    prevRandomChar = randomChar;
                    message[i] = randomChar;
                }

                break;
            case FilterMode.Asterisks:
                for(int i = profanityIndex; i < profanityIndex + profanityLength; i++)
                {
                    if (char.IsWhiteSpace(message[i])) continue;

                    message[i] = '*';
                }

                break;
            case FilterMode.Furry:
                // Might wanna remove this.
                // With the optimizations (using StringBuilders), this can cause corruption if the furry word isn't the same length as the profane word.
                // I'm too fucking lazy and have too much of a migraine to fix this.
                // - Rosie
                string randomWord = randomFurry[CryptoHelper.GenerateRandomInt32(0, randomFurry.Length)];
                string afterProfanity = message.ToString(profanityIndex + profanityLength,
                    message.Length - (profanityIndex + profanityLength));

                message.Length = profanityIndex;

                message.Append(randomWord);
                message.Append(afterProfanity);
                break;
            case FilterMode.None: break;
            default: throw new ArgumentOutOfRangeException(nameof(message));
        }
    }
}