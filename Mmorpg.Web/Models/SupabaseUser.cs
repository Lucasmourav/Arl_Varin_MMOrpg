using System;
using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;
using Postgrest.Models;

namespace Mmorpg.Web.Models
{
    [Table("users")]
    public class SupabaseUser : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("username")]
        public string? Username { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("last_login")]
        public DateTime? LastLogin { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        // Propriedades específicas do jogo
        [Column("character_id")]
        public Guid? CharacterId { get; set; }

        [Column("guild_id")]
        public Guid? GuildId { get; set; }

        [Column("is_online")]
        public bool IsOnline { get; set; } = false;

        [Column("last_online")]
        public DateTime? LastOnline { get; set; }

        [Column("profile_image_url")]
        public string? ProfileImageUrl { get; set; }

        [Column("bio")]
        public string? Bio { get; set; }
    }
}
