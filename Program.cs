public class Program {
    public static void Main(String[] args)
    {
         Console.WriteLine(Add("//[*][%]\n1*2%3"));
    }
    //
    public static int Add(string numbers)
    {
        //string test = "";
        int sum = 0;
        if (numbers != "")
        {
            string[] numbersArray = numbers.Split(Delimeters(numbers), StringSplitOptions.None);
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (int.TryParse(numbersArray[i], out int n) == true)
                {
                    if (Convert.ToInt16(numbersArray[i]) > 1000)
                    {
                        i++;
                    }
                    if (Convert.ToInt16(numbersArray[i]) < 0)
                    {
                        throw new ArithmeticException(ThrowEx(numbersArray));
                    }
                    sum += Convert.ToInt16(numbersArray[i]);
                }
            }
        }
        return sum;
    }

    //Delimeters list method
    public static string[] Delimeters(string numbers)
    {
        List<string> delimeterList = new List<string>();
        delimeterList.Add(",");
        delimeterList.Add("\n");
        if (numbers.Contains("//"))
        {
            if (numbers.Substring(2, 1) == "*")
            {
                delimeterList.Add(ExtendedDelimeter(numbers));
            }
            if (numbers.Substring(2, 1) == "[") 
            {
                foreach (var delilemterItem in BracketdDelimeter(numbers).ToCharArray()) 
                {
                    delimeterList.Add(delilemterItem.ToString());
                }
            }
            delimeterList.Add(numbers.Substring(2, 1));
            delimeterList.Remove("[");
        }
        string[] delimeters = delimeterList.ToArray();
        return delimeters;
    }
    // *** Delimeter
    static string ExtendedDelimeter(string numbers)
    {
        string delimeter = "";
        char[] characterArray = numbers.ToCharArray();
        for (int x = 2; x < characterArray.Length - 1; x++)
        {
            if (characterArray[x] == '*')
            {
                delimeter += "*";
            }
            break;
        }
        return delimeter;
    }
    static string ThrowEx(string[] arrayofNumbers)
    {
        string negetives = "Negatives not allowed.";
        foreach (var item in arrayofNumbers)
        {
            if (int.TryParse(item, out int n).Equals(true) && Convert.ToInt16(item) < 0)
            {
                negetives += "\n" + item;
            }
        }
        return negetives;
    }
    static string BracketdDelimeter(string numbers)
    {
        string delimeter = "";
        int index = numbers.LastIndexOf("]");
        delimeter = numbers.Substring(3, index - 3).Replace("]", "");
        delimeter = delimeter.Replace("[", "");
        return delimeter.Trim();
    }
}


