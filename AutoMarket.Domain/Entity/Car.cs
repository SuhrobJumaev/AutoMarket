using AutoMarket.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMarket.Domain.Entity
{
    public class Car
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("speed")]
        public double Speed { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("date_create")]
        public DateTime DateCreate { get; set; }
        [Column("type")]
        public TypeCar TypeCar { get; set; } 

    }
}
