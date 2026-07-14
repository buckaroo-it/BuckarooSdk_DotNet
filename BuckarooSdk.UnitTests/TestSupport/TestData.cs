using System.IO;
using System.Text;

namespace BuckarooSdk.UnitTests.TestSupport
{
    /// <summary>
    /// Loads recorded JSON fixtures that are copied next to the test assembly (see the
    /// <c>TestData\**\*.json</c> item in the csproj). Reading from <see cref="System.AppContext.BaseDirectory"/>
    /// keeps fixture loading independent of the working directory and the target framework's bin depth.
    /// </summary>
    public static class TestData
    {
        private static string Root => Path.Combine(System.AppContext.BaseDirectory, "TestData");

        public static string ReadText(params string[] relativeSegments)
        {
            var segments = new string[relativeSegments.Length + 1];
            segments[0] = Root;
            System.Array.Copy(relativeSegments, 0, segments, 1, relativeSegments.Length);
            return File.ReadAllText(Path.Combine(segments), Encoding.UTF8);
        }

        public static byte[] ReadBytes(params string[] relativeSegments)
            => Encoding.UTF8.GetBytes(ReadText(relativeSegments));
    }
}
