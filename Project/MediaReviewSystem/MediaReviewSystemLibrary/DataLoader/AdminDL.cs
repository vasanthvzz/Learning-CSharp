
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.DataLoader
{
    internal class AdminDL
    {
        public static void Initialize()
        {
            LoadData();
        }

        private static void LoadData()
        {
            IMediaDatabase _db = MediaDatabase.GetDb();
            _db.AddAdmin(new Admin(100));
        }
    }
}
