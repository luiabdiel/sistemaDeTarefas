using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum StatusTask
    {
        [Description("Task to be done")]
        TeDone = 0,
        [Description("Task in progress")]
        InProgress = 1,
        [Description("Task completed")]
        Completed = 2,
    }
}
