namespace Project1.Model
{
    public class Manager
    {
        private int roles;

        public Manager(int roles)
        {
            this.roles = roles;
        }

        public Manager()
        {
        }

        public int Roles
        {
            get => roles;
            set => roles = value;
        }

        public override string ToString()
        {
            return roles.ToString();
        }
    }
}