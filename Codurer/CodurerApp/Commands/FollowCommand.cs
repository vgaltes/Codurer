namespace CodurerApp.Commands
{
    public class FollowCommand : Command
    {
        private Codurer codurer;
        private string user;
        private string following;

        public FollowCommand(Codurer codurer, string user, string following)
        {
            this.codurer = codurer;
            this.user = user;
            this.following = following;
        }

        public CommandResult Execute()
        {
            codurer.Follow(user, following);
            return new CommandResult();
        }

        public CommandResult Execute(System.DateTime postingTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
