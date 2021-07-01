using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public Operator ExerciseOperator { get; set; }
        public double Result { get; set; }
    }
}
