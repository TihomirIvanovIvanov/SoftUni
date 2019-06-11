namespace Mishmash.Services
{
    using Models;
    using System.Collections.Generic;

    public interface ITagService
    {
        Tag CreateTag(Tag tag);

        bool AddTagToChannel(string tagId, ChannelTag channelTag);

        ICollection<Tag> GetAllTags();

        Tag GetTagById(string id);
    }
}