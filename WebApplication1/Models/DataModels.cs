using Microsoft.ML.Data;

namespace WebApplication1.Models
{
    public class SpamInput
    {
        [LoadColumn(0)]
        public string Label;  // "spam" or "ham"

        [LoadColumn(1)]
        public string Message;
    }

    public class SpamPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsSpam;  // true = spam, false = ham

        public float Score;
        public float Probability;
    }

// Class for custom mapping
    public class SpamBoolean
    {
        public bool IsSpam;
    }
}