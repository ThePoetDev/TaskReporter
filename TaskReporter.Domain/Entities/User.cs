using System.ComponentModel.DataAnnotations.Schema;
using TaskReporter.Core.Entities;

namespace TaskReporter.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
}