// See https://aka.ms/new-console-template for more information
int n = 5 / 2;
string o = "ffff";
string test = InterviewQuestion.ReverseString("maths");
List<int> ans = InterviewQuestion.TwoSums([3, 4, 5, 20,39,10,28], 48);
Console.WriteLine($"test1 : {ans}");
for (int i = 0; i < ans.Count; i++)
{
    Console.WriteLine(ans[i]);
}
// int? findingMode = InterviewQuestion.Mode([3,4,5,5,5,3,4,3,3,3,3,3,5,4,4,5,5,4,4]);
// Console.WriteLine($"the mode is {findingMode}");
class InterviewQuestion
{
    public static bool Anagam(string word)
    {
        int half = word.Length / 2;
        int stringIndex = word.Length - 1;
        for (int i = 0; i < half; i++)
        {
            bool status = word[i] == word[stringIndex];
            if (status)
            {
                stringIndex--;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    public static string ReverseString (string word)
    {
        string reverse = "";
        int wordIndexes = word.Length - 1;
        for (int i = wordIndexes; i >= 0; i--)
        {
            reverse = reverse + word[i];
        }
        return reverse;
    }
    public static List<int> TwoSums(List<int> arr, int target)
    {
        var array = new List<int>();
        int length = arr.Count;
        for (int i = 0; i < length; i++)
        {
            for (int j = i+1; j < length; j++)
            {
                int result = target - (arr[i] + arr[j]);
                if (result == 0)
                {
                    array.Add(arr[i]);
                    array.Add(arr[j]);
                    return array;
                }
            }
        }
        return array;
    }
}