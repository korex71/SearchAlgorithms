using BenchmarkDotNet.Attributes;

namespace SearchAlgorithms.Algorithms;

public class JaccardIndex
{
    public class QuestionSimilarity(string question1, string question2, double similarity)
    {
        public string Question1 { get; set; } = question1;
        public string Question2 { get; set; } = question2;
        public double Similarity { get; set; } = similarity;

        public override int GetHashCode()
        {
            return (Question1.GetHashCode() * 397) ^ Question2.GetHashCode();
        }

        public int Percentage => (int)(Similarity * 100);

        public global::System.Collections.Generic.List<string> GetQuestionNames()
        {
            return new global::System.Collections.Generic.List<string> { Question1, Question2 };
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
                
            var similarity = (QuestionSimilarity) obj;
            return Question1 == similarity.Question1 && Question2 == similarity.Question2;
        }

        public override string ToString()
        {
            return $"Question1: {Question1}, Question2: {Question2}, Similarity: {Similarity}, Percents: {Percentage}";
        }
    }

    private static readonly char[] separator = [' ', '.', ',', ';', '!', '?'];

    public static double Calculate(string str1, string str2) // O(N)
    {
        HashSet<string> set1 = new(str1.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries));
        HashSet<string> set2 = new (str2.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries));
        
        HashSet<string> intersection = new (set1);
        intersection.IntersectWith(set2);
        
        HashSet<string> union = new(set1);
        union.UnionWith(set2);
        
        return (double)intersection.Count / union.Count;
    }

    [Benchmark]
    public static List<QuestionSimilarity> CalculateSimilarities(string[] questions) // O(N²)
    {
        List<QuestionSimilarity> similarities = [];

        for (int i = 0; i < questions.Length; i++)
        {
            for (int j = i + 1; j < questions.Length; j++)
            {
                double similarity = Calculate(questions[i], questions[j]);
                similarities.Add(new QuestionSimilarity(questions[i], questions[j], similarity));
            }
        }

        return similarities;
    }

    
}