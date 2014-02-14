namespace CodurerApp.Commands
{
    public class FollowCommand : Command
    {
        private Codurer codurer;
        private string user;
        private string following;

        public FollowCommand(Codurer codurer, string[] parameters)
        {
            this.codurer = codurer;
            this.user = parameters[0];
            this.following = parameters[1];
        }

        public CommandResult Execute()
        {
            codurer.Follow(user, following);
            return new CommandResult();
        }


        public CommandResult Execute(System.DateTime postingTime)
        {
            return Execute();
        }
    }
}
