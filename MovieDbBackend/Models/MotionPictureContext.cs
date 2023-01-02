using Microsoft.EntityFrameworkCore;


namespace MovieDbBackend.Models
{
    public class MotionPictureContext : DbContext
    {
        public MotionPictureContext(DbContextOptions<MotionPictureContext> options)
        : base(options)
        {
        }

        public DbSet<MotionPicture> MotionPictures { get; set; } = null!;
    }
}
