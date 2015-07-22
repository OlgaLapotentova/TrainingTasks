using System;

namespace Net01_1.Model
{
    class ReferenceMaterial:BaseTrainingMaterial, ICloneable
    {
        public Uri ContentUri { get; set; }
        public TypeOfReferenceMaterial ContentType { get; set; }

        public override string ToString()
        {
            return Description;
        }

        public object Clone()
        {
            var reference = new ReferenceMaterial
            {
                ContentType = ContentType,
                ContentUri = ContentUri,
                Description = Description,
                Id = Id
            };
            return reference;
        }
    }

  
}
