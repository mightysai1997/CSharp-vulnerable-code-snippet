using System;

public class Program
{
    public static void Main()
    {
        string ssn = "123-45-6789";
        if (IsValidSSN(ssn))
        {
            Console.WriteLine("SSN is valid.");
        }
        else
        {
            Console.WriteLine("Invalid SSN.");
        }
    }

    public static bool IsValidSSN(string ssn)
    {
        // Check if SSN has the correct format (XXX-XX-XXXX)
        if (ssn.Length != 11 || ssn[3] != '-' || ssn[6] != '-')
        {
            return false;
        }

        // Check if the parts before and after dashes are numeric
        string[] parts = ssn.Split('-');
        if (!IsNumeric(parts[0]) || !IsNumeric(parts[1]) || !IsNumeric(parts[2]))
        {
            return false;
        }

        // Additional SSN validation logic can be added here if needed
        
        return true;
    }

    public static bool IsNumeric(string input)
    {
        foreach (char c in input)
        {
            if (!Char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
}
