using SearchAlgorithms.Algorithms;

namespace SearchAlgorithms;

public class SearchAlgorithm
{
    public static void Main()
    {
        // TODO: Create tests with NUnit

        string[] questions =  [
                                "Como você se sente sobre este projeto?",
                                "Como você se sente em relação a este projeto?",
                                "Como você se sente em relação a esse projeto?",
                                "Como você se sente a respeito deste projeto?",
                                "Como você se sente a respeito desse projeto?",
                                "Qual é a sua opinião sobre este projeto?",
                                "Qual é a sua opinião a respeito deste projeto?",
                                "Qual é a sua opinião em relação a este projeto?",
                                "Qual é a sua opinião sobre esse projeto?",
                                "Qual é a sua opinião em relação a esse projeto?"
                            ];
        
        List<JaccardIndex.QuestionSimilarity> similarities = JaccardIndex.CalculateSimilarities(questions);

        foreach (JaccardIndex.QuestionSimilarity similarity in similarities)
        {
            Console.WriteLine(similarity);
        }

        int[] arr = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
        int target = 23;
        
        int index = BinarySearch.Search(arr, target);
        
        Console.WriteLine($"Target {target}, index {index}");

    }
}