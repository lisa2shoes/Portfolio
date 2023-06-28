namespace JokeTeller
{
    public class JokeTeller
    {
        public static async Task<Joke> TellAJoke()
        {
            var jokeProperties = await JokePropertiesProxy.GetJokePropertiesAsync();
            var joke = new Joke();
            joke.Setup = jokeProperties.Setup;
            joke.Punchline = jokeProperties.Punchline;

            return joke;
        }

        public static async Task<List<Joke>> TellTenJokes()
        {
            var jokeProperties = await JokePropertiesProxy.GetTenJokesPropertiesAsync();
            var jokeList = new List<Joke>();

            foreach (var item in jokeProperties)
            {
                jokeList.Add(new Joke
                {
                    Setup = item.Setup,
                    Punchline = item.Punchline,
                });
            }

            return jokeList;
        }
    }
}
