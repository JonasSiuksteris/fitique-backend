using CreateExercise.Models;
using CreateExercise.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CreateExercise.CreateExercise;

public static class CreateExercise
{
    private static readonly ExerciseService ExerciseService = new ExerciseService();

    [FunctionName("CreateExercise")]
    public static async Task Run(
        [EventHubTrigger("temp", Connection = "EventHubConnectionAppSetting")] string eventHubMessage, ILogger log)
    {
        log.LogInformation($"Event Hub trigger function processed a message: {eventHubMessage}");

        try
        {
            var exercise = JsonConvert.DeserializeObject<ExerciseModel>(eventHubMessage);
            await ExerciseService.CreateExerciseAsync(exercise);
            log.LogInformation("Exercise created successfully.");
        }
        catch (Exception ex)
        {
            log.LogError($"Error in CreateExercise function: {ex.Message}");
        }
    }
}