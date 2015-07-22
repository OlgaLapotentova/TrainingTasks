using System;
using System.Linq;
using Net01_1.Inerface;

namespace Net01_1.Model
{
    public class TrainigLesson:BaseEntity, ICloneable, IVersionable
    {

        public int CountOfMaterials
        {
            get { return _trainingMaterial.Length; }
        }

        public bool IsEmpty {
            get { return (_nextFreePosiction == 0); }
        }

        public KindOfLessons KindOfLessons {
            get
            {
                return _trainingMaterial.OfType<VideoMaterial>().Any() ? KindOfLessons.VideoLesson : KindOfLessons.TextLessons;
            }
        }

        public byte[] Version { get; set; }


        public TrainigLesson(int countOfmaterils = 1)
        {
            _baseLength = countOfmaterils;
            Version =new byte[8];
            if (_baseLength < 1)
                throw new IndexOutOfRangeException("Count of material shoud be more than 0");
            _trainingMaterial = new BaseTrainingMaterial[_baseLength];
            _nextFreePosiction = 0;
        }

        public void AddMaterial(BaseTrainingMaterial material)
        {
            if (_nextFreePosiction == _trainingMaterial.Length)
            {
                Array.Resize(ref _trainingMaterial,_trainingMaterial.Length + 1);

            }
            _trainingMaterial[_nextFreePosiction] = material;
           _nextFreePosiction++;

        }

        public BaseTrainingMaterial RemoveMaterial()
        {
            if (_nextFreePosiction == 0)
            {
                throw new IndexOutOfRangeException("Already empty");
            }
            var material = _trainingMaterial[_nextFreePosiction - 1];
            
            ReduceTrainingMaterial();
            
            return material;
        }


        public BaseTrainingMaterial RemoveMaterialAt(int posistion)
        {
            if (posistion < 0 || posistion >= _trainingMaterial.Length)
            {
                throw new IndexOutOfRangeException("No such posistion in list of material");
            }
            var material = _trainingMaterial[posistion];
            for (var i = posistion; i < _trainingMaterial.Length-1; i++)
            {
                _trainingMaterial[i] = _trainingMaterial[i + 1];
            }

            ReduceTrainingMaterial();

            return material;
        }

        public override string ToString()
        {
            return Description;
        }
      
        public object Clone()
        {
            var lessons = new TrainigLesson(_trainingMaterial.Length)
            {
                Version = this.Version,
                Description = this.Description,
                _trainingMaterial = new BaseTrainingMaterial[this._trainingMaterial.Length]
            };
            for (var i = 0; i < _trainingMaterial.Length; i++)
            {
                lessons._trainingMaterial[i] = this._trainingMaterial[i];
            }

            return lessons;
        }


        private void ReduceTrainingMaterial()
        {
            _nextFreePosiction--;
            if (_nextFreePosiction >= _baseLength)
            {
                Array.Resize(ref _trainingMaterial, _trainingMaterial.Length - 1);
            }
            else
            {
                _trainingMaterial[_nextFreePosiction] = null;
            }
        }

        private BaseTrainingMaterial[] _trainingMaterial;
        private int _nextFreePosiction;
        private readonly int _baseLength;
    }

}
