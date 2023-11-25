using System.Data.SqlClient;
using CreateExercise.Models;

namespace CreateExercise.Services;

public class ExerciseService
{
    private readonly string? _connectionString = Environment.GetEnvironmentVariable("YourConnectionString");

    public async Task CreateExerciseAsync(ExerciseModel exercise)
    {
        await using var connection = new SqlConnection(_connectionString);
        const string query = "INSERT INTO Exercises (Name, Description, Duration, Reps, Sets, ExerciseType) VALUES (@Name, @Description, @Duration, @Reps, @Sets, @ExerciseType)";

        await using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Name", exercise.Name);
        command.Parameters.AddWithValue("@Description", exercise.Description);
        command.Parameters.AddWithValue("@Duration", exercise.Duration);
        command.Parameters.AddWithValue("@Reps", exercise.Reps);
        command.Parameters.AddWithValue("@Sets", exercise.Sets);
        command.Parameters.AddWithValue("@ExerciseType", exercise.ExerciseType);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }
}