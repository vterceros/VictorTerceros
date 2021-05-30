namespace VictorTerceros.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class People
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string CurrentRole { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(200)]
        public string Industry { get; set; }

        public int? NumberOfRecommendations { get; set; }

        public int? NumberOfConnections { get; set; }
    }
}
