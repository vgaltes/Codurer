namespace CodurerApp.Commands
{
    using System;
    using System.Linq;

    public class CommandDescriptor
    {
        Func<string, bool> conditionEvaluation;
        Func<string, string[]> parametersExtraction;
        Type commandType;
        
        public CommandDescriptor( Type commandType,
                                    Func<string, bool> conditionEvaluation, 
                                    Func<string, string[]> parametersExtraction)
        {
            this.commandType = commandType;
            this.conditionEvaluation = conditionEvaluation;
            this.parametersExtraction = parametersExtraction;
        }

        public bool IsCommand(string commandLine)
        {
            return conditionEvaluation(commandLine);
        }

        public Command GetCommand(Codurer codurer, string commandLine)
        {
            string[] parameters = parametersExtraction(commandLine);
            object[] constructorParameters = new object[] { codurer, parameters.ToArray<string>() };
            return (Command) Activator.CreateInstance(commandType, constructorParameters);            
        }
    }
}