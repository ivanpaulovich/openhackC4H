using System.Collections.Generic;
using MM.Domain.Services;

namespace MM.Infrastructure.Emoji
{
    public class EmojiService : IEmojiService
    {
        public string GetUrl(string text)
        {
            Dictionary<string, string> emojis = new Dictionary<string, string>();
            emojis.Add("/Computers & Electronics/Programming", "https://assets-cdn.github.com/images/icons/emoji/unicode/1f4bb.png");
            return emojis[text];
        }
    }
}