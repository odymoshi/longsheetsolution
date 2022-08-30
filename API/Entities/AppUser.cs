using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(45)]
        public string UserName { get; set; }

        [MaxLength(45)]
        public string First { get; set; }

        [MaxLength(45)]
        public string Last { get; set; }

        [Required]
        public LevelEnum Level { get; set; } = LevelEnum.U;

        [Required]
        public ActiveEnum Active { get; set; } = ActiveEnum.TRUE;

        [Required]
        public DirtyEnum Dirty { get; set; } = DirtyEnum.N;

        [Required]
        public DateTime LastSync { get; set; }

        // [Required]
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }


    }

    public enum LevelEnum
    {
        A,
        S,
        U
    }

    public enum ActiveEnum
    {
        TRUE,
        FALSE
    }

    public enum DirtyEnum
    {
        Y,
        N
    }
        
}
