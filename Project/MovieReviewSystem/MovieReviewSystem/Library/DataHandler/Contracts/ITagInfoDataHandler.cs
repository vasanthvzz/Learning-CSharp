
using MovieReviewSystem.Models;
using System.Data.Entity;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface ITagInfoDataHandler
    {
        public void Add(TagInfo tagInfo);
        public void Remove(TagInfo tagInfo);
    }
}
