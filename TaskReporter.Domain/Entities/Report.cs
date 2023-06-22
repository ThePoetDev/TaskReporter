using System.ComponentModel.DataAnnotations.Schema;
using TaskReporter.Core.Entities;

namespace TaskReporter.Domain.Entities;

public class Report : BaseEntity
{
   public int OwnerId { get; set; }
   public DateTime CreationDate { get; set; }
   public string Subject { get; set; }
   public string Title { get; set; }
   public string Context { get; set; }
   public User Owner { get; set; }
   
}