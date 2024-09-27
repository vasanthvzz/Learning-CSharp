using MovieReviewSystem.Models;
using System.Data.Entity;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface IPersonalMediaDataHandler
    {
        public List<PersonalMedia> GetAll();
        public void StorePersonalMedia(PersonalMedia personalMedia);
    }
}
