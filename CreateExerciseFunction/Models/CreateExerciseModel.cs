namespace CreateExercise.Models;

public class ExerciseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    public int Reps { get; set; }
    public int Sets { get; set; }
    public string ExerciseType { get; set; }
}