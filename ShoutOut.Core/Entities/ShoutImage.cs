namespace ShoutOut.Core
{
    public class ShoutImage : Entity
    {
        public ShoutImage(string name, string extension, byte[] imageBytes)
        {
            Name = name;
            Extension = extension;
            ImageBytes = imageBytes;
        }

        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
