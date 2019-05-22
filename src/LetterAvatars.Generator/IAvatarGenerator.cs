namespace LetterAvatars.Generator {
    public interface IAvatarGenerator {
        string MimeType { get; }
        Task<byte[]> GenerateAvatar(int squareSize, Rgba32 foregroundColor, Rgba32 backgroundColor);
    }
}