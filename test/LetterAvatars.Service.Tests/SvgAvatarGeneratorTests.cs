using System.Globalization;
using System.Text;
using LetterAvatars.Generator;
using Org.XmlUnit.Builder;
using Org.XmlUnit.Diff;
using SixLabors.ImageSharp.PixelFormats;

namespace LetterAvatars.Service.Tests;

public class SvgAvatarGeneratorTests {
    [Theory]
    [InlineData("en-US")]
    [InlineData("sv-SE")]
    [InlineData("ru")]
    [InlineData("ar")]
    public async Task OutputsCorrectNumberFormatsAsync(string culture) {
        Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

        var fontProvider = new DefaultFontProvider();
        var generator = new SvgAvatarGenerator(fontProvider);

        var bytes = await generator.GenerateAvatarAsync("SX", 512, Rgba32.ParseHex("fff"), Rgba32.ParseHex("000"));
        var xml = Encoding.UTF8.GetString(bytes!);

        var control = Input.FromString("<?xml version=\"1.0\" encoding=\"utf-8\"?><svg width=\"512\" height=\"512\" xmlns=\"http://www.w3.org/2000/svg\"><rect width=\"100%\" height=\"100%\" fill=\"#000000\" /><path stroke=\"#FFFFFF\" fill=\"#FFFFFF\" d=\"M254.4875 266.8625L 254.4875 266.8625C 231.84583 260.3542 215.36874 252.35625 205.05624 242.86874L 205.05624 242.86874L 205.05624 242.86874C 194.74374 233.38124 189.5875 221.67084 189.5875 207.7375L 189.5875 207.7375L 189.5875 207.7375C 189.5875 191.97083 195.88957 178.93124 208.49374 168.61874L 208.49374 168.61874L 208.49374 168.61874C 221.09792 158.30624 237.48334 153.15 257.65 153.15L 257.65 153.15L 257.65 153.15C 271.4 153.15 283.66043 155.80832 294.43127 161.125L 294.43127 161.125L 294.43127 161.125C 305.2021 166.44165 313.54376 173.775 319.45624 183.125L 319.45624 183.125L 319.45624 183.125C 325.36877 192.47499 328.325 202.69583 328.325 213.78749L 328.325 213.78749L 301.7875 213.78749L 301.7875 213.78749C 301.7875 201.6875 297.9375 192.17708 290.2375 185.25624L 290.2375 185.25624L 290.2375 185.25624C 282.5375 178.3354 271.675 174.87498 257.65 174.87498L 257.65 174.87498L 257.65 174.87498C 244.63333 174.87498 234.48125 177.73956 227.19376 183.46875L 227.19376 183.46875L 227.19376 183.46875C 219.90625 189.1979 216.2625 197.15 216.2625 207.325L 216.2625 207.325L 216.2625 207.325C 216.2625 215.48334 219.72292 222.38126 226.64375 228.01874L 226.64375 228.01874L 226.64375 228.01874C 233.56459 233.65625 245.34375 238.81248 261.98126 243.48749L 261.98126 243.48749L 261.98126 243.48749C 278.61877 248.16249 291.63544 253.31876 301.03125 258.95624L 301.03125 258.95624L 301.03125 258.95624C 310.42706 264.59375 317.39374 271.17084 321.93127 278.6875L 321.93127 278.6875L 321.93127 278.6875C 326.46875 286.20416 328.7375 295.05 328.7375 305.225L 328.7375 305.225L 328.7375 305.225C 328.7375 321.45 322.4125 334.44376 309.7625 344.20624L 309.7625 344.20624L 309.7625 344.20624C 297.1125 353.96875 280.2 358.85 259.025 358.85L 259.025 358.85L 259.025 358.85C 245.275 358.85 232.44167 356.2146 220.525 350.94376L 220.525 350.94376L 220.525 350.94376C 208.60834 345.6729 199.41875 338.45416 192.95625 329.2875L 192.95625 329.2875L 192.95625 329.2875C 186.49374 320.12085 183.2625 309.71667 183.2625 298.075L 183.2625 298.075L 209.8 298.075L 209.8 298.075C 209.8 310.175 214.26875 319.73126 223.20625 326.74377L 223.20625 326.74377L 223.20625 326.74377C 232.14375 333.75626 244.08334 337.2625 259.025 337.2625L 259.025 337.2625L 259.025 337.2625C 272.95834 337.2625 283.6375 334.42084 291.0625 328.73752L 291.0625 328.73752L 291.0625 328.73752C 298.48752 323.0542 302.2 315.30835 302.2 305.5L 302.2 305.5L 302.2 305.5C 302.2 295.69165 298.7625 288.10626 291.8875 282.74377L 291.8875 282.74377L 291.8875 282.74377C 285.0125 277.38126 272.54584 272.08752 254.4875 266.8625\" /></svg>").Build();
        var test = Input.FromByteArray(bytes).Build();
        var diff = new DOMDifferenceEngine();
        diff.DifferenceListener += (comparison, outcome) => {
            Assert.Fail("Found a difference: " + comparison);
        };
        diff.Compare(control, test);
    }
}
