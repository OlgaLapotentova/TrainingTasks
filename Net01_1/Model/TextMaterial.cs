using System;
using System.Text;

namespace Net01_1.Model
{
    class TextMaterial:BaseTrainingMaterial, ICloneable
    {
        public StringBuilder Text { get; set; }

        public TextMaterial()
        {
            Text = new StringBuilder(10000);
        }

        public override string ToString()
        {
            return Description;
        }

        public object Clone()
        {
            var text = new TextMaterial
            {
                Text = Text,
                Description = Description,
                Id = Id
            };

            return text;
        }
    }
}
