using Azure;
using Azure.AI.Language.QuestionAnswering;
using System;

namespace question_answering
{
    class Program
    {
        static void Main(string[] args)
        {

            Uri endpoint = new Uri("https://yomatsumlangapi.cognitiveservices.azure.com/");
            AzureKeyCredential credential = new AzureKeyCredential("f0617092fb654635b3066b9d1e55792b");
            string projectName = "faq";
            string deploymentName = "production";

            string question = "How can I cancel my hotel reservation?";

            int topN = 3;
            double confidenceScoreThreshold = 0.1;

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
            AnswersOptions options = new AnswersOptions();

            options.ConfidenceThreshold = confidenceScoreThreshold;
            options.Size = topN;

            Response<AnswersResult> response = client.GetAnswers(question, project, options);

            foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
            {
                Console.WriteLine($"Q:{question}");
                Console.WriteLine($"A:{answer.Answer}");
            }
        }
    }
}