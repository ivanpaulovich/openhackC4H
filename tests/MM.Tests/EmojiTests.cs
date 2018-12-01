namespace MM.Tests
{
    using MM.Domain.Services;
    using MM.Infrastructure.Emoji;
    using Xunit;

    public class EmojiTests
    {

        [Fact]
        public void GetEmoji_ReturnsUrl_WhenCategoryNameIsProvided()
        {
            IEmojiService emojiservice = new EmojiService();
            string cat = "/Computers & Electronics/Programming";

            string url = emojiservice.GetUrl(cat);

            Assert.Equal("https://assets-cdn.github.com/images/icons/emoji/unicode/1f4bb.png", url);
            
        }
    }
}