namespace CodurerApp.Commands
{
    using System;

    public class CommandDescriptor<T>
    {
        Func<string, bool> conditionEvaluation;
        Func<string, string[]> parametersExtraction;
        
        public CommandDescriptor(Func<string, bool> conditionEvaluation, 
                                    Func<string, string[]> parametersExtraction)
        {
            this.conditionEvaluation = conditionEvaluation;
            this.parametersExtraction = parametersExtraction;
        }

        public bool IsCommand(string commandLine)
        {
            throw new NotImplementedException();
        }
    }
}
