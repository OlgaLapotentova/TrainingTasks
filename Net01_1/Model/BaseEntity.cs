using System;
using System.Text;

namespace Net01_1.Model
{
    public class BaseEntity
    {
        public Guid Id { get;  set; }

        public string Description {
            get { return _description; }
            set
            {
                if (value.Length > 256)
                    throw new Exception("Description should contain less then 256 simbols");
                _description = value;
            }
        }

        public override bool Equals(Object entity)
        {
            if(entity == null)
                return false;
            if (entity is BaseEntity)
            {
                return (Id == ((BaseEntity)entity).Id);
            }

            return base.Equals(entity);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private string _description;
    }
}
