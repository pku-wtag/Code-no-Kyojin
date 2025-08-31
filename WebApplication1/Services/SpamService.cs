using Microsoft.ML;
using Microsoft.ML.Data;
using WebApplication1.Models;
using Microsoft.ML.Trainers.LightGbm;

namespace WebApplication1.Services
{
    public class SpamService
    {
        private readonly MLContext mlContext;
        private ITransformer model;
        private PredictionEngine<SpamInput, SpamPrediction> predictor;

        public SpamService()
        {
            mlContext = new MLContext();
            TrainModel();
        }

        private void TrainModel()
        {
            // Path to your CSV file
            var dataPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Data/spam.csv");

            // Load CSV file
            var data = mlContext.Data.LoadFromTextFile<SpamInput>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            var split = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);

            var pipeline = mlContext.Transforms
                .CustomMapping<SpamInput,
                    SpamBoolean>(mapAction: (input, output) => { output.IsSpam = input.Label.ToLower() == "spam"; },
                    contractName: null)
                .Append(mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features",
                    inputColumnName: nameof(SpamInput.Message))).Append(
                    mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "IsSpam",
                        featureColumnName: "Features"));

            model = pipeline.Fit(split.TrainSet);
            predictor = mlContext.Model.CreatePredictionEngine<SpamInput, SpamPrediction>(model);

            var transformedTest = model.Transform(split.TestSet);
            var metrics = mlContext.BinaryClassification.Evaluate(
                data: transformedTest,
                labelColumnName: "IsSpam");

            Console.WriteLine($"Model trained successfully!");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Precision: {metrics.PositivePrecision:P2}");
            Console.WriteLine($"Recall: {metrics.PositiveRecall:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
        }

        public bool Predict(string message)
        {
            var input = new SpamInput { Message = message, Label = "ham" };
            var result = predictor.Predict(input);
            return result.IsSpam;
        }
    }
}