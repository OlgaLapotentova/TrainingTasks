using System;

namespace Net01_1.Model
{
    class TextMaterial:BaseTrainingMaterial, ICloneable
    {
        public string Text
        {
            get { return _text; }
            set
            {
                if (value != null && value.Length > 1000)
                {
                    throw new ArgumentException("Text should contain less then 1000 simbols");
                }

                _text = value;
            }
        }

        private string _text;
      
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
