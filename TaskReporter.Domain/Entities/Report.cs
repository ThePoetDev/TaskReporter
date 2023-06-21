using TaskReporter.Core.Entities;

namespace TaskReporter.Domain.Entities;

public class Report : BaseEntity
{
   public DateTime CreationDate { get; set; }
   public string Subject { get; set; }
   public string Title { get; set; }
   public string Context { get; set; }
   
}