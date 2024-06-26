﻿using Citas_Backend.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_list_backend.Entities
{
    public class UserEntity : IdentityUser
    {
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        //esto sirve para que un usuario tenga muchas citas y que pueda acceder a todas las citas
        //public virtual IEnumerable<CitasEntity> Cita { get; set; }
    }
}
