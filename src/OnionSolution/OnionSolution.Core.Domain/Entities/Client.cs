using OnionSolution.Core.Domain.Common;

namespace OnionSolution.Core.Domain.Entities
{
    public class Client : AuditableBaseEntity
    {
        private int _age;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age
    {
            get
            {
                if (this._age <= 0)
                {
                    this._age = new DateTime(DateTime.Now.Subtract(this.DateOfBirth).Ticks).Year - 1;
                }

                return this._age;
            }
            set
            {
                this._age = value;
            }
        }
    }
}
