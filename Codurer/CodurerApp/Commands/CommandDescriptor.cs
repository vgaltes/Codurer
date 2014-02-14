namespace CodurerApp.Commands
{
    using System;
    using System.Linq;

    public class CommandDescriptor<T> where T: Command
    {
        Func<string, bool> conditionEvaluation;
        Func<string, string[]> parametersExtraction;
        
        public CommandDescriptor( Func<string, bool> conditionEvaluation, 
                                    Func<string, string[]> parametersExtraction)
        {
            this.conditionEvaluation = conditionEvaluation;
            this.parametersExtraction = parametersExtraction;
        }

        public bool IsCommand(string commandLine)
        {
            return conditionEvaluation(commandLine);
        }

        public T GetCommand(Codurer codurer, string commandLine)
        {
            string[] parameters = parametersExtraction(commandLine);
            object[] constructorParameters = new object[] { codurer, parameters.ToArray<string>() };
            return (T)Activator.CreateInstance(typeof(T), constructorParameters);            
        }
    }
}