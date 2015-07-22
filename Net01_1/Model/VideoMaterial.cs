using System;
using Net01_1.Inerface;

namespace Net01_1.Model
{
    class VideoMaterial:BaseTrainingMaterial, IVersionable, ICloneable
    {
        public Uri VideoUri { get; set; }
        public Uri HeadBandUri { get; set; }
        public VideoFormat VideoFormat { get; set; }
        public Byte[] Version { get; set; }

        public VideoMaterial()
        {
            Version = new byte[8];
        }


        public override string ToString()
        {
            return Description;
        }



        public object Clone()
        {
            var video = new VideoMaterial
            {
                HeadBandUri = HeadBandUri,
                Version = Version,
                VideoFormat = VideoFormat,
                VideoUri = VideoUri,
                Id = Id,
                Description = Description
            };
            return video;
        }
    }

}
