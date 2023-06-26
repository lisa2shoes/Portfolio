namespace GenderGuesser
{
    public class GenderGuesser
    {
        public static async Task<GuessedGender> GuessGenderByName(string name)
        {
            var nameCharacteristics = await NameCharacteristicsProxy.GetNameCharacteristicsAsync(name);
            var guessedGender = new GuessedGender();
            if (nameCharacteristics.Gender == "female")
            {
                guessedGender.Gender = "female";
                guessedGender.Probability = nameCharacteristics.Probability;
            }
            else
            {
                guessedGender.Gender = "male";
                guessedGender.Probability = nameCharacteristics.Probability;
            }

            return guessedGender;
        }
    }
}
