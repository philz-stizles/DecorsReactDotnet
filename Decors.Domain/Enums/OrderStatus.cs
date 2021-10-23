using System.ComponentModel;

namespace Decors.Domain.Enums
{
    public enum OrderStatus
    {
        [Description("Not Processed")]
        NotProcessed = 1,
        [Description("Processing")]
        Processing,
        [Description("Dispatched")]
        Dispatched,
        [Description("Cancelled")]
        Cancelled,
        [Description("Completed")]
        Completed
    }
}
