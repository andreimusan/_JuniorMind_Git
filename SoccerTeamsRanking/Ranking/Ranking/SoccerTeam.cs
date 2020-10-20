namespace Ranking
{
    public class SoccerTeam
    {
        private readonly string name;
        private int points;

        public SoccerTeam(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public bool HasFewerPoint(SoccerTeam otherTeam)
        {
            if (otherTeam is null)
            {
                return false;
            }

            return points < otherTeam.points;
        }

        public bool IsNameEqual(SoccerTeam team)
        {
            if (team is null)
            {
                return false;
            }

            return name == team.name;
        }

        public int AddPoints(int newPoints)
        {
            return points += newPoints;
        }
    }
}
