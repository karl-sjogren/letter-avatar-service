namespace LetterAvatars.AspNetCore.Contracts;

public interface IAvatarService {
    Task<byte[]?> GenerateAvatarAsync(string name, string formatExtension, Int32 squareSize, CancellationToken cancellationToken);
}
